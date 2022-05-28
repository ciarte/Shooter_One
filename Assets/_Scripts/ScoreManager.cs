using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;

    [Tooltip("Cantidad de puntos de la partida actual")]
    [SerializeField]
    private int amount = 10;
    public int Amount
    {
        get => amount;
        set => amount = value;
    }
    private void Awake()
    {
            if(SharedInstance == null)
        {
            SharedInstance = this;
        }
            else
        {
            Debug.LogWarning("Score Manager duplicado; debe ser destruido", gameObject);
            Destroy(gameObject);
        }
    }

}
