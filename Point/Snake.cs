using System;
using System.Collections.Generic;
using System.Linq;

namespace Point
{
    enum Direction // suute tähtetega enum!
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    class Snake:Figure
    {
        public Direction Direction;
        public int scorePoint;

        public Snake(MyPoint tail, int lenght, Direction _direction)
        {
            
            Direction = _direction;
            for(int i = 0; i< lenght; i++)
            {
                MyPoint newPoint = new MyPoint(tail);
                newPoint.MovePoint(i, Direction);
                pointList.Add(newPoint);
            }
        }
        //meetodi väljakutsumiseks on vaja objekti, objekt on ajutine, pärast kinnipanemist kustutatakse
        //funktsiooni saab niisama välja kutsuda

        public void MoveSnake()
        {
            MyPoint tail = pointList.First();
            pointList.Remove(tail);
            MyPoint head = GetNextPoint();
            pointList.Add(head);
            tail.Clear();
            head.Draw();
        }
        public MyPoint GetNextPoint()
        {
            MyPoint head = pointList.Last();
            MyPoint nextPoint = new MyPoint(head);
            nextPoint.MovePoint(1, Direction);
            return nextPoint;
        }
        public void ReadUserKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                Direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                Direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                Direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                Direction = Direction.DOWN;
            }
        }
        public bool EatGoodFood(MyPoint goodF)
        {
            
            //Console.ForegroundColor = ConsoleColor.Green;
            MyPoint head = GetNextPoint();
            if (head.IsHit(goodF))
            {
                goodF.symbol = head.symbol;
                pointList.Add(goodF); //kui sööb toidu ära, muutub osaks ussist.
                //scorePoint += 2;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EatBadFood(MyPoint badF)
        {
            
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            MyPoint head = GetNextPoint();
            if (head.IsHit(badF))
            {
                badF.symbol = head.symbol;
                pointList.Add(badF); //kui sööb toidu ära, muutub osaks ussist.
                //scorePoint--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
