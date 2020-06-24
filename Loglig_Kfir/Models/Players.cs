using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Loglig_Kfir.Models
{
    public class Players
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "First name cannot be empty.")]
        //[StringLength(20, ErrorMessage = "The maximum character size for First name is 20.")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Last name cannot be empty.")]
        //[StringLength(20, ErrorMessage = "The maximum character size for Last name is 20.")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Course name cannot be empty.")]
        //[StringLength(30, ErrorMessage = "The maximum character size for the Email is 30")]
        public string Email { get; set; }
    }
}