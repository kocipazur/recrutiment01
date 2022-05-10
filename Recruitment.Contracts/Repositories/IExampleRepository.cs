using Recruitment.Data.DTOs;
using Recruitment.Data.VOs;

namespace Recruitment.Contracts.Repositories;

public interface IExampleRepository
{
    public Task<ExampleEntityVO> Get(Guid id);
    public Task<ExampleEntityVO> Update(ExampleEntityDTO exampleEntity);
    public Task<ExampleEntityVO> Create(NewExampleEntityDTO exampleEntity);
    public Task Delete(Guid id);
}