using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour {

    public GameObject player;
    public GameObject playerSoundWave;
    public GameObject[] navPoints;
    public GameObject[] otherEnemies;
    public float speed;
    public float speedMod;
    public float timeFree;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per logic frame
	void FixedUpdate () {
        CircleCollider2D playerSoundWaveCC = playerSoundWave.GetComponent<CircleCollider2D>();
        CircleCollider2D enemyCC = this.GetComponent<CircleCollider2D>();
        Vector2 moveVector;
        //GameObject[] bottleSoundWaves = GameObject.FindGameObjectsWithTag("tag");
        if (enemyCC.IsTouching(playerSoundWaveCC))
        {
            moveVector = transform.position - player.transform.position;
            this.GetComponent<Rigidbody2D>().velocity = moveVector * -(speed);
        }
        else
        {
            for (int i = 0; i < navPoints.Length; i++)
            {
                BoxCollider2D navPointBC = navPoints[i].GetComponent<BoxCollider2D>();
                if (enemyCC.IsTouching(navPointBC))
                {
                    timeFree = 30;
                    //print("is touching");
                    if (i < navPoints.Length-1) {
                        //print(i + "Not First");
                        moveVector = transform.position - navPoints[i+1].transform.position;
                        this.GetComponent<Rigidbody2D>().velocity = moveVector * -(speed-speedMod);
                        return;
                    } else
                    {
                        //print(i + "Go to First");
                        moveVector = transform.position - navPoints[0].transform.position;
                        this.GetComponent<Rigidbody2D>().velocity = moveVector * -(speed-speedMod);
                        return;
                    }
                } 
                else
                {
                    timeFree -= Time.deltaTime;
                    if(timeFree < 0)
                    {
                        //print("out of time");
                        moveVector = transform.position - navPoints[i].transform.position;
                        this.GetComponent<Rigidbody2D>().velocity = moveVector * -(speed - speedMod);
                    }
                }
            }
        }

    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            SceneManager.LoadScene("GameOver");

    }
    
    
}
