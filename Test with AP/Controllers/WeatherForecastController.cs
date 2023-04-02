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

        public class SquareResult
        {
            public string DotPattern { get; set; }
            public int Count { get; set; }
        }


        [HttpGet("Square/{width}")]
        public IActionResult Square( int width)
        {
            string dotPattern = "";
            int count=0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += "•   ";    //x=x+1 == x+=1
                    count++;
                }
                dotPattern += "\n";
            }
            var result = new SquareResult { DotPattern = dotPattern, Count = count };
            return Ok(result);
            

        }

        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            int count = 0;  
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += "•  ";    //x=x+1 == x+=1
                    count++;
                }
                dotPattern += "\n";
            }
            var result = new SquareResult { DotPattern = dotPattern, Count = count };
            return Ok(result);

        }

        //[HttpGet("circle/{radius}")]
        //public IActionResult Circle(int radius)
        //{
        //    string dotPattern = " ";
        //    int count = 0;


        //    //for (int i = 1; i <= radius/2;i++)
        //    //{
        //    //    if (i == 1 || i == radius)//if (i == 0 or i== radius){ radius - 1 + print(".")}
        //    //    {
        //    //        for (int k = 0; k < radius; k++)
        //    //        {
        //    //            dotPattern += " ";
        //    //        }
        //    //        dotPattern += ".";
        //    //        dotPattern += "\n";

        //    //    }
        //    //    else
        //    //    {
        //    //        //for (int j = 1; j <= 2; j++)  //1st dot = radius -x       <---- space calculation 2nd dot = radius + x

        //    //            int mn = (radius*radius) - ((radius - i) * (radius - i));   //2x=2radius^2-(radius-i)^2  
        //    //            int m= (int)Math.Sqrt(mn);
        //    //            int n = (radius - m)+ (radius - m);
        //    //            int nn = (int)2m;
        //    //            for (int k = 0; k <= n; k++)
        //    //            {
        //    //                dotPattern += " ";
        //    //            }
        //    //            dotPattern += ".";

        //    //        for (int p = 0; p <= nn; p++)
        //    //        {
        //    //            dotPattern += nn;
        //    //        }

        //    //        for (int k = 0; k >= n; k++)
        //    //        {
        //    //            dotPattern += n;
        //    //        }


        //    //        dotPattern += ".";
        //    //            dotPattern += "\n";

        //    //    }


        //    //}



        //    //for (int y = -radius; y <= radius; y++)
        //    //{
        //    //    for (int x = -radius; x <= radius; x++)
        //    //    {
        //    //        double distance = Math.Sqrt(x * x + y * y);
        //    //        if (Math.Abs(distance - radius) < radius / 2)
        //    //        {
        //    //            dotPattern += "•";
        //    //            count++;        
        //    //        }
        //    //        else
        //    //        {
        //    //            dotPattern += " ";
        //    //            count++;
        //    //        }
        //    //    }
        //    //    dotPattern += "\n";
        //    //}

        //    var result = new SquareResult { DotPattern = dotPattern, Count = count };
        //    return Ok(result);


        //}



        [HttpGet("circle/{radius}/{resolution}")]
        public IActionResult GetCircle(int radius, int resolution)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt(x * x + y * y);

                    bool isOnCircumference = Math.Abs(distance - radius) < 0.5;

                    if (isOnCircumference)
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

          
            var result = new SquareResult { DotPattern = sb.ToString(), Count = count };
            return Ok(result);
        }




        //[HttpGet("circle/{radius}/{resolution}")]
        //public IActionResult GetCircle(int radius, int resolution)
        //{
        //    int centerX = radius;
        //    int centerY = radius;
        //    int count = 0;

        //    Bitmap bitmap = new Bitmap(radius * 2 + 1, radius * 2 + 1);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //        graphics.DrawEllipse(Pens.Black, new RectangleF(0, 0, radius * 2, radius * 2));
        //    }


        //    StringBuilder sb = new StringBuilder();

        //    for (int y = 0; y < bitmap.Height; y++)
        //    {
        //        for (int x = 0; x < bitmap.Width; x++)
        //        {
        //           double distance = Math.Sqrt((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY));

        //            bool isInside = distance <= radius;

        //            sb.Append(isInside ? "•" : " ");
        //            count++;
        //        }

        //        sb.Append("\n");
        //        count++;
        //    }


        //    var result = new SquareResult { DotPattern = sb.ToString(), Count = count };
        //    return Ok(result);
        //}



        [HttpGet("Trangle/{height}")]
        public IActionResult Trangle(int height)
        {
            string dotPattern = "";
            int count = 0;

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

            var result = new SquareResult { DotPattern = dotPattern, Count = count };
            return Ok(result);
        }


        [HttpGet("octagon/{size}")]
        public IActionResult GetOctagon(int size)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;  

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

            var result = new SquareResult { DotPattern = sb.ToString(), Count = count };
            return Ok(result);
        }




        [HttpGet("hexagon/{size}")]
        public IActionResult GetHexagon(int size)
        {
            int width = size * 2;
            int height = size * 2 + (size - 1) * 2;

            bool isInside;
            int count = 0;

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



            var result = new SquareResult { DotPattern = sb.ToString(), Count = count };
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
            var result = new SquareResult { DotPattern = braille, Count = count };
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
            "⠚", "⠁⠃", "⠉⠙", "⠑⠋", "⠍⠝", "⠕⠏", "⠋⠟", "⠛⠗", "⠓⠎", "⠊⠞"
        };
    
    }
}