using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Abstract
{
    public interface IIdentityCard:ICard
    {
        string GetIdentity();
        string GetBirthPlace();
    }
}
