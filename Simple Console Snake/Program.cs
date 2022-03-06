using System;
using System.Threading;

namespace Simple_Console_Snake
{
    class Snake
    {
        int Height = 20; 
        int Width = 30;

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random rnd = new Random();

        Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, (Width - 2));
            fruitY = rnd.Next(2, (Height - 2));
        }

        public void WriteBoard()
        {
            Console.Clear();
            Console.WriteLine("START THE GAME BY CLICKING W,A,D,S");
            for(int i = 1; i <= (Width+2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height+2));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width+2), i);
                Console.Write("|");
            }

        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        public void WritePoint(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("B");
        }

        public void Logic()
        {
            if (X[0] == fruitX)
            {
                if(Y[0] == fruitY)
                {
                    parts++;
                    fruitX = rnd.Next(2, (Width-2));
                    fruitY = rnd.Next(2, (Height-2));
                }
            }
            for(int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (key)
            {
                case 'w':
                        Y[0]--;
                    break;
                case 's':
                        Y[0]++;
                    break;
                case 'd':
                        X[0]++;
                    break;
                case 'a':
                        X[0]--;
                    break;
            }
            for(int i = 0;i <= (parts - 1); i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
        static void Main(string[] args)
        {
            int v,p;
            Snake snake = new Snake();
            
            Console.WriteLine("WELCOME TO SNAKE GAME");
            Console.WriteLine("\n \n \nCreated By : BISHAL NANDY[2022]");
            
            Console.WriteLine("\n\nINSTRUCTIONS");
            Console.WriteLine("Press W to move UP. \nPress S to move DOWN. \nPress A to move LEFT. \nPress D to move RIGHT.");
            
            Console.WriteLine("\n\nPRESS 1 TO CONTINUE");
            Console.WriteLine("PRESS 2 TO EXIT");
            v = Convert.ToInt32(Console.ReadLine());
            
            if (v == 1)
            {
                while (true)
                {
                    snake.WriteBoard();
                    snake.Input();
                    snake.Logic();
                }
                
                Console.ReadKey();

            }
            else if(v == 2)
            {
                Environment.Exit(0);
            }
            
        }
    }
}
