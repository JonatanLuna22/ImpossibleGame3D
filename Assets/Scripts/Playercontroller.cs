using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 0.02f; // A variable that is outside a function and is public, is called field.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) 
            // Jump sucede por la modificacion de dos variables. fuerza hacia arriba y grabedad.
            // La masa no afecta en la caida pero en la fuerza hacia arriba.
            // && GameObject (esta en contacto con el suelo o no esta en el aire)
        {
            float jumpforce = 300;
            Rigidbody rigidbody = GameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(0,jumpforce, 0);
        }
        transform.Translate(0,0,speed);
    }
}
// Por que se mueve hacia adelante cuando salta si el transform es un else?
// Por que 300 no lleva un f?
// por que speed es un public variable but jumpforce is not?