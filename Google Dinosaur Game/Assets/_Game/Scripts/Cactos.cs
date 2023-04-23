using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactos : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //rb2D.velocity = new Vector2(Time.deltaTime * -500f, 0);
        this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * 10f, Space.World);
    }
}
