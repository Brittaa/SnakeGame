﻿using System;
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
    }

}