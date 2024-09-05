namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Usuń książkę");
                Console.WriteLine("3. Wyświetl ksiżąki");
                Console.WriteLine("4. Wyszukaj ksiązkę");
                Console.WriteLine("5. Zakończ");
                Console.WriteLine("Wpisz numer opcji: ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;
                    case "2":
                        library.DeleteBook();
                        break;
                    case "3":
                        library.DisplayBooks();
                        break;
                    case "4":
                        library.FindBook();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Podano nieprawidłową opcje. Spróbuj ponownie");
                        Console.ResetColor();
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Program zakończony.");
            Console.ResetColor();
        }
    }
}
