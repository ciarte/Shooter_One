using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{[Tooltip("Puntos por enemigo")]
    public int pointsAmount = 10;


    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }

    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }
    private void DestroyEnemy()
    {

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke(nameof(PlayDestruccion), 1);

        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);

        Destroy(gameObject, 2);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }
    void PlayDestruccion()
    {
        ParticleSystem explosion = gameObject.GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
