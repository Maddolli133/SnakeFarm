using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SnakeFarm
{
    public partial class FarmScreen : UserControl
    {
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Pen orangePen = new Pen(Color.Orange, 15);

        public static int width, height;

        bool aKeyDown, dKeyDown, wKeyDown, sKeyDown, spaceKeyDown;
                   
        public static Player farmer;

        public static int countdown = 5;
        public static bool canRandomize = false;

        List<SnakeType> snaketype = new List<SnakeType>();
        SnakeType snake = new SnakeType("Gorgenschleimer");

        public static System.Windows.Media.MediaPlayer backSound = new System.Windows.Media.MediaPlayer();

        public static int counter = 0;

        public FarmScreen()
        {
            InitializeComponent();
            InitializeGame();
            backSound.Open(new Uri(Application.StartupPath + "\\Resources\\the-epicmusic.wav"));
            backSound.MediaEnded += new EventHandler(backSoundEnded);
            backSound.Play();
        }

        private void backSoundEnded(object sender, EventArgs e)
        {
            backSound.Stop();
            backSound.Play();
        }
        public void InitializeGame()
        {
            width = this.Width;
            height = this.Height;

            farmer = new Player(100, 100);
            //if ()
            snaketype.Add (snake); 
        }
        private void FarmScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;

            }
        }
        private void FarmScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move all the enemy 
            countdown--;
            if (countdown == 0)
            {
                canRandomize = true;
            }
            foreach (SnakeType enemy in snaketype)
            {
                enemy.Move();
            }

            //move the player
            if (wKeyDown)
            {
                farmer.Move("up");
            }

            if (sKeyDown)
            {
                farmer.Move("down");
            }

            if (dKeyDown)
            {
                farmer.Move("right");
            }

            if (aKeyDown)
            {
                farmer.Move("left");
            }
            // Player attack
            if (spaceKeyDown)
            {
                farmer.Attack(snake);
            }
            if (snake.health <= 0)
            {
                snake.gorgPoints.Clear();
                snake.x = -2000;
                snake.y = -2000;

            }
            if (snake.x <= -2000 /*&&*/)
            {
                gameTimer.Enabled = false;
                Form f = this.FindForm();
                f.Controls.Remove(this);

                ShopScreen ss = new ShopScreen();
                f.Controls.Add(ss);
            }
            canRandomize = false;

            Collision(snake);
            Refresh();

        }
        public bool Collision(SnakeType snake)
        {
            foreach (PointF p in snake.gorgPoints)
            {
                if (farmer.prect.Contains(new Point(Convert.ToInt32(p.X), Convert.ToInt32(p.Y))))
                {
                    farmer.health--;
                    if (farmer.health == 0)
                    {
                        gameTimer.Enabled = false;
                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        ShopScreen ss = new ShopScreen();
                        f.Controls.Add(ss);
                    }
                }
            }
            return false;
        }
        private void FarmScreen_Paint(object sender, PaintEventArgs e)
            {
            if (wKeyDown)
            {
                e.Graphics.DrawImage(Properties.Resources.w, farmer.x, farmer.y, farmer.width, farmer.height);
            }
            else if (sKeyDown)
            {
                e.Graphics.DrawImage(Properties.Resources.s, farmer.x, farmer.y, farmer.width, farmer.height);
            }
            else if (dKeyDown)
            {
                e.Graphics.DrawImage(Properties.Resources.d, farmer.x, farmer.y, farmer.width, farmer.height);
            }
            else if (aKeyDown)
            {
                e.Graphics.DrawImage(Properties.Resources.a, farmer.x, farmer.y, farmer.width, farmer.height);
            }
            else
            {
                e.Graphics.DrawImage(Properties.Resources.s, farmer.x, farmer.y, farmer.width, farmer.height);
            }
            e.Graphics.FillRectangle(redBrush, farmer.rect.X, farmer.rect.Y, farmer.rect.Width, farmer.rect.Height);
            
            for (int i = 1; i < snake.gorgPoints.Count; i++)
            {
                e.Graphics.DrawLine(orangePen, snake.gorgPoints[i], snake.gorgPoints[i - 1]);
            }
            e.Graphics.FillRectangle(redBrush, snake.x, snake.y, snake.width, snake.height);
            }
            
    }
}