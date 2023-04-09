using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    public float notaSayisi = 0.0f;
    private AudioSource _audioSource;
    public AudioClip _AudioClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            notaSayisi += 1;
            _audioSource.clip = _AudioClip;
            _audioSource.Play();
                Debug.Log("silindi");
            
            Destroy(gameObject);
        }
        
    }
}
