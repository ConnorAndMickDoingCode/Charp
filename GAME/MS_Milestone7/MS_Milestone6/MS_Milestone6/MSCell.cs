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
using System.Windows.Forms;

namespace MS_Milestone6
{

    /*
        This class is our minesweeper cell class that extends button.
        Inside of this class we have the following methods:
            MSCell()
            gameTicker_Tick()
            ButtonClick()
            CheckWinLoss()
            CheckWin()
    */
    public class MSCell : Button
    {
        Timer gameTimer;
        private PlayerStats ps = new PlayerStats();
        public static int CellWidth = 25;
        public static int CellHeight = 25;

        private bool flagged = false;
        private int row { get; set; }
        private int col { get; set; }

        /*
            MSCell()
            Constructor where all cell values are set
            makes a call to the ButtonClick method
        */
        public MSCell(int row, int col)
        {
            this.row = row;
            this.col = col;
            BackColor = System.Drawing.Color.Gray;
            Width = CellWidth;
            Height = CellHeight;


            MouseDown += new MouseEventHandler(ButtonClick);
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
        }

        /*
            gameTimer_Tick()
            method that counts the time for the game
        */
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameGrid.countTime++;
            GameGrid.lblTimer.Text = TimeSpan.FromSeconds(GameGrid.countTime).ToString();
        }

        /*
            ButtonClick()
            -method that decifers right and left clicks
            -first click starts the timer
            -right click drops flag

        */
        private void ButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GameGrid.firstClick)
                {
                    gameTimer.Start();
                    gameTimer.Tick += new EventHandler(gameTimer_Tick);
                }

                GameGrid.firstClick = false;

                if (flagged)
                {
                    return;
                }
                else
                {
                    BackColor = System.Drawing.Color.LightCoral;
                    Enabled = false;
                    GameGrid.ProcessCell(row, col, false);
                    CheckWinLoss();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (flagged)
                {
                    flagged = false;
                    this.BackgroundImage = null;
                    GameGrid.FlaggedCells--;
                    GameGrid.FlagsAvailable++;
                    GameGrid.lblFlag.Text = GameGrid.FlagsAvailable.ToString();
                }
                else
                {
                    if (GameGrid.FlaggedCells != Grid.LiveCells)
                    {
                        GameGrid.FlagsAvailable--;
                        GameGrid.lblFlag.Text = GameGrid.FlagsAvailable.ToString();
                        GameGrid.FlaggedCells++;
                        flagged = true;
                        BackgroundImage = Properties.Resources.Minesweeper2;
                    }
                    else
                    {
                        MessageBox.Show("You can't flag more then the amount of bombs you dingaling!");
                        return;
                    }
                }
            }
        }

        /*
            CheckWinLoss()
            -method that checks if the user won or lost
            -offers the choice to play again -> returns to main menu or exits
            -if the user won -> timer displays time and asks user if they want to play again

        */
        public void CheckWinLoss()
        {
            DialogResult result;
            if (GameGrid.Lose)
            {
                GameGrid.lblTimer.Hide();
                gameTimer.Stop();
                GameGrid.ShowBombs();
                result = MessageBox.Show("You've lost my dood, would you like to give it another go?", "Game Over! Ha loser", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }

            else if (CheckWin())
            {
                GameGrid.lblTimer.Hide();
                gameTimer.Stop();
                GameGrid.ShowBombs();

                if (MainMenu.gameDiff != "custom")
                {
                    GameGrid.endTime = GameGrid.countTime;
                    MessageBox.Show("WOW DUDE. YOU WON IN " + TimeSpan.FromSeconds(GameGrid.endTime));
                    ps.UpdateScores(MainMenu.gameDiff, GameGrid.endTime, MainMenu.Username);
                }

                else
                {
                    result = MessageBox.Show("Congrats you've won in " + TimeSpan.FromSeconds(GameGrid.countTime).ToString() +
                        ". Play again?", "You Won!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        /*
            CheckWin()
            -method is the actual logic for checking if the user won or not
            -checks the number of bombs, and the number of visited cells to decifer the win
        */
        public bool CheckWin()
        {
            int count = 0;
            int bombCount = 0;
            for (int i = 0; i < MainMenu.XLen; i++)
            {
                for (int j = 0; j < MainMenu.YLen; j++)
                {
                    if (Grid.theGrid[i, j].IsVisited)
                    {
                        count++;
                    }
                    if (Grid.theGrid[i, j].IsLive)
                    {
                        bombCount++;
                    }
                }
            }
            if (count == ((MainMenu.XLen * MainMenu.YLen) - bombCount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
