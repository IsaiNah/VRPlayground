using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{

    public XRController leftTeleportRay, rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool enableLeftTeleport { get; set; } = true;
    public bool enableRightTeleport { get; set; } = true;

    public XRRayInteractor leftInteractorRay, rightInteractorRay;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;


        if (leftTeleportRay)
        {
            // Debug.Log("leftTelePortRay Called");
            bool isLeftInteractorRayHovering = leftInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            leftTeleportRay.gameObject.SetActive(enableLeftTeleport && CheckIfActivated(leftTeleportRay) && !isLeftInteractorRayHovering);
            // Debug.Log("leftTelePortRay Result " + isLeftInteractorRayHovering);
        }
        if (rightTeleportRay)
        {

            // Debug.Log("RightTelePortRay Called");
            bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            rightTeleportRay.gameObject.SetActive(enableRightTeleport && CheckIfActivated(rightTeleportRay) && !isRightInteractorRayHovering);
            //   Debug.Log("rightTelePortRay Result " + isRightInteractorRayHovering);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {

     //   Debug.Log("Teleport check if Activated");
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);

        return isActivated;
    }



}
