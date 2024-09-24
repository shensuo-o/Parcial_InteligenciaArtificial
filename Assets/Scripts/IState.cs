using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IState
{
    void OnEnter();

    void OnUpdate();

    void OnExit();  
}
