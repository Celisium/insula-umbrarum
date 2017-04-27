using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed;
    public float Rotation;
    public int Health = 2;
    public int MaxHealth = 2;
    public GameObject CameraObj;
    public GameObject SpeakButton;
    public GameObject TextBox;
    public GameObject YouGotBox;
    public GameObject WeaponSelection;
    public GameObject CurrentWeaponIcon;
    public GameObject DrillObj;
    public GameObject WaterGunObj;
    public GameObject BucketObj;
    public GameObject BucketFullObj;
    public GameObject LaserShotObj;
    public GameObject WinText;
    public GameObject DrillSound;
    public GameObject HitSound;
    public GameObject WaterSound;
    public GameObject HealthSound;
    public GameObject LasershotSound;
    public GameObject MainCanvas;
    public GameObject WaterGunShot;
    public GameObject LasershotShot;
    public GameObject LastCheckpoint;
    public GameObject[] Levels;
    public int CurrentLevel = 1;
    public Sprite WeaponMenuBG;
    public Sprite WeaponMenuBGSelected;
    public Sprite DrillIcon;
    public Sprite WaterGunIcon;
    public Sprite BucketIcon;
    public Sprite LasershotIcon;
    public bool PauseAction = false;
    public bool HasDrill = false;
    public bool HasWaterGun = false;
    public bool HasBucket = false;
    public bool HasLasershot = false;
    public bool IsBucketFull = false;

    private Transform Sphere1Transform, Sphere2Transform, Sphere3Transform;
    private GameObject SpeakWith;
    private int ChatMessageIndex;
    private int SelectedWeapon;
    private float InvulnTimer = 0;
    private float WaterGunCooldown = 0;
    private float BucketCooldown = 0;
    private float LasershotCooldown = 0;

    void Start() {

        Sphere1Transform = transform.Find("Sphere1");
        Sphere2Transform = transform.Find("Sphere2");
        Sphere3Transform = transform.Find("Sphere3");

    }

    void Update() {

        Sphere1Transform.localPosition = new Vector3(Mathf.Cos(Time.time * -1), Mathf.Sin(Time.time * 2), Mathf.Cos(Time.time * -3)) / 2;
        Sphere2Transform.localPosition = new Vector3(Mathf.Cos(Time.time * 2), Mathf.Sin(Time.time * -1), Mathf.Cos(Time.time * 2)) / 2;
        Sphere3Transform.localPosition = new Vector3(Mathf.Cos(Time.time * -3), Mathf.Sin(Time.time * 2), Mathf.Cos(Time.time * -1)) / 2;

        CameraObj.transform.position = transform.position + new Vector3(0.0f, 7.5f, -7.5f);

        CharacterController Controller = GetComponent<CharacterController>();

        ///////////////////////////
        //                       //
        //    Health handling    //
        //                       //
        ///////////////////////////
        if (Health > MaxHealth) Health = MaxHealth;
        if (transform.position.y < -50) {
            Health = 0;
        }
        if (Health <= 0) {
            PauseAction = true;
            Destroy(GameObject.Find("Level" + CurrentLevel));
            GameObject NewLevel = Instantiate(Levels[CurrentLevel - 1]);
            NewLevel.name = "Level" + CurrentLevel;
            transform.position = LastCheckpoint.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
            PauseAction = false;
            Health = MaxHealth;
            IsBucketFull = false;
        }
        InvulnTimer -= Time.deltaTime;
        if (InvulnTimer < 0) InvulnTimer = 0;
        gameObject.GetComponent<MeshRenderer>().enabled = !(InvulnTimer > 0 && Time.renderedFrameCount % 4 == 0);

        WaterGunCooldown -= Time.deltaTime;
        if (WaterGunCooldown < 0) WaterGunCooldown = 0;
        BucketCooldown -= Time.deltaTime;
        if (BucketCooldown < 0) BucketCooldown = 0;
        LasershotCooldown -= Time.deltaTime;
        if (LasershotCooldown < 0) LasershotCooldown = 0;

        WeaponSelection.SetActive(false);

        DrillObj.GetComponent<DrillController>().DoDamage = false;
        if (!PauseAction) {
            Vector3 MovementDelta = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            /////////////////////////////////
            //                             //
            //    Weapon Usage Handling    //
            //                             //
            /////////////////////////////////
            if (Input.GetAxis("Fire1") > 0.5f) {
                switch (SelectedWeapon) {
                    case 1:
                        DrillObj.GetComponent<DrillController>().DoDamage = true;
                        break;
                    case 2:
                        if (WaterGunCooldown <= 0.0f) {
                            GameObject NewShot = Instantiate(WaterGunShot, transform.position + transform.forward * 1.75f, Quaternion.identity);
                            NewShot.SetActive(true);
                            NewShot.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
                            WaterGunCooldown = 0.5f;
                            WaterSound.GetComponent<AudioSource>().Play();
                        }
                        break;
                    case 3:
                        // Bucket has no click-based interactions.
                        break;
                    case 4:
                        if (LasershotCooldown <= 0.0f) {
                            GameObject NewShot = Instantiate(LasershotShot, transform.position + transform.forward * 1.75f, Quaternion.identity);
                            NewShot.SetActive(true);
                            NewShot.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
                            LasershotCooldown = 0.25f;
                            LasershotSound.GetComponent<AudioSource>().Play();
                        }
                        break;
                    default:
                        break;
                }
            }

            if (DrillObj.GetComponent<DrillController>().DoDamage) {
                if (!DrillSound.GetComponent<AudioSource>().isPlaying) {
                    DrillSound.GetComponent<AudioSource>().Play();
                }
            } else {
                DrillSound.GetComponent<AudioSource>().Stop();
            }

            //////////////////////////////////
            //                              //
            //    Weapon Select Handling    //
            //                              //
            //////////////////////////////////
            if (Input.GetAxis("Fire2") > 0.5f) {
                WeaponSelection.SetActive(true);
                int HalfScreenX = Screen.width / 2, HalfScreenY = Screen.height / 2;
                if (Input.mousePosition.x < HalfScreenX) { // Left
                    if (Input.mousePosition.y < HalfScreenY) { // Bottom
                        SelectedWeapon = 3;
                    } else { // Top
                        SelectedWeapon = 1;
                    }
                } else { // Right
                    if (Input.mousePosition.y < HalfScreenY) { // Bottom
                        SelectedWeapon = 4;
                    } else { // Top
                        SelectedWeapon = 2;
                    }
                }
                WeaponSelection.transform.FindChild("Drill").gameObject.SetActive(HasDrill);
                WeaponSelection.transform.FindChild("WaterGun").gameObject.SetActive(HasWaterGun);
                WeaponSelection.transform.FindChild("Bucket").gameObject.SetActive(HasBucket);
                WeaponSelection.transform.FindChild("LaserShot").gameObject.SetActive(HasLasershot);
                if (SelectedWeapon == 4 && !HasLasershot) {
                    SelectedWeapon = 3;
                }
                if (SelectedWeapon == 3 && !HasBucket) {
                    SelectedWeapon = 2;
                }
                if (SelectedWeapon == 2 && !HasWaterGun) {
                    SelectedWeapon = 1;
                }
                if (SelectedWeapon == 1 && !HasDrill) {
                    SelectedWeapon = 0;
                }

                CurrentWeaponIcon.SetActive(true);
                switch (SelectedWeapon) {
                    case 3:
                        WeaponSelection.transform.FindChild("DrillBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("WaterGunBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("BucketBG").GetComponent<Image>().sprite = WeaponMenuBGSelected;
                        WeaponSelection.transform.FindChild("LaserShotBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        CurrentWeaponIcon.GetComponent<Image>().sprite = BucketIcon;
                        DrillObj.SetActive(false);
                        WaterGunObj.SetActive(false);
                        BucketObj.SetActive(true);
                        LaserShotObj.SetActive(false);
                        break;
                    case 1:
                        WeaponSelection.transform.FindChild("DrillBG").GetComponent<Image>().sprite = WeaponMenuBGSelected;
                        WeaponSelection.transform.FindChild("WaterGunBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("BucketBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("LaserShotBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        CurrentWeaponIcon.GetComponent<Image>().sprite = DrillIcon;
                        DrillObj.SetActive(true);
                        WaterGunObj.SetActive(false);
                        BucketObj.SetActive(false);
                        LaserShotObj.SetActive(false);
                        break;
                    case 4:
                        WeaponSelection.transform.FindChild("DrillBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("WaterGunBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("BucketBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("LaserShotBG").GetComponent<Image>().sprite = WeaponMenuBGSelected;
                        CurrentWeaponIcon.GetComponent<Image>().sprite = LasershotIcon;
                        DrillObj.SetActive(false);
                        WaterGunObj.SetActive(false);
                        BucketObj.SetActive(false);
                        LaserShotObj.SetActive(true);
                        break;
                    case 2:
                        WeaponSelection.transform.FindChild("DrillBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("WaterGunBG").GetComponent<Image>().sprite = WeaponMenuBGSelected;
                        WeaponSelection.transform.FindChild("BucketBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("LaserShotBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        CurrentWeaponIcon.GetComponent<Image>().sprite = WaterGunIcon;
                        DrillObj.SetActive(false);
                        WaterGunObj.SetActive(true);
                        BucketObj.SetActive(false);
                        LaserShotObj.SetActive(false);
                        break;
                    case 0:
                        WeaponSelection.transform.FindChild("DrillBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("WaterGunBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("BucketBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        WeaponSelection.transform.FindChild("LaserShotBG").GetComponent<Image>().sprite = WeaponMenuBG;
                        CurrentWeaponIcon.SetActive(false);
                        DrillObj.SetActive(false);
                        WaterGunObj.SetActive(false);
                        BucketObj.SetActive(false);
                        LaserShotObj.SetActive(false);
                        break;
                }
            }

            BucketFullObj.transform.FindChild("Cylinder_001").gameObject.SetActive(IsBucketFull);

            /////////////////////
            //                 //
            //    Health UI    //
            //                 //
            /////////////////////
            for (int i = 0; i < 8; i++) {
                MainCanvas.transform.FindChild("HP" + (i + 1)).gameObject.SetActive(false);
            }
            for (int i = 0; i < Health; i++) {
                MainCanvas.transform.FindChild("HP" + (i + 1)).gameObject.SetActive(true);   
            }

            ////////////////////
            //                //
            //    Movement    //
            //                //
            ////////////////////
            if (MovementDelta != new Vector3(0, 0, 0)) {
                transform.eulerAngles = new Vector3(0.0f, Mathf.Atan2(MovementDelta.x, MovementDelta.z) * Mathf.Rad2Deg, 0.0f);
            }

            Controller.SimpleMove(MovementDelta.normalized * Speed);

            foreach (GameObject v in GameObject.FindGameObjectsWithTag("Chat")) {
                SpeakButton.SetActive(false);
                if ((v.transform.position - transform.position).sqrMagnitude < 4) {
                    SpeakButton.SetActive(true);
                    SpeakWith = v;
                    break;
                }
            }
        }

    }

    public void Speak() {
        if (SpeakWith != null) {
            ChatController ChatCon = SpeakWith.GetComponent<ChatController>();
            PauseAction = true;
            SpeakButton.SetActive(false);
            TextBox.SetActive(true);
            ChatMessageIndex = 0;
            // Set name.
            TextBox.transform.FindChild("NamePanel/Name").GetComponent<Text>().text = ChatCon.Messages[ChatCon.Message][0];
            // Show the first message.
            ChatNext();
        }
    }

    public void ChatNext() {
        ChatController ChatCon = SpeakWith.GetComponent<ChatController>();
SkipMessage:
        ChatMessageIndex++;
        if (ChatMessageIndex == ChatCon.Messages[ChatCon.Message].Length - 1) {
            TextBox.SetActive(false);
            PauseAction = false;
            ChatCon.Message = int.Parse(ChatCon.Messages[ChatCon.Message][ChatMessageIndex]);
        } else {
            string NextText = ChatCon.Messages[ChatCon.Message][ChatMessageIndex];
            switch (NextText) {
                case "/givedrill":
                    TextBox.transform.FindChild("NamePanel").gameObject.SetActive(false);
                    YouGotBox.transform.FindChild("Text").GetComponent<Text>().text = "You got the Drill!";
                    YouGotBox.SetActive(true);
                    TextBox.transform.FindChild("Text").GetComponent<Text>().text = "Now you can <color=orange>drill through both walls and enemies alike</color>! Try it out on a <color=orange>weak-looking wall or enemy</color> and see for yourself.";
                    HasDrill = true;
                    break;
                case "/givewatergun":
                    TextBox.transform.FindChild("NamePanel").gameObject.SetActive(false);
                    YouGotBox.transform.FindChild("Text").GetComponent<Text>().text = "You got the Water Gun!";
                    YouGotBox.SetActive(true);
                    TextBox.transform.FindChild("Text").GetComponent<Text>().text = "Now you can <color=orange>soak fires and drench your foes</color>! Try it out on a <color=orange>blazing inferno or enemy</color> and see for yourself.";
                    HasWaterGun = true;
                    break;
                case "/givebucket":
                    TextBox.transform.FindChild("NamePanel").gameObject.SetActive(false);
                    YouGotBox.transform.FindChild("Text").GetComponent<Text>().text = "You got the Bucket!";
                    YouGotBox.SetActive(true);
                    TextBox.transform.FindChild("Text").GetComponent<Text>().text = "Now you can <color=orange>transport water between containers</color> (because that's exciting)! Try it out on a <color=orange>brimming basin</color> and see for yourself.";
                    HasBucket = true;
                    break;
                case "/givelasershot":
                    TextBox.transform.FindChild("NamePanel").gameObject.SetActive(false);
                    YouGotBox.transform.FindChild("Text").GetComponent<Text>().text = "You got the Lasershot!";
                    YouGotBox.SetActive(true);
                    TextBox.transform.FindChild("Text").GetComponent<Text>().text = "Now you can <color=orange>make the bad guys cry like an-</color> sorry, almost got carried away. Try it out on a <color=orange>massive swarm or titanic ringleader</color> and see for yourself.";
                    HasLasershot = true;
                    break;
                case "/centrealign":
                    TextBox.transform.FindChild("Text").GetComponent<Text>().alignment = TextAnchor.UpperCenter;
                    goto SkipMessage;
                case "/leftalign":
                    TextBox.transform.FindChild("Text").GetComponent<Text>().alignment = TextAnchor.UpperLeft;
                    goto SkipMessage;
                default:
                    YouGotBox.SetActive(false);
                    TextBox.transform.FindChild("NamePanel").gameObject.SetActive(true);
                    TextBox.transform.FindChild("Text").GetComponent<Text>().text = NextText;
                    break;
            }
        }
    }

    public void TakeDamage(int damage) {
        if (InvulnTimer <= 0) {
            Health -= damage;
            InvulnTimer = 1.5f;
            HitSound.GetComponent<AudioSource>().Play();
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.collider.gameObject.GetComponent<GruntController>() || hit.collider.gameObject.GetComponent<FireWallController>()) {
            TakeDamage(1);
        } else if (hit.collider.gameObject.GetComponent<HealthOrbController>()) {
            MaxHealth++;
            Health = MaxHealth;
            HealthSound.GetComponent<AudioSource>().Play();
            Destroy(hit.collider.gameObject);
        } else if (hit.collider.gameObject.GetComponent<CheckpointInController>()) {
            CheckpointInController Con = hit.collider.gameObject.GetComponent<CheckpointInController>();
            LastCheckpoint = Con.GoTo;
            CurrentLevel = Con.FinishesLevel + 1;
            transform.position = Con.GoTo.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
            Health = MaxHealth;
            IsBucketFull = false;
        } else if (hit.collider.gameObject.GetComponent<WaterBasin>() && BucketCooldown <= 0.0f && HasBucket) {
            WaterBasin WaterCon = hit.collider.gameObject.GetComponent<WaterBasin>();
            if(WaterCon.HasWater && !IsBucketFull) {
                IsBucketFull = true;
                WaterCon.HasWater = false;
                BucketCooldown = 0.5f;
            } else if (!WaterCon.HasWater && IsBucketFull) {
                IsBucketFull = false;
                WaterCon.HasWater = true;
                BucketCooldown = 0.5f;
            }
        }

    }

    public void Win() {
        print("Win was called");
        PauseAction = true;
        WinText.SetActive(true);
    }
}
