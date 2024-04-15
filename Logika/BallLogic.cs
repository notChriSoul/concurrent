using Dane;
using System;

namespace Logika;

public class BallLogic
{
    private const int BallDiameter = 76;
    private const int CanvasWidth = 828;
    private const int CanvasHeight = 457;
    private const int OffsetX = 0;
    private const int OffsetY = 0;
    public static readonly CircleList circleList = new CircleList();
    private Random random = new Random();
    public Ball Move(Ball ball)
    {
        lock (circleList) // lockowanie całej listy, zeby odczytywac terazniejsze dane a nei z brudnopisu
        {
            // poruszanie kulki
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            // odbijanie od scianek
            if (ball.X <= 0 + OffsetX || ball.X >= CanvasWidth - BallDiameter + OffsetX)
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (ball.Y <= 0 + OffsetY || ball.Y >= CanvasHeight - BallDiameter + OffsetY)
            {
                ball.VelocityY = -ball.VelocityY;
            }

            //odbijanie od siebie wzajemnie

            for (int i = 0; i < circleList.CountCircles(); i++)
            {
                // kwadrat odleglosci
                double distancesq = (circleList.GetCircle(i).X - ball.X) * (circleList.GetCircle(i).X - ball.X)
                    + (circleList.GetCircle(i).Y - ball.Y) * (circleList.GetCircle(i).Y - ball.Y);

                //odbijanie od siebie
                if (distancesq <= BallDiameter * BallDiameter)

                {
                    if (!ball.Equals(circleList.GetCircle(i)))
                    {
                        ball.VelocityY = -ball.VelocityY;
                        ball.VelocityX = -ball.VelocityX;

                        // TO JEST GLUPIE
                        /*
                        circleList.GetCircle(i).VelocityX = -circleList.GetCircle(i).VelocityX;
                        circleList.GetCircle(i).VelocityY = -circleList.GetCircle(i).VelocityY;
                        */
                    }

                }
            }


        }
        return ball;
    }
    
    public Ball CreateBall()
    {
        Ball ball;
        bool overlap;
        do
        {
            ball = new Ball
            {
                X = random.Next(0, 828 - 76),
                Y = random.Next(0, 457 - 76),

                VelocityX = 5 * (random.Next(2) == 0 ? 1 : -1),
                VelocityY = 5 * (random.Next(2) == 0 ? 1 : -1)
            };

            // Check if the new ball overlaps with any existing ball
             overlap = false;
            for (int i = 0; i < circleList.CountCircles(); i++)
            {
                double distanceSq = (circleList.GetCircle(i).X - ball.X) * (circleList.GetCircle(i).X - ball.X)
                    + (circleList.GetCircle(i).Y - ball.Y) * (circleList.GetCircle(i).Y - ball.Y);

                if (distanceSq <= BallDiameter * BallDiameter)
                {
                    overlap = true;
                    break; // no need to continue checking if there's an overlap
                }
            }

            // If there's an overlap, create a new ball with new coordinates
        } while (overlap);

        // Add the ball to the list only if there's no overlap
        circleList.AddCircle(ball);

        return ball;
    }
    



}

