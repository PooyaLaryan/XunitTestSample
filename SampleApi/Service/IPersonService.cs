using SampleApi.Data.Entities;
using SampleApi.Infrastructure;
using SampleApi.Model;
using SampleApi.Repository;

namespace SampleApi.Service
{
    public class PersonService(IUnitOfWork unitOfWork) : IPersonService
    {
        public async Task<int> InsertAsync(PersonDto personDto)
        {
            var repository = unitOfWork.PersonRepository;
            var entity = (Person)personDto;

            repository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
    public interface IPersonService
    {
        Task<int> InsertAsync(PersonDto personDto);
    }
}
