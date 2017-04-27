using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int Health;
    public int MaxHealth;

    private Vector3 StartPos;

	void Start () {
        StartPos = transform.position;
	}
	
	void Update () {
        if (transform.position.y <= -50.0f) {
            Health = 0;
        }
		if (Health <= 0) {
            if (gameObject.name == "BigGrunt") {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Win();
            }
            Destroy(gameObject);
        }
        if (Health > MaxHealth) {
            Health = MaxHealth;
        }
    }

    public void TakeDamage(int damage) {
        Health -= damage;
    }
}
