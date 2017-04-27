using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBasin : MonoBehaviour {

    public bool HasWater;

	void Start () {
		
	}
	
	void Update () {
        transform.FindChild("Cylinder_001").gameObject.SetActive(HasWater);
	}
}
