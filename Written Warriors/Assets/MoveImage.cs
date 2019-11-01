using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<RectTransform>().localPosition += Vector3.right * 0.5f;
        if (gameObject.GetComponent<RectTransform>().localPosition.x >= 1280f)
        {
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-1280,0,0);
        }
    }
}
