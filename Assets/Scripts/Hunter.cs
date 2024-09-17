using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    // Start is called before the first frame update
    public Node rootNode;
    public bool Energia;
    public bool DistanciaRebaño;


    private void Update()
    {
        rootNode.Execute(this);
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
