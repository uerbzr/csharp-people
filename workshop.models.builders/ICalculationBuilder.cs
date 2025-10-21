using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.models.builders
{
    public interface ICalculationBuilder
    {
        ICalculationBuilder SetA(int A);
        ICalculationBuilder SetB(int B);
        ICalculationBuilder SetResult(int Result);
        ICalculationBuilder SetPersonId(int id);
        Calculation Build();
        
    }
}
