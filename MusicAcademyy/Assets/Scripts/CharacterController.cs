using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float runSpeed = 5.0f;
    private bool run = false;

    public Transform cameraholder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50f;
    public float downLimit = 50f;
    
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
        {
            run = false;
        }
        
        Vector3 hareket = new Vector3(yatay,0.0f, dikey);
        hareket = transform.TransformDirection(hareket);

        float speed = run ? runSpeed : moveSpeed;
        _animator.SetFloat("speed",speed* (Math.Abs(dikey) +Math.Abs(yatay))/1.5f);
        if (hareket != Vector3.zero)
        {
            transform.Translate(hareket * speed * Time.deltaTime,Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(hareket);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.01f);
        }
        else
        {
            _animator.SetFloat("speed", 0.0f);
        }

        rotate();
    }

    public void rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        
        transform.Rotate(0,horizontalRotation*mouseSensitivity,0f);
        cameraholder.Rotate(-verticalRotation * mouseSensitivity,0,0);

        Vector3 currentRotation = cameraholder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraholder.localRotation = Quaternion.Euler(currentRotation);
    }
}