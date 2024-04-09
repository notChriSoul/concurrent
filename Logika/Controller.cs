﻿using Dane;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace Logika
{
    public class Controller
    {


        public static BallList BallList= new BallList();

        public static void spawnCircles(int value, Canvas canvas)
        {
            for (int i = 0; i < value; i++)
            {
                spawnCircle(canvas, 10, 10);
            }
        }

        public static void spawnCircle(Canvas canvas, int size, int radius)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());

            int x = r.Next(0, (int)canvas.ActualWidth);
            int y = r.Next(0, (int)canvas.ActualHeight);
            double speed = 0;
            int speedInt = 0;


            while (speed == 0)
            {
                Random random = new Random();
                speed = random.Next(-2, 2);
                //speed = random.NextDouble() * 2.0 - 1.0;

            }

            Ball BallObjet = new Ball(x, y, size, radius, speed, 1);

            Ellipse circle = new Ellipse();
            circle.Width = 2 * radius;
            circle.Height = 2 * radius;
            circle.Fill = new SolidColorBrush(Colors.Red);

            Canvas.SetLeft(circle, x - radius);
            Canvas.SetTop(circle, y - radius);

            canvas.Children.Add(circle);

            circleList.AddCircle(circleObject);
            Task task = new Task(() =>
            {
                while (true)
                {
                    var dispatcher = Application.Current.Dispatcher;
                    dispatcher.Invoke(() =>
                    {

                        double left = Canvas.GetLeft(circle);
                        double top = Canvas.GetTop(circle);

                        if (left + circle.Width >= canvas.ActualWidth)
                        { // odbicie od PRAWEJ krawedzi
                            circleObject.DirectionX = -circleObject.DirectionX;
                        }
                        else if (left <= 0)
                        { // odbicie od LEWEJ krawedzi
                            circleObject.DirectionX = -circleObject.DirectionX;
                        }

                        if (top + circle.Height >= canvas.ActualHeight)
                        { // odbicie od DOLNEJ krawedzi
                            circleObject.DirectionY = -circleObject.DirectionY;
                        }
                        else if (top <= 0)
                        { // odbicie od GORNEJ krawedzi
                            circleObject.DirectionY = -circleObject.DirectionY;
                        }

                        circleObject.X += circleObject.DirectionX;
                        circleObject.Y += circleObject.DirectionY;


                        for (int i = 0; i < circleList.CountCircles(); i++)
                        {
                            double distance = Math.Sqrt(Math.Pow(circleList.GetCircle(i).X - circleObject.X, 2) + Math.Pow(circleList.GetCircle(i).Y - circleObject.Y, 2));

                            if (distance <= circleObject.Radius + circleList.GetCircle(i).Radius && circleObject.X != circleList.GetCircle(i).X && circleObject.Y != circleList.GetCircle(i).Y)
                            { // czy 2r <= odleglosci, jak tak to sie odbijaja (warunek 1)
                              // i zabezpieczenie, ze przechodzac cala tablice natkniemy sie na ta sama kulke do ktorej porownujemy(warunek 2 i 3)
                                circleObject.DirectionY = -circleObject.DirectionY; // ?

                                circleList.GetCircle(i).DirectionX = -circleList.GetCircle(i).DirectionX;
                                circleList.GetCircle(i).DirectionY = -circleList.GetCircle(i).DirectionY;

                            }
                        }


                        Canvas.SetLeft(circle, circleObject.X - circleObject.Radius);
                        Canvas.SetTop(circle, circleObject.Y - circleObject.Radius);
                    });
                    Thread.Sleep(20);
                }
            });
            task.Start();

        }





    }
}
