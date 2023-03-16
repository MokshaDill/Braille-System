using Microsoft.AspNetCore.Mvc;

namespace Test_with_AP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);

        }
    }
    }