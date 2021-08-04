using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitTest.Abstract;
using UnitTest.Concrete;

namespace UnitTest
{
    public class TestSync
    {
        public async Task StartASync(string name)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(name + " :" + i);
                    Thread.Sleep(1000);
                }
            });
        }
        public void StartSync(string name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(name + " :" + i);
                Thread.Sleep(1000);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestSync testSync = new TestSync();
            Console.WriteLine("başladı: "+DateTime.Now.ToString());
            _ = testSync.StartASync("birinci");
             testSync.StartSync(" ikinci");
            Console.WriteLine("bitti:" + DateTime.Now.ToString());
        }
    }
}
