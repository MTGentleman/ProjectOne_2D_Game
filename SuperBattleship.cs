using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDestroyer : MonoBehaviour
{
    float SPEED_LIMIT_X = 0.5f;
    public float vx;
    public float vy;
    public float energy;
    public bool shieldUp;
    Transform t;
    Rigidbody2D rb2d;
    void Start()
    {
        shieldUp = false;
        t = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        vx = rb2d.velocity.x;
        vy = rb2d.velocity.y;
        verticalChecker();
        speedLimiter();
    }
    void verticalChecker()
    {
        if (vy != 0)
        {
            rb2d.velocity = new Vector2(vx, 0);
            t.position = new Vector2(t.position.x, 0);
        }
    }
    void speedLimiter()
    {
        if (SPEED_LIMIT_X < vx)
        { rb2d.velocity = new Vector2(0.5f, 0); }
        if (-SPEED_LIMIT_X > vx)
        { rb2d.velocity = new Vector2(-0.5f, 0); }
    }
}
