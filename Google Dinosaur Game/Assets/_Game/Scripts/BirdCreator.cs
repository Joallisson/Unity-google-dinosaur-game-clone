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
        Instantiate(bird, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, birdParent);
    }
}
