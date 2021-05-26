using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerWebApp.Repositories {
    public class BrouwerRepository : IBrouwerRepository {

        private readonly BierlandContext context;
        public BrouwerRepository(BierlandContext context) => this.context = context;

        public async Task<List<Brouwer>> FindAllAsync() =>
        await context.Brouwers.AsNoTracking().ToListAsync();
        public async Task<Brouwer> FindByIdAsync(int id) =>
        await context.Brouwers.FindAsync(id);
    }
}
