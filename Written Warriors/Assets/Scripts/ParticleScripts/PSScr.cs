using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSScr : MonoBehaviour
{
    // public ParticleSystem ps;
    public float endtime;
    void Start()
    {
       StartCoroutine(killself());
    }

    IEnumerator killself()
    {
        yield return new WaitForSeconds(endtime);
        Destroy(gameObject);
    }
}
