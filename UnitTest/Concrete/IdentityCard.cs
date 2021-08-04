using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Abstract;

namespace UnitTest.Concrete
{
    public class IdentityCard : CardBase, IIdentityCard
    {
        public List<string> SecretFunc()
        {
            List<string> list = new List<string>();
            list.Add("1234323424213");
            list.Add("elektronik imza");
            list.Add("doğum yeri");
            return list;
        }
        public string GetIdentity()
        {
            return this.SecretFunc()[0];
        }

        public string GetBirthPlace()
        {
            return this.SecretFunc()[2];
        }
    }
}
