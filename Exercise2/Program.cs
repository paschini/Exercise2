

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

            string choice = "Y";
            while (choice.ToUpper() == "Y")
            {
                // för att försätta testa personen, man måste ange Y när vi frågar "Y" eller "N". Nått annat går tillbacka till huvudmeny
                Console.Clear();
                Console.WriteLine("På detta funktion kand du få Bio pris till en person eller flera.\nVi räknar ut med ungdoms och pensionärs rabbat.");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Pris till (E)n person eller få en antal pris till (F)lera? \nSkriva E eller F. Skriva nått annat för att gå tillbacka.");
                choice = Console.ReadLine() ?? "E";
                while (!(choice.ToUpper() == "E") || (choice.ToUpper() == "F"))
                {
                    Console.Write("Ogiltig inmatning. Vänligen ange en giltig nummer av personer: ");
                }

                if (choice.ToUpper() == "E")
                {
                    Console.Write("\nAnge personens ålder: ");

                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                    {
                        Console.Write("Ogiltig inmatning. Vänligen ange en giltig ålder: ");
                    }

                    double price = CalculatePersonPrice(age);

                    if (age < 20)
                    {
                        Console.WriteLine($"Personen är berättigad till ungdomspris: {price:C2}.");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N: ");
                        choice = Console.ReadLine() ?? "N";
                    }
                    else if (age >= 64)
                    {
                        Console.WriteLine($"Personen är berättigad till ungdomspris: {price:C2}.");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N: ");
                        choice = Console.ReadLine() ?? "N";
                    }
                    else
                    {
                        Console.WriteLine($"Personen är berättigad till ungdomspris: {price:C2}.");
                        Console.Write($"Testa en till persons ålder? Trycka på Y eller N: ");
                        choice = Console.ReadLine() ?? "N";
                    }
                }
                else if(choice.ToUpper() == "F") {
                    // Det menar att användaren vill hantera en grupp och få total pris.
                    // "F" för Flera ska bara kalkylera pris för gruppen en gång.
                    GroupPrice();   
                }   
            }
        }

        private static double CalculatePersonPrice(int age)
        {
            const double youngPrice = 80;
            const double retiredPrice = 90;
            const double standardPrice = 120;

            if (age < 20)
            {
                return youngPrice;
            }
            else if (age >= 64)
            {
                return retiredPrice;
            }
            else
            {
                return standardPrice;
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

            double totalPrice = 0;

            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.Write($"\nAnge personens {i + 1} ålder: ");

                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.Write("Ogiltig inmatning. Vänligen ange en giltig ålder: ");
                }
                totalPrice += CalculatePersonPrice(age);
            }

            Console.WriteLine($"\nTotala priset för gruppen med {numberOfPeople} personner är: {totalPrice:C2}.");
            Console.ReadLine(); // bara för att användare ska få läsa resultatet innan gå tillbacka till huvudmeny
        }
    }
}