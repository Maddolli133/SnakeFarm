using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeFarm
{
    internal class Player
    {
        public int x, y;
        public int width = 30;
        public int height = 10;
        public int speed = 6;
        public int health = 3;
        public int strength = 1;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= speed;

                if (y < 0)
                {
                    y = 0;
                }
            }
            else if (direction == "down")
            {
                y += speed;

                if (y > FarmScreen.height - height)
                {
                    y = FarmScreen.height - height;
                }
            }
            else if (direction == "left")
            {
                x -= speed;

                if (x < 0)
                {
                    x = 0;
                }
            }
            else
            {
                x += speed;

                if (x > FarmScreen.width - width)
                {
                    x = FarmScreen.width - width;
                }
            }
        }

        //public bool Collision(SnakeType.Snake snake)
        //{
        //    Rectangle playerRec = new Rectangle(x, y, width, height);
        //    Rectangle ballRec = new Rectangle(snake.x, snake.y, snake.size, snake.size);

        //    if (Player.IntersectsWith(snake))
        //    {

        //    }

        //    return false;
        //}
    }
}
