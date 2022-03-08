using BefolkPostGres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BefolkPostGres.Repositories
{
    public class CPR_Samlet_REPO3 : IRepository<CprPrognoseSamlet3>
    {
        private readonly egedalContext _context;
        public CPR_Samlet_REPO3(egedalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CprPrognoseSamlet3>> GetAll()
        {
            using (egedalContext egedalContext = new egedalContext())
            {
                return (IEnumerable<CprPrognoseSamlet3>)await _context.CprPrognoseSamlet3.Select(item => item.Sum).ToListAsync();
            }
        }

        //public async Task<IEnumerable<CprPrognoseSamlet3>> GetAll()
        //{
        //    List<CprPrognoseSamlet3> data;
        //    data = await _context.CprPrognoseSamlet3.ToListAsync();
        //    return data;
        //}
    }
}
