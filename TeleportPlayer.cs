using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField]
    private TeleportPosition teleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scary trigger colliding");
        teleportPosition.TelerportToA();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Scary Collision detected");
    }
}
