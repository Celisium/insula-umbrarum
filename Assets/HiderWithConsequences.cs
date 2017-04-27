using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderWithConsequences : MonoBehaviour
{

    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public int Correct;
    public GameObject Hiding1;
    public GameObject Hiding2;

    private bool HurtPlayerForFirst = false;
    private bool HurtPlayerForSecond = false;
    private bool HurtPlayerForThird = false;

    void Start() {

        // Fix for hiders with only one output.
        if (!Hiding2) {
            Hiding2 = Hiding1;
        }

    }

    void Update() {

        Player PlayerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // Hurt for wrong answers.
        if (First.GetComponent<WaterBasin>().HasWater && Correct != 1 && !HurtPlayerForFirst) {
            HurtPlayerForFirst = true;
            PlayerCon.TakeDamage(2);
        }
        if (Second.GetComponent<WaterBasin>().HasWater && Correct != 2 && !HurtPlayerForSecond) {
            HurtPlayerForSecond = true;
            PlayerCon.TakeDamage(2);
        }
        if (Third.GetComponent<WaterBasin>().HasWater && Correct != 3 && !HurtPlayerForThird) {
            HurtPlayerForThird = true;
            PlayerCon.TakeDamage(2);
        }

        // Show for right answers.
        if (Hiding1) {
            Hiding1.SetActive(false);
            Hiding2.SetActive(false);
            if (First.GetComponent<WaterBasin>().HasWater && Correct == 1) {
                Hiding1.SetActive(true);
                Hiding2.SetActive(true);
            }
            if (Second.GetComponent<WaterBasin>().HasWater && Correct == 2) {
                Hiding1.SetActive(true);
                Hiding2.SetActive(true);
            }
            if (Third.GetComponent<WaterBasin>().HasWater && Correct == 3) {
                Hiding1.SetActive(true);
                Hiding2.SetActive(true);
            }

            // Mild hack.
            foreach (WaterBasin v in Hiding1.GetComponentsInChildren<WaterBasin>()) {
                v.gameObject.transform.FindChild("Cylinder_001").gameObject.SetActive(v.HasWater);
            }
        }

    }
}
