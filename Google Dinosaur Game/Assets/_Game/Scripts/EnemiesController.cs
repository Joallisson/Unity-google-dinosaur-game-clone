using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private CactusInstantiete cactoCreate;
    private BirdCreator birdCreate;
    public float timerCreate, timerInterval;

    private bool startedGame, startedCoroutine;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        startedCoroutine = false;
        cactoCreate = FindObjectOfType<CactusInstantiete>();
        birdCreate = FindObjectOfType<BirdCreator>();
        cactoCreate.gameObject.SetActive(false);
        //birdCreate.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(timerInterval);
        Debug.Log(">>>>>>>>>>>>>>>>>>>>> CRIOU UM INIMIGO");
        birdCreate.InitCreateBird();
        StopCoroutine(CreateEnemy());
        startedCoroutine = false;
    }

    public void StopCreateEnemies()
    {
        StopAllCoroutines();
        startedCoroutine = false;
    }


}
