using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float time;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCloud());
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateCloud()
    {
        while(true)
        {
            //Debug.Log("TOTAL >>>>>>>>>>>>>>>>>" + (time - gameController.timePlus));
            yield return new WaitForSeconds(time);
            Instantiate(cloudPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
       
    }
}
