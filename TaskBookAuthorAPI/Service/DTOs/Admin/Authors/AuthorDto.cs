using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Authors
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> BooksName { get; set; }
    }
}
