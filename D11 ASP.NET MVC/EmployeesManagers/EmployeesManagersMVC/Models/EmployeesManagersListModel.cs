using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesManagersMVC.Models
{
    public class EmployeesManagersListModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Salary")]
        public double Salary { get; set; }

        [HiddenInput]
        public int ManagerId { get; set; }

        [Required]
        [Display(Name="Manager")]
        public string ManagerName { get; set; }
    }
}