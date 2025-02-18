using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217retry
{
    public class GameObject
    {
        public int x;
        public int y;
        public char shape;
        public GameObject() { }

        public virtual void DrawObject()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(shape);
        }

        public virtual List<int> UpdatePosition()
        {
            return null;
        }
    }

    public class Player : GameObject
    {
        public Player(int pX, int pY, char pShape)
        {
            x = pX;
            y = pY;
            shape = pShape;
        }

        public override List<int> UpdatePosition()
        {
            int tempX = x;
            int tempY = y;
            if (Engine.Instance().keyInfo.Key == ConsoleKey.W || Engine.Instance().keyInfo.Key == ConsoleKey.UpArrow)
            {
                y--;
            }
            else if (Engine.Instance().keyInfo.Key == ConsoleKey.S || Engine.Instance().keyInfo.Key == ConsoleKey.DownArrow)
            {
                y++;
            }
            else if (Engine.Instance().keyInfo.Key == ConsoleKey.A || Engine.Instance().keyInfo.Key == ConsoleKey.LeftArrow)
            {
                x--;
            }
            else if (Engine.Instance().keyInfo.Key == ConsoleKey.D || Engine.Instance().keyInfo.Key == ConsoleKey.RightArrow)
            {
                x++;
            }
            if (tempX == x && tempY == y)
            {
                return null;
            }
            else
            {
                return new List<int> { tempX, tempY, x, y };
            }
        }
    }

    public class Monster : GameObject
    {
        Random rand = new Random();
        public Monster(int pX, int pY, char pShape)
        {
            x = pX;
            y = pY;
            shape = pShape;
        }

        public override List<int> UpdatePosition()
        {
            int point = rand.Next(0, 4);
            if (point == 0)
            {
                y--;
            }
            else if (point == 1)
            {
                y++;
            }
            else if (point == 2)
            {
                x--;
            }
            else if (point == 3)
            {
                x++;
            }
            return null;
        }
    }

    public class Wall : GameObject
    {
        public Wall(int pX, int pY, char pShape)
        {
            x = pX;
            y = pY;
            shape = pShape;
        }
    }

    public class Floor : GameObject
    {
        public Floor(int pX, int pY, char pShape)
        {
            x = pX;
            y = pY;
            shape = pShape;
        }

        // 바닥은 따로 그리지 않도록
        public override void DrawObject()
        {
        }
    }

    public class Goal : GameObject
    {
        public Goal(int pX, int pY, char pShape)
        {
            x = pX;
            y = pY;
            shape = pShape;
        }
    }
}
