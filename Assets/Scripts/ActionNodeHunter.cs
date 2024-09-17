using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNodeHunter : Node
{
    public TypeAction type;

    public override void Execute(Hunter hunter)
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

    public enum TypeAction
    {
        Perseguir,
        Patrullar,
        Descansar
    }
}
