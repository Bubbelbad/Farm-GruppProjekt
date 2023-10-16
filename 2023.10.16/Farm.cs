using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Farm
    {
        public void MainMenu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Här kommer vi att lägga till en flervalsmeny: \n\n" +
                                  "Val nummer 1                           [1]\n" +
                                  "Val nummer 2                           [2]\n" +
                                  "Val nummer 3                           [3]\n");

                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        default:
                            Console.WriteLine("Vänligen skriv en siffra mellan 1 - 3");
                            break;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
