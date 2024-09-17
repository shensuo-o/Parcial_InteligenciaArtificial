using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNodeHunter : Node
{
    public Node trueNode;
    public Node falseNode;
    public TypeQuestion questionType;

    public override void Execute(Hunter hunter)
    {
        switch (questionType)
        {
            case TypeQuestion.Energy:
                if(hunter.Energia == true)
                    trueNode.Execute(hunter);
                else 
                    falseNode.Execute(hunter);
                break;
            case TypeQuestion.Distance:
                if(hunter.DistanciaRebaño == true)
                    trueNode.Execute(hunter);
                else
                    falseNode.Execute(hunter);
                break;
        }
    }
   public enum TypeQuestion
    {
        Energy,
        Distance
    }
}
