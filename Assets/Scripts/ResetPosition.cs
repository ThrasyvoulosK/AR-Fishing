using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OriginalPosition()
    {
        gameObject.transform.position = startingPosition.transform.position;
        gameObject.transform.rotation = startingPosition.transform.rotation;
    }
}
