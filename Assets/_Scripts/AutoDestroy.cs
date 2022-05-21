using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Tiempo despues del cual se destruye el objeto")]
    public float destructionDelay;
  
    void OnEnable()
    {
        //Destroy(gameObject, destruccionDelay);
        Invoke(nameof(HideObject), destructionDelay);
    }

    void HideObject()
    {
        gameObject.SetActive(false);
    }
}
