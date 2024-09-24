using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Rest : IState
{
    FSM _fsm;
    public Vector3 _velocity;
    public Rest(FSM fsm)
    {
        _fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("Empezo a descansar.");
    }

    public void OnUpdate()
    {
        Debug.Log("Esta descansando.");
    }

    public void OnExit()
    {
        Debug.Log("Dejo de descansar.");
    }
}
