using Personal.Core.Core.Models;
using Personal.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Repository.DataAccess
{
    public class EntranceRepository : ModelRepository<Entrance>, IEntranceRepository
    {
        public EntranceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
