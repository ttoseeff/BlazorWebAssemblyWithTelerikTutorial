using BlazorProject.Shared;

namespace BlazorProject.Client.Models
{
    public class BooksDto
    {
        public BooksDto() 
        {
            Author = new Author();
            BookType = new BookType();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public BookType? BookType { get; set; }
        public int? BookTypeId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Sales { get; set; }
    }
}
