using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {
	
	public Transform m_tPlayerPosition;
	private Vector3 m_v3LastUpdatedMapPosition;
	public GameObject[] m_goDirtBlockPrefabs;
	private float m_iDirtBlockHeight;
	
	
	int MAX_AMOUNT_DIRT_BLOCKS = 3000; 

	int iAmountOfDirtBlocksInScreen = 0;
	int iIndexDirtBlockArray = 0;
	
	enum EGroundTiles
	{
		EGroundTiles_Ground1 = 0,
		EGroundTiles_Ground2,
		EGroundTiles_Ground3,
		EGroundTiles_Ground4,
		EGroundTiles_Ground5,
		EGroundTiles_Rock1,
		EGroundTiles_Rock2,
		
		EGroundTiles_Max
		
	};
	
	
	EGroundTiles[] dirtBlockMapLayout = new EGroundTiles[3000];
	GameObject[] dirtBlockActiveList = new GameObject[30];	//TODO: replace 100 by amount of dirtblocks that will be visible on the screen

	
	// Use this for initialization
	void Start () 
	{
	
		m_v3LastUpdatedMapPosition  = transform.position;
		m_iDirtBlockHeight = m_goDirtBlockPrefabs[0].transform.lossyScale.y;
	
		
		GenerateMapLayout();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if( m_tPlayerPosition.position.y < m_v3LastUpdatedMapPosition.y - m_iDirtBlockHeight )
		{
			
			DisplaMapTilesAroundPosition( m_v3LastUpdatedMapPosition - new Vector3(  m_iDirtBlockHeight * 3, m_iDirtBlockHeight, 0 ) ); 
			
		}
		
	}
	
	
	void GenerateMapLayout()
	{
		
		for(int i = 0; i <  MAX_AMOUNT_DIRT_BLOCKS; i++)
		{
			
			EGroundTiles typeOfBlock;
			
			
			if(Random.Range(0,100) >= 90)
			{
				
				//typeOfBlock = Random.Range(EGroundTiles_Ground1,0);
				typeOfBlock = EGroundTiles.EGroundTiles_Ground1;
			}
			else
			{
				//typeOfBlock = Random.Range(0,0);
				typeOfBlock = EGroundTiles.EGroundTiles_Rock1;
				
			}
			
			dirtBlockMapLayout[i] = typeOfBlock;
			
		}
		
	}
	
	void DisplaMapTilesAroundPosition( Vector3 v3NewRowPosition )
	{
		
		for( int i = 0; i < 6; i++ )
		{
			iIndexDirtBlockArray ++;
			
				
			if(iIndexDirtBlockArray == MAX_AMOUNT_DIRT_BLOCKS)
			{
				
				iIndexDirtBlockArray = 0;
			}
			
			GameObject.Destroy(dirtBlockActiveList[iIndexDirtBlockArray]);
			
			dirtBlockActiveList[ iIndexDirtBlockArray ] = GameObject.Instantiate(m_goDirtBlockPrefabs[0], new Vector3( v3NewRowPosition.x + ( i * m_iDirtBlockHeight ), v3NewRowPosition.y, v3NewRowPosition.z),Quaternion.identity) as GameObject;
			dirtBlockActiveList[ iIndexDirtBlockArray ].transform.parent = transform;
			iAmountOfDirtBlocksInScreen++;
		}
		
		m_v3LastUpdatedMapPosition =  new Vector3(transform.position.x, v3NewRowPosition.y, transform.position.z);
		
	}
	
	

}
