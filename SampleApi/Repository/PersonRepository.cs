using SampleApi.Data;
using SampleApi.Data.Entities;
using SampleApi.Infrastructure;

namespace SampleApi.Repository;

public class PersonRepository(AppDbContext dbContext) : Repository<Person>(dbContext), IPersonRepository;
public interface IPersonRepository : IRepository<Person>;
