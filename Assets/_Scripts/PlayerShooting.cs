using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shootingPoint;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {        
        GameObject bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("Bullet Player");
        bullet.transform.SetPositionAndRotation(shootingPoint.transform.position, shootingPoint.transform.rotation);
        bullet.SetActive(true);
        }
    }
}
