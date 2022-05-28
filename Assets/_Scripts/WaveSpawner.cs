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
    
    private void Start()
    {
        WaveManager.SharedInstance.AddWave(this);
        InvokeRepeating(nameof(SpawnEnemy), starTime, spawnRate);
        Invoke(nameof(EndWave), endTime);
    }

    private void SpawnEnemy()
    {  
        /*Quaternion q = Quaternion.Euler(x: 0, 
            y: transform.rotation.eulerAngles.y + Random.Range(-45.0f, 45.0f),z: 0);
        */
        Instantiate(prefab, transform.position, transform.rotation);
       
    }

    private void EndWave()
    {
        WaveManager.SharedInstance.RemoveWave(this);
        CancelInvoke();
    }
}
