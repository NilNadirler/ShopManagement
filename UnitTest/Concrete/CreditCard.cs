using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Abstract;

namespace UnitTest.Concrete
{
    public class CreditCard : CardBase, ICreditCard
    {
        public int Amount = 100;
        public int GetAmount()
        {
            return this.Amount;
        }

        public int GetCCV()
        {
            return 123;
        }
    }
}
