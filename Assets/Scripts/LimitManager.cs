using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    public static LimitManager instance;
    public float width, height;

    public void Awake()
    {
        instance = this;
    }

    public Vector3 ApplyBounds(Vector3 pos)
    {
        if (pos.x > width)
        {
            pos.x = -width;
        }
        if (pos.x < -width)
        {
            pos.x = width;
        }

        if (pos.z > height)
        {
            pos.z = -height;
        }
        if (pos.z < -height)
        {
            pos.z = height;
        }

        return pos;
    }
}
