using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    Collider collider; 
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!collider.enabled)
        {
            Debug.Log("Collider is disabled, object pickedup. Triggering.");
            transform.parent.GetComponent<MoveShelf>().TriggerShelf();
        }
    }
    
    //Call parent to move shelf

}
