using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Character
{
    public Node rootNode;

    public bool Energia;
    public float Energy;
    public float PatrollEnergyCost;
    public float PursuitEnergyCost;

    public bool DistanciaRebaño;

    [Range(0f, 1f)]
    [SerializeField] float _maxSteering;

    [SerializeField] public Character target;

    [SerializeField] int currentTarget;
    [SerializeField] Transform[] targets;
    [SerializeField] float distanceThreshold;


    protected override void Update()
    {
        base.Update();
        rootNode.ExecuteHunter(this);

        if (Energy <= 0)
        {
            Energia = false;
        }

        if(Vector3.Distance(transform.position, targets[currentTarget].position) < distanceThreshold)
        {
            NextTarget();
        }
    }
    public void Descansar()
    {
        Debug.Log("Esta descansando");
        Energy += 10 * Time.deltaTime;
    }

    public void Patrullar()
    {
        Debug.Log("Esta patrullando");
        Energy -= PatrollEnergyCost *Time.deltaTime;
        AddForce(Seek(targets[currentTarget].position));
    }

    public Vector3 Perseguir(Character target)
    {
        Debug.Log("Esta persiguiendo");
        Energy -= PursuitEnergyCost * Time.deltaTime;
        var posPre = target.transform.position + target.Velocity; //Prediccion de donde va a estar el void.
        return Seek(posPre);
    }

    public Vector3 Seek(Vector3 target)
    {
        Debug.Log("Estoy yendo a la fruta");
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= _maxVelocity;

        Vector3 steeringVelocity = desiredVelocity - _velocity;        
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, _maxSteering);
        return steeringVelocity;
    }

    public void NextTarget()
    {
        Debug.Log("Cambio de target");
        currentTarget = (currentTarget + 1) % targets.Length;
    }
}
