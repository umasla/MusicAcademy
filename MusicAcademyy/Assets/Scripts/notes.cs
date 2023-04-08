using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    public float notaSayisi = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
            notaSayisi += 1;
        }
    }
}
