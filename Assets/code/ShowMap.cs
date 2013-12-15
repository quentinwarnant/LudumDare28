using UnityEngine;
using System.Collections;

public class ShowMap : MonoBehaviour {
	
	private Transform m_tPlayerPosition;
	private Vector3 m_v3LastUpdatedMapPosition;
	
	private	int[,] dirtBlockMapLayout; //= new int[ (m_iAmountOfRows*100), m_iAmountOfColumns];
	private GameObject[,] dirtBlockActiveList; //= new GameObject[ m_iAmountOfRows, m_iAmountOfColumns];	//TODO: replace 100 by amount of dirtblocks that will be visible on the screen
	
	private GameObject[] m_goTileBlockPrefabs;
	
	public GenerateMap map;
	
	int m_iAmountOfColumns;
	int m_iAmountOfRows;
	
	// Use this for initialization
	void Start () {
		
		m_iAmountOfColumns = map.GetColumnAmount();
		m_iAmountOfRows = map.GetRowAmount();
		
		dirtBlockMapLayout = map.dirtBlockMapLayout;
		dirtBlockActiveList = new GameObject[ m_iAmountOfRows, m_iAmountOfColumns ];
		m_goTileBlockPrefabs = map.m_goTileBlockPrefabs;
		m_v3LastUpdatedMapPosition  = transform.position;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		m_tPlayerPosition = this.transform;
		
		
		if( m_tPlayerPosition.position.y < m_v3LastUpdatedMapPosition.y - 1 )
		{
			
			DisplaMapTilesAroundPosition( m_v3LastUpdatedMapPosition - new Vector3(  1 * (m_iAmountOfColumns/2), 1, 0 ) ); 
			
		}
	}
	
	
	void DisplaMapTilesAroundPosition( Vector3 v3NewRowPosition )
	{
		
		for( int i = 0; i < m_iAmountOfColumns; i++ )
		{
			
				
			if(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y)) % m_iAmountOfRows, i] != null)
			{
				
				GameObject.Destroy(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y))% m_iAmountOfRows,i]);
				
			}
			Debug.Log("block to spawn " + dirtBlockMapLayout[(- (int)Mathf.Floor(v3NewRowPosition.y)),i]);
			GameObject newTileToDisplay = m_goTileBlockPrefabs[dirtBlockMapLayout[(- (int)Mathf.Floor(v3NewRowPosition.y)),i]];
			
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % m_iAmountOfRows,i ] = GameObject.Instantiate(newTileToDisplay, new Vector3( v3NewRowPosition.x + ( i * 1 ), v3NewRowPosition.y, v3NewRowPosition.z),Quaternion.identity) as GameObject;
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % m_iAmountOfRows,i ].transform.parent = map.transform;
		
		}
		
		m_v3LastUpdatedMapPosition =  new Vector3(map.transform.position.x, v3NewRowPosition.y, map.transform.position.z);
		
	}
}
