using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomGameMode : MainStatesMachine
    {
        [Header("Room's parameters")]
        [SerializeField]
        private int m_roomLength = 10;
        [SerializeField]
        private Vector2Int m_roomWidth = new Vector2Int(5, 10);
        [SerializeField]
        private int m_roomMaxWidthStep = 2;

        [Header("Rooms references")]
        [SerializeField]
        private GameObject m_enterDoors = null;
        [SerializeField]
        private Transform m_roomParent = null;

        [Header("Tiles Prefab")]
        [SerializeField]
        private float m_tileSize = 1;
        [SerializeField]
        private GameObject m_groundTile = null;
        [SerializeField]
        private GameObject m_wallTile = null;

        #region Tiling
        struct Tile
        {
            public enum ETileType
            {
                Ground,
                Lava,
                Spikes,
                Void
            }
            public ETileType TileType;
            public Vector3 Position;
        }
        private List<Tile> m_tiles = new List<Tile>();
        #endregion

        public override IEnumerator LoadAsync()
        {
            yield return null;
            int lastWidth = -1;
            for(int i = 0; i < m_roomLength; ++i)
            {
                float currentZ = m_enterDoors.transform.position.z + (i + m_tileSize) * m_tileSize;
                //Random.InitState((new System.Random((int)Time.time * 100 * GetHashCode())).Next(-10000, 100000));
                int width;
                if(lastWidth == -1)
                {
                    width = Random.Range(m_roomWidth.x, m_roomWidth.y);
                    for(int j = 1; j < width; ++j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ - m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    yield return null;
                    for (int j = -2; j >= -width; --j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ - m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    yield return null;
                }
                else
                {
                    width = lastWidth + Random.Range(-m_roomMaxWidthStep, m_roomMaxWidthStep);
                    if(width < m_roomWidth.x || width > m_roomWidth.y)
                    {
                        width = lastWidth;
                    }
                }
                

                Debug.Log(width);
                for(int j = 0; j < width; ++j)
                {
                    float currentX = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;

                    Tile newTile;
                    newTile.TileType = Tile.ETileType.Ground;
                    newTile.Position = new Vector3(currentX, 0, currentZ);
                    m_tiles.Add(newTile);
                    //Instantiate(m_groundTile, new Vector3(currentX, 0, currentZ), Quaternion.identity, m_roomParent);
                }
                yield return null;
                for (int j = 0; j < width; ++j)
                {
                    float currentX = m_enterDoors.transform.position.x + -(j + (m_tileSize / 2)) * m_tileSize;
                    Tile newTile;
                    newTile.TileType = Tile.ETileType.Ground;
                    newTile.Position = new Vector3(currentX, 0, currentZ);
                    m_tiles.Add(newTile);
                    //Instantiate(m_groundTile, new Vector3(currentX, 0, currentZ), Quaternion.identity, m_roomParent);
                }
                yield return null;
                float wallWidthPos = width;
                do
                {
                    float x = m_enterDoors.transform.position.x + (wallWidthPos + (m_tileSize / 2)) * m_tileSize;
                    Instantiate(m_wallTile, new Vector3(x, 0, currentZ), Quaternion.identity, m_roomParent);
                    x = m_enterDoors.transform.position.x + -(wallWidthPos + (m_tileSize / 2)) * m_tileSize;
                    Instantiate(m_wallTile, new Vector3(x, 0, currentZ), Quaternion.identity, m_roomParent);

                    if(wallWidthPos < lastWidth)
                    {
                        wallWidthPos++;
                    }
                    else if(wallWidthPos > lastWidth)
                    {
                        wallWidthPos--;
                    }
                } while (wallWidthPos != lastWidth && lastWidth != -1) ;
                yield return null;
                if(i == m_roomLength - 1)
                {
                    for (int j = 1; j < width; ++j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    for (int j = -2; j >= -width; --j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }
                }

                lastWidth = width;
                yield return null;
            }
            yield return null;

            for(int i = 0; i < m_tiles.Count; ++i)
            {
                if(m_tiles[i].TileType == Tile.ETileType.Ground)
                {
                    Instantiate(m_groundTile, m_tiles[i].Position, Quaternion.identity, m_roomParent);
                }
                else if(m_tiles[i].TileType == Tile.ETileType.Lava)
                {

                }
                else if(m_tiles[i].TileType == Tile.ETileType.Spikes)
                {

                }
                else if(m_tiles[i].TileType == Tile.ETileType.Void)
                {

                }
                else
                {
                    Debug.LogError("Incorrect tile type");
                }
            }

            yield return base.LoadAsync();
        }
    }
}