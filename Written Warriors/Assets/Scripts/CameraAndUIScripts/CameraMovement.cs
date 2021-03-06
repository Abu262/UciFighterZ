﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public Camera C;
    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        FixedCameraFollowSmooth(C, P1.transform, P2.transform);
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 0.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;
        //Debug.Log(midpoint.x);

            // Distance between objects
            float distance = (t1.position - t2.position).magnitude;

            //if (distance >= 6f)
            //{
            //   cam.orthographicSize = distance;

            //}

            // Move camera a certain distance
            Vector3 newDistance = midpoint - cam.transform.forward * 5 * zoomFactor;
            //if (newDistance.x >= -6f && newDistance.x <= 6f)
            //{
            Vector3 cameraDestination = midpoint - cam.transform.forward * 5 * zoomFactor;
            cameraDestination = new Vector3(cameraDestination.x, cam.transform.position.y, cam.transform.position.z);
        // Adjust ortho size if we're using one of those
        // You specified to use MoveTowards instead of Slerp
        if (cameraDestination.x >= -11.0f && cameraDestination.x <= 11.0f && Hit == false)
        {
            cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

            // Snap when close enough to prevent annoying slerp behavior
            if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
                cam.transform.position = cameraDestination;
            //}
        }
        if (cameraDestination.x < -11.0f)
        {
            cameraDestination.x = -11.0f;
        }
        if (cameraDestination.x > 11.0f)
        {
            cameraDestination.x = 11.0f;
        }





    }
}
