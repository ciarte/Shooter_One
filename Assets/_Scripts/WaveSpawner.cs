using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("Prefab de enemigos a generar")]
    public GameObject prefab;

    [Tooltip("Tiempo en que inicia y finaliza la oleada")]
    public float starTime, endTime;

    [Tooltip("Tiempo entre la generacion de enemigos")]
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), starTime, spawnRate);
        Invoke(nameof(CancelInvoke), endTime);
    }

    void SpawnEnemy()
    {  
        /*Quaternion q = Quaternion.Euler(x: 0, 
            y: transform.rotation.eulerAngles.y + Random.Range(-45.0f, 45.0f),z: 0);
        */
        Instantiate(prefab, transform.position, transform.rotation);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
