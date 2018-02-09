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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Milestone6
{
    /*
    This is my PlayerStats class that implements IComparable.
    To be honest I don't know how to implement it or what it does.
    The main logic is within the methods. With that said the
    class contains the following methods:
        ViewScores()
        UpdateScores()
        CompareTo()
    */
    class PlayerStats : IComparable
    {
        public static string connString = "server=localhost;database=minesweeper;uid=root;pwd=;";
        private MySqlConnection conn = new MySqlConnection(connString);
        private MySqlConnection conn2 = new MySqlConnection(connString);
        private MySqlCommand command, commandUp, commandDel, commandIn;
        private string sql, sqlUp, sqlDel, sqlIn;
        private MySqlDataReader dataReader, dataReaderUp, dataReaderDel, dataReaderIn;
        public String playerName;
        public String diffLevel;
        public String score;

        /*
        This method is a DataTable named ViewScores that takes
        in a string which is the difficulty level.
        It is a try / catch statement that throws a MySqlException
        if it does not connect. However if it does, it opens the
        connection > displays the user, time, and place depending 
        on the difficulty in a data table.

        */
        public DataTable ViewScores(string difficulty)
        {
            try
            {
                conn.Open();
                if(difficulty == "all")
                {
                    sql = "SELECT USERNAME, DIFFICULTY, TIME, PLACE FROM user ORDER BY DIFFICULTY, PLACE";
                }
                else
                {
                    sql = "SELECT USERNAME, TIME, PLACE FROM user WHERE DIFFICULTY='" + difficulty + "' ORDER BY PLACE" ;
                }

                command = new MySqlCommand(sql, conn);
                dataReader = command.ExecuteReader();

                DataTable hst = new DataTable();
                hst.Load(dataReader);
                conn.Close();
                return hst;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e.ToString());
                return null;
            }
        }

        /*
        This is the UpdateScores method that takes in a string for difficulty,
        double for time, and string for the username. inside is a try / catch
        statement that reads an error if it fails but if it works:
        opens connection > sql statments inserts information depending on the 
        difficulty > limits the high score to display top 5 of the leader boards
        */
        public void UpdateScores(string diff, double time, string user)
        {
            try
            {
                conn.Open();

                sql = "SELECT * FROM user WHERE DIFFICULTY='" + diff + "' ORDER BY PLACE";
                command = new MySqlCommand(sql, conn);
                dataReader = command.ExecuteReader();

                int temp = 0;
                int visitNum = 0;
                while(dataReader.Read())
                {
                    double prevTime = TimeSpan.Parse(dataReader["TIME"].ToString()).TotalSeconds;

                    if((prevTime > time) && (visitNum == 0))
                    {
                        temp = (int)dataReader["PLACE"];
                        conn2.Open();
                        TimeSpan ts = TimeSpan.FromSeconds(time);

                        sqlIn = "INSERT INTO user (USERNAME, TIME, PLACE, DIFFICULTY) VALUES('" + user + "', '" + ts + "', '" + temp + "', '" + diff + "')";
                        commandIn = new MySqlCommand(sqlIn, conn2);
                        dataReaderIn = commandIn.ExecuteReader();

                        visitNum++;
                        conn2.Close();
                    }
                    if(temp >=(int)dataReader["PLACE"])
                    {
                        conn2.Open();
                        sqlUp = "UPDATE user SET PLACE='" + ((int)dataReader["PLACE"] + 1) + "'WHERE ID='" + dataReader["ID"] + "'";
                        commandUp = new MySqlCommand(sqlUp, conn2);
                        dataReaderUp = commandUp.ExecuteReader();
                        temp++;
                        conn2.Close();
                    }
                    conn2.Open();
                    sqlDel = "DELETE FROM user WHERE PLACE='" + 6 + "'";
                    commandDel = new MySqlCommand(sqlDel, conn2);
                    dataReaderDel = commandDel.ExecuteReader();
                    conn2.Close();
                }
                conn.Close();
                HighScoreForm hf = new HighScoreForm(MainMenu.gameDiff);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
        }

        /*
        Like I said above, I am not sure how to use this since all the logic 
        is above in the other methods for updating scores and displaying them.
        */
        public int CompareTo(object obj)
        {
            conn.Open();
            sql = "SELECT * FROM user";
            command = new MySqlCommand(sql, conn);
            dataReader = command.ExecuteReader();

            double oldTime = TimeSpan.Parse(dataReader["TIME"].ToString()).TotalSeconds;
            if(oldTime <= (double)obj)
            {
                MessageBox.Show("New highscore!");
                return 1;
            }else
            {
                return 0; 
            }


            throw new NotImplementedException();
        }

    }
}
