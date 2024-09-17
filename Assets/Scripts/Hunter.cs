using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Node rootNode;
    public bool Energia;
    public bool DistanciaRebaño;


    private void Update()
    {
        rootNode.ExecuteHunter(this);
    }
    public void Descansar()
    {
        Debug.Log("Esta descansando");
    }

    public void Patrullar()
    {
        Debug.Log("Esta patrullando");
    }

    public void Perseguir()
    {
        Debug.Log("Esta persiguiendo");
    }
}
