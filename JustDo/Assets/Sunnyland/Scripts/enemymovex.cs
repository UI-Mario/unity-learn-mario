using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class enemymovex : MonoBehaviour
{

    public Rigidbody2D dog;
    public float movespeed = 0.001f;
    public float xmax = -0.4f;
    public float xmin = -2.2f;
    // Use this for initialization
    void Start()
    {

        dog = GetComponent<Rigidbody2D>();
        dog.velocity = new Vector2(movespeed, dog.velocity.y);
        // Update is called once per frame

    }
    void Update() 
    {
        if (dog.position.x > xmax) 
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x),
                this.transform.localScale.y, this.transform.localScale.z);
            dog.velocity = new Vector2(movespeed, dog.velocity.y);

        }
        if (dog.position.x < xmin) 
        {
            dog.transform.localScale = new Vector3(-Mathf.Abs(dog.transform.localScale.x),
                dog.transform.localScale.y, dog.transform.localScale.z);
            dog.velocity = new Vector2(-movespeed, dog.velocity.y);
        }
    }
}
