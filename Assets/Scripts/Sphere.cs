using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 20;
    private void OnCollisionEnter(Collider other)
    {
        Vector3 velocity = other.GetComponent<Rigidbody>().velocity;
        velocity.y = jumpForce;
        other.GetComponent<Rigidbody>().velocity = velocity;
    }
}