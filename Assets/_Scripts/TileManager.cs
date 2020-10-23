using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    // declare queue of type of gameobject
    private Queue<GameObject> m_TilePool;

    // the maximum amount of tiles.
    public int MaxTiles;

    // Start is called before the first frame update
    void Start() // TODO: replace with Awake?
    {
        m_TilePool = new Queue<GameObject>();
        _BuildTilePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildTilePool()
    {
        // The instantiates itself.
        for(var count = 0; count < MaxTiles; count++)
        {
            // Enque a new file from the factory
            var tempTile = TileFactory.Instance().CreateTile();
            tempTile.SetActive(false);
            m_TilePool.Enqueue(tempTile);
        }
    }

    /// <summary>
    /// Returned a GameObject Tile.
    /// </summary>
    /// <returns></returns>
    public GameObject GetTile()
    {
        Debug.Log(m_TilePool.Count);

        // when it's removed from the pool, set it to active.
        var tempTile = m_TilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    /// <summary>
    /// returns a GameObject tile back into the pool.
    /// </summary>
    /// <param name="tile"></param>
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        m_TilePool.Enqueue(tile);
    }
}
