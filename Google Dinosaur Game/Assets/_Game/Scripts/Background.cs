using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float speedTexture;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Paralax();
    }

    private void Paralax()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speedTexture * Time.deltaTime, 0);
    }
}
