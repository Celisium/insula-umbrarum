using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGruntController : MonoBehaviour {

    public GameObject Laser;
    public Material NormalLaserMat;
    public Material ReadyLaserMat;

    private float FireTimer;

	void Start () {
		
	}
	
	void Update () {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        transform.eulerAngles = new Vector3(0.0f, Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0.0f);

        Ray RayThing = new Ray(transform.position + transform.forward * 3, -(transform.position - Player.transform.position) * 1000);
        Debug.DrawRay(transform.position + transform.forward * 3, -(transform.position - Player.transform.position) * 1000);
        RaycastHit Info;
        bool Hit = Physics.Raycast(RayThing, out Info);


        Laser.SetActive(false);
        if ((Player.transform.position - transform.position).sqrMagnitude <= 625 && Hit && (Info.collider.gameObject.GetComponent<Player>() || Info.collider.gameObject.GetComponent<DrillController>())) {
            FireTimer += Time.deltaTime;
            Laser.GetComponent<MeshRenderer>().material = (FireTimer >= 2.0f) ? ReadyLaserMat : NormalLaserMat;
            Laser.SetActive(true);
            Laser.transform.position = transform.position - (transform.position - Player.transform.position) / 2;
            Laser.transform.rotation = Quaternion.LookRotation(transform.position - Player.transform.position);
            Laser.transform.eulerAngles += new Vector3(90.0f, 0.0f, 0.0f);
            Laser.transform.localScale = new Vector3(0.25f, (transform.position - Player.transform.position).magnitude / 2, 0.25f);

            if (FireTimer >= 3.0f) {
                //Ray RayThing2 = new Ray(transform.position + transform.forward * 10, -(transform.position - Player.transform.position) * 1000);
                //Debug.DrawRay(transform.position + transform.forward * 10, -(transform.position - Player.transform.position) * 1000);
                RaycastHit Info2;
                bool Hit2 = Physics.Raycast(RayThing, out Info2);
                if (Hit2 && (Info2.collider.gameObject.GetComponent<Player>() || Info2.collider.gameObject.GetComponent<DrillController>())) {
                    Player.GetComponent<Player>().TakeDamage(2);
                    FireTimer = 0.0f;
                }
            }
        } else {
            FireTimer -= Time.deltaTime / 2;
        }

        if (FireTimer >= 3.0f || FireTimer < 0.0f) FireTimer = 0.0f;
    }
}
