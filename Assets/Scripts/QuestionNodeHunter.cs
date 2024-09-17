using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNodeHunter : Node
{
    public Node trueNode;
    public Node falseNode;
    public TypeQuestion questionType;

    public override void ExecuteBoid(Boid boid)
    {
        switch (questionType)
        {
            case TypeQuestion.Hunter:
                if(boid.hunter == true) 
                    trueNode.ExecuteBoid(boid);
                else
                    falseNode.ExecuteBoid(boid);
                break;
            case TypeQuestion.Fruit:
                if (boid.fruit == true)
                    trueNode.ExecuteBoid(boid);
                else
                    falseNode.ExecuteBoid(boid);
                break;

        }
    }

    public override void ExecuteHunter(Hunter hunter)
    {
        switch (questionType)
        {
            case TypeQuestion.Energy:
                if(hunter.Energia == true)
                    trueNode.ExecuteHunter(hunter);
                else 
                    falseNode.ExecuteHunter(hunter);
                break;
            case TypeQuestion.Distance:
                if(hunter.DistanciaRebaño == true)
                    trueNode.ExecuteHunter(hunter);
                else
                    falseNode.ExecuteHunter(hunter);
                break;
        }
    }
   public enum TypeQuestion
    {
        Energy,
        Distance,
        Hunter,
        Fruit
    }
}
