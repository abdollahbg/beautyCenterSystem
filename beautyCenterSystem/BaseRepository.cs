using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenterSystem.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DbConnectionFactory _dbFactory;

        protected BaseRepository(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
    }
}
