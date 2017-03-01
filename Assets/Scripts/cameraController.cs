using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float farLook;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per logical frame
	void FixedUpdate () {
        /*
        if(Input.GetKey("Mouse1"))
        {
            offset.x = offset.x * farLook;
            offset.y = offset.y * farLook;
        }
        */
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
	}
}
