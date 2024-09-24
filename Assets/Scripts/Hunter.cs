using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Node rootNode;
    public bool Energia;
    public bool DistanciaRebaño;

    Vector3 _velocity;
    [SerializeField] float _maxVelocity;
    [Range(0f, 1f)]
    [SerializeField] float _maxSteering;
    [SerializeField] int currentTarget;
    [SerializeField] Transform[] targets;
    [SerializeField] float distanceThreshold;


    private void Update()
    {
        rootNode.ExecuteHunter(this);

        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;

        if(Vector3.Distance(transform.position, targets[currentTarget].position) < distanceThreshold)
        {
            NextTarget();
        }
    }
    public void Descansar()
    {
        Debug.Log("Esta descansando");
    }

    public void Patrullar()
    {
        Debug.Log("Esta patrullando");
        Seek(targets[currentTarget].position);
    }

    public void Perseguir()
    {
        Debug.Log("Esta persiguiendo");

    }

    public void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }

    public void Seek(Vector3 target)
    {
        Debug.Log("Estoy yendo a la fruta");
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= _maxVelocity;

        Vector3 steeringVelocity = desiredVelocity - _velocity;        
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, _maxSteering);
        AddForce(steeringVelocity);
    }

    public void NextTarget()
    {
        Debug.Log("Cambio de target");
        currentTarget = (currentTarget + 1) % targets.Length;
    }
}
