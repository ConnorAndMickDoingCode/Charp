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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Milestone6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        /*
            BEHOLD..THE PROGRAM..WHICH RUNS MY STUFF..YEAHHHHHH..
        */
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
