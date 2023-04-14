using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusInstantiete : MonoBehaviour
{
    public GameObject[] cactus;
    public Transform cactosParent;
    [HideInInspector] public float timer;

    public void CreateCactus()
    {
        int newCactoIndex = Random.Range(0, 6);
        float posY = this.transform.position.y;

        Instantiate(cactus[newCactoIndex], new Vector2(this.transform.position.x, posY), Quaternion.identity, cactosParent);
    }
}
