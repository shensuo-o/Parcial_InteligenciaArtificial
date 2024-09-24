using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : IState
{
    FSM _fsm;

    public float Energia;

    public Patroll(FSM fsm, float Energy)
    {
        _fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("Empezo a patrullar.");
    }

    public void OnUpdate()
    {
        Debug.Log("Esta patrullando.");
    }

    public void OnExit()
    {
        Debug.Log("Dejo de patrullar.");
    }
}
