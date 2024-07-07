using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book :BaseEntity
    {
        public string Title { get; set; }
        public ICollection<AuthorBook> AuthorBooks{ get; set; }
    }
}
