using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.ViewModels
{
    public class BugEditVM : BugVM
    {
        [Display(Name = "Bug Image")]
        public IFormFile UploadedImage { get; set; }

        [Display(Name = "Delete Image")]
        public bool DeleteImage { get; set; }
    }
}
