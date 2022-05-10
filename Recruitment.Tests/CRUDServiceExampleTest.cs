using System;
using Microsoft.Extensions.Logging;
using Moq;
using Recruitment.Contracts.Repositories;
using Recruitment.Data.VOs;
using Recruitment.Infrastructure.Services;
using Xunit;

namespace Recruitment.Tests;

public class CRUDServiceExampleTest
{
    [Fact]
    public void GetShouldReturn()
    {
        var guid = Guid.NewGuid();
        var repository = new Mock<IExampleRepository>();
        repository.Setup(x => x.Get(guid)).ReturnsAsync(new ExampleEntityVO());
        
        var loggerMock = new Mock<ILogger<CRUDServiceExample>>();

        var service = new CRUDServiceExample(repository.Object, loggerMock.Object);

        service.Get(guid);
    }
}