using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged; //implementacja interfejsu

        public double X { get; set; }
        public double Y { get; set; }
        public int Size { get; set; }
        public int Radius { get; set; }
        public double DirectionX { get; set; }
        public double DirectionY { get; set; }

        public double Speed { get; set; }

        public double Mass { get; set; }



        public Ball(int x, int y, int size, int radius, double speed, double mass)
        {
            X = x;
            Y = y;
            Size = size;
            Radius = radius;
            Speed = speed;
            Mass = mass;

            DirectionX = 0;
            DirectionY = 0;


            while (DirectionX == 0 && DirectionY == 0)
            {
                Random random = new Random();
                DirectionX = random.NextDouble() * 2.0 - 1.0;
                DirectionY = random.NextDouble() * 2.0 - 1.0;
            }

            Console.WriteLine("dir X: " + DirectionX + "dir Y: " + DirectionY + "Speed: " + speed);

            DirectionX *= speed / mass;
            DirectionY *= speed / mass;
        }

        //tu jeszcze niby jest main u Jacka ale zobaczymy czy jest sens go robic potem (tam jest pusty)

    }

}
