using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Abstract;

namespace UnitTest.Concrete
{
    public class IstanbulCard : CardBase, IIstanbulCard
    {
        int Amount=0;
        public int GetAmount()
        {
            return this.Amount;
        }
    }
}
