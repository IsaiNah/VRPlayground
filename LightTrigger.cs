using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{

/*    private void OnCollisionEnter(Collision collision)
    {
        transform.parent.GetComponent<LightController>().CollisionDetected(this);
        Debug.Log("Child is colliding");
    }*/

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<LightController>().CollisionDetected(this);
        Debug.Log("Child is colliding BUMBACLOT");
    }

    
}
