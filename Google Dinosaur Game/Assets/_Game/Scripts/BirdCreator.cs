using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCreator : MonoBehaviour
{
    public GameObject bird;
    public Transform birdParent;

    private GameController gameController;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void CreateBird()
    {
        int random = Random.Range(0,2);
        float posY = -2.5f;

        //Se o random for 1 então o cria o passáro em cima, se for 0 cria em baixo
        if (random == 1f)
        {
            posY = 1f;
        }

        Instantiate(bird, new Vector2(this.transform.position.x, posY), Quaternion.identity, birdParent);
    }
}
