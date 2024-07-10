using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApi.Model;

namespace SampleApi.Data.Entities
{
    public record Person : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static implicit operator Person(PersonDto personDto)
        {
            return new Person
            {
                Name = personDto.Name,
                Description = personDto.Description,
            };
        }
    }

    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
            builder.HasKey(p => p.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        }
    }
}
