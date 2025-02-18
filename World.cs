using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217retry
{
    public class World
    {
        GameObject[] gameObjects;
        Map map;

        public World(Map pMap) 
        {
            map = pMap;
            gameObjects = new GameObject[map.mapDesign1.Length * map.mapDesign1[0].Length];
        }

        int objectCount = 0;
        int monsterIndex = 0;
        int playerIndex = 0;

        public void CreateObject(GameObject pObject)
        {
            gameObjects[objectCount] = pObject;
            if (pObject.GetType().Name.Equals("Player"))
            {
                playerIndex = objectCount;
            }
            if (pObject.GetType().Name.Equals("Monster"))
            {
                monsterIndex = objectCount;
            }
            objectCount++;
        }

        public void Render()
        {
            Console.Clear();
            foreach (GameObject pObject in gameObjects)
            {
                if (pObject != null)
                {
                    pObject.DrawObject();
                }
            }
        }

        public void Update()
        {
            foreach (GameObject pObject in gameObjects)
            {
                if (pObject != null)
                {
                    GameObject tempObj = pObject;
                    List<int> list = pObject.UpdatePosition();
                    if (list != null)
                    {
                        int tempX = list[0];
                        int tempY = list[1];
                        int changeX = list[2];
                        int changeY = list[3];

                        if (map.mapDesign1[changeY][changeX] == '*')
                        {
                            pObject.y = tempY;
                            pObject.x = tempX;
                        }
                    }

                    if (gameObjects[playerIndex].y == gameObjects[monsterIndex].y && gameObjects[playerIndex].x == gameObjects[monsterIndex].x)
                    {
                        Console.Clear();
                        Console.WriteLine("You Died");
                        Engine.Instance().Shutdown();
                        break;
                    }

                }
            }
        }
    }
}
