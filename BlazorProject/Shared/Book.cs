using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey(nameof(Author))]

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public BookType? BookType { get; set; }
        [ForeignKey(nameof(BookType))]
        public int? BookTypeId { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Sales { get; set; }
    }
}
