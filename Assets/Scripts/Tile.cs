using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public enum TileTypes
    {
        Walkable,
        Damaging,
        Blocking,
        Interactive
    }

    public TileTypes tileType = TileTypes.Walkable;

}
