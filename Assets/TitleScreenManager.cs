using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject InstructionsText;
    public GameObject CopyrightText;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void PlayClicked() {
        Application.LoadLevel(1);
    }

}
