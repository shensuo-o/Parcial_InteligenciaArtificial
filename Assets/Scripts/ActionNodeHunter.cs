using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNodeHunter : Node
{
    public TypeAction type;

    public override void ExecuteHunter(Hunter hunter)
    {
        switch (type)
        {
            case TypeAction.Descansar:
                hunter.Descansar();
                break;
            case TypeAction.Perseguir:
                hunter.AddForce(hunter.Perseguir(hunter.target));
                break;
            case TypeAction.Patrullar:
                hunter.Patrullar();
                break;
        }
    }
    public override void ExecuteBoid(Boid boid)
    {
         switch(type)
         { 
            case TypeAction.Flocking:
                boid.Flocking();   
                break;
            case TypeAction.Seek: 
                boid.AddForce(boid.Seek(boid.target.position));
                break;
            case TypeAction.Evade:
                boid.AddForce(boid.Evade(boid.cazador));
                break;
        
         }
    }

    public enum TypeAction
    {
        Perseguir,
        Patrullar,
        Descansar,
        Flocking,
        Evade,
        Seek
    }
}
