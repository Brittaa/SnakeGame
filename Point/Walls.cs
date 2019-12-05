using System;
using System.Collections.Generic;

namespace Point
{
    class Walls
    {
        List<Figure> wallList;
        Random rnd = new Random();

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLines topLine = new HorizontalLines(0, mapWidth -2,0, '#');
            HorizontalLines bottomLine = new HorizontalLines(0, mapWidth - 2, mapHeight - 1, '#');
            VerticalLine leftLine = new VerticalLine(0,mapHeight -1, 0,'#');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '#');
            VerticalLine obstacleVertical = new VerticalLine(rnd.Next(2,25), rnd.Next(2, 25), rnd.Next(2, 25), '+');
            HorizontalLines obstacleHorizontal = new HorizontalLines(rnd.Next(2, 25), rnd.Next(2, 25), rnd.Next(2, 25), '+');
            wallList.Add(topLine);
            wallList.Add(bottomLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(obstacleHorizontal);
            wallList.Add(obstacleVertical);
        }
        public void DrawWalls()
        {
            foreach(Figure wall in wallList)
            {
                wall.DrawFigure();
            }
        }
        public bool IsHitByFigure(Figure figure)
        {
            foreach (Figure wall in wallList)
            {
                if (wall.IsHitByFigure(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
