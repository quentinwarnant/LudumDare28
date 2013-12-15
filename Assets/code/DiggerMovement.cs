using UnityEngine;
using System.Collections;

public class DiggerMovement : MonoBehaviour 
{
	public Vector2 m_v2DiggerSpeed = new Vector2( 0.1f, -0.01f );
	//private float m_fHorizontalMovement;
	//private Vector3 m_vMoveDirection = new Vector3(0f,-1f,0f);
	// Use this for initialization
	void Start () 
	{
	
	}
	// Update is called once per frame
	void Update()
	{
		Move();
	}
	
	// Move in 2D space
	void Move()
	{
		transform.RotateAround( transform.position, Vector3.forward, GetInput() );
		transform.Translate( new Vector3( 0, m_v2DiggerSpeed.y, 0 ) );
	}
	
	// Get input
	float GetInput()
	{		
		return Input.GetAxis( "DiggerHorizontal" );
	}

//	void Update ()
//	{
//		m_fHorizontalMovement = Input.GetAxis("DiggerHorizontal");
//
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate () 
//	{
//		//transform.Translate(m_vMoveDirection * m_fDiggerSpeed);
//		if (m_fHorizontalMovement > 0)
//		{
//			m_vMoveDirection += new Vector3(0.1f,0f,0f);
//		}
//		else if (m_fHorizontalMovement < 0)
//		{
//			m_vMoveDirection += new Vector3(-0.1f,0f,0f);
//		}
//	}
}
