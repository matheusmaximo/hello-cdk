using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HelloCdkApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class ProducerController
    {
        /// <summary>
        /// Send a message to the topic
        /// </summary>
        /// <param name="message">Message to be sent</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
