using System;
using System.Collections.Generic;
namespace Point
{
    class Figure //public eest kustuta!
    {
        protected List<MyPoint> pointList = new List<MyPoint>(); // ei lase listi omadust muuta, saavad kasutada klassid, mis pärinevad sellest klassist
        public void DrawFigure()
        {
            foreach (MyPoint point in pointList)
            {
                point.Draw();
            }
        }
        public bool IsHitByPoint(MyPoint point)
        {
            foreach(MyPoint p in pointList)
            {
                if(p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsHitByFigure(Figure figure)
        {
            foreach(MyPoint point in pointList)
            {
                if(figure.IsHitByPoint(point))
                {
                    return true;
                }
            }
            return false;
        }

      
    }
}
