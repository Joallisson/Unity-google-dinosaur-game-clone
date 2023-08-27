using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float speedTexture;
    private GameController gameController;
    private float initailSpeedTexture;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        gameController = FindObjectOfType<GameController>();
        initailSpeedTexture = speedTexture;
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

    public void IncrementVelocitySpeed()
    {
        speedTexture += 0.1f;
    }

    public void SetInitialVelocity()
    {
        speedTexture = initailSpeedTexture;
    }
}
