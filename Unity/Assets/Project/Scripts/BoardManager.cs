using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public class Count
    {
        public int minimum;
        public int maximum;
        
        public Count (int min, int max)
        {
            minimum = min
            maximum = max
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count (5,9);
    public Count chestCount = new Count (1,5);
    public GameObject door;
    public GameObject[] wallTiles;
    public GameObject[] chestTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder;
    private List <Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x,y,0f));
            }
        }
    }

    void BoardSetup ()
    {
        boardHolder = new GameObject ("Board").transform;

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                if (x == 1 || x == columns || y == 1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range (0, outerWallTiles.Lenght)];

                GameObject instance = Instantiate(toInstantiate, new Vector3 (x,y,0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 RandomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return RandomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] titleArray, int minimum, int maximum)
    {
        int objectCount = Random.Range (minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 RandomPosition = RandomPosition();
            GameObject titleChoice = titleArray[Random.Range (0, titleArray.Lenght)];
            Instantiate (titleChoice, RandomPosition, Quaternion.identity);
        }
    }

    public void SetupScene (int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(chestTiles, chestCount.minimum, chestCount.maximum);
        int enemyCount = (int)Mathf.Log(level,2f);
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
        Instantiate(door, new Vector3(columns - 1, rows -1, 0F), Quaternion.identity);
    }
}
