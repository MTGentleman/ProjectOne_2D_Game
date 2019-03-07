using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossman : MonoBehaviour {
    public Transform t;
    Vector3 movingTo;
    public float speed;
    public float fireCD;
    int yLevel;
    int phase;
    float maxCD;
    float normalSpeed;
    bool swiping;
    Vector3 cameraSizeMax;
    Vector3 cameraSizeMin;
    void Start () {
        t = GetComponent<Transform>();
        fireCD = maxCD;
        yLevel = 3;
        phase = 1;
        swiping = false;
        enterScreen();
        movingTo = pickDirection();
    }
	
	void Update () {
        checkPhase();
        checkFireCD();
        moveToPosition(movingTo);
        if (!swiping) { attack(); }
        if (t.position == movingTo)
        { movingTo = pickDirection(); }
        cameraSizeMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        cameraSizeMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
    void attack()
    {
        speed = normalSpeed;
        fireBullet();
    }
    void attackPattern()
    {
//        Vector2 endPoint = pickDirection();
//        moveToPosition(endPoint);
//        Vector3 endPoint3 = new Vector3(endPoint.x, endPoint.y);
//        while (t.position != endPoint3)
//        {
//            fireBullet();
//        }
//        attackPattern();
    }
    Vector2 pickDirection()
    {
        float randomX = Random.Range(cameraSizeMin.x, cameraSizeMax.x);
        float randomY = Random.Range(cameraSizeMax.y * 0.5f, cameraSizeMax.y);

        float newX = Random.Range(-7, 7);
        float newY = Random.Range(0, 4.9f);
        return new Vector3(newX, newY);
    }
    void checkFireCD()
    {
        if (fireCD < 0)
        { fireCD = 0; }
        if (fireCD > 0)
        { fireCD -= Time.deltaTime; }
    }
    void enterScreen()
    {
        Vector2 startingPoint = new Vector2(0, 2.5f);
        movingTo = startingPoint;
        attackPattern();
    }
    void backSwipe()
    {
        Vector2 topLeft = new Vector2(-7, 4.9f);
        Vector3 topLeft3 = new Vector3(-7, 4.9f, 0);
        Vector2 endPoint = new Vector2(5, 4.9f);
        while (t.position != topLeft3)
        {
            moveToPosition(topLeft);
            fireBullet();
        }
        Vector3 endPoint3 = new Vector3(endPoint.x, endPoint.y);
        while (t.position != endPoint3)
        {
            swiping = true;
            speed = 5;
            fireBullet();
        }
        swiping = false;
    }
    void checkPhase()
    {
        if (phase == 1)
        {

        }
        normalSpeed = 0.5f + phase * 0.75f;
    }
    void moveToPosition(Vector2 newPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(t.position, newPosition, step);
    }
    void fireBullet()
    {
        if (fireCD <= 0)
        {
            print("oof, owie");
            fireCD = maxCD;
        }
    }
}
