using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System.Drawing;
using System.IO;
using System.Security.Policy;
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
                    dotPattern += "•   ";    //x=x+1 == x+=1
                    count++;
                }
                dotPattern += "\n";
            }
            var result = new SquareResult { DotPattern = dotPattern, Count = count };
            return Ok(result);

        }

        [HttpGet("circle/{radius}")]
        public IActionResult Circle(int radius)
        {
            string dotPattern = " ";
            

            for (int i = 1; i <= radius/2;i++)
            {
                if (i == 1 || i == radius)//if (i == 0 or i== radius){ radius - 1 + print(".")}
                {
                    for (int k = 0; k < radius; k++)
                    {
                        dotPattern += " ";
                    }
                    dotPattern += ".";
                    dotPattern += "\n";

                }
                else
                {
                    //for (int j = 1; j <= 2; j++)  //1st dot = radius -x       <---- space calculation 2nd dot = radius + x
                    
                        int mn = (radius*radius) - ((radius - i) * (radius - i));   //2x=2radius^2-(radius-i)^2  
                        int m= (int)Math.Sqrt(mn);
                        int n = (radius - m)+ (radius - m);
                        int nn = (int)2m;
                        for (int k = 0; k <= n; k++)
                        {
                            dotPattern += " ";
                        }
                        dotPattern += ".";

                    for (int p = 0; p <= nn; p++)
                    {
                        dotPattern += nn;
                    }

                    for (int k = 0; k >= n; k++)
                    {
                        dotPattern += n;
                    }
                   

                    dotPattern += ".";
                        dotPattern += "\n";
                    
                }

            
            }



            //for (int y = -radius; y <= radius; y++)
            //{
            //    for (int x = -radius; x <= radius; x++)
            //    {
            //        double distance = Math.Sqrt(x * x + y * y);
            //        if (Math.Abs(distance - radius) < step / 2)
            //        {
            //            dotPattern += "•";
            //        }
            //        else
            //        {
            //            dotPattern += " ";
            //        }
            //    }
            //    dotPattern += "\n";
            //}
            return Ok(dotPattern);
        }

        [HttpGet("Trangle/{height}")]
        public IActionResult Trangle(int height)
        {
            string dotPattern = "";


            for (int row = 1; row <= height; row++)
            {
                for (int space = 1; space <= height - row; space++)
                {
                    dotPattern += " ";
                }
                for (int col = 1; col <= 2 * row - 1; col++)
                {
                    dotPattern += "•";
                }
                dotPattern += "\n";
            }

            return Ok(dotPattern);
        }


        //text converter
        [HttpGet("text/{tex}")]
        public IActionResult Square(String tex)
        {
            string dotPattern = "";
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