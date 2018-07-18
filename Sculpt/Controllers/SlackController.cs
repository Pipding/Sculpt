using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Slack;
using System;
using System.Collections.Generic;

namespace Sculpt.Controllers
{
    /// <summary>
    /// Provides API calls to functionality relating to Halts
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SlackController : ControllerBase
    {
        private IConfiguration _configuration;

        /// <summary>
        /// API controller for interacting with Slack
        /// </summary>
        public SlackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region POSTs

        /// <summary>
        /// Post a message in one or more slack channels
        /// </summary>
        /// <param name="message">Message to be posted</param>
        /// <param name="channels">Channels to post in</param>
        /// <returns>HTTP 200 if message is posted successfully. HTTP 500 if there's a problem</returns>
        [HttpPost]
        public ActionResult<bool> Post(string message, IEnumerable<string> channels)
        {
            try
            {
                return Ok(SlackClient.PostMessage(_configuration["Slack:WebhookURL"], message, channels));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        #endregion

    }
}
