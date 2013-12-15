using UnityEngine;
using System.Collections;

public class ShowMap : MonoBehaviour {
	
	private Transform m_tPlayerPosition;
	private Vector3 m_v3LastUpdatedMapPosition;
	
	private	int[,] dirtBlockMapLayout; 
	private GameObject[,] dirtBlockActiveList; 
	
	private GameObject[] m_goTileBlockPrefabs;
	
	public GenerateMap map;
	
	int m_iAmountOfColumns;
	int m_iAmountOfRows;
	
	// Use this for initialization
	void Start () {
		
		m_iAmountOfColumns = map.GetColumnAmount();
		m_iAmountOfRows = map.GetRowAmount();
		
		dirtBlockMapLayout = map.dirtBlockMapLayout;
		dirtBlockActiveList = new GameObject[ m_iAmountOfRows/380, m_iAmountOfColumns ];
		m_goTileBlockPrefabs = map.m_goTileBlockPrefabs;
		m_v3LastUpdatedMapPosition  = transform.position;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		m_tPlayerPosition = this.transform;
		
		
		if( m_tPlayerPosition.position.y < m_v3LastUpdatedMapPosition.y - 32  && ( m_v3LastUpdatedMapPosition.y - 32  >= -(m_iAmountOfRows ) ))
		{
			
			DisplaMapTilesAroundPosition( m_v3LastUpdatedMapPosition - new Vector3(   (m_iAmountOfColumns/2) * 32, 32, 0 ) ); 
			
		}
	}
	
	
	void DisplaMapTilesAroundPosition( Vector3 v3NewRowPosition )
	{
		
		for( int i = 0; i < m_iAmountOfColumns; i++ )
		{
			
				
			if(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y)) % (m_iAmountOfRows/380), i] != null)
			{
				
				GameObject.Destroy(dirtBlockActiveList[(- (int)Mathf.Floor(v3NewRowPosition.y)) % (m_iAmountOfRows/380),i]);
				
			}
			GameObject newTileToDisplay = m_goTileBlockPrefabs[dirtBlockMapLayout[(- (int)Mathf.Floor(v3NewRowPosition.y)),i]];
			
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % (m_iAmountOfRows/380),i ] = GameObject.Instantiate(newTileToDisplay, new Vector3( v3NewRowPosition.x + ( i * 32 ), v3NewRowPosition.y , v3NewRowPosition.z),Quaternion.identity) as GameObject;
			dirtBlockActiveList[ (- (int)Mathf.Floor(v3NewRowPosition.y)) % (m_iAmountOfRows/380),i ].transform.parent = map.transform;
		
		}
		m_v3LastUpdatedMapPosition =  new Vector3(map.transform.position.x, v3NewRowPosition.y, map.transform.position.z);
		
	}
}
