using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    public bool teleport = false;
    public Transform teleportPosition, spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint)
            transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (teleport)
            TelerportToA();*/
    }

    public void TelerportToA()
    {
        Debug.Log("TelerportToA colliding");
        //transform.position = new Vector3(180f,1.38f,175f);
        transform.position = teleportPosition.position;
    }
}
