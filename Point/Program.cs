using System;
using System.Diagnostics;
using System.Threading;


namespace Point
{
    class Program
    {
        //private static object stopwatch;
        public static Stopwatch timer = new Stopwatch();

        static void Main(string[] args)
        {

            /*Point p1 = new Point(5, 5, '*');
            p1.Draw();

            Point p2 = new Point(6, 5, '*');
            p2.Draw();

            Point p3 = new Point(7, 5, '*');
            p3.Draw();
            Point p4 = new Point(8, 5, '*');
            p4.Draw();
            Point p5 = new Point(9, 5, '*');
            p5.Draw();
            Console.ReadLine();*/

            /*for(int i =5; i<10; i++)
            {
                MyPoint newPoint = new MyPoint(i, 5, '*');
                newPoint.Draw();
                MyPoint newPoint2 = new MyPoint(5, i, '#');
                newPoint2.Draw();
            } //list, mille sees on objektid, objekt klassis point*/

            //Console.SetWindowSize(80, 25); ei tööta
            //Console.SetBufferSize(80, 25);

            /*HorizontalLines hrLine = new HorizontalLines(5,10, 10,'*');
            hrLine.DrawHorizontlLine();

            VerticalLine vrLine = new VerticalLine(11, 20, 5, '#');
            vrLine.DrawVerticallLine();

            HorizontalLines hrLine2 = new HorizontalLines(10, 15, 10, '*');
            hrLine2.DrawHorizontlLine();

            VerticalLine vrLine2 = new VerticalLine(10, 15, 10, '#');
            vrLine2.DrawVerticallLine();*/

            /*HorizontalLines topLine = new HorizontalLines(0, 78, 0, '*');
            topLine.DrawFigure();

            HorizontalLines bottomLine = new HorizontalLines(0, 78, 24, '*');
            bottomLine.DrawFigure();

            VerticalLine leftLine = new VerticalLine(0, 24, 0, '*');
            leftLine.DrawFigure();

            VerticalLine rightLine = new VerticalLine(0, 24, 78, '*');
            rightLine.DrawFigure();*/

            
            timer.Start();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.DrawWalls();

            MyPoint tail = new MyPoint(6, 5, '*');
            Snake snake = new Snake(tail, 4, Direction.RIGHT);

            snake.DrawFigure();

            //toidu serveerimine
            /*FoodCatering foodCatered = new FoodCatering(80, 25, '$');
            MyPoint food = foodCatered.CaterFood();
            food.Draw();*/

            FoodCatering goodFood = new FoodCatering(80, 25, '€');
            MyPoint goodF = goodFood.CaterGoodFood();
            Console.ForegroundColor = ConsoleColor.Green;
            goodF.Draw();

            FoodCatering badFood = new FoodCatering(80, 25,'@');
            MyPoint badF = badFood.CaterBadFood();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            badF.Draw();

            int scorePoints = 0; 
            
            while(true)
            {
                if(walls.IsHitByFigure(snake))
                {
                    Console.Beep();
                    break;
                }

                if (snake.EatGoodFood(goodF))
                {
                    goodF = goodFood.CaterGoodFood();
                    Console.ForegroundColor = ConsoleColor.Green;
                    scorePoints +=2;
                    goodF.Draw();
                    badF.Draw();
                }
                else if (snake.EatBadFood(badF))
                {
                    badF = badFood.CaterBadFood();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    scorePoints--;
                    badF.Draw();
                    goodF.Draw();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    snake.MoveSnake();
                }

                Thread.Sleep(200);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(); // loeb klahvi nuppu
                    snake.ReadUserKey(key.Key);
                }
            }
            
            WriteGameOver(scorePoints);
            Console.ReadLine();

        }
        public static void WriteGameOver(int scorePoints)
        {
            Console.Clear();
            int xOffset = 25;
            int yOffset = 6;
            timer.Stop();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage("GAME OVER", xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage($"Score: {scorePoints} point(s)", xOffset, yOffset++);
            ShowMessage("=================", xOffset, yOffset++);
            ShowMessage($"Time of playing: {timer.Elapsed.TotalSeconds} seconds", xOffset, yOffset++);
            ShowMessage("==================================", xOffset, yOffset++);

        }
        public static void ShowMessage(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        /*public static void GoodFood()
        {
            int scorePoints = 0;
            FoodCatering goodFood = new FoodCatering(80, 25, '€');
            MyPoint goodF = goodFood.CaterFood();
            Console.ForegroundColor = ConsoleColor.Green;
            scorePoints = +2;
            goodF.Draw();
        }
        public static void BadFood()
        {
            int scorePoints = 0;
            FoodCatering badFood = new FoodCatering(80, 25, '@');
            MyPoint badF = badFood.CaterFood();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            scorePoints--;
            badF.Draw();

        }*/
    }
}
