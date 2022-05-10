using Recruitment.Data.DTOs;
using Recruitment.Data.Enums;
using Recruitment.Data.VOs;

namespace Recruitment.Contracts.Services;

public interface ICRUDServiceExample
{
    public Task<ExampleEntityVO> Get(Guid id);
    public Task<ExampleEntityVO> Update(ExampleEntityDTO exampleEntity);
    public Task<ExampleEntityVO> Create(NewExampleEntityDTO exampleEntity);
    public Task Delete(Guid id);
}