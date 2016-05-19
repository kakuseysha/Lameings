using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {

    Tile[,] tileMap;
    List<GameObject> tileObjects = new List<GameObject>();
    GameObject mapObject;

    public void CreateRandomTileMap(int sizeX = 1, int sizeY = 1)
    {
        tileMap = new Tile[sizeX, sizeY];

        mapObject = GameObject.Instantiate(Resources.Load<GameObject>("Empty"));
        mapObject.name = "TileMap";

        for (int y = 0; y < sizeY; y++)
        {            
            for (int x = 0; x < sizeX; x++)
            {
                int rand = Random.Range(0, 3);

                string randomTile = "Tile_";
                if (rand == 0)
                    randomTile += "Block";
                else if (rand == 1)
                    randomTile += "Damage";
                else
                    randomTile += "Walkable";                

                GameObject newTile = GameObject.Instantiate(Resources.Load<GameObject>(randomTile));
                newTile.transform.parent = mapObject.transform;
                Vector3 tilePosition = new Vector3(x, 0, y);
                newTile.transform.position = tilePosition;
                tileObjects.Add(newTile);
                tileMap[x, y] = newTile.GetComponent<Tile>();
            }
        }

        Vector3 cameraPosition = new Vector3(((float)(sizeX - 1.0f)/ 2), 5 , -5);
       // Camera.main.transform.position = cameraPosition;
        Debug.Log(tileMap[0, 1]);
    }
}
