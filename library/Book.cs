namespace library
{
    public class Book
    {
        public int ID;
        public string Title;
        public string Author;
        public int Year;
        public int Pages;

        // Constructor

        public Book(int ID, string Title, string Author, int Year, int Pages)
        {
            this.ID = ID;
            this.Title = Title;
            this.Author = Author;
            this.Year = Year;
            this.Pages = Pages;
        }
    }
}
