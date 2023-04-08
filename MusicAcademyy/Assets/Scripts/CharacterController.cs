using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float runSpeed = 2f;
    public float rotationSpeed = 10.0f;
    private bool run = false;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
            run = false;

        Vector3 hareket = new Vector3(yatay, 0.0f, dikey);
        hareket = transform.TransformDirection(hareket);

        float speed = run ? runSpeed : moveSpeed;
        _animator.SetFloat("speed",speed* (Math.Abs(dikey)+Math.Abs(yatay)));
        
        Debug.Log(speed);
        transform.position += hareket * speed * Time.deltaTime;
    } 
}
