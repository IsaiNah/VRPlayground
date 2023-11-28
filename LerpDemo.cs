using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;

    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPct = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startPos.position, endPos.position, lerpPct);
        transform.rotation = Quaternion.Lerp(startPos.rotation, endPos.rotation, lerpPct);
    }
}
