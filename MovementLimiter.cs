using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLimiter : MonoBehaviour {
    public float px;
    public float py;
    Rigidbody2D rb2d;
    Transform t;
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }
	void Update () {
        px = t.position.x;
        py = t.position.y;

        if (px >= 7 && -4.9 < py && py < 4.9) { t.position = new Vector3(7, py, 0); }
        if (px >= 7 && py >= 4.9) { t.position = new Vector3(7, 4.9f, 0); }
        if (px >= 7 && py <= -4.9) { t.position = new Vector3(7, -4.9f, 0); }

        if (px <= -7 && -4.9 < py && py < 4.9) { t.position = new Vector3(-7, py, 0); }
        if (px <= -7 && py >= 4.9) { t.position = new Vector3(-7, 4.9f, 0); }
        if (px <= -7 && py <= -4.9) { t.position = new Vector3(-7, -4.9f, 0); }
        
        if (py >= 4.9 && px < 7 && px > -7) { t.position = new Vector3(px, 4.9f, 0); }
        if (py <= -4.9 && px < 7 && px > -7) { t.position = new Vector3(px, -4.9f, 0); }
    }
}