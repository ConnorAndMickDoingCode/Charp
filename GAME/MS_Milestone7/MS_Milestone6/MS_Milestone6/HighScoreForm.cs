/*
    @author:        Mick Torres
    @course:        CST-227
    @assignment:    Milestone 7
    @date:          December 5th 2017
    @note:          This is my own work. However Kaleb and I have
                    worked on this project together throughout
                    the entire semester.

*/

using MySql.Data.MySqlClient;
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
    Here is the HighScoreForm that extends form.
    This class has the following methods:
        HighScoreForm()
        mainMenuBtn_Click()
        easyBtn_Click()
        medBtn_Click()
        hardBtn_Click()
        HighScoreForm_FormClosed()
    */
    public partial class HighScoreForm : Form
    {
        private PlayerStats ps;
        private MySqlDataReader dr;
        private DataTable dt;


        /*
        The HighScoreForm() displays the form itself and it is
        comprised of an instance of the PlayerStats class, a 
        data table that displays the high score information
        */
        public HighScoreForm(string diff)
        {
            InitializeComponent();
            this.Show();
            ps = new PlayerStats();
            dt = ps.ViewScores(diff);


            HSdatagv.DataSource = dt;  
        }

        /*
        If the main menu button is clicked > restarts application > returns to main menu
        */
        private void mainMenuBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /*
        if the easy button is clicked > displays top 5
        high scores, username, and place for the easy difficulty mode
        */
        private void easyBtn_Click(object sender, EventArgs e)
        {
            HSdatagv.Controls.Clear();
            DataTable dataTable = ps.ViewScores("easy");
            HSdatagv.DataSource = dataTable;
        }

        /*
        if the medium button is clicked > displays top 5
        high scores, username, and place for the medium difficulty mode
        */
        private void medBtn_Click(object sender, EventArgs e)
        {
            HSdatagv.Controls.Clear();
            DataTable dataTable = ps.ViewScores("medium");
            HSdatagv.DataSource = dataTable;
        }

        /*
        if the hard button is clicked > displays top 5
        high scores, username, and place for the hard difficulty mode
        */
        private void hardBtn_Click(object sender, EventArgs e)
        {
            HSdatagv.Controls.Clear();
            DataTable dataTable = ps.ViewScores("hard");
            HSdatagv.DataSource = dataTable;
        }

        /*
        if the form is closed the application closes.
        */
        private void HighScoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
