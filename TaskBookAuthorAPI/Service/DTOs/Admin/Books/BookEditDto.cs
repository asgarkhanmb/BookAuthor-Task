using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Books
{
    public class BookEditDto
    {
        public string Title { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
