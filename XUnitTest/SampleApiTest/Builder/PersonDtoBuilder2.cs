using SampleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.SampleApiTest.Builder.Base;

namespace XUnitTest.SampleApiTest.Builder
{
    public class PersonDtoBuilder2 : ReflectionBuilder<PersonDto, PersonDtoBuilder2>
    {
        public readonly PersonDtoBuilder2 _builder;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PersonDtoBuilder2()
        {
            _builder = this;
        }
        public override PersonDto Build()
        {
            return new PersonDto
            {
                Name = Name,
                Description = Description,
                Id = Id
            };
        }
    }
}
