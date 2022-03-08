using BefolkPostGres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BefolkPostGres.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BefolkPostGres.Repositories
{
    public class CPR_Samlet_REPO : IRepository<CprPrognoseSamlet>
    {

        private readonly egedalContext _context;
        public CPR_Samlet_REPO(egedalContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<CprPrognoseSamlet>> GetAll()
        {
            //using (egedalContext egedalContext = new egedalContext())
            //{
            //    return (IEnumerable<CprPrognoseSamlet>)await _context.CprPrognoseSamlet.Select(item => item.Sum).ToListAsync();
            //}

            List<CprPrognoseSamlet> data;
            data = (List<CprPrognoseSamlet>)_context.CprPrognoseSamlet.Select(item => item.Sum);
            return (data);
        }
    }
}
