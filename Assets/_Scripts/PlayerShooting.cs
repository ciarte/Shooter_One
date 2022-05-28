using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public int bulletsAmount;
    private Animator _animator;
    public Weapon wepon;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
        {
            _animator.SetTrigger("Shot bullet");

            if (wepon.ShootBullet("Bullet Player", 0.02f) && bulletsAmount > 0)
            {
                bulletsAmount--;
                if(bulletsAmount < 0)
                {
                    bulletsAmount = 0;
                }
            }
        }
    }
}
