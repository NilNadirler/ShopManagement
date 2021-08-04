using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Abstract
{
    public interface ICreditCard:ICard
    {
        int GetAmount();
        int GetCCV();
    }
}
