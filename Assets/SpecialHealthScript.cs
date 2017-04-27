using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialHealthScript : MonoBehaviour
{

    public int Health;
    public int MaxHealth;

    private Vector3 StartPos;

    void Start() {
        StartPos = transform.position;
    }

    void Update() {
        if (transform.position.y <= 50.0f) {
            transform.position = StartPos;
        }
        if (Health <= 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Win();
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
