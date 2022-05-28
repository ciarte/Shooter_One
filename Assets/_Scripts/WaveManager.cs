using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
{
   public static WaveManager SharedInstance;
   private List<WaveSpawner> waves;

   public UnityEvent onWaveChange;
    public int WavesCount => waves.Count;

    private int maxWaves;
    public int MaxWaves
    {
        get => maxWaves;
    }
    
    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            waves = new List<WaveSpawner>();
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddWave(WaveSpawner wave)
    {
        maxWaves++;
        waves.Add(wave);
        onWaveChange.Invoke();
    }
    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onWaveChange.Invoke();
    }

}
