using UnityEngine;
using System.Collections;

public class DiggerMovement : MonoBehaviour 
{
	public float diggerSpeed = 5.0f;
	private float horizontalMovement;
	private Vector3 moveDirection = new Vector3(0f,-1f,0f);
	// Use this for initialization
	void Start () 
	{
	
	}

	void Update ()
	{
		horizontalMovement = Input.GetAxis("DiggerHorizontal");

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(moveDirection * diggerSpeed);
		if (horizontalMovement > 0)
		{
			moveDirection += new Vector3(0.1f,0f,0f);
		}
		else if (horizontalMovement < 0)
		{
			moveDirection += new Vector3(-0.1f,0f,0f);
		}
	}
}
