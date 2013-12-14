using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	private Vector2 m_v2ShipSpeed = new Vector2( 0.1f, -0.01f );

	// Use this for initialization
	void Start()
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
		transform.Translate( new Vector3( 0, m_v2ShipSpeed.y, 0 ) );
	}

	// Get input
	float GetInput()
	{		
		return Input.GetAxis( "ShipHorizontal" );
	}
}