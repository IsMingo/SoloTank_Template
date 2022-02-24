using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : BaseController
{
    public Transform tankTransform;
    public float detectionDistance = 4f;
    private float timeBeforeFire;
    private float _Timer;
    private bool _isTankDetected;

    private void Update()
    {
        isTankDetected();
    }

    private void isTankDetected()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position);
        if (Physics.Raycast(headTransform.position, direction, out hit, 100f))
        {
            if (hit.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                Debug.DrawRay(headTransform.position,direction,Color.red,1f);
                Debug.Log("J'ai choppé un truc!!!!");
                headTransform.forward = (new Vector3(direction.x, 0f, direction.z));
                if (timeBeforeFire>2f)
                {
                    timeBeforeFire = 0f;
                    Instantiate(projectilePrefab);
                }
            }
        }
    }

    private void FireTimer()
    {
        timeBeforeFire = +Time.fixedDeltaTime;
    }
}
