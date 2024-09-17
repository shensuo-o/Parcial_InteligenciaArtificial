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
                hunter.Perseguir();
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
            case TypeAction.Pursuit: 
                boid.Pursuit();
                break;
            case TypeAction.Evade:
                boid.Evade();
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
        Pursuit
    }
}
