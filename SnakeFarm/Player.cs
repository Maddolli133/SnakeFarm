using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeFarm
{
    public class Player
    {
        public int x, y;
        public int width = 30;
        public int height = 30;
        public int speed = 6;
        public int health = 3;
        public int strength = 1;

        public bool sword;

        string direction;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Rectangle rect = new Rectangle(0, 0, 30, 30);

        public void Move(string direction)
        {
            this.direction = direction;
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
        private void startPowers()
        {
            if (sword == true)
            {

            }
        }
        public void Attack(SnakeType target)
        {
            if (direction == "up")
            {
                rect.X = x;
                rect.Y = y - 30;
                foreach (PointF p in target.gorgPoints)
                {
                    Point temp = new Point((int)p.X, (int)p.Y);

                    if (rect.Contains(temp))
                    {
                          target.health -= strength;
                        break;
                    }
                }
            }
            else if (direction == "down")
            {
                rect.X = x;
                rect.Y = y + 30;
                foreach (PointF p in target.gorgPoints)
                {
                    Point temp = new Point((int)p.X, (int)p.Y);

                    if (rect.Contains(temp))
                    {
                        target.health -= strength;
                        break;
                    }
                }
            }
            else if (direction == "right")
            {
                rect.X = x + 30;
                rect.Y = y;
                foreach (PointF p in target.gorgPoints)
                {
                    Point temp = new Point((int)p.X, (int)p.Y);

                    if (rect.Contains(temp))
                    {
                        target.health -= strength;
                        break;
                    }
                }
            }
            else if (direction == "left")
            {
                rect.X = x - 30;
                rect.Y = y;
                foreach (PointF p in target.gorgPoints)
                {
                    Point temp = new Point((int)p.X, (int)p.Y);

                    if (rect.Contains(temp))
                    {
                        target.health -= strength;
                        break;
                    }
                }
            }

        }

        //public bool Collision(SnakeType snake)
        //{

        //    if (Player.IntersectsWith(snake.gorgPoints))
        //    {

        //    }

        //    return false;
        //}
    }
}
