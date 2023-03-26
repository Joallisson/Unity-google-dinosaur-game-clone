using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusInstantiete : MonoBehaviour
{
    public GameObject[] cactus;
    public Transform cactosParent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCactus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateCactus()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            int newCactoIndex = Random.Range(0, 6);
            float posY = this.transform.position.y;

            if (newCactoIndex == 3)
            {
                posY = this.transform.position.y - 0.4f;
            }
            else if(newCactoIndex == 4 || newCactoIndex == 5)
            {
                posY = this.transform.position.y - 0.2f;
            }
           
            Instantiate(cactus[newCactoIndex], new Vector2(this.transform.position.x, posY), Quaternion.identity, cactosParent);
        }
    }
}
