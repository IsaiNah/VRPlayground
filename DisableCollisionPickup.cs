using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollisionPickup : MonoBehaviour
{
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("DisableCollisionPickup Start");
        // Getting the collider
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableCollision()
    {
        /* (gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;*/
        collider.enabled = false;
       // Debug.Log("Collider disabled");

    }

    public void EnableCollision()
    {
        /*(gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;*/
        collider.enabled = true;
       // Debug.Log("Collider enabled");
    }
}
