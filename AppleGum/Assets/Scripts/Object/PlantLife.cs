using UnityEngine;
using System.Collections;

public class PlantLife : MonoBehaviour {

	//variables
	//---------
	private Animator _animator;
	private float timer = 0;

	public static int _plantstate = 1;
	public static bool _fullgrow = false;



	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
		if (_fullgrow) _plantstate = 5;
	}


	void Update () {

		if (!_fullgrow) timer -= Time.deltaTime;

		if (timer < -2) { _plantstate++ ; timer = 0; } // Grow interval

		if (_plantstate > 4) _fullgrow = true; //Declare when plant is full gown


		_animator.SetBool ("FullGrown", _fullgrow);
		_animator.SetInteger("PlantState",_plantstate);
	}
}
