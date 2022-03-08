using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BefolkPostGres.Repositories
{
    public interface IRepository<T1> where T1 : class
    {
        public Task<IEnumerable<T1>> GetAll();
    
    }
}
