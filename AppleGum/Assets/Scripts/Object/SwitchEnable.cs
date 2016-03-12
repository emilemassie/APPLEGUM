using UnityEngine;
using System.Collections;

public class SwitchEnable : MonoBehaviour {

	private Animator Switch;

	public static bool Switch_En = false;

	// Use this for initialization
	void Start () {

		Switch_En = GameObject.FindGameObjectWithTag ("Switch");
        Switch_En = false;
		Switch = gameObject.GetComponent<Animator> ();

	}


	void OnTriggerEnter2D (Collider2D col){
		if (Switch_En)
			Switch_En = false;
		else Switch_En = true;
		Switch.SetBool ("Switch_En", Switch_En);
	}

	void OnTriggerExit2D (Collider2D col){
		if (Switch_En) {
			Switch_En = true;
		} else
			Switch_En = false;

	}

	void OnTriggerStay2D (Collider2D col){

		if (Switch_En) {
			Switch_En = true;
		} else
			Switch_En = false;
	}
}
