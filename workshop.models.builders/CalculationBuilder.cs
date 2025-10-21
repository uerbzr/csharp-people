

using workshop.models;
using workshop.models.builders;

public class CalculationBuilder : ICalculationBuilder
{
    private Calculation _calculation = new Calculation();
    public Calculation Build()
    {
        return _calculation;
    }

    public ICalculationBuilder SetA(int A)
    {
        _calculation.A = A;
        return this;
    }

    public ICalculationBuilder SetB(int B)
    {
        _calculation.B = B;
        return this;
    }

    public ICalculationBuilder SetPersonId(int id)
    {
        _calculation.PersonId = id;
        return this;
    }

    public ICalculationBuilder SetResult(int Result)
    {
        _calculation.Result = Result;
        return this;
    }
}
