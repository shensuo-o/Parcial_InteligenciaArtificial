using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float _maxVelocity;
    protected Vector3 _velocity;

    [SerializeField] protected float touchRadius;
    [SerializeField] protected float detectionRadius;
    [SerializeField] public float FruitRadius;
    [SerializeField] public float HunterRadius;

    public Vector3 Velocity { get { return _velocity; } }
    public float MaxVelocity { get { return _maxVelocity; } }

    protected virtual void Update()
    {
        transform.position =LimitManager.instance.ApplyBounds(transform.position + _velocity * Time.deltaTime);
        transform.forward = _velocity * Time.deltaTime;
    }

    public virtual void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }
}
