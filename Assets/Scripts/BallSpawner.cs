using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    void Start()
    {
        Instantiate(ballPrefab, new Vector2(0, 0), Quaternion.identity, transform);
    }

    public void spawnBall()
    {
        Instantiate(ballPrefab, new Vector2(0, 0), Quaternion.identity, transform);
    }
}
