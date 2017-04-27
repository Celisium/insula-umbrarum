using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointInController : MonoBehaviour {

    public GameObject GoTo;
    public int FinishesLevel;

	void Start () {
		
	}
	
	void Update () {
		
	}

    /*
    void OnCollisionEnter(Collision info) {
        if (info.collider.gameObject.GetComponent<Player>()) {
            info.collider.gameObject.GetComponent<Player>().LastCheckpoint = GoTo;
            info.collider.gameObject.GetComponent<Player>().CurrentLevel = FinishesLevel + 1;
            info.collider.gameObject.transform.position = GoTo.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
            info.collider.gameObject.GetComponent<Player>().Health = info.collider.gameObject.GetComponent<Player>().MaxHealth;
        } else if (info.collider.gameObject.GetComponent<DrillController>()) {
            info.collider.gameObject.GetComponentInParent<Player>().LastCheckpoint = GoTo;
            info.collider.gameObject.GetComponentInParent<Player>().CurrentLevel = FinishesLevel + 1;
            info.collider.gameObject.GetComponentInParent<Player>().gameObject.transform.position = GoTo.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
            info.collider.gameObject.GetComponentInParent<Player>().Health = info.collider.gameObject.GetComponentInParent<Player>().MaxHealth;
        }
    }
    */
}
