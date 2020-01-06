using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class StudentListModel : PageModel
    {
        public List<Student> Students { get; set; }
        public void OnGet()
        {
            using (OisContext ois = new OisContext())
            {
                Students = ois.Student.ToList<Student>();
            }
        }
        public void OnPostSearch()
        {
            using (OisContext ois = new OisContext())
            {
                Students = ois.Student.ToList<Student>();
            }
        }
    }
}