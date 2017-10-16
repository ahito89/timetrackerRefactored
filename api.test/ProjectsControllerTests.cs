using System;
using api.Controllers;
using Moq;
using service;
using Xunit;

namespace api.test
{
    public class ProjectsControllerTests
    {
        private readonly Mock<IProjectService> projectServiceMock = new Mock<IProjectService>();
        private readonly ProjectsController subject;

        [Fact]
        public void Test1()
        {
            
        }
    }
}
