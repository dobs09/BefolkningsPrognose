using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BefolkPostGres.Models;
using BefolkPostGres.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BefolkPostGres.Repositories

{
    public class PROGNOSE_hardcodet_REPO : IRepository<PrognoseHardcodet>
    {
        
        private readonly egedalContext _context;
        public PROGNOSE_hardcodet_REPO(egedalContext context)
        {
            _context = context;
        }

        //public IActionResult GetAll()
        //{            
                        
        //    var data = _context.PrognoseHardcodet.Select(item => item.Sum).ToList();
        //    return data;
        //}

        public async Task<IEnumerable<PrognoseHardcodet>> GetAll()
        {
            //using (egedalContext egedalContext = new egedalContext())
            //{
            //    return await egedalContext.PrognoseHardcodet.FromSqlRaw("SELECT id, sum FROM \"flis\".\"PROGNOSE_hardcodet\"").ToListAsync();
            //}

            //using (egedalContext egedalContext = new egedalContext())
            //{
            //    return (IEnumerable<PrognoseHardcodet>)await _context.PrognoseHardcodet.Select(item => item.Sum).ToListAsync();
            //}


            List<PrognoseHardcodet> data;
            data = (List<PrognoseHardcodet>)_context.PrognoseHardcodet.Select(item => item.Sum);
            return data;
        }


    }
}
