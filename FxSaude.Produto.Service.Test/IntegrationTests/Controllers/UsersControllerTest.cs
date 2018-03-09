using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using NUnit.Framework;

namespace FxSaude.Produto.Service.Test.IntegrationTests.Controllers
{
    [TestFixture]
    public class UsersControllerTest
    {
        [Ignore("TODO Integration Environment")]
        [Test]
        public void SimpleTest()
        {
            var client = new HttpClient();
            var url = "http://localhost:57374/api/Users";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));

            var response = client.SendAsync(request);
            Assert.IsNotNull(response.Result);
        }
    }
}