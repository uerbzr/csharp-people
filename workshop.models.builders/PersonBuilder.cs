using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.models.builders
{
    public class PersonBuilder : IPersonBuilder
    {
        private Person _person;
        public PersonBuilder()
        {
            _person = new Person();
        }
        public Person Build()
        {
           return _person;
        }

        public IPersonBuilder SetEmail(string email)
        {
            _person.Email = email;
            return this;
        }

        public IPersonBuilder SetName(string name)
        {
            _person.Name = name;
            return this;
        }
    }
}
