using Microsoft.AspNetCore.Mvc.Rendering;

namespace LghBaitapLesson06.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TongSoTrangSach { get; set; }
        public string Sumary { get; set; }
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", AuthorId = 1, GenreId = 1, Image = "book1.jpg", Price = 9.99f, TongSoTrangSach = 200, Sumary = "Summary of Book 1" },
            new Book { Id = 2, Title = "Book 2", AuthorId = 2, GenreId = 2, Image = "book2.jpg", Price = 14.99f, TongSoTrangSach = 300, Sumary = "Summary of Book 2" },
            new Book { Id = 3, Title = "Book 3", AuthorId = 3, GenreId = 3, Image = "book3.jpg", Price = 19.99f, TongSoTrangSach = 400, Sumary = "Summary of Book 3" }
        };
            return books;
        }
        public Book GetBookById( )
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == this.Id);
            return book;
        }
        public List<SelectListItem> Authors { get; set; } =new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam cao" },
            new SelectListItem { Value = "2", Text = "Ngo Tat To" },
            new SelectListItem { Value = "3", Text = "Le Gia Hung" }
        };
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Trinh tham" },
            new SelectListItem { Value = "2", Text = "Kinh di" },
            new SelectListItem { Value = "3", Text = "Khoa hoc" }
        };
    }
}
