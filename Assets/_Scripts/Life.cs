using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;

    public float Amount 
    {
        get => amount;
        set
        {
            amount = value;
            if (amount <= 0)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Play Die");

                Invoke("PlayDestruccion", 1);

                Destroy(gameObject, 2); 
            }
        }
    }

    void PlayDestruccion()
    {

        ParticleSystem explosion = gameObject.GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }

}
