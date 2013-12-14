using UnityEngine;
using System.Collections;

public class Digging : MonoBehaviour {
	
	public GameObject m_goDiggedCubePrefab;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{
			GameObject.Instantiate(m_goDiggedCubePrefab,transform.position,transform.rotation);  
		}
	}
}
