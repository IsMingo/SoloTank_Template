using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tank : BaseController
{
    public float moveSpeed = 4f;
    public float rotateSpeed;
    private new Vector3 MoouseDirection;


    private void Update()
    {
        MoveTank();
    }

    public void MoveTank()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f,0f,.004f * moveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(.0f,0f,-.004f*moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f,-.05f,0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f,+.05f,0f);
        }
        
        GetMousePosition();
    }

    private void GetMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            headTransform.forward = new Vector3(4f, 0f, 0f);
            
        }

    }

    public void GetMouseClic()
    {
        
    }

    
}   

