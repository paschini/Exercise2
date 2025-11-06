namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();

            static void MainMenu()
            {
                bool exitProgram = false;
                while (!exitProgram)
                {
                    Console.Clear();
                    Console.WriteLine("Välkomen till HuvudMeny");
                    Console.WriteLine("\nSkriva en av nerstående siffror följd med <Enter> för att navigera till en function:");
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                    Console.WriteLine("0 - Stäng ner programmet"); // default
                    Console.WriteLine("1 - Första fukntion\n");

                    string input = Console.ReadLine() ?? "0";
                    switch (input)
                    {
                        case "0":
                            exitProgram = true;
                            break;
                        case "1":
                            Console.WriteLine("Du har valt första funktionen. Tryck på valfri tangent för att återvända till huvudmenyn.");
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att försöka igen.");
                            Console.ReadKey();
                            break;
                    }
                }


            }
        }
    }
}
