using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 0.02f; // A variable that is outside a function and is public, is called field.
    public float jumpforce = 300;                         // Start is called before the first frame update
    public float gravity;
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && istouchingground()) 
            // Jump sucede por la modificacion de dos variables. fuerza hacia arriba y grabedad.
            // La masa no afecta en la caida pero en la fuerza hacia arriba.
            // && GameObject (esta en contacto con el suelo o no esta en el aire)
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(0,jumpforce, 0);
        }
        transform.Translate(0,0,speed);
    }

    bool istouchingground()
    {
        int layerMask = LayerMask.GetMask("Ground");
        return Physics.CheckBox(transform.position, transform.lossyScale / 1.99f, transform.rotation, layerMask);
    }
}
// Por que se mueve hacia adelante cuando salta si el transform es un else? No es un else.
// Se mueve porque en cuanto la fuerza y es aplicada, inmediatamente despues el player se sigue moviendo ahcia adelante.
// Por que 300 no lleva un f? Porque no tiene decimales. Funciona como un int.
// Por que speed es un public variable but jumpforce is not? Al estar fuera de la funcion, hago que la variable funcione
// en funciones mas adelante. Al hacerla publica hago que pueda modificarla later en unity.
// Error