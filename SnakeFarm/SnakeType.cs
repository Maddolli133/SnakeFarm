using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeFarm
{
    internal class SnakeType
    {
        public int x, y;
        public int width;
        public int height;
        public int xSpeed;
        public int ySpeed;
        public int health;
        public string type;
        public int speed;

        public double Direction;

        public List<PointF> gorgPoints = new List<PointF>(); // these are the points of the snakes tail so you can see a clear movement with the snakes
        
        public SnakeType(string type)
        {
            this.type = type;

            Random randGen = new Random();
            x = randGen.Next(0, 1366);
            y = randGen.Next(0, 768);

            gorgPoints.Add(new PointF(x, y));

            if (this.type == "Gorgenschleimer")
            {
                Gorgenschleimer();
            }

        }

        private void Gorgenschleimer()
        {
            width = 20;
            height = 20;
            health = 10;
            
            // Initialize the speed based on the given speed parameter

            // Ensure the snake starts moving in a random direction
            Random randGen = new Random();

            if (FarmScreen.canRandomize)
            {
                float turnAmount = (float)(randGen.Next(-50, 51) * (Math.PI / 180)); //Take in degrees rand num and convert to radian measure
                Direction += turnAmount;
                FarmScreen.countdown = 5;
                gorgPoints.Add(new PointF(x, y));
            }
            xSpeed = (int)(5 * Math.Cos(Direction));
            ySpeed = (int)(5 * Math.Sin(Direction));

            if (gorgPoints.Count == 20)
            {
                gorgPoints.RemoveAt(0);
            }
        }
        public void Move()
        {
            x += xSpeed;
            y += ySpeed;

            if (x < 0 || x > FarmScreen.width - width)
            {
                xSpeed *= -10;
            }

            else if (y < 0 || y > FarmScreen.height - height)
            {
                ySpeed *= -10;
            }
            else if (FarmScreen.countdown <= 0)
            {
                Gorgenschleimer();
            }
            //put change in direction here and all movements here



        }
    }
}
