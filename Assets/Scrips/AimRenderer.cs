using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRenderer : MonoBehaviour
{
    public Transform target; 
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (target == null)
        {
            Debug.LogError("Line Render es mi 20 en la PA2.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);
        }
    }
}

