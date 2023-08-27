using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy = new GameObject[6];
    [SerializeField] private GameObject cactusParent;
    private GameController gameController;
    private float initailSpeedEnemy;
    private float currentTime = 0f;

    public float totalTimeInstantiate;
    public float speedEnemy;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //InvokeRepeating(nameof(SpawerEnemy), 2f, 4f);
        initailSpeedEnemy = speedEnemy;
    }

    void Update()
    {
        CountTimeInstantiate();
    }

    public void CreateEnemy()
    {

    }

    private void SpawerEnemy()
    {
        int indexEnemy = Random.Range(0, 6);
        GameObject newEnemy = Instantiate(enemy[indexEnemy], transform.position, Quaternion.identity);
        newEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newEnemy.transform.SetParent(cactusParent.transform);
    }

    public void DestroyAllEnemiesChildren()
    {
        foreach (Transform child in cactusParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void CountTimeInstantiate()
    {
        if (gameController.isStartedGame)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= totalTimeInstantiate)
            {
                SpawerEnemy();
                currentTime = 0;
            }
        }
    }

    public void IncrementVelocitySpeed()
    {
        speedEnemy = speedEnemy + 1f;
    }

    public void SetInitialVelocity()
    {
        speedEnemy = initailSpeedEnemy;
    }
}
