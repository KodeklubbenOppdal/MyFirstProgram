using System;

namespace My_First_C_sharp_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hei, hva heter du?");
            string name = Console.ReadLine();
            Console.WriteLine(string.Format("Hei {0}", name));
            bool svarOK = true;
            while (svarOK)
            {
                Console.WriteLine("Har du det bra?");
                string bra = Console.ReadLine();
                if (bra == "ja")
                {
                    Console.WriteLine("Det er bra, jeg også!");
                    svarOK = false;
                }
                else if (bra == "nei")
                {
                    Console.WriteLine("Det vare synd!!");
                    svarOK = false;
                }

                else
                {
                    Console.WriteLine("Prøv en gang til (ja eller nei)");
                }
            }

            Console.ReadLine();

        }
    }
}
