using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly MemberDetailsContext _db;

        public ResultsModel(MemberDetailsContext db)
        {
            _db = db;
        }


        public void OnGet()
        {


            //var list =_db.SurfReport
            //    .Where(x => x.Wind.Speed <= _)
            //    .
        }
    }
}