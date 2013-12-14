using UnityEngine;
using System.Collections;

public class Digging : MonoBehaviour 
{
	
	public GameObject m_goDiggedCubePrefab;
	
	// Use this for initialization
	void Start () 
	{
		GameObject.Instantiate(m_goDiggedCubePrefab,transform.position+new Vector3(0,0.5f,0),transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position,transform.rotation);  
		}
	}
	void FixedUpdate()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("entered: " + other.tag);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "DiggedSquare")
		{
			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position+new Vector3(0,0.5f,0),transform.rotation);
		}
	}
}