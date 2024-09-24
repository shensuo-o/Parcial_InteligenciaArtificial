using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    Dictionary<string, IState> _states = new Dictionary<string, IState>(); 

    IState _currentState;

    public void CreateState(string name, IState state)
    {
        if (!_states.ContainsKey(name))
        {
            _states.Add(name, state);
        }
    }

    public void ChangeState(string name)
    {
        if (_states.ContainsKey(name))
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }
            _currentState = _states[name];
            _currentState.OnEnter();
        }
    }

    public void Execute()
    {
        if (_currentState != null)
        {
            _currentState.OnUpdate();
        }
    }
}
