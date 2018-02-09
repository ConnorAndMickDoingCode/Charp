/*
    @author:        Mick Torres
    @course:        CST-227
    @assignment:    Milestone 7
    @date:          December 5th 2017
    @note:          This is my own work. However Kaleb and I have
                    worked on this project together throughout
                    the entire semester.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Milestone6
{
    /*
        This is out Grid class from our old console project.
        It focuses everything grid related.
        Includes the following methods:
            Grid()
            CreateCells()
            isActive()
            CountNeighbors()
            getCell()
    */
    public class Grid
    {
        public int Height { set; get; }

        public int Width { set; get; }

        private int count;

        public static Random Rnd = new Random();

        public static int LiveCells;

        public static Cell[,] theGrid;

        /*
            Grid()
            Constructor that assigns the width and height
            as x and y accordingly
        */
        public Grid(int x, int y)
        {
            this.Width = x;
            this.Height = y;
            theGrid = new Cell[x, y];
            CreateCells();
        }

        /*
            CreateCells()
            -the method creates each cell
            -declares whether it is a bomb or not by calling IsActive()
            -makes a call to CountNeighbors for each cell

        */
        public void CreateCells()
        {
            LiveCells = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    theGrid[i, j] = new Cell();
                    theGrid[i, j].Row = i;
                    theGrid[i, j].Col = j;
                    if (IsActive() == true)
                    {
                        LiveCells++;
                        theGrid[i, j].IsLive = true;
                    }
                }
            }
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    CountNeighbors(x, y);
                }
            }
        }

        /*
            IsActive()
            -this method returns 15%
            -which is called for declaring bombs in the CreateCells() method
        */
        public bool IsActive()
        {
            int rNum = Rnd.Next(1, 20);
            if (rNum <= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
            CreateCells()
            -this method will execute if the cell is not live
            -checks the 8 surrounding neigbors and increments count
            -checks to make sure the neighbors are within the array
        */
        public void CountNeighbors(int x, int y)
        {
            count = 0;


            if (theGrid[x, y].IsLive == false)
            {

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {

                        if (x + i >= 0 && x + i < Height && y + j >= 0 && y + j < Height && x + i < Width && y + j < Width)
                        {
                            if (theGrid[x + i, y + j].IsLive == true)
                            {
                                count++;
                            }
                        }
                    }
                }
                theGrid[x, y].LiveNeighbors = count;
            }
            else
            {
                theGrid[x, y].LiveNeighbors = 9;
            }
        }

        /*
            getCell()
            -this method just gets the cell by position (row, col)
        */
        public static Cell getCell(int row, int col)
        {
            return theGrid[row, col];
        }

    }
}
