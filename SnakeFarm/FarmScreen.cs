using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static int counter = 0;

        public FarmScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            width = this.Width;
            height = this.Height;

            farmer = new Player(100, 100);
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

            canRandomize = false;
            Refresh();
        }
            private void FarmScreen_Paint(object sender, PaintEventArgs e)
            {
            e.Graphics.FillRectangle(redBrush, farmer.rect.X, farmer.rect.Y, farmer.rect.Width, farmer.rect.Height);  
            e.Graphics.FillRectangle(greenBrush, farmer.x, farmer.y, farmer.width, farmer.height);
            for (int i = 1; i < snake.gorgPoints.Count; i++)
            {
                e.Graphics.DrawLine(orangePen, snake.gorgPoints[i], snake.gorgPoints[i - 1]);
            }
            e.Graphics.FillRectangle(redBrush, snake.x, snake.y, snake.width, snake.height);
            }
            
    }
}