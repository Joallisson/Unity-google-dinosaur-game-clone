using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, startPos;
    private Transform cam;
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveParallax();
    }

    private void MoveParallax()
    {
        float rePos = cam.transform.position.x * (1 - parallaxSpeed);
        float distance = cam.transform.position.x * parallaxSpeed;

        transform.position = new Vector2(startPos + distance, transform.position.y);

        if(rePos > startPos + length)
        {
            startPos += length;
        }
        else if(rePos < startPos - length)
        {
            startPos -= length;
        }
    }
}
