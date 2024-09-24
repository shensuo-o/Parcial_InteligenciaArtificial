using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    [SerializeField] protected float ArriveRadius;

    public void Start()
    {
        GameManager.Instance.boids.Add(this);

        AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)));
    }

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

    Vector3 Alignment(List<Boid> boids, float radius)
    {
        Vector3 desiredDirection = Vector3.zero;
        int count = 0;

        foreach (var boid in boids) 
        {
            if (Vector3.Distance(transform.position, boid.transform.position) > radius || boid == this)
            {
                continue;
            }
            desiredDirection += boid._velocity;
            count++;
        }

        if (count == 0)
        {
            return Vector3.zero;
        }

        desiredDirection /= count;

        desiredDirection.Normalize();
        desiredDirection *= _maxVelocity;

        var steering = desiredDirection - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSteering);

        return steering;
    }

    Vector3 Separation(List<Boid> boids, float radius)
    {
        Vector3 desiredDirection = Vector3.zero;

        foreach (Boid boid in boids)
        {
            var dir = transform.position - boid.transform.position;

            if (dir.magnitude > radius || boid == this)
            {
                continue;
            }

            desiredDirection += dir;
        }

        if(desiredDirection == Vector3.zero)
        {
            return desiredDirection;
        }

        desiredDirection.Normalize();
        desiredDirection *= _maxVelocity;

        var steering = desiredDirection - _velocity;
        steering = Vector3.ClampMagnitude(-steering, _maxSteering);

        return steering;
    }

    public Vector3 Cohesion(List<Boid> boids, float radius)
    {
        var desiredDirection = Vector3.zero;
        int count = 0;

        foreach(var boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) > radius || boid == this)
            {
                continue;
            }
            desiredDirection += boid.transform.position;
            count++;
        }

        if (count == 0)
        {
            return Vector3.zero;
        }
        desiredDirection /= count;
        desiredDirection -= transform.position;
        desiredDirection.Normalize();
        desiredDirection *= _maxVelocity;
        
        var steering = desiredDirection - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSteering);
        return steering;
    }


    public void Flocking()
    {
        Debug.Log("Hago Flocking");
        AddForce(Alignment(GameManager.Instance.boids, GameManager.Instance.AlignmentRadius) * GameManager.Instance.AlignmentWeigth);
        AddForce(Separation(GameManager.Instance.boids, GameManager.Instance.SeparationRadius) * GameManager.Instance.SeparationWeigth);
        AddForce(Cohesion(GameManager.Instance.boids, GameManager.Instance.CohesionRadius) * GameManager.Instance.CohesionWeigth);
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

    public Vector3 Arrive(Vector3 target)
    {
        var desired = target - transform.position;

        float distance = desired.magnitude;

        if (distance >= ArriveRadius)
        {
            return Seek(target);
        }
        else
        {
            desired.Normalize();
            desired *= _maxVelocity * (distance / ArriveRadius);

            var steering = desired - _velocity;
            steering = Vector3.ClampMagnitude(steering, _maxSteering);

            return steering;
        }
    }

    public Vector3 Evade(Character hunter)
    {
        Debug.Log("Estoy huyendo");
        var posPre = hunter.transform.position + hunter.Velocity;
        return -Seek(posPre);
    }
}
