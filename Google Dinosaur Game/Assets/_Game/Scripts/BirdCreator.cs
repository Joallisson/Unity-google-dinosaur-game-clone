using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCreator : MonoBehaviour
{
    public GameObject bird;
    public Transform birdParent;
    private bool gameStarted, startedCreateCloud;
    private GameController gameController;
    public float timer;
    private float timerControllerPlus;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        gameStarted = gameController.gameStarted;
        startedCreateCloud = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timerControllerPlus = gameController.timePlus;
        gameStarted = gameController.gameStarted;
        //VerifyCreateBird();
    }

    public void InitCreateBird()
    {
        if (gameStarted)
        {
            //startedCreateCloud = true;
            StartCoroutine(CreateBird());
        }
    }

    private IEnumerator CreateBird()
    {
        yield return new WaitForSeconds(0f);
        Instantiate(bird, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, birdParent);
        StopCoroutine(CreateBird());
        //startedCreateCloud = false;
    }
}
