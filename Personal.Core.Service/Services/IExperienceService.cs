using Personal.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Services
{
    public interface IExperienceService : IRepositoryService<Experience>
    {
        Task<List<Experience>> OrderByDescendingExperience();

    }
}
