using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paylocity.CodingChallenge.Web.Tests.Integration
{
    public class ResultsPageTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ResultsPageTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task get_returns_redirect_to_indexif_no_temp_data_cookie_passed()
        {
            // Arrange
            var client = _factory.CreateClient(
                                    new WebApplicationFactoryClientOptions
                                    {
                                        AllowAutoRedirect = false
                                    });


            // Act
            var response = await client.GetAsync("/Results");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }
    }
}
