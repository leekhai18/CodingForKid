using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
public class RoadTile : Tile
{
    /// <summary>
    /// An array with all the roadTiles that we have in our game
    /// </summary>
    [SerializeField]
    private Sprite[] roadSprites;
    //A preview of the tile
    [SerializeField]
    private Sprite preview;
    /// <summary>
    /// Refreshes this tile when something changes
    /// </summary>
    /// <param name="position">The tiles position in the grid</param>
    /// <param name="tilemap">A reference to the tilemap that this tile belongs to.</param>
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -5; y <= 5; y++) //Runs through all the tile's neighbours 
        {
            for (int x = -5; x <= 5; x++)
            {
                //We store the position of the neighbour 
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if (HasRoad(tilemap, nPos)) //If the neighbour has road on it
                {

                    tilemap.RefreshTile(nPos); //Them we make sure to refresh the neighbour aswell
                    
                   
               }
            }
        }
        
    }

    /// <summary>
    /// Changes the tiles sprite to the correct sprites based on the situation
    /// </summary>
    /// <param name="location">The location of this sprite</param>
    /// <param name="tilemap">A reference to the tilemap, that this tile belongs to</param>
    /// <param name="tileData">A reference to the actual object, that this tile belongs to</param>
    /// 
  
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;//Makes an empty string as compostion, we need this so that we change the sprite
        
        for (int x = -1; x <= 1; x++)//Runs through all neighbours 
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 || y != 0) //Makes sure that we aren't checking our self
                {
                    //If the value is a roadtile
                    if (HasRoad(tilemap, new Vector3Int(location.x + x, location.y + y, location.z)))
                    {
                        composition += 'R';
                    }
                    else
                    {
                        composition += 'E';
                    }
                  


                }
            }
        }
        tileData.sprite = roadSprites[0];
      

        //THANG
        if (( composition[1] == 'R' ||composition[6]=='R') && composition[3] == 'E' && composition[4] == 'E' )
        {
            tileData.sprite = roadSprites[0];
        }
        if (composition[1] == 'E' && composition[6] == 'E' && (composition[3] == 'R' || composition[4] == 'R'))
        {    tileData.sprite = roadSprites[1];
        }
        if (composition[1] == 'E' && composition[6] == 'E' && composition[3] == 'R' && composition[4] == 'R')
        {
            tileData.sprite = roadSprites[1];
        }
        if (composition[1] == 'R' && composition[6] == 'R' && composition[3] == 'E' && composition[4] == 'E')
        {
            tileData.sprite = roadSprites[0];
        }

        //TRAFFIC SIGNAL
        if (composition[3] == 'R')
        {
            //if (HasSignal(tilemap, new Vector3Int(location.x, location.y - 1, location.z), 12))
            //    tileData.sprite = roadSprites[8];
            if (HasSignal(tilemap, new Vector3Int(location.x, location.y + -1, location.z), 14))
                tileData.sprite = roadSprites[8];
        }
        if (composition[4] == 'R')
        {
            //if (HasSignal(tilemap, new Vector3Int(location.x, location.y + 1, location.z), 10))
            //    tileData.sprite = roadSprites[6];

            if (HasSignal(tilemap, new Vector3Int(location.x, location.y + 1, location.z), 14))
                tileData.sprite = roadSprites[6];
        }
        if (composition[1] == 'R')
        {
        //    if (HasSignal(tilemap, new Vector3Int(location.x + -1, location.y + 0, location.z), 13))
        //        tileData.sprite = roadSprites[9];
            if (HasSignal(tilemap, new Vector3Int(location.x + -1, location.y + 0, location.z), 14))
                tileData.sprite = roadSprites[9];
        }
        if (composition[6] == 'R')
        {
            //if (HasSignal(tilemap, new Vector3Int(location.x + 1, location.y + 0, location.z), 11))
            //    tileData.sprite = roadSprites[7];
            if (HasSignal(tilemap, new Vector3Int(location.x + 1, location.y + 0, location.z), 14))
                tileData.sprite = roadSprites[7];
        }

        //QUEO
        //4E
        if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = roadSprites[2];
        }
        if (composition[1] == 'R' && composition[3] == 'E' && composition[4] == 'R' && composition[6] == 'E')
        {
            tileData.sprite = roadSprites[3];
        }
        if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'R' && composition[6] == 'R')
        {
            tileData.sprite = roadSprites[4];
        }
        {
        if (composition[1] == 'E' && composition[3] == 'R' && composition[4] == 'E' && composition[6] == 'R')
            tileData.sprite = roadSprites[5];
        }



        //NGA BA
    
        if ( composition[1] == 'R'  && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'E')
        {
            tileData.sprite = roadSprites[11];
        }
        if (composition[1] == 'R' && composition[3] == 'R' && composition[4] == 'E' && composition[6] == 'R')
        {
            tileData.sprite = roadSprites[10];
        }
        if (composition[1] == 'E' && composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R')
        {
            tileData.sprite = roadSprites[13];
        }
        if (composition[1] == 'R' && composition[3] == 'E' && composition[4] == 'R' && composition[6] == 'R')
        {
            tileData.sprite = roadSprites[12];
        }
        //traffic
        if (composition[3] == 'R')
        {
            if (HasSignal(tilemap, new Vector3Int(location.x, location.y - 1, location.z), 12))
            {
                tileData.sprite = roadSprites[8];
                //if (!HasSignal(tilemap, new Vector3Int(location.x + 1, location.y - 1, location.z), 12) || !HasSignal(tilemap, new Vector3Int(location.x - 1, location.y - 1, location.z), 12))
                //    tileData.sprite = roadSprites[1];
                if(composition[0]=='E'||composition[5]=='E')
                    tileData.sprite = roadSprites[1];
            }
        }
        if (composition[4] == 'R')
        {
            if (HasSignal(tilemap, new Vector3Int(location.x, location.y + 1, location.z), 10))
            {
                tileData.sprite = roadSprites[6];
                //if (!HasSignal(tilemap, new Vector3Int(location.x - 1, location.y + 1, location.z), 10) || !HasSignal(tilemap, new Vector3Int(location.x + 1, location.y + 1 + 1, location.z), 10))
                //    tileData.sprite = roadSprites[1];
                if (composition[3] == 'E' || composition[7] == 'E')
                    tileData.sprite = roadSprites[1];
            } }
        if (composition[1] == 'R')
        {
            if (HasSignal(tilemap, new Vector3Int(location.x + -1, location.y + 0, location.z), 13))
            {
                tileData.sprite = roadSprites[9];
                //if (!HasSignal(tilemap, new Vector3Int(location.x - 1, location.y + 1, location.z), 13) || !HasSignal(tilemap, new Vector3Int(location.x - 1, location.y - 1, location.z), 13))
                //    tileData.sprite = roadSprites[0];
                if (composition[0] == 'E' || composition[2] == 'E')
                    tileData.sprite = roadSprites[0];
            }
        }
        if (composition[6] == 'R')
        {
            if (HasSignal(tilemap, new Vector3Int(location.x + 1, location.y + 0, location.z), 11))
            {
                tileData.sprite = roadSprites[7];
                //if (!HasSignal(tilemap, new Vector3Int(location.x + 1, location.y + 1, location.z), 11) || !HasSignal(tilemap, new Vector3Int(location.x + 1, location.y - 1, location.z), 11))
                //    tileData.sprite = roadSprites[0];
                if (composition[5] == 'E' || composition[7] == 'E')
                    tileData.sprite = roadSprites[0];
            }
        }
      
        //NGA TU
        if (composition[0] == 'E' && composition[1] == 'R' && composition[2] == 'E' && composition[3] == 'R' && composition[4] == 'R' && composition[5] == 'E' && composition[6] == 'R')
        {
            tileData.sprite = roadSprites[14];
          
        }
        //2 CHIEU
        if (composition[1] == 'R' && composition[6] == 'R' && composition[4] == 'R')
        {
            if (composition[2] == 'R' && composition[7] == 'R')
                tileData.sprite = roadSprites[0];

        }
        if (composition[1] == 'R' && composition[6] == 'R' && composition[3] == 'R')
        {

            if (composition[0] == 'R' && composition[5] == 'R')
                tileData.sprite = roadSprites[0];
        }
        if (composition[3] == 'R' && composition[4] == 'R' && composition[1] == 'R')
        {
            if (composition[2] == 'R' && composition[0] == 'R')
                tileData.sprite = roadSprites[1];
        }

        if (composition[3] == 'R' && composition[4] == 'R' && composition[6] == 'R')
        {
            if (composition[7] == 'R' && composition[5] == 'R')
                tileData.sprite = roadSprites[1];
        }
     
      
        
    }
    
    private bool HasSignal(ITilemap tilemap, Vector3Int position,int nPos)
    {
        if (tilemap.GetTile(position) == this)

        {
            if (tilemap.GetSprite(position) == roadSprites[nPos])
                return true;
        }
        return false;

    }
    private bool HasRoad(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }
    
    
    [MenuItem("Assets/Create/Tiles/RoadTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Roadtile", "New Roadtile", "asset", "Save Roadtile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RoadTile>(), path);
    }
#endif
}
