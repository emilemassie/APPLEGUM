using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 30f;
	public float MaxSpeed = 2;
	public float JumpPower = 182f;
	public float DoubleJumpPower;
	public float DoubleJumpModifier=0.18f;


	public bool grounded = true;
	public bool canDoubleJump;
    public bool jumped=false;

	private Rigidbody2D rgb2d;
	private Animator PlayerAnim;


	void Start () {

		rgb2d = gameObject.GetComponent<Rigidbody2D> ();
		PlayerAnim = gameObject.GetComponent<Animator> ();
	
	}

	void Update () {

		PlayerAnim.SetBool ("Grounded", grounded);
		PlayerAnim.SetFloat ("Speed", Mathf.Abs (rgb2d.velocity.x));
        


		// Changes character orientation
		// -----------------------------

		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetButtonDown("Jump")) {
			if (grounded) {
				rgb2d.AddForce (Vector2.up * JumpPower);
				canDoubleJump = true;
                jumped = true;
                PlayerAnim.SetBool("jumped", jumped);
            } 
			else 
			{
				if (canDoubleJump) 
				{
					canDoubleJump = false;
					rgb2d.velocity = new Vector2(rgb2d.velocity.x, 0);
					DoubleJumpPower = JumpPower + (JumpPower*DoubleJumpModifier);
					rgb2d.AddForce(Vector2.up * DoubleJumpPower);
				}
			}
				
		}
        if (grounded)
        {
            jumped = false;
            PlayerAnim.SetBool("jumped", jumped);
        }
	}

	void FixedUpdate () {

		float h = Input.GetAxis ("Horizontal");
		rgb2d.AddForce((Vector2.right * Speed) * h);

		if (rgb2d.velocity.x > MaxSpeed)
			rgb2d.velocity = new Vector2 (MaxSpeed, rgb2d.velocity.y);
		
		if (rgb2d.velocity.x < -MaxSpeed)
			rgb2d.velocity = new Vector2 (-MaxSpeed, rgb2d.velocity.y);

	}
}
