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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Milestone6
{
    /*
        This is out MainMenu class that extends form.
        Inside we have the following methods:
            MainMenu()
            btnStart_Click()

    */
    public partial class MainMenu : Form
    {

        Grid grid;
        GameGrid diff;
        public static int XLen, YLen;
        public static string gameDiff;
        public static string Username;


        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        /*
            btnStart_Click()
            -this method decides what size the GameGrid based
            on user input
            -using radio buttons for each size -> easy, medium, hard, custom
            -the main menu will Hide() and the gamegrid will appear
        */
        private void btnStart_Click(object sender, EventArgs e)
        {

            grid = null;
            Username = tbPlayer.Text;
            if (Username.Length > 0)
            {


                if (radEasy.Checked)
                {
                    XLen = 10;
                    YLen = 10;
                    Hide();
                    gameDiff = "easy";
                    grid = new Grid(10, 10);
                    diff = new GameGrid(10, 10);
                }

                else if (radMed.Checked)
                {
                    XLen = 15;
                    YLen = 15;
                    Hide();
                    gameDiff = "medium";
                    grid = new Grid(15, 15);
                    GameGrid med = new GameGrid(15, 15);
                }

                else if (radHard.Checked)
                {
                    XLen = 20;
                    YLen = 20;
                    Hide();
                    gameDiff = "hard";
                    grid = new Grid(20, 20);
                    diff = new GameGrid(20, 20);
                }

                else if (radCustom.Checked)
                {
                    int x, y;
                    gameDiff = "custom";

                    if (int.TryParse(tbCol.Text, out x) && int.TryParse(tbRow.Text, out y))
                    {

                        if (x < 31 && y < 31 && x > 0 && y > 0)
                        {
                            XLen = x;
                            YLen = y;
                            Hide();
                            grid = new Grid(x, y);
                            diff = new GameGrid(x, y);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Error: You need to enter a name to play!");
            }
        }


        private void HSBtn_Click(object sender, EventArgs e)
        {
            Hide();
            HighScoreForm hs = new HighScoreForm("all");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
