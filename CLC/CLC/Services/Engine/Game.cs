using System;
using CLC.Models;

namespace CLC.Services.Engine
{
    public class Game
    {
        public CellGrid Grid { get; set; }
        public int Mines { get; set; }
        public int Count { get; set; } = 0;
        public bool Started { get; set; } = false;

        public Game(int w, int h, int m)
        {
            Mines = m;
            Grid = new CellGrid(h, w);

            // initialize cells
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Grid.Cells[x, y] = new Cell(x, y);
                }
            }
        }

        public void InitCells(int fX, int fY)
        {
            int w = Grid.Width;
            int h = Grid.Height;

            // set mines
            var ran = new Random();
            for (int m = 0; m < Mines; m++)
            {
                var x = ran.Next(w);
                var y = ran.Next(h);
                if (Grid.Cells[x, y].Mine || (x == fX && y == fY))
                    m--;
                else
                {
                    Grid.Cells[x, y].Mine = true;
                    for (int rx = x - 1; rx < x + 2; rx++)
                    {
                        for (int ry = y - 1; ry < y + 2; ry++)
                        {
                            if (inBounds(rx, ry))
                                Grid.Cells[rx, ry].Adjacent++;
                        }
                    }
                }
            }
            Started = true;
        }

        public void Check(int x, int y)
        {
            // check cell
            var c = Grid.Cells[x, y];
            c.Checked = true;
            Count++;

            // reveal nearby, if necessary
            if (c.Adjacent == 0)
            {
                for (int relX = x - 1; relX <= x + 1; relX++)
                {
                    for (int relY = y - 1; relY <= y + 1; relY++)
                    {
                        if (inBounds(relX, relY) && !Grid.Cells[relX, relY].Checked)
                            Check(relX, relY);
                    }
                }
            }

            // check for Lose
            Grid.Lose = c.Mine;

            // check for Win
            Grid.Win = Count + Mines == (Grid.Height * Grid.Width);
        }

        public void Flag(int x, int y)
        {
            var c = Grid.Cells[x, y];
            c.Flagged = !c.Flagged;
        }

        private bool inBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Grid.Width && y < Grid.Height;
        }
    }
}