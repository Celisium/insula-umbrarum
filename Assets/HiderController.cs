using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderController : MonoBehaviour {

    public GameObject[] MustBeOn;
    public GameObject[] MustBeOff;
    public GameObject Hiding;

	void Start () {
		
	}
	
	void Update () {

        bool MustBeOnAreAllOn = true;
        foreach (GameObject v in MustBeOn) {
            if (!v.GetComponent<WaterBasin>().HasWater) {
                MustBeOnAreAllOn = false;
            }
        }

        bool MustBeOffAreAllOff = true;
        foreach (GameObject v in MustBeOff) {
            if (v.GetComponent<WaterBasin>().HasWater) {
                MustBeOffAreAllOff = false;
            }
        }

        if (Hiding) {
            Hiding.SetActive(MustBeOnAreAllOn && MustBeOffAreAllOff);
        }

    }
}
