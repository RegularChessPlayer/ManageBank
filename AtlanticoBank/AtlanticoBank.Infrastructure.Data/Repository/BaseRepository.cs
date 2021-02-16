using AtlanticoBank.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Infrastructure.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

    }
}
