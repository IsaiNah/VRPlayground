using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrapActivate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        AxeActivate.Instance.Activate();
    }
}
