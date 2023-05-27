using Personal.Core.Core.Models;
using Personal.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Repository.DataAccess
{
    public class LanguageRepository : ModelRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
