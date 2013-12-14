using UnityEngine;
using System.Collections;

public class DiggerMovement : MonoBehaviour 
{
	public float m_fDiggerSpeed = 0.01f;
	private float m_fHorizontalMovement;
	private Vector3 m_vMoveDirection = new Vector3(0f,-1f,0f);
	// Use this for initialization
	void Start () 
	{
	
	}

	void Update ()
	{
		m_fHorizontalMovement = Input.GetAxis("DiggerHorizontal");

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//transform.Translate(m_vMoveDirection * m_fDiggerSpeed);
		if (m_fHorizontalMovement > 0)
		{
			m_vMoveDirection += new Vector3(0.1f,0f,0f);
		}
		else if (m_fHorizontalMovement < 0)
		{
			m_vMoveDirection += new Vector3(-0.1f,0f,0f);
		}
	}
}
