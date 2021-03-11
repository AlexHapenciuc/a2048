using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace a2048
{
    public partial class MyWForm : Form
    {
        int[,] m = new int[4, 4];
        int col, lin;
        

        public MyWForm()
        {
            InitializeComponent();

            NewBoard();
            UpdateTilesValue();
            UpdateTilesType();
        }

        public void NewBoard()
        {
            for (lin = 0; lin < 4; lin++)
                for (col = 0; col < 4; col++)
                    m[lin, col] = 0;
            AddTile();
            AddTile();
        }
        
        public void UpdateTilesValue()
        {
            tile1.Text = "" + m[0,0];   tile2.Text = "" + m[0,1];   tile3.Text = "" + m[0,2];   tile4.Text = "" + m[0,3];
            tile5.Text = "" + m[1,0];   tile6.Text = "" + m[1,1];   tile7.Text = "" + m[1,2];   tile8.Text = "" + m[1,3];
            tile9.Text = "" + m[2,0];   tile10.Text = "" + m[2,1];  tile11.Text = "" + m[2,2];  tile12.Text = "" + m[2,3];
            tile13.Text = "" + m[3,0];  tile14.Text = "" + m[3,1];  tile15.Text = "" + m[3,2];  tile16.Text = "" + m[3,3];
        }

        public void UpdateTilesType()
        {
            int temp, count;

            foreach (Control x in this.Controls)
                if (x is Button && x.Text != "High Scores" && x.Text != "New Game")
                {
                    count = 0;

                    if (x.Text != "0")
                        temp = Int32.Parse(x.Text);
                    else temp = 1;

                    while (temp > 1)
                    {
                        temp = temp / 2;
                        count++;
                    }
                    switch (count)
                    {
                        case 0:
                            x.BackgroundImage = Properties.Resources.tile0;
                            break;
                        case 1:
                            x.BackgroundImage = Properties.Resources.tile1;
                            break;
                        case 2:
                            x.BackgroundImage = Properties.Resources.tile2;
                            break;
                        case 3:
                            x.BackgroundImage = Properties.Resources.tile3;
                            break;
                        case 4:
                            x.BackgroundImage = Properties.Resources.tile4;
                            break;
                        case 5:
                            x.BackgroundImage = Properties.Resources.tile5;
                            break;
                        case 6:
                            x.BackgroundImage = Properties.Resources.tile6;
                            break;
                        case 7:
                            x.BackgroundImage = Properties.Resources.tile7;
                            break;
                        case 8:
                            x.BackgroundImage = Properties.Resources.tile8;
                            break;
                        case 9:
                            x.BackgroundImage = Properties.Resources.tile9;
                            break;
                        case 10:
                            x.BackgroundImage = Properties.Resources.tile10;
                            break;
                        case 11:
                            x.BackgroundImage = Properties.Resources.tile11;
                            break;
                        case 12:
                            x.BackgroundImage = Properties.Resources.tile12;
                            break;
                        default:
                            x.BackgroundImage = Properties.Resources.tile1;//errortile
                            break;
                    }
                } 
        }

        public void AddTile()
        {
            Random rnd = new Random();
            int rndLin, rndCol, rndVal;

            rndLin = rnd.Next(4);
            rndCol = rnd.Next(4);
            rndVal = rnd.Next(30);

            while (m[rndLin, rndCol] != 0)
            {
                rndLin = rnd.Next(4);
                rndCol = rnd.Next(4);
            }

            if (rndVal > 20)
                m[rndLin, rndCol] = 4;
            else
                m[rndLin, rndCol] = 2;
        }

        public void MoveTilesUp()
        {
            int xlin;

            for (col = 0; col < 4; col++)
            {
                xlin = 0;

                for (lin = 1; lin < 4; lin++)
                {
                    if (m[lin, col] != 0)
                    {
                        if (m[lin, col] == m[xlin, col])
                        {
                            m[xlin, col] = m[xlin, col] * 2;
                            m[lin, col] = 0;
                        }
                        else if (m[xlin, col] == 0)
                        {
                            m[xlin, col] = m[lin, col];
                            m[lin, col] = 0;
                            xlin--;
                        }
                        else if (lin - xlin > 1)
                        {
                            m[xlin + 1, col] = m[lin, col];
                            m[lin, col] = 0;
                        }
                        xlin++;
                    }
                }
            }
        }

        public void MoveTilesLeft()
        {
            int xcol;
            for (lin = 0; lin < 4; lin++)
            {
                xcol = 0;
                for (col = 1; col < 4; col++)
                {
                    if (m[lin, col] != 0)
                    {
                        if (m[lin, col] == m[lin, xcol])
                        {
                            m[lin, xcol] = m[lin, xcol] * 2;
                            m[lin, col] = 0;
                        }
                        else if (m[lin, xcol] == 0)
                        {
                            m[lin, xcol] = m[lin, col];
                            m[lin, col] = 0;
                            xcol--;
                        }
                        else if (col - xcol > 1)
                        {
                            m[lin, xcol + 1] = m[lin, col];
                            m[lin, col] = 0;
                        }
                        xcol++;
                    }
                }
            }
        }

        public void MoveTilesRight()
        {
            int xcol;
            for (int lin = 0; lin < 4; lin++)
            {
                xcol = 3;
                for (int col = 2; col >= 0; col--)
                {
                    if (m[lin, col] != 0)
                    {
                        if (m[lin, col] == m[lin, xcol])
                        {
                            m[lin, xcol] = m[lin, xcol] * 2;
                            m[lin, col] = 0;

                        }
                        else if (m[lin, xcol] == 0)
                        {
                            m[lin, xcol] = m[lin, col];
                            m[lin, col] = 0;
                            xcol++;
                        }
                        else if (xcol - col > 1)
                        {
                            m[lin, xcol - 1] = m[lin, col];
                            m[lin, col] = 0;
                        }
                        xcol--;
                    }
                }
            }
        }

        public void MoveTilesDown()
        {
            int xlin;

            for (int col = 0; col < 4; col++)
            {
                xlin = 3;
                for (int lin = 2; lin >= 0; lin--)
                {
                    if (m[lin, col] != 0)
                    {
                        if (m[lin, col] == m[xlin, col])
                        {
                            m[xlin, col] = m[xlin, col] * 2;
                            m[lin, col] = 0;

                        }
                        else if (m[xlin, col] == 0)
                        {
                            m[xlin, col] = m[lin, col];
                            m[lin, col] = 0;
                            xlin++;
                        }
                        else if (xlin - lin > 1)
                        {
                            m[xlin - 1, col] = m[lin, col];
                            m[lin, col] = 0;
                        }
                        xlin--;
                    }
                }
            }
        }

        private void NewGame_MouseClick(object sender, MouseEventArgs e)
        {
            NewBoard();
            UpdateTilesValue();
            UpdateTilesType();
        }

        private void MyWForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) MoveTilesLeft();
            if (e.KeyCode == Keys.Right) MoveTilesRight();
            if (e.KeyCode == Keys.Down) MoveTilesDown();
            if (e.KeyCode == Keys.Up) MoveTilesUp();

            if (e.KeyCode == Keys.Escape) Application.Exit();

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                AddTile();
                UpdateTilesValue();
                UpdateTilesType();
            }
        }
    }
}
