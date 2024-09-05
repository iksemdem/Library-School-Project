namespace library
{
    public class Library
    {
        private static int nextID = 1;
        public List<Book> Books { get; set; } = new List<Book>();

        public Library()
        {
            // Dodaj domyślne książki
            Books.Add(new Book(nextID++, "Pan Tadeusz", "Adam Mickiewicz", 1834, 376));
            Books.Add(new Book(nextID++, "To", "Stephen King", 1986, 360));
            Books.Add(new Book(nextID++, "Smętarz dla zwierzaków", "Stephen King", 1983, 416));
        }

        public void AddBook()
        {
            bool finished = false;

            while (!finished)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nAby dodać książke, wpisz teraz jej Tytuł");
                Console.ResetColor();
                string tempTitle = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Wpisz teraz jej Autora");
                Console.ResetColor();
                string tempAuthor = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Wpisz teraz jej rok wydania");
                Console.ResetColor();
                int tempYear = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Wpisz teraz ile ma stron");
                Console.ResetColor();
                int tempPages = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nTwoja książka to: {tempTitle}, {tempAuthor}, {tempYear}, {tempPages}. Zgadza się? (tak/nie)");
                Console.ResetColor();
                bool validChoice = false;

                while (!validChoice)
                {
                    string choice = Console.ReadLine();

                    switch (choice.ToLower())
                    {
                        case "tak":
                            Book newBook = new Book(nextID++, tempTitle, tempAuthor, tempYear, tempPages);
                            Books.Add(newBook);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Świetnie, dodawanie książki...");
                            Console.ResetColor();
                            finished = true;
                            validChoice = true;
                            break;
                        case "nie":

                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Console.WriteLine("Wprowadź dane ponownie.");
                            Console.ResetColor();
                            validChoice = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Nieprawidłowy wybór, wpisz tak/nie");
                            Console.ResetColor();
                            break;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nLista wszystkich książek:\n");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nZakończono.");
            Console.ResetColor();
        }

        public void DeleteBook()
        {
            bool finished = false;

            while (!finished)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nAby usunąć książkę musisz podać jej ID. Czy chcesz wyświetlić listę wszystkich książek? (tak/nie)");
                Console.ResetColor();

                bool validChoice = false;

                while (!validChoice)
                {
                    string choice = Console.ReadLine();

                    switch (choice.ToLower())
                    {
                        case "tak":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nLista wszystkich książek:\n");
                            foreach (var book in Books)
                            {
                                Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                            }
                            Console.ResetColor();
                            validChoice = true;
                            break;
                        case "nie":
                            validChoice = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Nieprawidłowy wybór, wpisz tak/nie");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nPodaj ID książki, którą chcesz usunąć:");
                Console.ResetColor();
                if (int.TryParse(Console.ReadLine(), out int tempID))
                {
                    var bookToRemove = Books.FirstOrDefault(b => b.ID == tempID);

                    if (bookToRemove != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"\nZnaleziono książkę:\nID: {bookToRemove.ID}, Tytuł: {bookToRemove.Title}, Autor: {bookToRemove.Author}, Rok: {bookToRemove.Year}, Strony: {bookToRemove.Pages}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Czy na pewno chcesz usunąć tę książkę? (tak/nie)");
                        Console.ResetColor();

                        bool confirmChoice = false;

                        while (!confirmChoice)
                        {
                            string confirm = Console.ReadLine();

                            switch (confirm.ToLower())
                            {
                                case "tak":
                                    Books.Remove(bookToRemove);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Książka o ID {tempID} została usunięta.");
                                    Console.ResetColor();
                                    finished = true;
                                    confirmChoice = true;
                                    break;
                                case "nie":
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("\nPodaj ID książki, którą chcesz usunąć:");
                                    Console.ResetColor();
                                    confirmChoice = true;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nieprawidłowy wybór, wpisz tak/nie");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieprawidłowe ID, spróbuj ponownie.");
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nLista wszystkich książek:\n");
                    foreach (var book in Books)
                    {
                        Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                    }
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nZakończono.");
                    Console.ResetColor();
                }
                
            }
        }

        public void DisplayBooks()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nLista wszystkich książek:\n");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nZakończono.");
            Console.ResetColor();
        }

        public void FindBook()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWybierz numer z opcją, po czym chcesz wyszukać książkę.\n");
            Console.WriteLine("1. Po tytule");
            Console.WriteLine("2. Po autorze");
            Console.WriteLine("3. Po roku wydania");
            Console.WriteLine("4. Po liczbie stron");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Wpisz numer opcji: ");
            Console.ResetColor();

            string choice = Console.ReadLine();

            string SearchQuery;

            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj tytuł po jakim wyszukać");
                    Console.ResetColor();
                    SearchQuery = Console.ReadLine();
                    SearchBooks(SearchQuery, "Title");
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj autora po jakim wyszukać");
                    Console.ResetColor();
                    SearchQuery = Console.ReadLine();
                    SearchBooks(SearchQuery, "Author");
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj rok wydania po jakim wyszukać");
                    Console.ResetColor();
                    SearchQuery = Console.ReadLine();
                    SearchBooks(SearchQuery, "Year");
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj liczbę stron po jakiej wyszukać");
                    Console.ResetColor();
                    SearchQuery = Console.ReadLine();
                    SearchBooks(SearchQuery, "Pages");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podano nieprawidłową opcje. Spróbuj ponownie");
                    Console.ResetColor();
                    break;
            }
        }

        public void SearchBooks(string query, string searchBy)
        {
            if(searchBy == "Title")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWyszukiwanie po tytule...");
                Console.ResetColor();

                var booksByTitle = Books.Where(b => b.Title.Equals(query, StringComparison.OrdinalIgnoreCase)).ToList();

                if (booksByTitle.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nZnalezione książki:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var book in booksByTitle)
                    {
                        Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono książek o tym tytule.");
                    Console.ResetColor();
                }

            } else if (searchBy == "Author")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWyszukiwanie po autorze...");
                Console.ResetColor();

                var booksByAuthor = Books.Where(b => b.Author.Equals(query, StringComparison.OrdinalIgnoreCase)).ToList();

                if (booksByAuthor.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nZnalezione książki:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var book in booksByAuthor)
                    {
                        Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono książek napisanych przez autora o podanym imieniu i nazwisku.");
                    Console.ResetColor();
                }

            } else if (searchBy == "Year")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWyszukiwanie po roku wydania...");
                Console.ResetColor();

                var booksByYear = Books.Where(b => b.Year == int.Parse(query)).ToList();

                    if (booksByYear.Any())
                    {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nZnalezione książki:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var book in booksByYear)
                        {
                            Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono książek wydanych w podanym roku.");
                    Console.ResetColor();
                }

            } else if (searchBy == "Pages")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWyszukiwanie po liczbie stron...");
                Console.ResetColor();

                var booksByPages = Books.Where(b => b.Pages == int.Parse(query)).ToList();

                if (booksByPages.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nZnalezione książki:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (var book in booksByPages)
                    {
                        Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Strony: {book.Pages}\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono książek z podaną liczbą stron.");
                    Console.ResetColor();
                }

            } else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Coś poszło nie tak. Spróbuj ponownie");
                Console.ResetColor();
            }
        }
    }
}