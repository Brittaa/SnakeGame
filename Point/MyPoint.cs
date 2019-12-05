using System;

namespace Point
{
    class MyPoint
    {
        public int x;
        public int y;
        public char symbol;
        public MyPoint(int _x, int _y, char _symbol)
        {
            x = _x;
            y = _y;
            symbol = _symbol;
        }
        public MyPoint(MyPoint _p)
        {
            x = _p.x;
            y = _p.y;
            symbol = _p.symbol;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        public void Clear()
        {
            symbol = ' ';
            Draw();  //staatilist kasutad klassi puhul
        }
        public void MovePoint(int offset, Direction direction) 
        {
            if(direction == Direction.RIGHT)
            {
                x += offset;
            }
            else if (direction == Direction.LEFT)
            {
                x -= offset;
            }
            else if (direction == Direction.UP)
            {
                y -= offset;
            }
            else if( direction == Direction.DOWN)
            {
                y += offset;
            }
        }
        public bool IsHit(MyPoint point)
        {
            //kontrollime kas punktid on ühel kohal
            return point.x == x && point.y == y;
        }
    }
}
