using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public abstract void ExecuteHunter(Hunter hunter);
    public abstract void ExecuteBoid(Boid boid);
}
