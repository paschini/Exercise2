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
                Console.WriteLine("0 - Stäng ner programmet\n");
                Console.WriteLine("1 - Räkna Bio pris till en person eller flera\n"); // har en submeny för att välja en eller flera personer
                Console.WriteLine("2 - Räkna Bio pris till en grupp\n"); // har inget submeny, bara räkna pris för gruppen en gång
                Console.WriteLine("3 - Upprepa inmatning 10 gånger\n");
                Console.WriteLine("4 - Hitta 3:e ordet i en mening\n");

                string input = Console.ReadLine() ?? "0";
                switch (input)
                {
                    case "0":
                        exitProgram = true;
                        break;
                    case "1":
                        YoungOrRetired();
                        break;
                    case "2":
                        GroupPrice();
                        break;
                    case "3":
                        RepeatInput();
                        break;
                    case "4":
                        Find3rdWord();
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
                Console.WriteLine("På denna funktion ska du få Bio pris till en person eller flera.\nVi räknar ut med ungdoms och pensionärs rabbat.");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Pris till (E)n person eller få en antal pris till (F)lera? \nSkriva E eller F. Skriva nått annat för att gå tillbacka.");
                choice = Console.ReadLine() ?? "E";
                while (!(choice.ToUpper() == "E" || choice.ToUpper() == "F"))
                {
                    Console.Write("Ogiltig inmatning. Vänligen ange E till 1 person eller F till 2 personer eller mer: ");
                    choice = Console.ReadLine() ?? "E";
                }

                if (choice.ToUpper() == "E")
                {
                    Console.Write("\nAnge personens ålder: ");

                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                    {
                        Console.Write("Ogiltig inmatning. Vänligen ange en giltig ålder: ");
                    }

                    Console.WriteLine(MoviesPrice.CalculatePersonPrice(age).Message);
                    Console.Write($"Räkna Bio pris igen? [Y]es eller [N]o: ");
                    choice = Console.ReadLine() ?? "N";
                }
                else if (choice.ToUpper() == "F")
                {
                    // Det menar att användaren vill hantera en grupp och få total pris.
                    // "F" för Flera ska bara kalkylera pris för gruppen en gång.
                    // om vi vill låta användaren kalkylera flera grupp, behöver vi bara okommentera ut "choice = "Y";" nedan.
                    // choice = "Y";
                    GroupPrice();
                }
            }
        }

        private static void GroupPrice()
        {
            Console.Clear();
            Console.WriteLine("På denna funktion ska du få Bio pris till en grupp.\nVi räknar ut med ungdoms och pensionärs rabbat.");
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
                totalPrice += MoviesPrice.CalculatePersonPrice(age).Price;
            }

            Console.WriteLine($"\nTotala priset för gruppen med {numberOfPeople} personner är: {totalPrice:C2}.");
            // bara för att användare ska få läsa resultatet innan gå tillbacka till huvudmeny
            Console.ReadLine();
        }

        private static void RepeatInput()
        {
            Console.Clear();
            Console.WriteLine("På denna funktion upprepar din inmatning 10 gånger.\nTexten som du skriver in måste vara helt på en rad.");
            Console.WriteLine("\nAnge en text som du vill upprepa: ");
            string input = Console.ReadLine() ?? "";

            if (input != string.Empty)
            {
                Console.WriteLine("\nDin inmatning upprepas 10 gånger:\n");
                string repeatedInputs = StringHelper.RepeatedInput(input);

                Console.WriteLine(repeatedInputs);
            }
            else
            {
                Console.WriteLine("Ingen inmatning att upprepa.");
            }

            // bara för att användare ska få läsa resultatet innan gå tillbacka till huvudmeny
            Console.ReadLine();
        }

        private static void Find3rdWord()
        {
            bool exitFunction = false;
            while (!exitFunction)
            {
                Console.Clear();
                Console.WriteLine("På denna funktion hittar du det 3:e ordet i en mening.");
                Console.Write("\nAnge en mening med minst 3 ord: ");

                string input = Console.ReadLine() ?? "";
                string? thirdWord = StringHelper.Get3rdWord(input);

                if (thirdWord != null)
                {
                    Console.WriteLine($"Det 3:e ordet i din mening är: \"{thirdWord}\".");
                    exitFunction = true;
                }
                else
                {
                    Console.WriteLine("Mening innehåller mindre än 3 ord. Vänligen försök igen med en längre mening.");
                    Console.WriteLine("Kolla också  att det finns inte   flera   mellanslag tillsammans i   mening.");
                    Console.ReadLine();
                }
            }

            // bara för att användare ska få läsa resultatet innan gå tillbacka till huvudmeny
            Console.ReadLine();
        }
    }
}