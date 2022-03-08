using BefolkPostGres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BefolkPostGres.Repositories
{
    public class CPR_Samlet_REPO1 : IRepository<CprPrognoseSamlet1>
    {
        private readonly egedalContext _context;
        public CPR_Samlet_REPO1(egedalContext context)
        {
            _context = context;
        }

                

        public async Task<IEnumerable<CprPrognoseSamlet1>> GetAll()
        {

            using (egedalContext egedalContext = new egedalContext())
            {
                return (IEnumerable<CprPrognoseSamlet1>) await _context.CprPrognoseSamlet1.Select(item => item.Sum).ToListAsync();
            }

            //List<CprPrognoseSamlet1> data;
            //data = await _context.CprPrognoseSamlet1.ToListAsync();
            //return data;
        }
    }
}
