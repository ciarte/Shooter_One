using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        //Destroy(gameObject); PROHIBIDO, OBJECT POOLING ES MEJOR

        gameObject.SetActive(false);//desactiva la bala

        /* if (other.CompareTag("Enemy") || other.CompareTag("Player"))
         {
             Destroy(other.gameObject);//destuye el otro objeto (enemigo o player)
         }*/

        Life life = other.GetComponent<Life>();

        if(life != null)
        {
            life.Amount -= damage;
        }


    }
}
