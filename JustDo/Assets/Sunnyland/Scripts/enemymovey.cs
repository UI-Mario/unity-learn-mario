using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class enemymovey : MonoBehaviour
{

    public Rigidbody2D bird;
    public float movespeedy = 0.001f;
    public float ymax = -0.4f;
    public float ymin = -2.2f;
    // Use this for initialization
    void Start()
    {

        bird = GetComponent<Rigidbody2D>();
        bird.velocity = new Vector2(bird.velocity.x, movespeedy);
        // Update is called once per frame

    }
    void Update()
    {
        if (bird.position.y > ymax)
        {
            bird.velocity = new Vector2(bird.velocity.x,movespeedy);

        }
        if (bird.position.y < ymin)
        {
            bird.velocity = new Vector2(bird.velocity.x, -movespeedy);
        }
    }
}
