using UnityEngine;

namespace DefaultNamespace
{
    public class Jump
    {
        
    }
}

void update()
{
    if (Input.GetButtonDown("Jump")) // && GameObject (esta en contacto con el suelo o no esta en el aire)
    {
        float jumpforce = 300;
        Rigidbody rigidbody = GameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(0,jumpforce, 0);
    }
}