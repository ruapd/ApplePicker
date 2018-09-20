using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    //accessing appl prefab
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDerections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

	void Start () {
        //dropping apples every second
        Invoke("DropApple", 2f);
	}

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

	void Update () {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//move left
        }
       
	}

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDerections)
        {
            speed *= -1;//changes direction by flipping the valuef from
        }
    }
}
