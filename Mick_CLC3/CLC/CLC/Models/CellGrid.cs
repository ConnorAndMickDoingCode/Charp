using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class CellGrid
    {
        public Cell[,] Cells { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool Win { get; set; } = false;
        public bool Lose { get; set; } = false;

        public CellGrid(int h, int w)
        {
            Cells = new Cell[h, w];
            Height = h;
            Width = w;
        }
    }
}