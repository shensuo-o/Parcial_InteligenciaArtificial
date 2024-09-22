using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Node rootNode;
    public bool hunter;
    public bool fruit;

    [SerializeField] Transform target; //Objetivo del Seek.

    Vector3 _velocity; //Velocidad del Boid.

    [SerializeField] float _maxVelocity; //Velocidad maxima del Boid.
    [Range(0f, 1f)]
    [SerializeField] float _maxSteering; //Que tan brusca es la curva del Seek.

    private void Update()
    {
        rootNode.ExecuteBoid(this);

        Seek(target.position); //Llamado a Seek.
        transform.position += _velocity * Time.deltaTime; //Hace que se mueva.
        transform.forward = _velocity; //Hace que el Boid mire a donde va.
    }

    //AddForce hace que el Boid se mueva en una direccion con una velocidad maxima.
    public void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }

    public void Flocking()
    {
        Debug.Log("Hago Flocking");
    }

    public void Seek(Vector3 target)
    {
        Debug.Log("Estoy yendo a la fruta");
        Vector3 desiredVelocity = target - transform.position; //Hacia donde quiere ir.
        desiredVelocity.Normalize(); //Normaliza la velocidad deseada, para que sea de 1 en 1.
        desiredVelocity *= _maxVelocity; //Setea la velocidad maxima.

        Vector3 steeringVelocity = desiredVelocity - _velocity; //En que direccion va a ser la curva. 
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, _maxSteering); //Definde que tan brusca es la curva del steering. Mas grande mas rapido gira.
        AddForce(steeringVelocity); //Hace que avance en la direccion del Seek.
    }

    public void Evade()
    {
        Debug.Log("Estoy huyendo");
    }
}
