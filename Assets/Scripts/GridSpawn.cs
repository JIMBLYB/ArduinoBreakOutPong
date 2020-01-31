using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    public float distanceX;
    public float distanceY;

    private const int X = 19;
    private const int Y = 15;

    // 11 Vertical
    // 19 Horizontal
    private int[,] positions = new int[X, Y];
    public GameObject blockPrefab;

    private void Start()
    {
        for (int i = 0; i < positions.GetLength(0); i++)
        {
            for (int j = 0; j < positions.GetLength(1); j++)
            {
                if (j != (Y - 1) / 2 && j != (Y - 1) / 2 - 1 && j != (Y - 1) / 2 + 1)
                {
                    Instantiate(blockPrefab, new Vector2((i * distanceX) - (((X - 1) / 2) * distanceX), (j * distanceY) - (((Y - 1) / 2) * distanceY)), Quaternion.identity);
                }
            }
        }
    }
}
