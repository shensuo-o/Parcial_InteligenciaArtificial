using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Node rootNode;
    public bool hunter;
    public bool fruit;

    private void Update()
    {
        rootNode.ExecuteBoid(this);
    }

    public void Flocking()
    {
        Debug.Log("Hago Flocking");
    }

    public void Pursuit()
    {
        Debug.Log("Estoy yendo a la fruta");
    }

    public void Evade()
    {
        Debug.Log("Estoy huyendo");
    }
}
