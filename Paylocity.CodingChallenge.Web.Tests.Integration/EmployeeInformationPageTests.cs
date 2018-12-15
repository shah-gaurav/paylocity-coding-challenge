using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paylocity.CodingChallenge.Web.Tests.Integration
{
    public class EmployeeInformationPageTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EmployeeInformationPageTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task get_returns_redirect_to_index_if_numberofdependents_not_provided()
        {
            // Arrange
            var client = _factory.CreateClient(
                                    new WebApplicationFactoryClientOptions
                                    {
                                        AllowAutoRedirect = false
                                    });


            // Act
            var response = await client.GetAsync("/EmployeeInformation");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task get_returns_success_if_numberofdependents_provided()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/EmployeeInformation?numberofdependents=3");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
