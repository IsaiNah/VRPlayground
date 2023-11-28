using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
      /*  Debug.Log("XROffsetGrabInteractable Called");
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;*/
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {

/*        Debug.Log("OnSelectEnter Called");
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("interactor is XRDirectInteractor");
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
       else
        {
            Debug.Log("interactor not XRDirectInteractor");
            attachTransform.position = initialAttachLocalPos;
            attachTransform.rotation = initialAttachLocalRot;
        }
        
        base.OnSelectEnter(interactor);*/
    }
}
