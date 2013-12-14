using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	private Vector2 m_v2ShipSpeed = new Vector2( 0.1f, -0.1f );

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		GetInput();
	}

	// Take input
	void GetInput()
	{
		transform.RotateAround( transform.position, Vector3.forward, Input.GetAxis( "ShipHorizontal" ) );		
	}
}