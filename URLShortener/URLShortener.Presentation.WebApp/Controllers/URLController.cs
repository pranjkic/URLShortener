using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using URLShortener.Core.Ports.ServiceInterfaces;

namespace URLShortener.Presentation.WebApp.Controllers
{
    //[Authorize]
    [RoutePrefix("api/url")]
    public class URLController : ApiController
    {
        IURLService _urlService;

        public URLController(IURLService urlService)
        {
            _urlService = urlService;
        }

        [Route("")]
        public IEnumerable<string> Get()
        {
            _urlService.Test();
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("InsertLink")]
        public IHttpActionResult InsertLink(string url, string shortUrl)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uriResult);
                /*&& uriResult.Scheme == Uri.UriSchemeHttp;*/

            if (result)
            {
                try
                {
                    _urlService.InsertLink(User.Identity.Name, url, shortUrl);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("RedirectLink")]
        public IHttpActionResult RedirectLink(string shortUrl)
        {
            try
            {
                string url = _urlService.RedirectPath(shortUrl);
                System.Uri uri = new System.Uri(url);
                return Redirect(uri);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
