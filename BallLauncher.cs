using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    [SerializeField] Rigidbody ball;
    [SerializeField] Transform target;
    [SerializeField] float maxVerticalDisplacement; // (H according to tutorial)
    [SerializeField] float gravity = -18; // Not earth gravity, can plug in other units or earth gravity from main controller script
    public bool launchBall = false;

    // Start is called before the first frame update
    void Start()
    {
        ball.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (launchBall)
            Launch();
    }


    void Launch()
    {
      // Physics.gravity = Vector3.up * gravity; // applys this gravity to physics engine; (not good. Change after)
        //ball.useGravity = true;
        ball.velocity = CalculateLaunchVelocity();
        print(CalculateLaunchVelocity());
    }

    Vector3 CalculateLaunchVelocity() 
    {
        float displacementY = target.position.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0 , target.position.z - ball.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * maxVerticalDisplacement);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2*maxVerticalDisplacement/gravity) + Mathf.Sqrt(2*(displacementY - maxVerticalDisplacement) / gravity));

        Debug.Log("CalculateLaunchVelocity Result = " + velocityXZ.normalized + " " + velocityY.normalized);
        return velocityXZ - velocityY;
    }

}
