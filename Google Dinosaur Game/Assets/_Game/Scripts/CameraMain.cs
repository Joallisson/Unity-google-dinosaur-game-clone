using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    private Transform cam;
    public float speed, count;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        cam = Camera.main.transform;
        count = speed;
    }

    private void FixedUpdate()
    {
        MoveCam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveCam()
    {
        count += Time.deltaTime * speed + gameController.timePlus;
        cam.position = new Vector3(count, this.transform.position.y, this.transform.position.z);
    }
}
