using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] sprites = new Sprite[10];
    float SPEED_LIMIT = 1.25f;
    public int frame;
    public float diveTime;
    public float regeneratingCD;
    public float diveCD;
    public float vx;
    public float vy;
    public float changeFrameCD;
    public bool diving;
    Rigidbody2D rb2d;
	void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        frame = 0;
        changeFrameCD = 0.1f;
        diveTime = 2.5f;
        regeneratingCD = 1.5f;
        rb2d = GetComponent<Rigidbody2D>();
    }
	void Update ()
    {
        frameCheck();
        vx = rb2d.velocity.x;
        vy = rb2d.velocity.y;
        speedLimiter();
        if (Input.GetKey(KeyCode.E))
            dive(); 
        else { surface(); }
	}
    void dive()
    {
        if (diveTime > 0)
        {
            diving = true;
            rb2d.drag = 0.8f;
            regeneratingCD = 1.5f;
            diveTime -= Time.deltaTime;
            if ( vx > 0.5 ) { vx = 0.5f; }
            if ( vy > 0.5 ) { vy = 0.5f; }
            if ( vx < -0.5 ) { vx = -0.5f; }
            if ( vy < -0.5 ) { vy = -0.5f; }
        }
        else
        {
            diveCD = 0.5f;
            surface();
        }
    }
    void surface()
    {
        diving = false;
        rb2d.drag = 0.4f;
        if (diveCD > 0)
        {
            diveCD -= Time.deltaTime;
            if (diveCD < 0) { diveCD = 0; }
        }
        else
        {
            if (regeneratingCD <= 0)
            {
                regeneratingCD = 0;
                if (diveTime < 2.5)
                {
                    diveTime += Time.deltaTime;
                    if (diveTime > 2.5)
                        diveTime = 2.5f;
                }
            }
            else regeneratingCD -= Time.deltaTime;
        }
    }
    void frameCheck()
    {
        changeFrameCD -= Time.deltaTime;
        if (changeFrameCD <= 0)
        {
            changeFrameCD = 0.1f;
            changeFrame();
        }
    }
    void changeFrame()
    {
        if (diving && frame < 9)
        { frame += 1; }
        if (!diving && frame > 0)
        { frame -= 1; }
        sr.sprite = sprites[frame];
    }
    void speedLimiter()
    {
        if (vx >= SPEED_LIMIT && vy < SPEED_LIMIT && vy > -SPEED_LIMIT) { rb2d.velocity = new Vector2(SPEED_LIMIT, vy); }
        if (vx >= SPEED_LIMIT && vy >= SPEED_LIMIT) { rb2d.velocity = new Vector2(SPEED_LIMIT, SPEED_LIMIT); }
        if (vx >= SPEED_LIMIT && vy <= -SPEED_LIMIT) { rb2d.velocity = new Vector2(SPEED_LIMIT, -SPEED_LIMIT); }

        if (vx <= -SPEED_LIMIT && vy < SPEED_LIMIT && vy > -SPEED_LIMIT) { rb2d.velocity = new Vector2(-SPEED_LIMIT, vy); }
        if (vx <= -SPEED_LIMIT && vy >= SPEED_LIMIT) { rb2d.velocity = new Vector2(-SPEED_LIMIT, SPEED_LIMIT); }
        if (vx <= -SPEED_LIMIT && vy <= -SPEED_LIMIT) { rb2d.velocity = new Vector2(-SPEED_LIMIT, -SPEED_LIMIT); }
        
        if (vy >= SPEED_LIMIT && vx < SPEED_LIMIT && vx > -SPEED_LIMIT) { rb2d.velocity = new Vector2(vx, SPEED_LIMIT); }
        if (vy >= SPEED_LIMIT && vx < SPEED_LIMIT && vx > -SPEED_LIMIT) { rb2d.velocity = new Vector2(vx, SPEED_LIMIT); }
    }
}