using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerWebApp.Models;

namespace BrouwerWebApp.Repositories {
    public interface IBrouwerRepository {
        Task<List<Brouwer>> FindAllAsync();
        Task<Brouwer> FindByIdAsync(int id);
    }
}
