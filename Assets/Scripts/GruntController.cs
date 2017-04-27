using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {

        Rigidbody RBody = GetComponent<Rigidbody>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if ((Player.transform.position - transform.position).sqrMagnitude <= 100) {
            transform.eulerAngles = new Vector3(0.0f, Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0.0f);
            RBody.AddForce(transform.forward * 2.0f);
            if (Time.time % 0.2 > 0.1f) {
                transform.FindChild("gruntwalk").localScale = new Vector3(1.0f, 1.0f, 1.0f) * 0.3f;
            } else {
                transform.FindChild("gruntwalk").localScale = new Vector3(-1.0f, 1.0f, 1.0f) * 0.3f;
            }
        }

    }

    //void OnCollisionEnter(Collision info) {
    //    Player PlayerController = info.collider.GetComponent<Player>();
    //    if (PlayerController) {
    //        PlayerController.TakeDamage(1);
    //    }
    //}
}
