using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeActivate : MonoBehaviour
{
    public static AxeActivate Instance {get; private set;}

    private HingeJoint hingeJoint;
    public bool activate/* = false*/;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject); // Prevents multiples 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useMotor = true;
        activate = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            hingeJoint.useMotor = false;

        }
    }

    public void Activate()
    {
        Debug.Log("External call");
        activate = true;
    }


}
