using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void TestDelegate(string name);
public class Turret : BaseController
{   
    public event TestDelegate TestEvent;   
    public Transform tankTransform;
    public float detectionDistance = 4f;
    [SerializeField]private float timeBeforeFire = 0f;
    private float _Timer;
    private bool _isTankDetected;

    private void Start()
    {
        timeBeforeFire = 0f; 
    }

    private void Update()
    {
        isTankDetected();
        FireTimer();
        
        
    }

    private void FixedUpdate()
    { 
        
        
    }

    private void isTankDetected()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position);
        if (Physics.Raycast(headTransform.position, direction, out hit, 800f))
        {
            if (hit.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                Debug.DrawRay(headTransform.position,direction,Color.red,1f);
                Debug.Log("J'ai choppé un truc!!!!");
                headTransform.forward = (new Vector3(direction.x, 0f, direction.z));
                if (timeBeforeFire >= 2f)
                {
                    Debug.Log("prout");
                    LaunchBullet(projectilePrefab, projectileSpawnPoint.position,headTransform.forward);
                    timeBeforeFire = 0f;
                    
                }
            }
        }
    }

    private void FireTimer()
    {
        timeBeforeFire += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Bullet>())
            TestEvent("paf");
    }
}
