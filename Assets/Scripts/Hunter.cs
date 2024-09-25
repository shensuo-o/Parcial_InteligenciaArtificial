using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Hunter : Character
{
    public Node rootNode;

    public bool Energia;
    public float Energy;
    public float PatrollEnergyCost;
    public float PursuitEnergyCost;
    public float FullEnergy;

    public bool DistanciaRebaño;

    [Range(0f, 1f)]
    [SerializeField] float _maxSteering;

    [SerializeField] public Character target;

    [SerializeField] int currentTarget;
    [SerializeField] Transform[] targets;
    [SerializeField] float distanceThreshold;

    FSM _fsm;

    private void Start()
    {
        _fsm = new FSM();

        _fsm.CreateState("Rest", new Rest(_fsm));
        _fsm.CreateState("Hunt", new Hunt(_fsm));
        _fsm.CreateState("Patroll", new Patroll(_fsm, Energy));

        _fsm.ChangeState("Patroll");
    }

    protected override void Update()
    {
        base.Update();
        rootNode.ExecuteHunter(this);

        if (Energy <= 0)
        {
            Energia = false;
            DistanciaRebaño = false;
        }
        else if (Energy > 0)
        {
            Detector(GameManager.Instance.boids, detectionRadius);
            Kill(GameManager.Instance.boids, touchRadius);
        }

        if(Vector3.Distance(transform.position, targets[currentTarget].position) < distanceThreshold)
        {
            NextTarget();
        }

        _fsm.Execute();

        
    }

    public void Detector(List<Boid> boids, float radius)
    {
        foreach (var boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < radius)
            {
                DistanciaRebaño = true;
            }
            else
            {
                DistanciaRebaño = false;
            }
        }
    }

    public void Kill(List<Boid> boids, float radius)
    {
        foreach (var boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < touchRadius)
            {
                GameManager.Instance.boids.Remove(boid);
                Destroy(boid);
                DistanciaRebaño = false;
            }
        }
    }

    public void Descansar()
    {
        Debug.Log("Esta descansando");
        _velocity = Vector3.zero;
        Energy += 10 * Time.deltaTime;
        if (Energy >= FullEnergy)
        {
            Energia = true;
        }
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
