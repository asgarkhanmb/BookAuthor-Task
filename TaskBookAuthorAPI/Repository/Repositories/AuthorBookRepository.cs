﻿using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AuthorBookRepository : BaseRepostiory<AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(AppDbContext context) : base(context) { }

    }
}
