using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : Character
{
    public Node rootNode;
    public bool hunter;
    public bool fruit;
    public GameManager gameManager;

    [SerializeField] public Transform target; //Objetivo del Seek.

    [Range(0f, 1f)]
    [SerializeField] float _maxSteering; //Que tan brusca es la curva del Seek.

    [SerializeField] public Character cazador;

    protected override void Update()
    {
         base.Update();

         rootNode.ExecuteBoid(this);

         float distanceToTarget = Vector3.Distance(target.position, transform.position);
         if (distanceToTarget <= touchRadius)
         {
              gameManager.DestroyFruit();
         }      
    }

    public void Detector()
    {

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("nuevo target = " + target);
    }

    public void Flocking()
    {
        Debug.Log("Hago Flocking");
    }

    public Vector3 Seek(Vector3 target)
    {
        Debug.Log("Estoy yendo a la fruta");
        Vector3 desiredVelocity = target - transform.position; //Hacia donde quiere ir.
        desiredVelocity.Normalize(); //Normaliza la velocidad deseada, para que sea de 1 en 1.
        desiredVelocity *= _maxVelocity; //Setea la velocidad maxima.

        Vector3 steeringVelocity = desiredVelocity - _velocity; //En que direccion va a ser la curva. 
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, _maxSteering); //Definde que tan brusca es la curva del steering. Mas grande mas rapido gira.
        return steeringVelocity; //Devuelve el Vector para deapues aplicar AddForce.
    }

    public Vector3 Evade(Character hunter)
    {
        Debug.Log("Estoy huyendo");
        var posPre = hunter.transform.position + hunter.Velocity;
        return -Seek(posPre);
    }
}
