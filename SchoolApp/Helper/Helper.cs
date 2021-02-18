using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassApp.Helper
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Student = "Student";
        public static string Teacher = "Teacher";

        public static List<SelectListItem> GetRolesForDropdown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin, Text=Helper.Admin},
                new SelectListItem{Value=Helper.Student, Text=Helper.Student},
                new SelectListItem{Value=Helper.Teacher, Text=Helper.Teacher}
            };
        }
    }
}
