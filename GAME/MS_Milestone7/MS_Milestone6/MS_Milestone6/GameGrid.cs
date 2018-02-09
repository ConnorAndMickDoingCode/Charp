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
        This is our GameGrid class that extends form.
        Inside the class we have the following methods:
            GameGrid()
            fillArray()
            ProcessCell()
            ShowBombs()
            CheckInBounds()    
    */
    public partial class GameGrid : Form
    {

        private static MSCell[,] click;
        private static Cell temp;

        public static Label lblFlag;
        public static Label lblTimer;
        public static bool firstClick = true;
        public static bool Lose = false;

        public static int FlaggedCells = 0;
        public static int countTime = 0;
        public static int endTime = 0;

        public int hei, wid;
        public static int FlagsAvailable = Grid.LiveCells;

        public static Label Username;

        /*
            GameGrid()
            -Constructor that sets the height and width of the board
            based on user input
            -the values are then used to limit the array
        */
        public GameGrid(int hei, int wid)
        {
            InitializeComponent();
            this.hei = hei;
            this.wid = wid;
            click = new MSCell[this.hei, this.wid];

            this.Show();
            this.AutoSize = true;

            pnlMenu.AutoSize = true;
            pnlMenu.Width = wid * 25;

            pnlGame.AutoSize = true;
            fillArray();

            lblFlag = new Label();
            Image flag = Properties.Resources.Minesweeper2;
            lblFlag.Font = new Font("Microsoft Sans Serif", 10);
            lblFlag.Text = FlagsAvailable.ToString();
            lblFlag.Image = flag;
            lblFlag.ImageAlign = ContentAlignment.MiddleCenter;
            lblFlag.TextAlign = ContentAlignment.MiddleLeft;
            pnlMenu.Controls.Add(lblFlag);
            lblFlag.Location = new Point(0, 20);
            

            lblTimer = new Label();
            lblTimer.Font = new Font("Microsoft Sans Serif", 10);
            pnlMenu.Controls.Add(lblTimer);
            lblTimer.Location = new Point(170, 20);

            Username = new Label();
            Username.Font = new Font("Microsoft Sans Serif", 10);
            Username.Location = new Point(98, 20);
            Username.Text = MainMenu.Username;
            pnlMenu.Controls.Add(Username);

        }

        private void GameGrid_Load(object sender, EventArgs e)
        {

        }

        /*
            fillArray()
            -populates the board with buttons
        */
        private void fillArray()
        {
            for (int i = 0; i < this.hei; i++)
            {
                for (int j = 0; j < this.wid; j++)
                {
                    click[i, j] = new MSCell(i, j);
                    click[i, j].Location = new System.Drawing.Point(i * MSCell.CellHeight, j * MSCell.CellWidth);
                    pnlGame.Controls.Add(click[i, j]);
                }
            }
        }

        /*
            ProcessCell()
            -this method was taken from the console file Minesweeper game
            that was deleted
            -this is the main game logic where the recusion occurs
            -user cant die on the first move lol
            -liveNeighbors are in a blue color, non active cells are green yellow

        */
        public static void ProcessCell(int x, int y, bool firstIteration)
        {
            if (CheckInbounds(x, y))
            {
                temp = Grid.getCell(x, y);
                if (temp.IsLive == true)
                {
                    Lose = true;
                    click[x, y].BackgroundImage = Properties.Resources.Bomb;
                    click[x, y].Enabled = false;
                    return;
                }
                else if (temp.LiveNeighbors != 0)
                {
                    temp.IsVisited = true;
                    click[x, y].Text = temp.LiveNeighbors.ToString();
                    click[x, y].BackColor = System.Drawing.Color.CadetBlue;
                    click[x, y].Enabled = false;
                }
                else
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (CheckInbounds(x + i, y + j) && !temp.IsVisited)
                            {
                                click[x, y].BackColor = System.Drawing.Color.GreenYellow;
                                click[x, y].Enabled = false;
                                temp.IsVisited = true;
                                ProcessCell(x - 1, y, true);
                                ProcessCell(x + 1, y, true);
                                ProcessCell(x, y - 1, true);
                                ProcessCell(x, y + 1, true);
                                ProcessCell(x + 1, y + 1, true);
                                ProcessCell(x - 1, y - 1, true);
                                ProcessCell(x + 1, y - 1, true);
                                ProcessCell(x - 1, y + 1, true);
                            }
                        }
                    }
                }
            }
        }

        /*
            ShowBombs()
            -This method shows the bombs
            and it is called when the user either
            wins or loses  
        */
        public static void ShowBombs()
        {
            for (int i = 0; i < MainMenu.XLen; i++)
            {
                for (int j = 0; j < MainMenu.YLen; j++)
                {
                    temp = Grid.getCell(i, j);
                    if (temp.IsLive)
                    {
                        click[i, j].BackgroundImage = Properties.Resources.Bomb;
                    }
                }
            }
        }

        /*
            CheckInBounds()
            -this method makes sure the inputs are in bounds
        */
        public static bool CheckInbounds(int x, int y)
        {
            return x >= 0 && x < MainMenu.XLen && y >= 0 && y < MainMenu.XLen && x < MainMenu.YLen && y < MainMenu.YLen;
        }

        
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
