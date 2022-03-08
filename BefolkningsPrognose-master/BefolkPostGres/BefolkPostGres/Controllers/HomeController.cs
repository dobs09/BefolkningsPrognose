using BefolkPostGres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BefolkPostGres.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Dapper;

namespace BefolkningPostGres.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly egedalContext _egeContex;

        private readonly IRepository<CprPrognoseSamlet> _rep;
        private readonly IRepository<CprPrognoseSamlet1> _rep1;
        private readonly IRepository<CprPrognoseSamlet2> _rep2;
        private readonly IRepository<CprPrognoseSamlet3> _rep3;
        private readonly IRepository<CprPrognoseSamlet4> _rep4;
        private readonly IRepository<PrognoseHardcodet> _repHard;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(
        egedalContext egeContext,
         IRepository<CprPrognoseSamlet> rep,
         IRepository<CprPrognoseSamlet1> rep1,
         IRepository<CprPrognoseSamlet2> rep2,
         IRepository<CprPrognoseSamlet3> rep3,
         IRepository<CprPrognoseSamlet4> rep4,
         IRepository<PrognoseHardcodet> repHard,
         ILogger<HomeController> logger)
        {
            _egeContex = egeContext;
            _rep = rep;
            _rep1 = rep1;
            _rep2 = rep2;
            _rep3 = rep3;
            _rep4 = rep4;
            _repHard = repHard;
            _logger = logger;

        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult SøgData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCprBefSamlet(string Area, string Age)
        {
            List<int?> egedal = new List<int?>();
            dynamic egedal1 = null;
            //dynamic data = null;
            if (Area == "alle")
            {
                if (Age == "nul")
                {

                    //egedal1 = _egeContex.CprPrognoseSamlet
                    //    .Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    //    .OrderByDescending(d => d.AarMaaned).ToList();

                    egedal1 = (
                        from p in _egeContex.CprPrognoseSamlet
                        group p by p.AarMaaned into g
                        select new
                        {
                                                //PersonId = g.Key,
                                                egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                        }
                        ).ToList();
                }
                if (Age == "alle")
                {

                    //egedal1 = _egeContex.CprPrognoseSamlet
                    //    .Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    //    .OrderByDescending(d => d.AarMaaned).ToList();

                    egedal1 = (
                        from p in _egeContex.CprPrognoseSamlet
                        group p by p.AarMaaned into g
                        select new
                        {
                            //PersonId = g.Key,
                            egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                        }
                        ).ToList();
                }
                if (Age == null)
                {
                    //egedal1 = _egeContex.CprPrognoseSamlet.OrderByDescending(d => d.AarMaaned).FirstOrDefault();

                    egedal1 = _egeContex.CprPrognoseSamlet
                        .Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                        .OrderByDescending(d => d.AarMaaned).FirstOrDefault();



                    //egedal1 = (
                    //from p in _egeContex.CprPrognoseSamlet
                    //group p by p.AarMaaned into g
                    //select new
                    //{
                    //    //PersonId = g.Key,
                    //    egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    //}
                    //).ToList();
                }
                if (Age == "0")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(a => a._0).ToList();
                    //egedal1 = _egeContex.CprPrognoseSamlet
                    //    .Select(a => new { a._0, a.AarMaaned })
                    //    .OrderByDescending(d => d.AarMaaned).ToList();

                    //egedal1 = (
                    //from p in _egeContex.CprPrognoseSamlet
                    //group p by p.AarMaaned into g
                    //select new
                    //{
                    //    //PersonId = g.Key,
                    //    egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    //}
                    //).ToList();

                    //egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._0).ToList();

                }
                else if (Age == "1")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._1).ToList();
                }
                else if (Age == "02")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._02).ToList();
                }
                else if (Age == "35")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._35).ToList();
                }
                else if (Age == "616")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._616).ToList();
                }
                else if (Age == "1724")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._1724).ToList();
                }
                else if (Age == "2564")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._2564).ToList();
                }
                else if (Age == "6574")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._6574).ToList();
                }
                else if (Age == "7584")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._7584).ToList();
                }
                else if (Age == "85")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet.Select(item => item._85).ToList();
                }
            }
            else if (Area == "ølstykke")
            {
                if (Age == null)
                {
                    egedal1 = (
                    from p in _egeContex.CprPrognoseSamlet1
                    group p by p.AarMaaned into g
                    select new
                    {
                        //PersonId = g.Key,
                        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    }
                    ).ToList();

                    //egedal1 = _egeContex.CprPrognoseSamlet1
                    //.Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    //.OrderByDescending(d => d.AarMaaned).First();
                }

                if (Age == "alle")
                {
                    egedal1 = (
                    from p in _egeContex.CprPrognoseSamlet1
                    group p by p.AarMaaned into g
                    select new
                    {
                        //PersonId = g.Key,
                        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    }
                    ).ToList();

                    //egedal1 = _egeContex.CprPrognoseSamlet1
                    //.Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    //.OrderByDescending(d => d.AarMaaned).First();
                }

                //data = await _rep.GetAll();
                else if (Age == "0")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._0).ToList();
                }
                else if (Age == "1")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._1).ToList();
                }
                else if (Age == "02")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._02).ToList();
                }
                else if (Age == "35")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._35).ToList();
                }
                else if (Age == "616")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._616).ToList();
                }
                else if (Age == "1724")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._1724).ToList();
                }
                else if (Age == "2564")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._2564).ToList();
                }
                else if (Age == "6574")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._6574).ToList();
                }
                else if (Age == "7584")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._7584).ToList();
                }
                else if (Age == "85")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet1.Select(item => item._85).ToList();
                }

            }
            else if (Area == "stenløse")
            {
                if (Age == null)
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2
                    .Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    .OrderByDescending(d => d.AarMaaned).First();
                }
                if (Age == "alle")
                {
                    egedal1 = (
                    from p in _egeContex.CprPrognoseSamlet2
                    group p by p.AarMaaned into g
                    select new
                    {
                        //PersonId = g.Key,
                        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    }
                    ).ToList();
                }
                //data = await _rep.GetAll();
                else if (Age == "0")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._0).ToList();
                }
                else if (Age == "1")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._1).ToList();
                }
                else if (Age == "02")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._02).ToList();
                }
                else if (Age == "35")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._35).ToList();
                }
                else if (Age == "616")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._616).ToList();
                }
                else if (Age == "1724")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._1724).ToList();
                }
                else if (Age == "2564")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._2564).ToList();
                }
                else if (Age == "6574")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._6574).ToList();
                }
                else if (Age == "7584")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._7584).ToList();
                }
                else if (Age == "85")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet2.Select(item => item._85).ToList();
                }
            }
            else if (Area == "ganløse")
            {
                if (Age == null)
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3
                                            
                        .Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                        .OrderByDescending(d => d.AarMaaned).First();
                }
                if (Age == "alle")
                {
                    egedal1 = (
                    from p in _egeContex.CprPrognoseSamlet3
                    group p by p.AarMaaned into g
                    select new
                    {
                        //PersonId = g.Key,
                        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                    }
                    ).ToList();
                }
                if (Age == "0")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._0).ToList();
                }

                //data = await _rep.GetAll();
                else if (Age == "1")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._1).ToList();
                }
                else if (Age == "02")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._02).ToList();
                }
                else if (Age == "35")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._35).ToList();
                }
                else if (Age == "616")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._616).ToList();
                }
                else if (Age == "1724")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._1724).ToList();
                }
                else if (Age == "2564")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._2564).ToList();
                }
                else if (Age == "6574")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._6574).ToList();
                }
                else if (Age == "7584")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._7584).ToList();
                }
                else if (Age == "85")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet3.Select(item => item._85).ToList();
                }
                
            }
            else if (Area == "smørum")
            {
                if (Age == "alle")
                {
                    egedal1 = (
                   from p in _egeContex.CprPrognoseSamlet4
                   group p by p.AarMaaned into g
                   select new
                   {
                        //PersonId = g.Key,
                        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                   }
                   ).ToList();
                    //egedal1 = _egeContex.CprPrognoseSamlet4
                    //.Select(a => new { a._0, a._1, a._02, a._35, a._616, a._1724, a._2564, a._6574, a._7584, a._85, a.AarMaaned })
                    //.OrderByDescending(d => d.AarMaaned).First();
                }
                if (Age == "0")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._0).ToList();
                }

                //data = await _rep.GetAll();
                else if (Age == "1")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._1).ToList();
                }
                else if (Age == "02")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._02).ToList();
                }
                else if (Age == "35")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._35).ToList();
                }
                else if (Age == "616")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._616).ToList();
                }
                else if (Age == "1724")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._1724).ToList();
                }
                else if (Age == "2564")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._2564).ToList();
                }
                else if (Age == "6574")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._6574).ToList();
                }
                else if (Age == "7584")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._7584).ToList();
                }
                else if (Age == "85")
                {
                    egedal1 = _egeContex.CprPrognoseSamlet4.Select(item => item._85).ToList();
                }
                
            }

            return Json(egedal1);
        }
        [HttpGet]
        public ActionResult GetPrognose(string Area, String Age)
        {
            //Her findes den data, som bruges til at vise (document.ready) når man loader søge-siden.
            dynamic egedal = null;
            if (Age == "nul")
            {
                
                egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle")
                    .Select(x => new { x.Alder0, x.Alder1, x.Alder02, x.Alder35, x.Alder616, x.Alder1724, x.Alder2564, x.Alder6574, x.Alder7584, x.Alder85, x.Id }).FirstOrDefault();
            }
            if (Age == "alle")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Sum).ToList();

                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id).Where(b => b.Omraade == "alle")
                    //.Select(x => new { x.Alder0, x.Alder1, x.Alder02, x.Alder35, x.Alder616, x.Alder1724, x.Alder2564, x.Alder6574, x.Alder7584, x.Alder85, x.Id }).FirstOrDefault();

                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Sum).ToList();                            

                    //egedal = _egeContex.PrognoseHardcodet
                    //.FromSqlRaw("select \"sum\" from \"flis\".\"PROGNOSE_hardcodet\" where omraade = 'alle' ").ToList();

                    //egedal = _egeContex.PrognoseHardcodet.Select(a => a.Alder02 + a.Alder35 + a.Alder616 + a.Alder1724 + a.Alder2564 + a.Alder6574 + a.Alder7584 + a.Alder85).Sum();

                    //egedal = _egeContex.PrognoseHardcodet.Select(b => new { b, Total = b.Alder02 + b.Alder35 + b.Alder616 + b.Alder1724 + b.Alder2564 + b.Alder6574 + b.Alder7584 + b.Alder85 })
                    //    .GroupBy(_egeContex.PrognoseHardcodet.).ToList();

                    //.GroupBy(b => b.Aarstal)
                    //.Select(g => new { Aarstal = g.Key, Total = g.Sum(i => i.Total) });

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Sum).ToList();
                    
                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id)
                    //    .Where(b => b.Omraade == "ølstykke")
                    //    .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "stenløse")
                {

                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Sum).ToList();
                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id)
                    //    .Where(b => b.Omraade == "stenløse")
                    //    .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Sum).ToList();
                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id)
                    //    .Where(b => b.Omraade == "ganløse")
                    //    .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Sum).ToList();
                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id)
                    //    .Where(b => b.Omraade == "smørum")
                    //    .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
            }
            if (Age == null)
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Sum).ToList();

                    //egedal = _egeContex.PrognoseHardcodet.OrderByDescending(c => c.Id).Where(b => b.Omraade == "alle")
                    //.Select(x => new { x.Alder0, x.Alder1, x.Alder02, x.Alder35, x.Alder616, x.Alder1724, x.Alder2564, x.Alder6574, x.Alder7584, x.Alder85, x.Id }).FirstOrDefault();
                    
                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Sum).ToList();                            

                    //egedal = _egeContex.PrognoseHardcodet
                    //.FromSqlRaw("select \"sum\" from \"flis\".\"PROGNOSE_hardcodet\" where omraade = 'alle' ").ToList();

                    //egedal = _egeContex.PrognoseHardcodet.Select(a => a.Alder02 + a.Alder35 + a.Alder616 + a.Alder1724 + a.Alder2564 + a.Alder6574 + a.Alder7584 + a.Alder85).Sum();

                    //egedal = _egeContex.PrognoseHardcodet.Select(b => new { b, Total = b.Alder02 + b.Alder35 + b.Alder616 + b.Alder1724 + b.Alder2564 + b.Alder6574 + b.Alder7584 + b.Alder85 })
                    //    .GroupBy(_egeContex.PrognoseHardcodet.).ToList();

                    //.GroupBy(b => b.Aarstal)
                    //.Select(g => new { Aarstal = g.Key, Total = g.Sum(i => i.Total) });

                }
                if (Area == "ølstykke")
                {
                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Sum).ToList();
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id)
                        .Where(b => b.Omraade == "ølstykke")
                        .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "stenløse")
                {
                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Sum).ToList();
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id)
                        .Where(b => b.Omraade == "stenløse")
                        .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "ganløse")
                {
                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Sum).ToList();
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id)
                        .Where(b => b.Omraade == "ganløse")
                        .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
                if (Area == "smørum")
                {
                    //egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Sum).ToList();
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id)
                        .Where(b => b.Omraade == "smørum")
                        .Select(a => new { a.Alder0, a.Alder1, a.Alder02, a.Alder35, a.Alder616, a.Alder1724, a.Alder2564, a.Alder6574, a.Alder7584, a.Alder85, a.Id }).FirstOrDefault();

                }
            }
            if (Age == "0")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder0).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder0).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder0).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder0).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder0).ToList();
                }

            }
            if (Age == "1")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder1).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder1).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder1).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder1).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder1).ToList();
                }
            }
            if (Age == "02")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder02).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder02).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder02).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder02).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder02).ToList();
                }
            }
            if (Age == "35")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder35).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder35).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder35).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder35).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder35).ToList();
                }
            }
            if (Age == "616")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder616).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder616).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder616).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder616).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder616).ToList();
                }
            }
            if (Age == "1724")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder1724).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder1724).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder1724).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder1724).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder1724).ToList();
                }
            }
            if (Age == "2564")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder2564).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder2564).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder2564).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder2564).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder2564).ToList();
                }
            }
            if (Age == "6574")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder6574).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder6574).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder6574).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder6574).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder6574).ToList();
                }
            }
            if (Age == "7584")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder7584).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder7584).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder7584).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder7584).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder7584).ToList();
                }
            }
            if (Age == "85")
            {
                if (Area == "alle")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "alle").Select(a => a.Alder85).ToList();

                }
                if (Area == "ølstykke")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ølstykke").Select(a => a.Alder85).ToList(); ;

                }
                if (Area == "stenløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "stenløse").Select(a => a.Alder85).ToList();

                }
                if (Area == "ganløse")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "ganløse").Select(a => a.Alder85).ToList();
                }
                if (Area == "smørum")
                {
                    egedal = _egeContex.PrognoseHardcodet.OrderBy(c => c.Id).Where(b => b.Omraade == "smørum").Select(a => a.Alder85).ToList();
                }
            }

            return Json(egedal);
         }



        public IActionResult GetAlleAldersGrupper(string Area)
        {
            dynamic data1 = null;
            if (Area == "alle")
            {

                data1 = _egeContex.CprPrognoseSamlet.OrderByDescending(a => a.AarMaaned)
                    .Select(x => new { x._0, x._1, x._02, x._35, x._616, x._1724, x._2564, x._6574, x._7584, x._85, x.AarMaaned }).FirstOrDefault();
                //data1 = (
                //    from p in _egeContex.CprPrognoseSamlet
                //    group p by p.AarMaaned into g
                //    select new
                //    {
                //        //PersonId = g.Key,
                //        egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                //    }
                //    ).ToList();

                //int totalPrice = TotalPrice.Sum();

                //using (var connection = new NpgsqlConnection("Host=10.192.144.48;Port=5432;Database=egedal; User Id=egedal;Password=GsYrICM4nA9j; "))
                //{
                //    string flis = "flis.\"CPR_Prognose_Samlet\"";
                //    string query = $"select sum('0_2' + '3_5' + '6_16' + '17_24' + '25_64' + '65_74' + '75_84' + '85_') from {flis} group by aar_maaned";
                //    //var res = connection.Execute(query);
                //    connection.Open();
                //    //connection.Execute("");
                //    egedal1 = connection.Query<string>(query).ToList();
                //}
            }
            else if(Area == "ølstykke")
            {
                data1 = (
                   from p in _egeContex.CprPrognoseSamlet1
                   group p by p.AarMaaned into g
                   select new
                   {
                       PersonId = g.Key,
                       egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                   }
                   ).ToList();
            }
            else if (Area == "stenløse")
            {
                data1 = (
                   from p in _egeContex.CprPrognoseSamlet2
                   group p by p.AarMaaned into g
                   select new
                   {
                       PersonId = g.Key,
                       egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                   }
                   ).ToList();
            }
            else if (Area == "ganløse")
            {
                data1 = (
                   from p in _egeContex.CprPrognoseSamlet3
                   group p by p.AarMaaned into g
                   select new
                   {
                       PersonId = g.Key,
                       egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                   }
                   ).ToList();
            }
            else if (Area == "smørum")
            {
                data1 = (
                   from p in _egeContex.CprPrognoseSamlet4
                   group p by p.AarMaaned into g
                   select new
                   {
                       PersonId = g.Key,
                       egedal = g.Sum(c => c._02 + c._35 + c._616 + c._1724 + c._2564 + c._6574 + c._7584 + c._85)
                   }
                   ).ToList();
            }
            
            return Json(data1);                  

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
