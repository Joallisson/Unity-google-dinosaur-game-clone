using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float speedTexture;
    private GameController gameController;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        Paralax();
    }

    private void Paralax()
    {
        if (gameController.isStartedGame)
        {
            meshRenderer.material.mainTextureOffset += new Vector2(speedTexture * Time.deltaTime, 0);
        }
    }
}
