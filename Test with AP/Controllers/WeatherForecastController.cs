using com.sun.codemodel.@internal;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tsp;
using SkiaSharp;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Policy;
using System.Text;
using static MyProject.References;



namespace Test_with_AP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private string braille = "";
        private int brailledot = 0;




        public class SquareResult
        {
            public string DotPattern { get; set; }
            public int Count { get; set; }

            public string Braille { get; set; }

            public int brailledot { get; set; }
        }


        [HttpGet("Square/{width}")]
        public IActionResult Square( int width)
        {
            string dotPattern = "";
            int count=0;
            string tex = "square";
            

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += "•   ";    //x=x+1 == x+=1
                    count++;
                }
                dotPattern += "\n";
            }

            brailledotCounter(tex);


            var result = new SquareResult { DotPattern = dotPattern, Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
            

        }

        

        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            int count = 0;
            string tex = "rectangle";

            brailledotCounter(tex);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += "•  ";    //x=x+1 == x+=1
                    count++;
                }
                dotPattern += "\n";
            }

            

            var result = new SquareResult { DotPattern = dotPattern, Count = count , Braille = braille, brailledot = brailledot };
            return Ok(result);

        }


        [HttpGet("circle/{radius}")]
        public IActionResult GetCircle(int radius)
        {
            int count = 0;
            string tex = "circle";

            brailledotCounter(tex);

            StringBuilder sb = new StringBuilder();

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt(x * x + y * y);

                    bool isOnCircumference = Math.Abs(distance - radius) < 0.5;

                    if (isOnCircumference)
                    {
                        sb.Append("•");
                        count++;
                    }
                    else
                    {
                        sb.Append("  ");
                    }


                }

                sb.Append("\n");
            }


            var result = new SquareResult { DotPattern = sb.ToString(), Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
        }


        [HttpGet("Trangle/{height}")]
        public IActionResult Trangle(int height)
        {
            string dotPattern = "";
            int count = 0;
            string tex = "trangle";

            brailledotCounter(tex);

            for (int row = 1; row <= height; row++)
            {
                for (int space = 1; space <= height - row; space++)
                {
                    dotPattern += " ";
                }
                for (int col = 1; col <= 2 * row - 1; col++)
                {
                    dotPattern += "•";
                    count++;

                }
                dotPattern += "\n";
            }

            var result = new SquareResult { DotPattern = dotPattern, Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
        }


        [HttpGet("octagon/{size}")]
        public IActionResult GetOctagon(int size)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            string tex = "diamond";

           brailledotCounter(tex);

            int width = size * 2 - 1;
            int height = size * 2 - 1;

            for (int y = 0; y < height; y++)
            {
                int startX = y < size ? size - y - 1 : y - size + 1;
                int endX = y < size ? startX + width - 1 - (size - y - 1) * 2 : startX + width - 1 - (y - size + 1) * 2;

                for (int x = 0; x < width; x++)
                {
                    bool isInside = (x == startX || x == endX) && y >= size / 2 && y < height - size / 2 ||
                                    (y == size / 2 || y == height - size / 2 - 1) && x >= size / 2 && x < width - size / 2;

                   if (isInside)
                    {
                        sb.Append(".");
                        count++;
                    }
                    else
                    {
                        sb.Append(" ");
                    }

                }

                sb.Append("\n");
            }

            var result = new SquareResult { DotPattern = sb.ToString(), Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
        }


        [HttpGet("hexagon/{size}")]
        public IActionResult GetHexagon(int size)
        {
            int width = size * 2;
            int height = size * 2 + (size - 1) * 2;

            bool isInside;
            int count = 0;
            string tex = "hexagon";

            brailledotCounter(tex);


            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                int startX = y < size ? size - y - 1 : y - size + 1;
                int endX = y < size ? startX + width - 1 - (size - y - 1) * 2 : startX + width - 1 - (y - size + 1) * 2;

               for (int x = 0; x < width; x++)
                {
                    isInside = x >= startX && x <= endX;

                    if (isInside)
                    {
                        sb.Append(".");
                        count++;
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                sb.Append("\n");
            }



            var result = new SquareResult { DotPattern = sb.ToString(), Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
        }



        //text converter
        [HttpGet("text/{tex}")]
        public IActionResult Square(String tex)
        {
            //string dotPattern = "";
            string braille = "";
            int count = 0;

                foreach (char c in tex)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        braille += braille_a_to_z[c - 'a'];
                        count++;
                    }
                    else if (c >= 'A' && c <= 'Z')
                    {
                        braille += braille_A_to_Z[c - 'A'];
                        count++;
                    }
                    else if (c >= '0' && c <= '9')
                    {
                        braille += braille_0_to_9[c - '0'];
                        count++;
                    }
                    else
                    {
                        braille += " ";
                        count++;
                    }
                }
            var result = new SquareResult { DotPattern = braille, Count = count, Braille = braille, brailledot = brailledot };
            return Ok(result);
        }


        private static string[] braille_a_to_z = new string[]
       {
            "⠁", "⠃", "⠉", "⠙", "⠑", "⠋", "⠛", "⠓", "⠊", "⠚",
            "⠅", "⠇", "⠍", "⠝", "⠕", "⠏", "⠟", "⠗", "⠎", "⠞",
            "⠥", "⠧", "⠺", "⠭", "⠽", "⠵"
       };

        private static string[] braille_A_to_Z = new string[]
        {
            "⠠⠁", "⠠⠃", "⠠⠉", "⠠⠙", "⠠⠑", "⠠⠋", "⠠⠛", "⠠⠓", "⠠⠊", "⠠⠚",
            "⠠⠅", "⠠⠇", "⠠⠍", "⠠⠝", "⠠⠕", "⠠⠏", "⠠⠟", "⠠⠗", "⠠⠎", "⠠⠞",
            "⠠⠥", "⠠⠧", "⠠⠺", "⠠⠭", "⠠⠽", "⠠⠵"
        };

        private static string[] braille_0_to_9 = new string[]
        {
            "⠚", "⠁", "⠃", "⠉", "⠁⠃", "⠑","⠍", "⠛", "⠓", "⠠⠁"
        };

        // Define the dot count for each Braille character
        Dictionary<char, int> dotCount = new Dictionary<char, int>()
{
            { '⠁', 1 }, { '⠃', 2 }, { '⠉', 2 }, { '⠙', 3 }, { '⠑', 2 }, { '⠋', 3 }, { '⠛', 4 }, { '⠓', 3 },
            { '⠊', 2 }, { '⠚', 3 }, { '⠅', 2 }, { '⠇', 3 }, { '⠍', 3 }, { '⠝', 4 }, { '⠕', 3 }, { '⠏', 4 },
            { '⠟', 5 }, { '⠗', 4 }, { '⠎', 3 }, { '⠞', 4 }, { '⠥', 3 }, { '⠧', 4 }, { '⠺', 4 }, { '⠭', 4 },
            { '⠽', 5 }, { '⠵', 4 }, { '⠠', 1 }, { ' ', 0 }
        };

        [HttpGet]
        public void brailledotCounter(string text)
        {


            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                {
                    braille += braille_a_to_z[c - 'a'];

                }
                else if (c >= 'A' && c <= 'Z')
                {
                    braille += braille_A_to_Z[c - 'A'];

                }
                else if (c >= '0' && c <= '9')
                {
                    braille += braille_0_to_9[c - '0'];
                }
                else
                {
                    braille += " ";
                }

                // Add the dot count for the current character
                if (dotCount.ContainsKey(braille[^1])) // Get the last character of the braille string
                {
                    brailledot += dotCount[braille[^1]];
                }

            }

        }

    }
}