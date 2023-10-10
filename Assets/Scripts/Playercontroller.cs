using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 0.02f;             // A variable that is outside a function and is public, is called field.
    public float jumpforce = 7;           // Start is called before the first frame update
    public float gravity;
    public float jumpspin = 2;
    public float fallgravity = -2;
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
    
// This is fucked up, fixed it:
    private void FixedUpdate()      // Esta funcion tiene que ver con caer mas rapido al saltar.
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.angularVelocity = new Vector3(jumpspin, 0, 0);
        Vector3 velocity = rigidbody.velocity;
        if (velocity.y < - 1f)
        {
            rigidbody.AddForce(0, fallgravity, 0);
        }

        velocity.z = speed;
        rigidbody.velocity = velocity;

        // transform.Translate(0,0,speed * Time.fixedDeltaTime, Space.World); Nos cargamos esto de aqui para sustituirlo por lo que esta justo arriva.
        // Aqui multiplicamos el speed por Time.fixedDeltaTime para que la velocidad del player este ligada al tiempo que ha pasado desde el ultimo update.
        // Y lo hemos movido de Udate a FixedUpdate para obligar al PC ha hacer la cosa (translate = movement) 15 veces por segundo.
        // Asi un pc lento simulara las 15 translaciones aunque no se puedan ver en pantalla. Lo que hace que no se salta la trampa. que te la comas aunque parezca que se la salta.
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetButton("Jump") && istouchingground()) 
            // Jump sucede por la modificacion de dos variables. fuerza hacia arriba y grabedad.
            // La masa no afecta en la caida pero en la fuerza hacia arriba.
            // && GameObject (esta en contacto con el suelo o no esta en el aire)
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            Vector3 velocity = rigidbody.velocity;
            velocity.y = jumpforce;
            rigidbody.velocity = velocity;
            rigidbody.angularVelocity = new Vector3(jumpspin, 0, 0);     // Este es el giro al saltar.
        }
    }

    bool istouchingground()
    {
        int layerMask = LayerMask.GetMask("Ground");
        return Physics.CheckBox(transform.position, transform.lossyScale / 1.99f, transform.rotation, layerMask);
    }
}
// Por que se mueve hacia adelante cuando salta si el transform es un else? Answer: No es un else.
// Se mueve porque en cuanto la fuerza es aplicada, inmediatamente despues el player se sigue moviendo ahcia adelante.
// Por que 300 no lleva un f? Porque no tiene decimales. Funciona como un int.
// Por que speed es un public variable but jumpforce is not? Al estar fuera de la funcion, hago que la variable funcione
// en funciones mas adelante. Al hacerla publica hago que pueda modificarla later en unity.

// Lo que sea que tengas que hacer con la camara, tiene que ver con la ubicacion inicial del player
// Input funciona por cada frame no se que. Las fisicas funcionan deben ir en Fixupdates.

// Tengo que anadir un physic material no friction al player.