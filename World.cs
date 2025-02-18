using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217retry
{
    public class World
    {
        public World() { }

        GameObject[,] gameObjects = new GameObject[50, 50];
        //int objectCount = 0;

        public void CreateObject(int x, int y, GameObject pObject)
        {
            gameObjects[y, x] = pObject;
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

                        if (gameObjects[changeY, changeX].shape == 'P')
                        {
                            pObject.y = tempY;
                            pObject.x = tempX;
                            gameObjects[tempY, tempX] = tempObj;
                        }
                    }
                }
            }
        }
    }
}
