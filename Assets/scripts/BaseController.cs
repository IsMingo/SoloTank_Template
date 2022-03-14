using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Transform headTransform;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    protected Vector3 Headdirection;
    
     protected void RotateHeadTowarDirection()
    {   
     
    }

    protected void HeadDirection()
    {
        
    }

    protected void LaunchBullet(GameObject bullet, Vector3 canonposition, Vector3 targetDirection)
    {
          
        Rigidbody bulletRb;
        GameObject bulleteLauch =Instantiate( bullet, canonposition,  Quaternion.identity);
        bulletRb = bulleteLauch.GetComponent<Rigidbody>();
        bulletRb.AddForce(targetDirection*5000f);
    }
}
