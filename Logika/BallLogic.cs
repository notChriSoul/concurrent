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
        lock (circleList) // lockowanie całej listy 
        {
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            if (ball.X <= 0 + OffsetX || ball.X >= CanvasWidth - BallDiameter + OffsetX)
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (ball.Y <= 0 + OffsetY || ball.Y >= CanvasHeight - BallDiameter + OffsetY)
            {
                ball.VelocityY = -ball.VelocityY;
            }

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
       Ball ball= new Ball
        {
            X = random.Next(0, 828 - 76),
            Y = random.Next(0, 457 - 76),

            VelocityX = 5 * (random.Next(2) == 0 ? 1 : -1),
            VelocityY = 5 * (random.Next(2) == 0 ? 1 : -1)
        };
        circleList.AddCircle(ball);

       

        return ball;
    }
}

