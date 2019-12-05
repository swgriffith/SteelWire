using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace src
{
    public static class steelwire
    {
        [FunctionName("steelwire")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string text = new StreamReader(req.Body).ReadToEnd();

            string top = "";
            string bottom= "";
            for (int i = 0; i < text.Length+2; i++)
            {
                top +="_";
                bottom+="-";
            }

            string output = $" {top}\n< {text} >\n {bottom}\n \\\n  \\\n    __\n   /  \\\n   |  |\n   @  @\n   |  |\n   || |/\n   || ||\n   |\\_/|\n   \\___/ \n";
            output += $"\nOS: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}\n";

            return text != null
                ? (ActionResult)new OkObjectResult(output)
                : new BadRequestObjectResult("Please send a message in the request body");
        }
    }
}
