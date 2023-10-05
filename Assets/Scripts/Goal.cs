using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    IEnumerator OnCollisionEnter(Collision other)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Win Scene");
    }
}