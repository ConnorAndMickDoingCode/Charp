using System;
using System.Security.Cryptography.X509Certificates;
using CLC.Models;

namespace CLC.Services.Business
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
            Cells = new Cell[w, h];
            Init();
        }

        private void Init()
        {
            // initialize cells
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y] = new Cell(x, y);
                }
            }

            // set mines
            var ran = new Random();
            for (int m = 0; m < Mines; m++)
            {
                var x = ran.Next(Width);
                var y = ran.Next(Height);
                Cells[x, y].Mine = true;
                for (int rx = x - 1; rx < x + 2; rx++)
                {
                    for (int ry = y - 1; ry < y + 2; ry++)
                        if (inBounds(rx, ry))
                            Cells[rx, ry].Adjacent++;
                }
            }
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
                        if (inBounds(relX, relY) && !Cells[relX, relY].Checked)
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