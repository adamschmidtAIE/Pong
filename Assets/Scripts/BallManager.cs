using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public GameObject[] allBalls;

    public void SpawnNewBall()
    {
        Instantiate(allBalls[Random.Range(0, allBalls.Length)], Vector3.zero, Quaternion.identity);
    }
}
