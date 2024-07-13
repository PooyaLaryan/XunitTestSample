using Bogus;
using Bogus.DataSets;
using NuGet.Frameworks;
using SampleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.SampleApiTest.Builder.Base;

namespace XUnitTest.SampleApiTest.Builder
{
    public class PersonDtoBuilder : BuilderBase, IBuilder<PersonDto>
    {
        public int _id;
        public string _name;
        public string _description;
        public PersonDto Build()
        {
            return new Faker<PersonDto>().CustomInstantiator(faker => new PersonDto
            {
                Id = GetId(faker),
                Name = GetName(faker),
                Description = GetDescription(faker),
            });
        }

        private int GetId(Faker faker) => IsPropertyAssigned(nameof(_id)) ? _id : faker.Random.Int();
        private string GetName(Faker faker)=> IsPropertyAssigned(nameof(_name)) ? _name : faker.Random.String();
        private string GetDescription(Faker faker) => IsPropertyAssigned(nameof(_description)) ? _description : faker.Random.String();
        
        public PersonDtoBuilder WithId(int id)
        {
            _id = id;
            AssignSpecificProperty(nameof(_id));
            return this;
        }

        public PersonDtoBuilder WithName(string name)
        {
            _name = name;
            AssignSpecificProperty(nameof(_name));
            return this;
        }

        public PersonDtoBuilder WithDescription(string description)
        {
            _description = description;
            AssignSpecificProperty(nameof(_description));
            return this;
        }

    }
}
