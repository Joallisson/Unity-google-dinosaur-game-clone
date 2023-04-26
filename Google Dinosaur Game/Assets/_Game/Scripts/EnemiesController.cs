using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private CactusInstantiete cactoCreate;
    private BirdCreator birdCreate;
    public float timerInterval;
    private bool startedGame, startedCoroutine;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        startedCoroutine = false;
        cactoCreate = FindObjectOfType<CactusInstantiete>();
        birdCreate = FindObjectOfType<BirdCreator>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        InitCreateEnemy();
    }

    private void InitCreateEnemy()
    {
        startedGame = gameController.gameStarted;

        if (startedGame && !startedCoroutine)
        {
            startedCoroutine = true;
            StartCoroutine(CreateEnemy());
        }
    }

    private IEnumerator CreateEnemy()
    {
        int numberRandomEnemy = Random.Range(1, 11);
       
        yield return new WaitForSeconds(1.2f);

        if (numberRandomEnemy <= 3)
        {
            birdCreate.CreateBird();
        }
        else
        {
            cactoCreate.CreateCactus();
        }

        StopCoroutine(CreateEnemy());
        startedCoroutine = false;
    }

    public void StopCreateEnemies()
    {
        StopAllCoroutines();
        startedCoroutine = false;
    }
}
