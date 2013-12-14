using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {
	
	public Transform m_tPlayerPosition;
	private Vector3 m_v3LastUpdatedMapPosition;
	public GameObject[] m_goDirtBlockPrefabs;
	private float m_iDirtBlockHeight;
	
	
	static int m_iAmountOfColumns = 6; 
	static int m_iAmountOfRows = 6; 
	
	
	int[,] dirtBlockMapLayout = new int[ (m_iAmountOfRows*100), m_iAmountOfColumns];
	GameObject[,] dirtBlockActiveList = new GameObject[ m_iAmountOfRows, m_iAmountOfColumns];	//TODO: replace 100 by amount of dirtblocks that will be visible on the screen

	int iAmountOfDirtBlocksInScreen = 0;
	int iIndexDirtBlockArray = 0;
	
	enum EGroundTiles
	{
		EGroundTiles_Ground1 = 0,
		EGroundTiles_Rock1,
		
		EGroundTiles_Max
		
	};
	
	
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
	
		if( m_tPlayerPosition.position.y < m_v3LastUpdatedMapPosition.y - 1 )
		{
			
			DisplaMapTilesAroundPosition( m_v3LastUpdatedMapPosition - new Vector3(  1 * 3, 1, 0 ) ); 
			
		}
		
	}
	
	
	void GenerateMapLayout()
	{
		
		for(int i = 0; i < m_iAmountOfRows * 100; i++)
		{
			for(int j = 0; j < m_iAmountOfColumns  ; j++)
			{
				int typeOfBlock;
				
				
				if(Random.Range(0,100) >= 90)
				{
					
					//typeOfBlock = Random.Range(EGroundTiles_Ground1,0);
					typeOfBlock = (int) EGroundTiles.EGroundTiles_Ground1;
				}
				else
				{
					//typeOfBlock = Random.Range(0,0);
					typeOfBlock =(int) EGroundTiles.EGroundTiles_Rock1;
					
				}
				
				dirtBlockMapLayout[i,j] = typeOfBlock;
			}
		}
		
	}
	
	void DisplaMapTilesAroundPosition( Vector3 v3NewRowPosition )
	{
		
		for( int i = 0; i < m_iAmountOfColumns; i++ )
		{
			
				
			if(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y)) % 6, i] != null)
			{
				
				GameObject.Destroy(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y))% 6,i]);
				
			}
			
			GameObject newTileToDisplay = m_goDirtBlockPrefabs[dirtBlockMapLayout[(- (int)Mathf.Floor(v3NewRowPosition.y)),i]];
			
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % 6,i ] = GameObject.Instantiate(newTileToDisplay, new Vector3( v3NewRowPosition.x + ( i * 1 ), v3NewRowPosition.y, v3NewRowPosition.z),Quaternion.identity) as GameObject;
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % 6,i ].transform.parent = transform;
			iAmountOfDirtBlocksInScreen++;
		}
		
		m_v3LastUpdatedMapPosition =  new Vector3(transform.position.x, v3NewRowPosition.y, transform.position.z);
		
	}
	
	

}
