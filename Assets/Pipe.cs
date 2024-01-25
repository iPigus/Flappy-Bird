using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float minPosX = -10f;
    const float maxPosY = 4f;

    private void Awake()
    {
        if (transform.position.x > 10f) transform.position = new(transform.position.x, Random.Range(-maxPosY, maxPosY), transform.position.z);
    }

    private void FixedUpdate()
    {
        if (transform.position.x < minPosX)
        {
            transform.position = new(transform.position.x + 30f, Random.Range(-maxPosY, maxPosY), transform.position.z);
        }
    }
}
