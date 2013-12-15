using UnityEngine;
using System.Collections;

public class Digging : MonoBehaviour 
{
	
	public GameObject m_goDiggedSquarePrefab;
	private float m_fDiggedSquareHeight;
	private float m_fDiggedSquareWidth;
	private Vector3 m_v3DiggerSavedPosition;
	private Vector3 m_v3LastDiggedSquarePosition;
	
	// Use this for initialization
	void Start () 
	{
		m_v3DiggerSavedPosition = transform.position;
		m_fDiggedSquareHeight = m_goDiggedSquarePrefab.transform.lossyScale.y;
		m_fDiggedSquareWidth = m_goDiggedSquarePrefab.transform.lossyScale.x;
		Debug.Log(m_v3DiggerSavedPosition);
		DigDown();
		//DigLeft();
		//DigRight();
		//GameObject.Instantiate(m_goDiggedCubePrefab,transform.position+new Vector3(0,0.5f,0),transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(Input.GetMouseButtonDown(0))
//		{
//			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position,transform.rotation);  
//		}
	//	Debug.Log("dig pos: " + transform.position.y);
	//	Debug.Log("dig: " + m_v3LastDiggedSquarePosition.y);
		if(transform.position.y < m_v3LastDiggedSquarePosition.y + m_fDiggedSquareHeight/2)
		{
			DigDown();
		}
	}

	void DigDown()
	{
		GameObject newDiggedSquare = Instantiate(m_goDiggedSquarePrefab,transform.position + new Vector3(0,-m_fDiggedSquareHeight,0),transform.rotation) as GameObject;
		m_v3LastDiggedSquarePosition = newDiggedSquare.transform.position;

	}
	void DigLeft()
	{
		GameObject.Instantiate(m_goDiggedSquarePrefab,transform.position + new Vector3(-m_fDiggedSquareWidth,0,0),transform.rotation);
	}
	void DigRight()
	{
		GameObject.Instantiate(m_goDiggedSquarePrefab,transform.position + new Vector3(m_fDiggedSquareWidth,0,0),transform.rotation);
	}
	void FixedUpdate()
	{

	}
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		Debug.Log("entered: " + other.tag);
//	}
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if(other.tag == "DiggedSquare")
//		{
//			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position+new Vector3(0,0.5f,0),transform.rotation);
//		}
//	}
}