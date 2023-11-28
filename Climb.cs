using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climb : MonoBehaviour
{
    private CharacterController character;
    public static  XRController climbHand;
    private ContinuesMovement continuesMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuesMovement = GetComponent<ContinuesMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (climbHand)
        {
            continuesMovement.enabled = false;
            CanClimb();
        }
    }

    // Applying the negative velocity (hand going down after grab) to propel player by same value
    private void CanClimb()
    {
        InputDevices.GetDeviceAtXRNode(climbHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
       
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
