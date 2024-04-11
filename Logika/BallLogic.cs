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
    public static CircleList circleList = new CircleList();
    private Random random = new Random();
    public Ball Move(Ball ball)
    {
        ball.X += ball.VelocityX;
        ball.Y += ball.VelocityY;

        if (ball.X <= 0 +OffsetX || ball.X >= CanvasWidth - BallDiameter + OffsetX)
        {
            ball.VelocityX = -ball.VelocityX;
        }
        if (ball.Y <= 0 + OffsetY || ball.Y >= CanvasHeight - BallDiameter + OffsetY)
        {
            ball.VelocityY = -ball.VelocityY;
        }

        for (int i = 0; i < circleList.CountCircles(); i++)
        {
            double distance = Math.Sqrt(Math.Pow(circleList.GetCircle(i).X - ball.X, 2) + Math.Pow(circleList.GetCircle(i).Y - ball.Y, 2));

            if (distance <= BallDiameter && ball.X != circleList.GetCircle(i).X && ball.Y != circleList.GetCircle(i).Y)
            {
                ball.VelocityY = -ball.VelocityY;

                circleList.GetCircle(i).VelocityX = -circleList.GetCircle(i).VelocityX;
               

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

