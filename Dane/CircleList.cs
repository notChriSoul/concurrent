using System.Collections.Generic;

namespace Dane
{
    public class CircleList
    {
        private List<Ball> circles;

        public CircleList()
        {
            circles = new List<Ball>();
        }

        public int CountCircles()
        {
            return circles.Count;
        }

        public void AddCircle(Ball circle)
        {
            circles.Add(circle);
        }

        public void Clear()
        {
            circles.Clear();
        }

        public Ball GetCircle(int index)
        {
            return circles[index];
        }

        public void RemoveCircle(Ball circle)
        {
            circles.Remove(circle);
        }


    }
}
