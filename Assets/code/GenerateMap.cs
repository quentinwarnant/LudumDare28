using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {
	
	public GameObject[] m_goTileBlockPrefabs;
	private float m_fDirtBlockHeight;
	
	public static int m_iAmountOfColumns = 40; 
	public static int m_iAmountOfRows = 8000; 
	
	public int[,] dirtBlockMapLayout = new int[ (m_iAmountOfRows)+1, m_iAmountOfColumns];
	
	int iAmountOfDirtBlocksInScreen = 0;
	int iIndexDirtBlockArray = 0;
	
	enum EGroundTiles
	{
		EGroundTiles_Ground1 = 0,
		EGroundTiles_Ground2,
		EGroundTiles_Rock1,
		EGroundTiles_Rock2,
		EGroundTiles_Rock3,
		EGroundTiles_Rock4,
		
		EGroundTiles_Max
		
	};
	
	
	// Use this for initialization
	void Start () 
	{
	
		m_fDirtBlockHeight = m_goTileBlockPrefabs[0].transform.lossyScale.y;
	
		
		GenerateMapLayout();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		
		
	}
	
	
	void GenerateMapLayout()
	{
		for(int i = 0; i < m_iAmountOfRows ; i++)
		{
			for(int j = 0; j < m_iAmountOfColumns  ; j++)
			{
				int typeOfBlock;
				int amountofRocksInThisRow = 0;
				
				if(Random.Range(0,100) <= (100 - ( i/500 ) ) )
				{
					
					typeOfBlock = Random.Range( (int) EGroundTiles.EGroundTiles_Ground1, (int) EGroundTiles.EGroundTiles_Ground2 );
					
				}
				else
				{
					amountofRocksInThisRow++;
					
					if(amountofRocksInThisRow > m_iAmountOfColumns/2)
					{
						typeOfBlock = Random.Range( (int) EGroundTiles.EGroundTiles_Ground1, (int) EGroundTiles.EGroundTiles_Ground2 );
					
					}
					else
					{
						typeOfBlock = Random.Range( (int) EGroundTiles.EGroundTiles_Rock1, (int) EGroundTiles.EGroundTiles_Rock4 );
					}
					
				}
				
				dirtBlockMapLayout[i,j] = typeOfBlock;
			}
		}
		
		//lowest level
		for(int j = 0; j < m_iAmountOfColumns  ; j++)
		{
			
			dirtBlockMapLayout[m_iAmountOfRows ,j] = (int) EGroundTiles.EGroundTiles_Rock1;
		}
	}
	
	public int GetColumnAmount()
	{
		
		return m_iAmountOfColumns;
	}
	
	
	public int GetRowAmount()
	{
		
		return m_iAmountOfRows;
	}
	

}
