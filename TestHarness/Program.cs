using MTG.Data;
using System;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MTGClient client = new MTGClient();
                client.SearchCards("f:pioneer c=rbu");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
