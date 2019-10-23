using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSScr : MonoBehaviour
{
   // public ParticleSystem ps;

    void Start()
    {
        StartCoroutine(killself());
    }

    IEnumerator killself()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
