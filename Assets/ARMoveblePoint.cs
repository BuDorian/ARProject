using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMoveblePoint : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    private Vector3 starDist;


    void OnMouseEnter()
    {
        originalColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.localPosition, Camera.main.transform.localPosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        starDist = transform.localPosition - rayPoint;
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.localPosition = rayPoint + starDist;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.1f, transform.localPosition.z);
        }
    }
}
