using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacleLayers;
    public Collider detectedTarget;
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);

        detectedTarget = null;

        //Hemos pasado el primer filtro, de la distancia
        foreach(Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
          
            //angulo que forma el vector de vision con el vector objetivo
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            //si el angulo es menor que al de la vision
            if(angleToCollider < angle)
            {
                //comprobar si hay o no obstaculos en la linea de vision
                if(!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstacleLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.red);
                    //guardamos referencia del objetivo detectado
                    detectedTarget = collider;
                    break;
                }
                else //hay hit
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        //gizmos del rango de vision
        Gizmos.color = Color.green;
        Vector3 rigthDir = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rigthDir * distance);

        Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDir * distance);
    }
}
