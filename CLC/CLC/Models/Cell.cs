using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class Cell
    {
        public bool Mine { set; get; }
        public bool Flagged { get; set; } = false;
        public bool Checked { set; get; } = false;
        public int Adjacent { get; set; } = 0;

        public Cell(bool isLive)
        {
            Mine = isLive;
        }
    }
}