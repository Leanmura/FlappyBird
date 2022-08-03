using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;
        int levelUp = 5;

        public Form1()
        {
            InitializeComponent();
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score.ToString();

            if(pipeBottom.Left < -100)
            {
                pipeBottom.Left = 600;
                pipeTop.Left = 600;
                score++;

            }
            if(bird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                bird.Bounds.IntersectsWith(pipeTop.Bounds) || 
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top < -25)
            {
                endGame();
            }

            if(score > levelUp)
            {
                pipeSpeed += 2;
                levelUp += 5;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
        }
    }
}
