using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates a line from the end of the rod to the sphere
public class LineScript : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField]
    Transform startingPoint;
    [SerializeField]
    Transform endingPoint;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, startingPoint.position);
        lineRenderer.SetPosition(1, endingPoint.position);
    }
}
