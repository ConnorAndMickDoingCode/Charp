using System;
using CLC.Models;
using CLC.Services.Business;

namespace CLC.Services.Engine
{
    public class Game
    {
        public CellGrid Grid { get; set; }
        

        public Game(int w, int h, int m)
        {
            Grid = new CellGrid(h, w, m);

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
            for (int m = 0; m < Grid.Mines; m++)
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

            Grid.Started = true;
        }

        public void Check(int x, int y)
        {
            // check cell
            var c = Grid.Cells[x, y];
            c.Checked = true;
            Grid.Count++;

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
            Grid.Win = Grid.Count + Grid.Mines == (Grid.Height * Grid.Width);
        }

        public void UpdateState(string cell, string time)
        {
            // parse request string
            var c = cell.Split(',');
            var x = int.Parse(c[0]);
            var y = int.Parse(c[1]);

            // check if initialized (prevent instant-deaths)
            if (!Grid.Started)
                InitCells(x, y);

            // update game board
            Check(x, y);

            // update time and click stats
            Grid.Time = int.Parse(time);
            Grid.Moves++;
        }

        public void EndGame(User user)
        {
            // remove save game from database
            var service = new GameStateService();
            service.DeleteGame(Grid.Id);

            // if win: add to leaderboard
            if (Grid.Win)
            {
                try
                {
                    // pass user and game grid to create the game stat object in service
                    var leaderboardService = new LeaderboardService();
                    leaderboardService.record(user, Grid);
                }
                catch (Exception e)
                {
                    // TODO: make better
                    Console.WriteLine(e);
                    throw;
                }
            }
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