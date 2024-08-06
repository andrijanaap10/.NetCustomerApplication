using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;


namespace App.Controller
{
    public class ReportController : ApiController
    {
        [HttpGet]
      //  [Authorize]
        [Route("api/report/download")]
        public HttpResponseMessage DownloadReport()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", $"AgentReport_{DateTime.Now.ToString("yyyyMMdd")}.csv");

                if (!File.Exists(filePath))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Report not found.");
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(fileStream);
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(filePath)
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
