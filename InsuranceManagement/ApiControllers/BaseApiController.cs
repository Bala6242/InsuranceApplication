using Insurance.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace InsuranceManagement.ApiControllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult Result<T>(Func<T> action) where T : IResponseDto, new()
        {
            bool hasError = false;
            string message = string.Empty;

            T response = default(T);
            try
            {
                if (action != null)
                    response = action.Invoke();
            }
            catch (ArgumentNullException ex)
            {
                response = ProcessArgumentException<T>(ex);
            }
            catch (Exception ex)
            {
                hasError = true;
                message = ProcessUnhandledException(ex);
            }

            if (hasError)
                return Response(statusCode: HttpStatusCode.InternalServerError, content: message);

            if (!response.IsSuccess)
                response.Reset();

            return Ok(response);
        }
        string ProcessUnhandledException(Exception ex)
        {
            //var crmConfiguration = UnityConfig.Container.Resolve<CrmConfiguration>();
            //string message = crmConfiguration.IsDevelopment()
            //    ? string.Concat(ex.ToDetailMessage(), " - ", ex.StackTrace)
            //    : ex.Message;
            //TrackException("Unhandled Exception", ex);
            //return message;
            return string.Empty;
        }

        private T ProcessArgumentException<T>(ArgumentNullException ex) where T : IResponseDto, new()
        {
            //var crmConfiguration = UnityConfig.Container.Resolve<CrmConfiguration>();
            T response = new T();
            //var errorMessage = crmConfiguration.IsDevelopment()
            //    ? string.Concat(ex.ToDetailMessage(), " - ", ex.StackTrace)
            //    : ex.Message;
            //response.ErrorCodes.Add(new ErrorCode(0, errorMessage));
            //TrackException("Argument Exception", ex);
            return response;
        }
        private void TrackException(string exceptionType, Exception ex)
        {

        }

        private IHttpActionResult Response(HttpStatusCode statusCode = HttpStatusCode.OK, object content = null, int cachetime = 0, string locationUri = null, bool setHeader = false, string responseConntentType = null)
        {
            return new LocalServicesHttpActionResult(Request, content, cachetime, statusCode, locationUri, setHeader: setHeader, responseConntentType: responseConntentType);
        }

    }
    public class LocalServicesHttpActionResult : IHttpActionResult
    {
        readonly object _content;
        readonly int _cacheTimeInMin;
        readonly HttpRequestMessage _request;
        readonly HttpStatusCode _statusCode;
        readonly string _uri;
        private bool _addHeader;
        private string _responseConntentType = string.Empty;
        private bool _isDeprecatedResponse;
        public LocalServicesHttpActionResult(HttpRequestMessage request, object content, int cachetime = 0, HttpStatusCode statusCode = HttpStatusCode.OK, string uri = null, bool setHeader = false, string responseConntentType = null, bool isDeprecatedResponse = false)
        {
            _content = content;
            _request = request;
            _cacheTimeInMin = cachetime;
            _statusCode = statusCode;
            _uri = uri;
            _addHeader = setHeader;
            _responseConntentType = responseConntentType;
            _isDeprecatedResponse = isDeprecatedResponse;

        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _content == null ? _request.CreateResponse(_statusCode) : _request.CreateResponse(_statusCode, _content);
            if (_addHeader)
            {
                response.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true, MustRevalidate = true };
                response.Content.Headers.Expires = DateTimeOffset.Now;
                response.Headers.Add("Pragma", "no-cache");
            }
            else
            {
                response.Headers.CacheControl = new CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromMinutes(_cacheTimeInMin)
                };
            }
            if (_isDeprecatedResponse)
                response.Headers.Add("X-deprecated-api", true.ToString());
            if (!string.IsNullOrEmpty(_responseConntentType))
                response.Content.Headers.ContentType.MediaType = _responseConntentType;
            if (_statusCode == HttpStatusCode.Created && !string.IsNullOrEmpty(_uri))
                response.Headers.Location = new Uri(_uri);
            return Task.FromResult(response);
        }
    }
}