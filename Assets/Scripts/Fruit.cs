using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.frutas.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
