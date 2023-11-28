using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
 protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);

        if (interactor is XRDirectInteractor)
        Climb.climbHand = interactor.GetComponent<XRController>();

    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        Debug.Log("Testing Interactor name " + interactor.name);
        //Causes falling 
        if (interactor is XRGrabInteractable)
        {
            if (Climb.climbHand && Climb.climbHand.name == interactor.name)
            {
                Climb.climbHand = null;
            }

        }
    }
}

