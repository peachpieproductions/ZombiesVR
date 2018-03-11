using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var touch = GvrControllerInput.TouchPos;
        if (GvrControllerInput.IsTouching) {
            transform.position += transform.right * (touch.x - .5f) * Time.deltaTime * 5;
            transform.position += transform.forward * (touch.y - .5f) * Time.deltaTime * -5;
        }

    }
}
