using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BefolkPostGres.Models;
using BefolkPostGres.Repositories;
using Microsoft.EntityFrameworkCore;
namespace BefolkPostGres.Repositories

{
    public class CprBefolkningSamlet_REPO 
    {
        private readonly egedalContext _context;
        public CprBefolkningSamlet_REPO(egedalContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CprBefolkningSamlet>> GetAll(int id)
        {


            //using (egedalContext egedalContext = new egedalContext())
            //{

            //    return await egedalContext.PrognoseHardcodet.FromSqlRaw("SELECT id, sum FROM \"flis\".\"PROGNOSE_hardcodet\"").ToListAsync();

            //}

            

            List<CprBefolkningSamlet> data;
            data = await _context.CprBefolkningSamlet.FromSqlRaw("SELECT * FROM \"flis\".\"CPR_Befolkning_Samlet\" WHERE skolekod = " + id + "").ToListAsync();
            return data;
        }

    }
}



   

        
    

