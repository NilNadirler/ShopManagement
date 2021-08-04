using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Abstract
{
    public abstract class CardBase
    {
        public string CardNo { get; set; }

        public string GetCardNo()
        {
            return this.CardNo;
        }
        public bool SetCardNo(string cardNo)
        {
            this.CardNo = cardNo.Replace("'","");
            return true;
        }
        public string GetFullName()
        {
            return "Nil Nadirler";
        }
        public string GetTask()
        {
            return "Nil Nadirler";
        }
        public string GetMask()
        {
            return "Nil Nadirler";
        }
    }
}
