using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy = new GameObject[6];
    void Start()
    {
        InvokeRepeating(nameof(SpawerEnemy), 2f, 4f);
    }

    void Update()
    {
        
    }

    private void SpawerEnemy()
    {
        int indexEnemy = Random.Range(0, 6);
        GameObject newEnemy = Instantiate(enemy[indexEnemy], transform.position, Quaternion.identity);
        newEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
