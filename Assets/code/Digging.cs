using UnityEngine;
using System.Collections;

public class Digging : MonoBehaviour 
{
	
	public GameObject m_goDiggedSquarePrefab;
	private float m_fDiggedSquareHeight;
	private float m_fDiggedSquareWidth;
	private Vector3 m_v3DiggerSavedPosition;
	private Vector3 m_v3LastDiggedSquarePosition;
	public GenerateMap map;
	
	// Use this for initialization
	void Start () 
	{
//		map.dirtBlockMapLayout;
		m_v3DiggerSavedPosition = transform.position;
		m_fDiggedSquareHeight = m_goDiggedSquarePrefab.transform.lossyScale.y;
		m_fDiggedSquareWidth = m_goDiggedSquarePrefab.transform.lossyScale.x;
		Debug.Log(m_v3DiggerSavedPosition);
		DigDown();
		Debug.Log(Mathf.Floor(10.0F));
		Debug.Log(Mathf.Floor(10.2F));
		Debug.Log(Mathf.Floor(10.7F));
		Debug.Log(Mathf.Floor(-10.0F));
		Debug.Log(Mathf.Floor(-10.2F));
		Debug.Log(Mathf.Floor(-10.7F));
		//DigLeft();
		//DigRight();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if(Input.GetMouseButtonDown(0))
//		{
//			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position,transform.rotation);
//		}
//		Debug.Log("dig pos: " + transform.position.y);
//		Debug.Log("dig: " + m_v3LastDiggedSquarePosition.y);
		CanDig();
		if(transform.position.y < m_v3LastDiggedSquarePosition.y + m_fDiggedSquareHeight/2)
		{
			DigDown();
		}
		if(transform.position.x < m_v3LastDiggedSquarePosition.x + m_fDiggedSquareWidth/2)
		{
			DigLeft();
		}
		if(transform.position.x > m_v3LastDiggedSquarePosition.x + m_fDiggedSquareWidth/2)
		{
			DigRight();
		}
	}
	bool CanDig()
	{
		int[,] mapArray = map.dirtBlockMapLayout;
		//Debug.Log(-(int)Mathf.Ceil(transform.position.y));
		Debug.Log(mapArray[-(int)Mathf.Ceil(transform.position.y),-(int)Mathf.Ceil(transform.position.y)]);
//		for ( int i = 0; i < m_iAmountOfColumns; i++ )
//		{
//
//		}
		return true;
	}
	void DigDown()
	{
		if(m_v3LastDiggedSquarePosition != m_v3DiggerSavedPosition + new Vector3(0,-1,0))
		{
			GameObject newDiggedSquare = Instantiate(m_goDiggedSquarePrefab, m_v3LastDiggedSquarePosition + new Vector3 (0,-1,0),Quaternion.identity) as GameObject;
			m_v3LastDiggedSquarePosition = newDiggedSquare.transform.position;
			newDiggedSquare.transform.parent = transform;
		}

	}
	void DigLeft()
	{
		GameObject newDiggedSquare = Instantiate(m_goDiggedSquarePrefab, m_v3LastDiggedSquarePosition + new Vector3 (-1,0,0),Quaternion.identity) as GameObject;
		m_v3LastDiggedSquarePosition = newDiggedSquare.transform.position;
		newDiggedSquare.transform.parent = transform;
	}
	void DigRight()
	{
		GameObject newDiggedSquare = Instantiate(m_goDiggedSquarePrefab, m_v3LastDiggedSquarePosition + new Vector3 (1,0,0),Quaternion.identity) as GameObject;
		m_v3LastDiggedSquarePosition = newDiggedSquare.transform.position;
		newDiggedSquare.transform.parent = transform;
	}


}