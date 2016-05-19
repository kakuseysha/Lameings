using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public MapManager mapManager;

    void Start()
    {
        mapManager.CreateRandomTileMap(10, 10);
    }
}
