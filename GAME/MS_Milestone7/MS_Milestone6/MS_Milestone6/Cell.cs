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
        This is our Cell class from our old console application.
        It has one method and a few properties.
    */
    public class Cell
    {
        /*
            -default values to the cell are set
            -setters and getters are available for value change 
        */
        public Cell()
        {
            this.Row = -1;
            this.Col = -1;
            this.LiveNeighbors = 0;
            this.IsLive = false;
            this.IsVisited = false;
        }

        public int Row { set; get; }

        public int Col { set; get; }

        public int LiveNeighbors { set; get; }

        public bool IsLive { set; get; }

        public bool IsVisited { set; get; }
    }
}

