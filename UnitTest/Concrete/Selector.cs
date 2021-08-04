using UnitTest.Abstract;

namespace UnitTest.Concrete
{
    public class Selector<T>
        where T:class,ICreditCard,new()
    {
        T Get()
        {
            return new T();
        }
    }
}
