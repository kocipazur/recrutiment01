using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;
using Recruitment.Contracts.Repositories;
using Recruitment.Contracts.Services;
using Recruitment.Data.DTOs;
using Recruitment.Data.Enums;
using Recruitment.Data.VOs;

namespace Recruitment.Infrastructure.Services;

public class CRUDServiceExample : ICRUDServiceExample
{
    private readonly IExampleRepository _repository;
    private readonly ILogger<CRUDServiceExample> _logger;

    public CRUDServiceExample(IExampleRepository repository, ILogger<CRUDServiceExample> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ExampleEntityVO> Get(Guid id)
    {
        try
        {
            var response = await _repository.Get(id);
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message + Environment.NewLine + e.StackTrace);
            throw;
        }
    }

    public async Task<ExampleEntityVO> Update(ExampleEntityDTO exampleEntity)
    {
        try
        {
            var response = await _repository.Update(exampleEntity);

            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message + Environment.NewLine + e.StackTrace);
            throw;
        }
    }

    public async Task<ExampleEntityVO> Create(NewExampleEntityDTO exampleEntity)
    {
        try
        {
            var response = await _repository.Create(exampleEntity);

            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message + Environment.NewLine + e.StackTrace);
            throw;
        }
    }

    public async Task Delete(Guid id)
    {
        try
        {
            await _repository.Delete(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message + Environment.NewLine + e.StackTrace);
            throw;
        }
    }
}