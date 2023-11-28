using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ControlShipWheel : XRGrabInteractable
{
      //Right Hand
       [SerializeField] private GameObject rightHand;
       [SerializeField] private Transform rightOriginalParent;
       private bool rightHandOnWheel = false;

    //Left Hand
    [SerializeField] private GameObject leftHand;
    [SerializeField] private Transform leftOriginalParent;
    private bool leftHandOnWheel = false;

    //[SerializeField] private List<XRSimpleInteractable> handGrabPoints = new List<XRSimpleInteractable>();


    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    public enum TwoHandRotationType { None, First, Second };
    public TwoHandRotationType twoHandRotationType;

   // private List<Transform> grabCubeCTransformPositions = new List<Transform>();
    public GameObject[] grabCubes;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in secondHandGrabPoints)
        {
            item.onSelectEnter.AddListener(OnSecondHandGrab);
            item.onSelectExit.AddListener(OnSecondHandRelease);
        }

        //Start Method Testing Colliders
  /*      foreach (var item in colliders)
        {
            Debug.Log("Control Ship Wheel Item Collider" + item.gameObject);
            grabCubeCTransformPositions.Add(item.transform);
        }

        foreach (var item in grabCubeCTransformPositions)
        {
            Debug.Log("Testing grabcude Colliders " + item.name + " " + item.transform.localPosition);
        }
*/

        rightOriginalParent = rightHand.transform.parent;
        leftOriginalParent = leftHand.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindClosestAttachTransform(/*ref GameObject hand, ref bool handonwheel*/)
    {
        Debug.Log("FindClosestAttachTransform ");

        //Finding closest snappoint using distance from hand
        var shortestDistance = Vector3.Distance(grabCubes[0].transform.position, rightHand.transform.position);
        var bestSnapPos = grabCubes[0];
        foreach (var grabCube in grabCubes)
        {
            var distance = Vector3.Distance(grabCube.transform.position, rightHand.transform.position);

            if (distance < shortestDistance)
                bestSnapPos = grabCube;
        }

        /*hand.transform.position = bestSnapPos.transform.position;
        hand.transform.parent = bestSnapPos.transform.parent;

        handonwheel = true;*/

        rightHand.transform.parent = bestSnapPos.transform.parent;
        rightHand.transform.position = bestSnapPos.transform.position;
        /*leftHand.transform.parent = leftGrabCube.transform.parent;
        leftHand.transform.position = leftGrabCube.transform.position;*/
        rightHandOnWheel = true;
        //leftHandOnWheel = true;

/*
        GameObject currentGrabCube = grabCubes[0];
        GameObject leftGrabCube = grabCubes[6];
        rightHand.transform.parent = currentGrabCube.transform.parent;
        rightHand.transform.position = currentGrabCube.transform.position;
        leftHand.transform.parent = leftGrabCube.transform.parent;
        leftHand.transform.position = leftGrabCube.transform.position;
        rightHandOnWheel = true;
        leftHandOnWheel = true;*/

    }


    public void ReleaseHandsOffWheel()
    {
        Debug.Log("ReleaseHandsOffWheel ");
        rightHand.transform.parent = rightOriginalParent;
        rightHand.transform.position = rightOriginalParent.position;
      //  leftHand.transform.parent = leftOriginalParent;
       // leftHand.transform.position = leftOriginalParent.position;
        rightHandOnWheel = false ;
      //  leftHandOnWheel = false;
    }

    //Overridding how the object moves

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
        {
            // Complete rotation - roatate the pivot point to make it look in the direction of the rotation
            selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
            secondInteractor.attachTransform.rotation = GetTwoHandRotation();
        }
        base.ProcessInteractable(updatePhase);
    }

    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation;

        if (twoHandRotationType.Equals(TwoHandRotationType.None))
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        else if (twoHandRotationType.Equals(TwoHandRotationType.First))
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
        }

        return targetRotation;

        /*   if (twoHandRotationType == TwoHandRotationType.None)
           {
               targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
           }
           else if (twoHandRotationType == TwoHandRotationType.First)
           {
               targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
           }
           else
           {
               targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
           }

           return targetRotation;*/
    }

    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Second Hand Grab");
        secondInteractor = interactor;
        attachInitialRotation = interactor.attachTransform.localRotation; // Setting initial rotation to reset after release
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Second Hand Release");
        secondInteractor = null;
    }


    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        Debug.Log("First Grab Enter");
        base.OnSelectEnter(interactor);
        
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        Debug.Log("First Grab Exit");
        base.OnSelectExit(interactor);
        secondInteractor = null;
    }

    //Checking if already selectedby other hand
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }

}
