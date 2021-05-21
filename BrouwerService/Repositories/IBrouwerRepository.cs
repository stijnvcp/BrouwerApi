﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerService.Models;

namespace BrouwerService.Repositories
{
    public interface IBrouwerRepository
    {
        IQueryable<Brouwer> FindAll();
        Brouwer FindById(int id);
        IQueryable<Brouwer> FindByBeginNaam(string begin);
        void Insert(Brouwer brouwer);
        void Delete(Brouwer brouwer);
        void Update(Brouwer brouwer);
    }
}
