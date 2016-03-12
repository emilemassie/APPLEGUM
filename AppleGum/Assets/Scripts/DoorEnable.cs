using UnityEngine;
using System.Collections;

public class DoorEnable : MonoBehaviour {

    private Animator Door;
    public static bool Door_En = false;

    // Use this for initialization
    void Start ()
    {
        Door = gameObject.GetComponent<Animator>();
        Door_En = SwitchEnable.Switch_En;
        Door_En = false;
        Door.SetBool("Door_En", Door_En);
    }
	
	// Update is called once per frame
	void Update () {
        Door_En = SwitchEnable.Switch_En;
        Door.SetBool("Door_En", Door_En);
    }
}
