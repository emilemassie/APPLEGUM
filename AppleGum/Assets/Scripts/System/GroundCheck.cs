using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {


	private Player Player;

	// Use this for initialization
	void Start () {

		Player = gameObject.GetComponentInParent<Player> ();
	
	}


	void OnTriggerEnter2D (Collider2D col){

		Player.grounded = true;
	}

	void OnTriggerExit2D (Collider2D col){

		Player.grounded = false;
	}

	void OnTriggerStay2D (Collider2D col){

		Player.grounded = true;
	}


}
