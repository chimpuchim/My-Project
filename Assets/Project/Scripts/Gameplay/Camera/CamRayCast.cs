using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRayCast : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit2D hit;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    
        if (hit.collider != null)
        {
            Debug.Log("Hit object name: " + hit.collider.gameObject.name);
        }
    }
}