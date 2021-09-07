using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    public partial class Form1 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, redGhostSpeedX, redGhostSpeedY, yellowGhostSpeedX, yellowGhostSpeedY, pinkGhostSpeedX, pinkGhostSpeedY;

      
        public Form1()
        {
            InitializeComponent();

            resetGame();

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = true;
            if (e.KeyCode == Keys.Down)
                godown = true;
            if (e.KeyCode == Keys.Left)
                goleft = true;
            if (e.KeyCode == Keys.Right)
                goright = true;

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = false;
            if (e.KeyCode == Keys.Down)
                godown = false;
            if (e.KeyCode == Keys.Left)
                goleft = false;
            if (e.KeyCode == Keys.Right)
                goright = false;
            if (e.KeyCode == Keys.Enter && isGameOver == true)
                resetGame();
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            label1.Text = "Счёт: " + score;

            if (goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }

            if (goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }

            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }

            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }

            if (pacman.Left < -10)
                pacman.Left = 410;
            if (pacman.Left > 410)
                pacman.Left = -10;


            if (pacman.Top < -10)
                pacman.Top = 355;
            if (pacman.Top > 355)
                pacman.Top = 0;

            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "coin" && x.Visible == true)
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        x.Visible = false;
                    }
                if ((string)x.Tag == "Wall")
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver("Вы проиграли.");
                    }

                   // if (pinkghost.Bounds.IntersectsWith(x.Bounds))
                   //     pinkGhostSpeedX = -pinkGhostSpeedX;

                   // if (yellowghost.Bounds.IntersectsWith(x.Bounds))
                   //   yellowGhostSpeedX = -yellowGhostSpeedX;

                   // if (redghost.Bounds.IntersectsWith(x.Bounds))
                        //redGhostSpeedX = -redGhostSpeedX;
                }

                if ((string)x.Tag == "ghost")
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver("Вы проиграли.");
                    }
            }

            pinkghost.Left -= pinkGhostSpeedX;
            pinkghost.Top -= pinkGhostSpeedY;

            if (pinkghost.Top < 0 || pinkghost.Top > 320)
            {
                pinkGhostSpeedY = -pinkGhostSpeedY;
            }

            if (pinkghost.Left < 0 || pinkghost.Left > 400)
            {
                pinkGhostSpeedX = -pinkGhostSpeedX;
            }

            redghost.Left -= redGhostSpeedX;
            redghost.Top -= redGhostSpeedY;

            if (redghost.Top < 0 || redghost.Top > 320)
            {
                redGhostSpeedY = -redGhostSpeedY;
            }

            if (redghost.Left < 0 || redghost.Left > 400)
            {
                redGhostSpeedX = -redGhostSpeedX;
            }

            yellowghost.Left -= yellowGhostSpeedX;
            yellowghost.Top -= yellowGhostSpeedY;

            if (yellowghost.Top < 0 || yellowghost.Top > 320)
            {
                yellowGhostSpeedY = -yellowGhostSpeedY;
            }

            if (yellowghost.Left < 0 || yellowghost.Left > 400)
            {
                yellowGhostSpeedX = -yellowGhostSpeedX;
            }

            if (score == 129)
            {
                gameOver("Вы выиграли!");
            }

        }

        private void resetGame()
        {
            label1.Text = "Счёт: 0";
            score = 0;

            playerSpeed = 5;
            redGhostSpeedX = 3;
            redGhostSpeedY = 3;
            yellowGhostSpeedX = 3;
            yellowGhostSpeedY = 3;
            pinkGhostSpeedX = 3;
            pinkGhostSpeedY = 3;

            isGameOver = false;

            pacman.Left = 7;
            pacman.Top = 170;
            redghost.Left = 160;
            redghost.Top = 115;
            yellowghost.Left = 200;
            yellowghost.Top = 115;
            pinkghost.Left = 240;
            pinkghost.Top = 115;

            gameTimer.Start();

            foreach (Control x in this.Controls)
                if (x is PictureBox)
                {
                    x.Visible = true;
                }


        }

        private void gameOver(string message)
        {
            isGameOver = true;

            gameTimer.Stop();

            label1.Text += Environment.NewLine + message;


            

        }
    }
}
