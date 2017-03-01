using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScale : MonoBehaviour {

    public Vector3 runSize = new Vector3(3, 3, 3);
    public Vector3 walkSize = new Vector3(2,2,2);
    public Vector3 stillSize = new Vector3(1, 1, 1);
    public Vector3 holdBreathSize = new Vector3(.25f, .25f, .25f);

    private float oldVelocity;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per logical frame
    void FixedUpdate() {
        GameObject player = GameObject.Find("player");
        Vector2 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;

        if(playerVelocity.magnitude >= 10)
        {
            transform.localScale = runSize;
        }
        else if (playerVelocity.magnitude >= 1)
        {
            transform.localScale = walkSize;
        }
        else if(Input.GetMouseButton(1))
        {
            transform.localScale = holdBreathSize;
        }
        else
        {
            transform.localScale = stillSize;
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    
}
