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

    public abstract class EntityConfig<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            ConfigTable(builder);
        }

        public abstract void ConfigTable(EntityTypeBuilder<T> builder);
    }

    public class PersonConfig() : EntityConfig<Person>
    {
        public override void ConfigTable(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
        }
    }
}
