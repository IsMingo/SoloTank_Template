using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;


public class Tank : BaseController
{
    
    public GameObject bulletObject;
    public float moveSpeed = 4f;
    private new Vector3 mouseDirection;
    private new float rotationSpeed = 0.0005f;
    public Turret Turret;
    public Turret[] Turrets;
    


    private void Start()
    {
        foreach (Turret turret in Turrets)
        {
            turret.TestEvent += BulletTestEvent;
        }
        

    }

    private void Update()
    {
        MoveTank();
        GetMousePosition();
        if (Input.GetMouseButtonDown(0))
        {
            LaunchBullet(bulletObject, projectileSpawnPoint.position,headTransform.forward);
        }
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
        
        
    }

    private void GetMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(ray.origin,ray.direction*200,Color.blue);
        
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            headTransform.LookAt(new Vector3(hit.point.x,headTransform.position.y,hit.point.z));
            
        }
        
    }

    public void GetMouseClic()
    {
        // Debug.Log("Test");
    }

    private void BulletTestEvent(string name)
    {
        Debug.Log("Pouf"+name);
    }

    
}   

    