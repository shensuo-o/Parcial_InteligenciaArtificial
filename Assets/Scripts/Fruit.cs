using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] Boid boid;
    public void DestroyFruit()
    {
        if (this != null)
        {
            Destroy(this);
            boid.fruit = false;
        }
    }
}
