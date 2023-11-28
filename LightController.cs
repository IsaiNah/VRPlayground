using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light light;
    private GameObject trigger;
    public Material changeToMaterial;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent(typeof(Light)) as Light;
       
        if (!light)
            Debug.Log("Light not initalized");
        else
        {
            Debug.Log("Light is initalized " + light.intensity);
          //  light.intensity = 10.0f;
         //   Debug.Log("Light intensity changed" + light.intensity);
        }
        trigger = transform.Find("Cube").gameObject;
        if (!trigger)
            Debug.Log("trigger not initalized");
        else
        {
            Debug.Log("trigger is initalized");
         
        }
        trigger.GetComponent<MeshRenderer>().material = changeToMaterial;
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollisionDetected(LightTrigger lightTrigger)
    {
        Debug.Log("Trigger Collision Detected");
        light.intensity = 0.0f;
    }
}
