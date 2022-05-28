using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Velocidad del personaje en N/s")]
    [Range(0, 1000)]
    public float speed;

    [Tooltip("Velocidad de Rotacion del personaje en Nwton/seg")]
    [Range (0,360)]
    public float rotationSpeed;

    private Rigidbody rb;
    private Animator _animator;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        //fisica de movimiento (espacio=velocidad*tiempo) incr S = V * incr t
        float space = speed*Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");//-1 a 1
        float vertical = Input.GetAxis("Vertical");//-1 a 1

        Vector3 dir = new Vector3( horizontal, 0, vertical);
        // Vector3 dir = new Vector3( 0, 0, vertical); para habilitar el bloque 39 y girar la camara con las teclas A,D
        // transform.Translate(dir.normalized * space);
        //FUERZA DE TRANSLACION
        rb.AddRelativeForce(dir.normalized * space);


        float angle = rotationSpeed*Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(xAngle: 0, yAngle: mouseX*angle, zAngle: 0);//gira con el mouse
        //UERZAQ DE ROTACION <=> TORQUE
        //transform.Rotate( 0, horizontal * angle, 0); girar la camara con las teclas A,D
        rb.AddRelativeTorque( 0,  mouseX * angle,  0);

        _animator.SetFloat("Velocity", rb.velocity.magnitude); //solo animacion de correr
       /* Animacion para correr pulsando shift, CORREGIR ANIMACIONES
        _animator.SetFloat("MoveX", horizontal);
        _animator.SetFloat("MoveY", vertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetFloat("Velocity", rb.velocity.magnitude);
        }
        else
        {
            if (Mathf.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01f)
            {
                _animator.SetFloat("Velocity", 0);
            }
            else
            {
                _animator.SetFloat("Velocity", 0.15f);
            }
        }




        /*
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //  this.transform.Translate(x: 0, y: 0, z: space);

        //  Es lo mismo que usar:
        //   this.transform.Translate(x: 0, y: 0, z: speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(x: 0, y: 0, z: -space);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(x: -space, y: 0, z: 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(x: space, y: 0, z: 0);
        }*/
    }
}
