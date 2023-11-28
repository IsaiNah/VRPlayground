using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollider : MonoBehaviour
{
    private EnemieController enemieController;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detection Collider | Robot Sees you");
     
        Vector3 detectionPoint = other.gameObject.transform.position;
        Debug.Log("TEST Logging detection point. " + detectionPoint.x + " " + detectionPoint.y + " " + detectionPoint.z);

        //enemieController = this.transform.GetComponent<EnemieController>();
        transform.parent.GetComponent<EnemieController>().Detected(detectionPoint);
        // EnemieController.Instance.Detected();
      
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Detection Collider | Robot Lost sight of you");
        //enemieController = this.transform.GetComponent<EnemieController>();
        transform.parent.GetComponent<EnemieController>().StopChase(false);
        //EnemieController.Instance.Detected();
    }
}
