using Jira;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;

namespace Sculpt.Controllers
{
    /// <summary>
    /// Provides API calls to functionality relating to Halts
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private IConfiguration _configuration;

        /// <summary>
        /// API controller for interacting with JIRA
        /// </summary>
        public JiraController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GETs

        /// <summary>
        /// Gets information about a case from Jira
        /// </summary>
        /// <param name="imc">IMC number of the case</param>
        /// <returns>Basic information about a Jira case</returns>
        [HttpGet]
        public ActionResult<JiraIssue> Get(string imc)
        {
            try
            {
                var imcKey = JiraClient.AppendPrefixIfMissing(_configuration["Jira:KeyPrefix"], imc);

                var url = _configuration["Jira:URL"] + imcKey + _configuration["Jira:Fields"];

                var authKey = _configuration["Jira:AuthenticationKey"];

                var issue = JiraClient.GetIssue(url, authKey);

                return Ok(issue);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        #endregion

    }
}
