using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz1.Models
{
    public class CalculatorModel
    {
        [Required]
        [DisplayName("Left value")]
        [DefaultValue("")]
        public double Left { get; set; }

        [Required]
        [DisplayName("Right value")]
        [DefaultValue("")]
        public double Right { get; set; }

        [Required]
        [DisplayName("Operation")]
        [DefaultValue("")]
        public string Action { get; set; }

        [Required]
        [DisplayName("Result")]
        [DefaultValue("")]
        public double Result { get; set; }
    }
}