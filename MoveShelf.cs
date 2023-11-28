using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShelf : MonoBehaviour
{
    public bool moveShelf;
    private Vector3 movePosition = new Vector3 (0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

        //  movePosition = transform.transform + movePosition.x * 5.0f;
       movePosition = this.transform.position + Vector3.left * 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveShelf)
        {
           // for (float i = 1.0f; i > 0; i = i - 0.5f)
           // {
                transform.localPosition = Vector3.Lerp(transform.localPosition, movePosition, Time.deltaTime * 0.3f);
           
            //}
        }
    }

    public void TriggerShelf()
    {
        moveShelf = true;
    }
}
