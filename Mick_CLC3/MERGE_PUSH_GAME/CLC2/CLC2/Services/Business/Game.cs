using CLC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC2.Services.Business
{
    public class Game
    {
        public Cell[,] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Mines { get; set; }
        public int Count { get; set; } = 0;
        public bool Lose { get; set; } = false;
        public bool Win { get; set; } = false;

        public Game(int w, int h, int m)
        {
            Width = w;
            Height = h;
            Mines = m;
            Init();
        }

        private void Init()
        {
        }

        public void Check(int x, int y)
        {
            // check cell
            var c = Cells[x, y];
            c.Checked = true;
            Count++;

            // reveal nearby, if necessary
            if (c.Adjacent == 0)
            {
                for (int relX = x - 1; relX <= x + 1; relX++)
                {
                    for (int relY = y - 1; relY <= y + 1; relY++)
                    {
                        if (inBounds(relX, relY) && !Cells[x, y].Checked)
                            Check(relX, relY);
                    }
                }
            }

            // check for lose
            Lose = c.Mine;

            // check for win
            Win = Count + Mines == (Height * Width);
        }

        public void Flag(int x, int y)
        {
            var c = Cells[x, y];
            c.Flagged = !c.Flagged;
        }

        private bool inBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Width && y < Height;
        }
    }
}