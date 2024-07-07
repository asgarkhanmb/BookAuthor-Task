using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string>AuthorsName { get; set; }
    }
}
