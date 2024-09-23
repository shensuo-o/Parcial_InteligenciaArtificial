using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject frutaPrefab;
    public Vector3 coordenadas;
    [Tooltip("cuanto se extiende en X el area")]
    public float areaX;
    [Tooltip("cuanto se extiende en Y el area")]
    public float areaY;
    [Tooltip("Area total")]
    public float area; //area total
    [Tooltip("Variabel que gaurda que fruta se instancia")]
    public GameObject frutaInstanciada;

    public Boid boid;
    public void Start()
    {
        Create();

    }
    public void Create()
    {
        area = areaX * areaY;
        coordenadas = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
        frutaInstanciada = Instantiate(frutaPrefab, coordenadas, Quaternion.identity);
        boid.SetTarget(frutaInstanciada.transform);
    }

    public void DestroyFruit()
    {
        if (frutaInstanciada != null)
        {
            Destroy(frutaInstanciada);
        }
            Create();
    }

}
