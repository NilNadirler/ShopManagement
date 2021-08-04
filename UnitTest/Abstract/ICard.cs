using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Abstract
{
    public interface ICard
    {
        string GetCardNo();
        bool SetCardNo(string cardNo);
        string GetFullName();
        string GetTask();
    }
}
