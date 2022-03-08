using BefolkPostGres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BefolkPostGres.Repositories
{
    public class CPR_Samlet_REPO2 : IRepository<CprPrognoseSamlet2>
    {
        private readonly egedalContext _context;
        public CPR_Samlet_REPO2(egedalContext context)
        {
            _context = context;
        }


        //public async Task<IEnumerable<CprPrognoseSamlet2>> GetAll()
        //{
        //    List<CprPrognoseSamlet2> data;
        //    data = await _context.CprPrognoseSamlet2.ToListAsync();
        //    return data;
        //}

        public async Task<IEnumerable<CprPrognoseSamlet2>> GetAll()
        { 
            using (egedalContext egedalContext = new egedalContext())
            {
                return (IEnumerable<CprPrognoseSamlet2>)await _context.CprPrognoseSamlet2.Select(item => item.Sum).ToListAsync();
            }
        }
    }
}
