using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    private List<Enemy> enemies;
    public int EnemyCount => enemies.Count;
    public UnityEvent onEnemyChange;
    private void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
            enemies = new List<Enemy>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onEnemyChange.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onEnemyChange.Invoke();
    }

}
