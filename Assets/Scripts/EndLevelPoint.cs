using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //print("Collision");
        if (coll.gameObject.tag == "Player") {
            //print("End Game");
            SceneManager.LoadScene("GameOver");
        }
    }
}
