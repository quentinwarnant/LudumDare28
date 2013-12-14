using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {
	
	public Transform m_tPlayerPosition;
	private Vector3 m_v3LastUpdatedMapPosition;
	public GameObject m_goDirtBlock;
	private float m_iDirtBlockHeight;
	
	
	int MAX_AMOUNT_DIRT_BLOCKS = 30; //6 X 5
	int iAmountOfDirtBlocksInScreen = 0;
	int iIndexDirtBlockArray = 0;
	
	GameObject[] dirtBlockList = new GameObject[30];	//TODO: replace 100 by amount of dirtblocks that will be visible on the screen
	
	// Use this for initialization
	void Start () 
	{
	
		m_v3LastUpdatedMapPosition  = transform.position;
		m_iDirtBlockHeight = m_goDirtBlock.transform.lossyScale.y;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if( m_tPlayerPosition.position.y < m_v3LastUpdatedMapPosition.y - m_iDirtBlockHeight )
		{
			
			GenerateDirtBlockRow( m_v3LastUpdatedMapPosition - new Vector3(  m_iDirtBlockHeight*3, m_iDirtBlockHeight, 0 ) ); 
			
		}
		
	}
	
	
	void GenerateDirtBlockRow( Vector3 v3NewRowPosition )
	{
		
		for( int i = 0; i < 6; i++ )
		{
			iIndexDirtBlockArray ++;
			
				
			if(iIndexDirtBlockArray == MAX_AMOUNT_DIRT_BLOCKS)
			{
				
				iIndexDirtBlockArray = 0;
			}
			
			GameObject.Destroy(dirtBlockList[iIndexDirtBlockArray]);
			
			dirtBlockList[ iIndexDirtBlockArray ] = GameObject.Instantiate(m_goDirtBlock, new Vector3( v3NewRowPosition.x + ( i * m_iDirtBlockHeight ), v3NewRowPosition.y, v3NewRowPosition.z),Quaternion.identity) as GameObject;
			dirtBlockList[ iIndexDirtBlockArray ].transform.parent = transform;
			iAmountOfDirtBlocksInScreen++;
		}
		
		m_v3LastUpdatedMapPosition =  new Vector3(transform.position.x, v3NewRowPosition.y, transform.position.z);
		
	}
}
