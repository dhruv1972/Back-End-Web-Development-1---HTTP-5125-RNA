using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AS1Controller : ControllerBase
    {
        /// <summary>
        /// Returns a welcome message.
        /// </summary>
        /// <returns>
        /// A string message "Welcome to 5125!"
        /// </returns>
        /// <example>
        /// 'GET' https://localhost:7152/api/AS1 -> Welcome to 5125
        /// Result: "Welcome to 5125!"
        /// </example>

        [HttpGet]
        public string Get()
        {
            return ("Welcome to 5125");
        }

        /// <summary>
        /// This method will recieve a name and greetings with that name 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <return>
        /// "Greetings to {FirstName}", where {FirstName} is an input string
        /// </return>
        /// <example>
        /// GET https://localhost:7152/api/AS1/Get1?FirstName=Dhruv
        /// Reslut : "Hi Dhruv!"

        [HttpGet(template: "Get1")]
        public string Get1(string FirstName)
        {
            string message = "Hi " + FirstName + "!";
            return message;
        }

        /// <summary>
        /// Calculate the cube for given number.
        /// </summary>
        /// <param name="IntNum">The IntNum is number to calculate cube</param>
        /// <return>
        /// The cube of the number 
        /// </return>
        /// <example>
        /// 'GET'https://localhost:7152/api/AS1/Get2?IntNum=10
        /// result = 1000
        /// </example>

        [HttpGet(template: "Get2")]
        public int Get2(int IntNum)
        {
            int cube = IntNum * IntNum * IntNum;
            return cube;
        }

        /// <summary>
        /// Returns the start of a knock-knock joke.
        /// </summary>
        /// <returns>
        /// A string "Who’s there?"
        /// </returns>
        /// <example>
        /// 'POST'https://localhost:7152/api/AS1/knockknock'
        /// Result: "Who’s there?"
        /// </example>

        [HttpPost("template = knockknock")]
        public string knockknock()
        {
            return ("Who's there?");
        }

        /// <summary>
        /// Acknowledges the provided secret integer.
        /// </summary>
        /// <param name="secret">The secret integer provided in the request body.
        /// </param>
        /// <returns>
        /// A string message acknowledging the secret.
        /// </returns>
        /// <example>
        /// 'POST' \'https://localhost:7152/api/AS1/secret_int?secret=5'
        /// Request : 5
        /// Result  : "Shh.. the secret is 5"

        [HttpPost("template = secret_int")]
        public string secret_int(int secret)
        {
            string message = ("Shh.. the secret is " + secret);
            return message;
        }

        /// <summary>
        /// Calculates the area of a regular hexagon with the given side length.
        /// </summary>
        /// <param name="side">The side length of the hexagon is greater than 0.
        /// </param>
        /// <returns>
        /// The area of the hexagon as a double.
        /// </returns>
        /// <example>
        /// 'GET' \'https://localhost:7152/api/AS1/template = hexagon?side=20'
        /// Result: 1039.2304845413264
        /// </example>

        [HttpGet("template = hexagon")]
        public double hexagon(double side)
        {
            double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
            return area;
        }

        /// <summary>
        /// Returns a string representation of the current date
        /// </summary>
        /// <param name="days">the days are adjustable.</param>
        /// <returns>A string representation of the adjusted date in yyyy-MM-dd format.</returns>
        /// <example>
        /// 'GET' \'https://localhost:7152/api/AS1/template = time_machine?days=1'
        /// Result: 2025-01-28
        /// </example>

        [HttpGet("template = time_machine")]
        public string time_machine(int days)
        {
            DateTime adjusteddate = DateTime.Today.AddDays(days);
            return (adjusteddate.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// Calculates the checkout summary for an order of SquashFellows plushies.
        /// </summary>
        /// <param name="Small">The small is number of small plushies.</param>
        /// <param name="Large">The small is number of small plushies.</param>
        /// <returns>
        /// It returns order details,subtotal,total and tax.
        /// </returns>
        /// <example>
        /// POST http://localhost:5000/api/q8/squashfellows
        /// Request Body: Small=1&Large=1
        /// Response: "1 Small @ $25.50 = $25.50; 1 Large @ $40.50 = $40.50; Subtotal = $66.00; Tax = $8.58 HST; Total = $74.58"
        /// </example>

        [HttpPost("template = SquashFellows")]
        public string SquahFellows ([FromForm] int Small, [FromForm] int Large)
        {
            double smallPrice = 25.50;
            double largePrice = 40.50;
            double HST = 0.13;
            double smallTotal = Small * smallPrice;
            double largeTotal = Large * largePrice;
            double subtotal = smallTotal + largeTotal;
            double tax = Math.Round(subtotal * HST, 2);
            double total = Math.Round(subtotal + tax, 2);
            string final = (Small + " Small @ $" + smallPrice.ToString("F2") + " = $" + smallTotal.ToString("F2") + "; " + Large + " Large @ $" 
                            + largePrice.ToString("F2") + " = $" + largeTotal.ToString("F2") + "; " +"Subtotal = $" 
                            + subtotal.ToString("F2") + "; " +"Tax = $" + tax.ToString("F2") + " HST; " +"Total = $" + total.ToString("F2"));
            return final;
            

        }
    }
}
