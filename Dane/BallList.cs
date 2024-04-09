namespace Dane
{
    public class BallList
    {
        private List<Ball> balls;

        public BallList()
        {
            balls = new List<Ball>();
        }

        public int Count { get { return balls.Count;} }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public void ClearBalls()
        {
            balls.Clear();
        }

        public Ball GetBall(int index)
        {
            return balls[index];
        }

    }
}
