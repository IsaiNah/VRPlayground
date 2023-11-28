using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
   
    private Vector3 moveToPosition;
    [SerializeField]
    private Transform wayPointA, wayPointB, wayPointC, wayPointD;
    private bool startMoving;
    private int lastMoveCall;
    private float timer = 5.0f;
    private DetectionCollider detectionCollider;
    private bool playerDetected;
    private Vector3 detectionPoint;


    // Start is called before the first frame update
    void Start()
    {
        //enemieBody.position = transform.localPosition; <- bad idea
        moveToPosition = wayPointA.position;
        Debug.Log("Move to position set : " + moveToPosition.x + "," + moveToPosition.y + "," + moveToPosition.z  + " | " + "Setting From " + wayPointA.position.x + "," + wayPointA.position.y + "," + wayPointA.position.z);
        startMoving = true;
        lastMoveCall = -1;
        detectionCollider = this.transform.parent.GetComponent<DetectionCollider>();
        playerDetected = false;
        //moveToPosition = this.transform.position + Vector3.forward * 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDetected) 
        { 
         if (startMoving)
         {

            //Set position after reaching it
 
             Vector3 relativePosition = transform.position - moveToPosition;
              Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.up);

                transform.rotation = rotation;
     
            transform.localPosition = Vector3.Lerp(transform.localPosition, moveToPosition, Time.deltaTime * 0.5f);
           
        }

        if (startMoving == false)
        {
            //start timer and set new position
            timer -= Time.deltaTime;
            if (timer <= 0) // TODO Create randomizer for amount of seconds to wait
            {
                Debug.Log("timer expired");


               // Transform moveNext = MoveToNextPosition(moveToPosition);
                moveToPosition =   MoveToNextPosition(moveToPosition);

                timer = 5.0f;
                startMoving = true;
            }

        }
        
        }else
        {

            Vector3 relativePosition = transform.position - detectionPoint;
            Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.up);

            transform.rotation = rotation;
            transform.localPosition = Vector3.Lerp(transform.localPosition, detectionPoint, Time.deltaTime * 0.5f);
        }

    }

    private Vector3 MoveToNextPosition(Vector3 currentpos)
    {
        Vector3 nextLocation = currentpos;
        //Gen random number to move to pos


        //  int wheretogo = Random.Range(0,3);
        int wheretogo = RandomLocation(lastMoveCall, 0, 4);
        while (wheretogo == lastMoveCall)
          wheretogo =  RandomLocation(lastMoveCall, 0 , 4);
      

        switch(wheretogo)
        {
            case 0:
                Debug.Log("Picked A");
              
                    Debug.Log("lastMoveCall|wheretogo " + lastMoveCall + "|" + wheretogo);
                    nextLocation = wayPointA.position;
                    lastMoveCall = 0;
                
                break;
            case 1:
                Debug.Log("Picked B");
              
                    Debug.Log("lastMoveCall|wheretogo " + lastMoveCall + "|" + wheretogo);
                    nextLocation = wayPointB.position;
                    lastMoveCall = 1;
                
                break;
            case 2:
                Debug.Log("Picked C");
       
                    Debug.Log("lastMoveCall|wheretogo " + lastMoveCall + "|" + wheretogo);
                    nextLocation = wayPointC.position;
                    lastMoveCall = 2;
               
                break;
            case 3:
                Debug.Log("Picked D");
             
                    Debug.Log("lastMoveCall|wheretogo " + lastMoveCall + "|" + wheretogo);
                    nextLocation = wayPointD.position;
                    lastMoveCall = 3;
             
                break;
        }
      
        return nextLocation;
    }

    private int RandomLocation(int lastMove, int minRange, int maxRange)
    {
        int gohere;

        gohere = Random.Range(minRange, maxRange);

        return gohere;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Waypoint entered");
        startMoving = false;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void Detected(Vector3 detectionPoint)
    {
        Debug.Log("EnemieController | Detected| External Call | Calling from DetectionCollider");

        // Set player detected to true
        this.detectionPoint = detectionPoint;
        playerDetected = true;

    }

    public void StopChase(bool playerDetected)
    {
        this.playerDetected = playerDetected;
    }
}
