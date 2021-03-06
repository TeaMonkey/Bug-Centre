using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.ViewModels
{
    public class BugCreateVM : BugVM
    {
        [Required, Display(Name = "Bug Image")]
        public IFormFile UploadedImage { get; set; }
    }
}
