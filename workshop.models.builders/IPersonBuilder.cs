using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.models.builders
{
    public interface IPersonBuilder
    {
        IPersonBuilder SetName(string name);
        IPersonBuilder SetEmail(string email);
        IPersonBuilder SetAge(int age);
        Person Build();
    }
}
