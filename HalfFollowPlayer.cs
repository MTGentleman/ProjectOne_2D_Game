using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfFollowPlayer : MonoBehaviour {
    Transform t;
    Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();
        rb2d = GameObject.Find("Player").GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        //t.position.Set(3 + rb2d.position.x / 2, -1 + rb2d.position.y / 2, -5);
        //Vector3 newPos = new Vector3(3 + rb2d.position.x / 2, -1 + rb2d.position.y / 2, -5);
        t.position = new Vector3(3 + rb2d.position.x / 2, -1 + rb2d.position.y / 2, -5);
    }
}
