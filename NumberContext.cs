using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brighteye
{
    class NumberContext : DbContext
    {
        public DbSet<NumberEntity> Number { get; set; }
    }
}
