using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriNguyen.AtmSimulation.Web.ApiModels
{
    public class LoginModel
    {
        [Required, DataType(DataType.Password), Display(Name = "PinNumber")]
        public string PinNumber { get; set; }
        //[HiddenInput]
        //public string ReturnUrl { get; set; }
    }
}
