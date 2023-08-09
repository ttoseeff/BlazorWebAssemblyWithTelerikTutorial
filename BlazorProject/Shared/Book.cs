using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public BookType BookType { get; set; }
        public int BookTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal Sales { get; set; }
    }
}
