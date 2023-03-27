using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float time;
    public Transform  cloudParent;
    private bool isInvoking;
    public GameObject cloudPrefab;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        isInvoking = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartInvoke();
    }

    private void StartInvoke()
    {
        if(!isInvoking && gameController.gameStarted)
        {
            isInvoking = true;
            float newTime = time -  gameController.timePlus;
            Invoke("CreateCloud", newTime);
        }
    }

    private void CreateCloud()
    {
        Instantiate(cloudPrefab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, cloudParent);
        isInvoking = false;
}

}
