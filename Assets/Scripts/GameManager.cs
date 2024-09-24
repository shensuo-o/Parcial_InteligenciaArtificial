using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public List<Boid> boids = new List<Boid>();
    public float AlignmentRadius;
    public float SeparationRadius;
    public float CohesionRadius;

    [Range(0, 1)]
    public float AlignmentWeigth;

    [Range(0, 1)]
    public float SeparationWeigth;

    [Range(0, 1)]
    public float CohesionWeigth;

    public float timer;
    public float spawnCD;

    public List<GameObject> frutas = new List<GameObject>();

    public Hunter Cazador;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        Create();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCD)
        {
            timer = 0;
            Create();
        }
    }

    public void Create()
    {
        area = areaX * areaY;
        coordenadas = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
        frutaInstanciada = Instantiate(frutaPrefab, coordenadas, Quaternion.identity);
        frutas.Add(frutaInstanciada);
    }

    public void DestroyFruit()
    {
        if (frutaInstanciada != null)
        {
            Destroy(frutaInstanciada);
        }
    }

}
