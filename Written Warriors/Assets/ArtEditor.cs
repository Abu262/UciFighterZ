using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtEditor : MonoBehaviour
{

    public SpriteRenderer CurrentForm; //refernece to the sprite object
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
