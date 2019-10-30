using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
   
    public Transform C;
    public Transform CL;
    public Transform cameraPos;
    // Use this for initialization
    void Start()
    {
        //Generate our empty objects
     
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        //Change our scale and positions to match the edges of the screen...   
        
        
     
    }
    private void FixedUpdate()
    {

        CL.position = new Vector3(cameraPos.position.x - screenSize.x - (CL.localScale.x * 0.5f), cameraPos.position.y, zPosition);
        C.position = new Vector3(cameraPos.position.x + screenSize.x + (C.localScale.x * 0.5f), cameraPos.position.y, zPosition);
    }
}
