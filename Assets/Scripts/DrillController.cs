using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour {

    public bool DoDamage;
    public float Cooldown;
    public GameObject SmokeParticles;

    void Start() {
		
	}
	
	void Update() {
        Cooldown -= Time.deltaTime;
        if (Cooldown < 0.0f) Cooldown = 0.0f;

        SmokeParticles.SetActive(DoDamage);
	}

    void OnCollisionStay(Collision info) {
        HealthController HealthCon = info.collider.gameObject.GetComponent<HealthController>();
        if (HealthCon && Cooldown <= 0.0f && DoDamage) {
            HealthCon.TakeDamage(25);
            Cooldown = 1.0f;
        }
    }

}
