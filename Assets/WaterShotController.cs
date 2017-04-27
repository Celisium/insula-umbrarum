using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotController : MonoBehaviour {

    public int Damage = 30;

    private float Lifetime;

	void Start () {
        Lifetime = 10.0f;
	}
	
	void Update () {

        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0.0f) {
            Destroy(gameObject);
        }

	}

    void OnCollisionEnter(Collision info) {
        FireWallController FireCon = info.collider.gameObject.GetComponent<FireWallController>();
        if (FireCon) {
            FireCon.Health--;
        }
        HealthController HealthCon = info.collider.gameObject.GetComponent<HealthController>();
        if (HealthCon) {
            HealthCon.TakeDamage(Damage);
        }

        if (info.collider.gameObject.name == "LasershotTarget") {
            GameObject.FindGameObjectWithTag("Player").transform.position = info.collider.gameObject.transform.position - new Vector3(1.0f, 0.0f, 0.0f);
        }

        Destroy(gameObject);
    }
}
