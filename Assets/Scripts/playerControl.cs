using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public float playerSpeed = 5f;
    public GameObject soundScale;
    private float fastSpeed = 10f;
    public GameObject[] endTriggers;
    public GameObject bottlePrefab;
    public Transform bottleSpawn;
    public float speed;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        float fastSpeed = playerSpeed * 2;
    }

    void Fire()
    {
        Vector3 bottleDirection;
        bottleDirection = Input.mousePosition;
        bottleDirection.z = 0.0f;
        bottleDirection = Camera.main.ScreenToWorldPoint(bottleDirection);
        bottleDirection = bottleDirection - bottleSpawn.position;
        bottleDirection.Normalize();
        GameObject bottle = Instantiate(bottlePrefab, bottleSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Vector2 bottleVelocity = new Vector2(bottleDirection.x * speed, bottleDirection.y * speed);
        bottle.GetComponent<Rigidbody2D>().velocity = bottleVelocity;
        Destroy(bottle, 2.0f);
    }

    // Fixed Update is not tied to frame rate 
    void FixedUpdate()
    {
        
        float horizontalIn = Input.GetAxis("Horizontal");
        float verticalIn = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontalIn, verticalIn);

        if (Input.GetKey("left shift"))
        {
            GetComponent<Rigidbody2D>().velocity = velocity * fastSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = velocity * playerSpeed;
        }
        /*
        for (int i = 0; i < endTriggers.Length; i++)
        {
            BoxCollider2D endTriggerBC = endTriggers[i].GetComponent<BoxCollider2D>();
            if (this.GetComponent<CircleCollider2D>().IsTouching(endTriggerBC))
            {

            }
                
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    

    
}

