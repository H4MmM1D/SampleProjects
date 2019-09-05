using Service;
using ShortLink.Logger;
using System;
using System.Net;
using System.Web.Http;

namespace ShortLink.Controllers
{
    public class LinkController : ApiController
    {
        private readonly IAppService _appService;

        public LinkController(IAppService appService)
        {
            _appService = appService;
        }

        public IHttpActionResult Get(string token)
        {
            try
            {
                var link = _appService.VisitUrl(token);

                if (string.IsNullOrWhiteSpace(link))
                {
                    return Content(HttpStatusCode.NotFound, "Invalid Url");
                }

                return Redirect(link);
            }

            catch (Exception ex)
            {
                CustomLogging.LogMessage(TracingLevel.ERROR, ex.Message);
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public IHttpActionResult Post(string link)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(link))
                    return Content(HttpStatusCode.BadRequest, "Url must have value");

                bool urlExist = CheckUrlIsExist(link);

                if (urlExist)
                {
                    var token = _appService.AddUrl(link);
                    return Content(HttpStatusCode.OK, token);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Url does not exist");
                }    
            }
            catch (Exception ex)
            {

                CustomLogging.LogMessage(TracingLevel.ERROR, ex.Message);
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        private bool CheckUrlIsExist(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}