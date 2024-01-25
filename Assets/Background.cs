using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    const float minPosX = -17f;

    private void FixedUpdate()
    {
        if (transform.position.x < minPosX) transform.position += new Vector3(48f, 0, 0);
    }
}
