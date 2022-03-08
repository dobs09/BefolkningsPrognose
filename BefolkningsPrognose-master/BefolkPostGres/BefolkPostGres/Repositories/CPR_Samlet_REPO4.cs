using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BefolkPostGres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BefolkPostGres.Repositories
{
    public class CPR_Samlet_REPO4 : IRepository<CprPrognoseSamlet4>
    {
        private readonly egedalContext _context;
        public CPR_Samlet_REPO4(egedalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CprPrognoseSamlet4>> GetAll()
        {
            using (egedalContext egedalContext = new egedalContext())
            {
                return (IEnumerable<CprPrognoseSamlet4>)await _context.CprPrognoseSamlet4.Select(item => item.Sum).ToListAsync();
            }
        }
        //public async Task<IEnumerable<CprPrognoseSamlet4>> GetAll()
        //{
        //    List<CprPrognoseSamlet4> data;
        //    data = await _context.CprPrognoseSamlet4.ToListAsync();
        //    return data;
        //}
    }
}
