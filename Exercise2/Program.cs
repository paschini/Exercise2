

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("Välkomen till HuvudMeny");
                Console.WriteLine("\nSkriva en av nerstående siffror följd med <Enter> för att navigera till en function:");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("0 - Stäng ner programmet");
                Console.WriteLine("1 - Ungdom eller Pensionär?\n");

                string input = Console.ReadLine() ?? "0";
                switch (input)
                {
                    case "0":
                        exitProgram = true;
                        break;
                    case "1":
                        YoungOrRetired();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att försöka igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void YoungOrRetired()
        {
            Console.Clear();
            Console.WriteLine("På detta funktion kand du kolla om en person får ungdoms- eller pensionärsrabatt på Bio pris.");
            Console.Write("\nAnge personens ålder: ");

            const double youngPrice = 80;
            const double retiredPrice = 90;
            const double standardPrice = 120;

            string choice = "Y";
            while (choice == "Y"){
                Console.Clear();
                Console.WriteLine("På detta funktion kand du kolla om en person får ungdoms- eller pensionärsrabatt på Bio pris.");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Testa ålder på (E)n person eller (F)lera? Skriva E eller F. Skriva nått annat för att gå tillbacka.");
                choice = Console.ReadLine() ?? "E";

                if (choice.ToUpper() == "E")
                {
                    Console.Write("\nAnge personens ålder: ");

                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                    {
                        Console.Write("Ogiltig inmatning. Vänligen ange en giltig ålder: ");
                    }

                    if (age < 20)
                    {
                        Console.WriteLine($"Personen är berättigad till ungdomspris: {youngPrice:C2}.");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N");
                        choice = Console.ReadLine() ?? "N";
                    }
                    else if (age >= 64)
                    {
                        Console.WriteLine($"Personen är berättigad till pensionärspris: {retiredPrice:C2}.");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N");
                        choice = Console.ReadLine() ?? "N";
                    }
                    else
                    {
                        Console.WriteLine($"Personen är inte berättigad till någon rabatt. Standard pris är: {standardPrice}");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N");
                        choice = Console.ReadLine() ?? "N";
                    }
                }
                else {
                    GroupPrice();   
                }   
            }
        }

        private static void GroupPrice()
        {
            Console.Write("\nAnge hur många personer finns i din grupp: ");

            int numberOfPeople;
            while (!int.TryParse(Console.ReadLine(), out numberOfPeople) || numberOfPeople < 1)
            {
                Console.Write("Ogiltig inmatning. Vänligen ange en giltig nummer av personer: ");
            }

            for (int i = 1; i <= numberOfPeople; i++)
            {
                
            }
        }
    }
}
