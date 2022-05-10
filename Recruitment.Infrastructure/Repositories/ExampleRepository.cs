using System.Data;
using Recruitment.Contracts.Repositories;
using Recruitment.Data.DTOs;
using Recruitment.Data.VOs;

namespace Recruitment.Infrastructure.Repositories;

public class ExampleRepository : IExampleRepository
{
    private readonly List<ExampleEntityVO> _exampleDataSource = new List<ExampleEntityVO>();

    public ExampleRepository()
    {
        _exampleDataSource.Add(new ExampleEntityVO
        {
            Id = new Guid("bb221100-4b78-434b-ba14-ee002ae051aa"),
            ExampleStringProperty = "example1",
            ExampleIntProperty = 1,
            ExampledDateTimeProperty = DateTime.Today
        });
        _exampleDataSource.Add(new ExampleEntityVO
        {
            Id = new Guid("adad75fe-bfcb-4541-93be-5598346470d1"),
            ExampleStringProperty = "example2",
            ExampleIntProperty = 2,
            ExampledDateTimeProperty = DateTime.Today.AddDays(1)
        });
        _exampleDataSource.Add(new ExampleEntityVO
        {
            Id = new Guid("9cdc493a-596a-452d-9553-6e3806a3e06d"),
            ExampleStringProperty = "example3",
            ExampleIntProperty = 3,
            ExampledDateTimeProperty = DateTime.Today.AddDays(2)
        });
    }

    public Task<ExampleEntityVO> Get(Guid id)
    {
        var elementToReturn = _exampleDataSource.FirstOrDefault(x => x.Id == id);

        if (elementToReturn is null)
            throw new KeyNotFoundException();

        return Task.FromResult(elementToReturn);
    }

    public Task<ExampleEntityVO> Update(ExampleEntityDTO exampleEntity)
    {
        var collectionElement = _exampleDataSource.FirstOrDefault(x => x.Id == exampleEntity.Id);

        if (collectionElement is null)
            throw new KeyNotFoundException();

        collectionElement.ExampleIntProperty = exampleEntity.ExampleIntProperty;
        collectionElement.ExampleStringProperty = exampleEntity.ExampleStringProperty;
        collectionElement.ExampledDateTimeProperty = exampleEntity.ExampledDateTimeProperty;

        return Task.FromResult(collectionElement);
    }

    public Task<ExampleEntityVO> Create(NewExampleEntityDTO exampleEntity)
    {
        var newId = Guid.NewGuid();

        var newEntity = new ExampleEntityVO
        {
            Id = newId,
            ExampleStringProperty = exampleEntity.ExampleStringProperty,
            ExampleIntProperty = exampleEntity.ExampleIntProperty,
            ExampledDateTimeProperty = exampleEntity.ExampledDateTimeProperty
        };
        
        _exampleDataSource.Add(newEntity);

        return Task.FromResult(newEntity);
    }

    public Task Delete(Guid id)
    {
        var elementToReturn = _exampleDataSource.FirstOrDefault(x => x.Id == id);

        if (elementToReturn is null)
            throw new KeyNotFoundException();

        _exampleDataSource.Remove(elementToReturn);

        return Task.CompletedTask;
    }
}