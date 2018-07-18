using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SQS;

namespace Sculpt.Controllers
{
    /// <summary>
    /// Provides API calls to functionality relating to Halts
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private IConfiguration _configuration;

        /// <summary>
        /// API controller for interacting with Amazon SQS
        /// </summary>
        public QueueController(IConfiguration configuraion)
        {
            _configuration = configuraion;
        }

        #region GETs

        /// <summary>
        /// Gets the oldest 5 entries from the SQS queue
        /// </summary>
        /// <returns>IEnumerable of strings containing the bodies of SQS messages</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(PollSQSWatcher());
        }


        private IEnumerable<string> PollSQSWatcher()
        {
            return Watcher.Poll(_configuration["AWS:AccessKey"], _configuration["AWS:SecretKey"], "All", 5, _configuration["SQS:URL"], 10, 5);
        }

        #endregion

    }
}
