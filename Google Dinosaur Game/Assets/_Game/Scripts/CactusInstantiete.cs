using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusInstantiete : MonoBehaviour
{
    public GameObject[] cactus;
    public Transform cactosParent;
    private GameController gameController;
    private bool gameStarted;
    private bool startedCreateCloud;
    [HideInInspector] public float timer;
    private EnemiesController enemiesController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        enemiesController = FindObjectOfType<EnemiesController>();
        gameStarted = gameController.gameStarted;
        startedCreateCloud = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameStarted = gameController.gameStarted;
        VerifyCreateCactos();
    }

    private void VerifyCreateCactos()
    {
        if (gameStarted && !startedCreateCloud)
        {
            timer = enemiesController.timerCreate;
            startedCreateCloud = true;
            StartCoroutine(CreateCactus());
        }  
    }

    private IEnumerator CreateCactus()
    {
        yield return new WaitForSeconds(timer);
        int newCactoIndex = Random.Range(0, 6);
        float posY = this.transform.position.y;

        if (newCactoIndex == 3)
        {
            posY = this.transform.position.y - 0.4f;
        }
        else if (newCactoIndex == 4 || newCactoIndex == 5)
        {
            posY = this.transform.position.y - 0.2f;
        }

        Instantiate(cactus[newCactoIndex], new Vector2(this.transform.position.x, posY), Quaternion.identity, cactosParent);

        StopCoroutine(CreateCactus());
        startedCreateCloud = false;
    }
}
