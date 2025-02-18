using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217retry
{
    public class Engine
    {
        public Map map;
        World world;
        private bool isRunning = true;
        public ConsoleKeyInfo keyInfo;

        public Engine()
        {
            map = new Map();
            world = new World(map);
        }

        private static Engine instance;
        public static Engine Instance()
        {
            if (instance == null)
            {
                instance = new Engine();
            }
            return instance;
        }

        public void Shutdown()
        {
            isRunning = false;
        }

        public void Load()
        {
            map = new Map();

            for (int y = 0; y < map.mapDesign1.Length; y++)
            {
                for (int x = 0; x < map.mapDesign1[y].Length; x++)
                {
                    if (map.mapDesign1[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, map.mapDesign1[y][x]);
                        world.CreateObject(wall);
                    }
                    else if (map.mapDesign1[y][x] == ' ')
                    {
                        Floor floor = new Floor(x, y, map.mapDesign1[y][x]);
                        world.CreateObject(floor);
                    }
                    else if (map.mapDesign1[y][x] == 'P')
                    {
                        Player player = new Player(x, y, map.mapDesign1[y][x]);
                        world.CreateObject(player);
                    }
                    else if (map.mapDesign1[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, map.mapDesign1[y][x]);
                        world.CreateObject(monster);
                    }
                    else if (map.mapDesign1[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, map.mapDesign1[y][x]);
                        world.CreateObject(goal);
                    }
                }
            }
        }

        public void Run()
        {
            while (isRunning)
            {
                world.Render();
                keyInfo = Console.ReadKey();
                world.Update();
            }
        }
    }
}
