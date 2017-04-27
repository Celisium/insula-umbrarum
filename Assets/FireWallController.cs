using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallController : MonoBehaviour {

    public int Health = 3;

	void Start () {
		
	}
	
	void Update () {
		if (Health <= 0) {
            GetComponentInChildren<AudioSource>().Play();
            Destroy(gameObject);
        }
	}
}
