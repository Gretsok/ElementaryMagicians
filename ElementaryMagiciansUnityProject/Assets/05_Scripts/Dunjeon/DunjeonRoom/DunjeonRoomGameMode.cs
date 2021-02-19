using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomGameMode : MainStatesMachine
    {
        [Header("Room's generation parameters")]
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
        [SerializeField]
        private Transform m_playerSpawnPoint = null;

        [Header("Tiles Prefab")]
        [SerializeField]
        private float m_tileSize = 1;
        [SerializeField]
        private GameObject m_groundTile = null;
        [SerializeField]
        private GameObject m_lavaTile = null;
        [SerializeField]
        private GameObject m_spikeTile = null;
        [SerializeField]
        private GameObject m_voidTile = null;
        [SerializeField]
        private GameObject m_wallTile = null;
        [SerializeField]
        private GameObject m_doorTile = null;

        [Header("Obstacles")]
        [SerializeField]
        private Vector2Int m_numberOfLavaHoles = new Vector2Int(1, 3);
        [SerializeField]
        private Vector2 m_sizeOfLavaHoles = new Vector2(2, 4);

        [SerializeField]
        private Vector2Int m_numberOfSpikesSpot = new Vector2Int(1, 2);
        [SerializeField]
        private Vector2 m_sizeOfSpikesSpot = new Vector2(0, 2);

        [SerializeField]
        private Vector2Int m_numberOfVoidHoles = new Vector2Int(1, 2);
        [SerializeField]
        private Vector2 m_sizeOfVoidHoles = new Vector2(2, 4);

        [Header("Objects to spawn")]
        [SerializeField]
        private MagePrison m_magePrisonPrefab = null;
        [SerializeField]
        private int m_magePrisonChanceToSpawnInPercent = 20;

        [Header("States")]
        [SerializeField]
        private DunjeonRoomLoseState m_loseState = null;



        [System.Serializable]
        struct EnnemyToSpawnData
        {
            public Vector2Int NumberOfEnnemiesToSpawn;
            public Ennemy.EnnemyAI EnnemyToSpawnPrefab;
        }
        [Header("Ennemies To Spawn")]
        [SerializeField]
        private List<EnnemyToSpawnData> m_ennemiesToSpawnData = new List<EnnemyToSpawnData>();

        private List<Ennemy.EnnemyAI> m_ennemies = new List<Ennemy.EnnemyAI>();
        internal List<Ennemy.EnnemyAI> Ennemies => m_ennemies;

        [Header("Other references")]
        [SerializeField]
        private Player.MagicianTeamController m_magicianTeamPrefab = null;
        private Player.MagicianTeamController m_magicianTeamController = null;
        public Player.MagicianTeamController MagicianTeamController => m_magicianTeamController;
        [SerializeField]
        private ProjElf.SceneData.SceneData m_roomSceneData = null;
        [SerializeField]
        private SaveMeWidget m_saveMeWidget = null;


        private bool m_canLoadNextRoom = false;



        #region Tiling
        internal enum ETileType
        {
            Ground,
            FixedGround,
            Lava,
            Spikes,
            Void
        }
        internal class TileData
        {

            internal ETileType TileType = ETileType.Ground;
            internal Vector3 Position;
        }
        private List<TileData> m_tiles = new List<TileData>();

        internal TileData GetGroundTile()
        {
            TileData tileToReturn = null;
            while (tileToReturn == null || tileToReturn != null && tileToReturn.TileType != ETileType.Ground && tileToReturn.TileType != ETileType.FixedGround)
            {
                int randomIndex = Random.Range(0, m_tiles.Count);
                tileToReturn = m_tiles[randomIndex];
            }
            return tileToReturn;
        }
        #endregion

        #region Obstacles
        struct Obstacle
        {
            public ETileType type;
            public Vector3 center;
            public float size;
        }

        #endregion

        public override IEnumerator LoadAsync()
        {
            yield return null;

            #region room generation
            int lastWidth = -1;
            for(int i = 0; i < m_roomLength; ++i)
            {
                float currentZ = m_enterDoors.transform.position.z + (i + m_tileSize / 2) * m_tileSize;
                //Random.InitState((new System.Random((int)Time.time * 100 * GetHashCode())).Next(-10000, 100000));
                int width;
                if(lastWidth == -1)
                {
                    width = Random.Range(m_roomWidth.x, m_roomWidth.y);
                    // Placing walls next to enter door
                    for(int j = 1; j < width; ++j)
                    {
                        float x = m_enterDoors.transform.position.x + j * m_tileSize + m_tileSize /2;
                        Instantiate(m_wallTile, new Vector3(x, 0, m_enterDoors.transform.position.z), Quaternion.identity, m_roomParent);
                    }
                    for (int j = -1; j > -width; --j)
                    {
                        float x = m_enterDoors.transform.position.x + j * m_tileSize - m_tileSize /2;
                        Instantiate(m_wallTile, new Vector3(x, 0, m_enterDoors.transform.position.z), Quaternion.identity, m_roomParent);
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
                    float currentX = m_enterDoors.transform.position.x + j * m_tileSize + m_tileSize /2;

                    TileData newTile = new TileData();
                    if (j == 0)
                    {
                        newTile.TileType = ETileType.FixedGround;
                    }
                    else
                    {
                        newTile.TileType = ETileType.Ground;
                    }
                    newTile.Position = new Vector3(currentX, 0, currentZ);
                    m_tiles.Add(newTile);
                    //Instantiate(m_groundTile, new Vector3(currentX, 0, currentZ), Quaternion.identity, m_roomParent);
                }
                for (int j = 0; j < width; ++j)
                {
                    float currentX = m_enterDoors.transform.position.x + -j * m_tileSize - m_tileSize /2;
                    TileData newTile = new TileData();
                    if(j == 0)
                    {
                        newTile.TileType = ETileType.FixedGround;
                    }
                    else
                    {
                        newTile.TileType = ETileType.Ground;
                    }
                    
                    newTile.Position = new Vector3(currentX, 0, currentZ);
                    m_tiles.Add(newTile);
                    //Instantiate(m_groundTile, new Vector3(currentX, 0, currentZ), Quaternion.identity, m_roomParent);
                }
                yield return null;
                float wallWidthPos = width;
                do
                {
                    float x = m_enterDoors.transform.position.x + wallWidthPos * m_tileSize + m_tileSize /2;
                    Instantiate(m_wallTile, new Vector3(x, 0, currentZ), Quaternion.identity, m_roomParent);
                    x = m_enterDoors.transform.position.x + -wallWidthPos * m_tileSize - m_tileSize /2;
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
                    // Placing walls next to exit door
                    /*for (int j = 1; j < width; ++j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    for (int j = -2; j >= -width; --j)
                    {
                        float x = m_enterDoors.transform.position.x + (j + (m_tileSize / 2)) * m_tileSize;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }*/
                    for (int j = 1; j < width; ++j)
                    {
                        float x = m_enterDoors.transform.position.x + j * m_tileSize + m_tileSize / 2;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    for (int j = -1; j > -width; --j)
                    {
                        float x = m_enterDoors.transform.position.x + j * m_tileSize - m_tileSize / 2;
                        Instantiate(m_wallTile, new Vector3(x, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                    }
                    Instantiate(m_doorTile, new Vector3(0, 0, currentZ + m_tileSize), Quaternion.identity, m_roomParent);
                }

                lastWidth = width;
                yield return null;
            }
            yield return null;

            List<Obstacle> m_obstacles = new List<Obstacle>();

            int numberOfLavAHoles = Random.Range(m_numberOfLavaHoles.x, m_numberOfLavaHoles.y);
            for(int i = 0; i < numberOfLavAHoles; ++i)
            {
                TileData randomTile = m_tiles[Random.Range(0, m_tiles.Count)];
                if(randomTile.TileType != ETileType.FixedGround)
                {
                    randomTile.TileType = ETileType.Lava;
                }
                

                Obstacle obstacle;
                obstacle.center = randomTile.Position;
                obstacle.type = ETileType.Lava;
                obstacle.size = Random.Range(m_sizeOfLavaHoles.x, m_sizeOfLavaHoles.y);
                m_obstacles.Add(obstacle);

            }

            int numberOfSpikesSpot = Random.Range(m_numberOfSpikesSpot.x, m_numberOfSpikesSpot.y);
            for (int i = 0; i < numberOfSpikesSpot; ++i)
            {
                TileData randomTile = m_tiles[Random.Range(0, m_tiles.Count)];
                if (randomTile.TileType != ETileType.FixedGround)
                {
                    randomTile.TileType = ETileType.Spikes;
                }

                Obstacle obstacle;
                obstacle.center = randomTile.Position;
                obstacle.type = ETileType.Spikes;
                obstacle.size = Random.Range(m_sizeOfSpikesSpot.x, m_sizeOfSpikesSpot.y);
                m_obstacles.Add(obstacle);
            }

            int numberOfVoidHoles = Random.Range(m_numberOfVoidHoles.x, m_numberOfVoidHoles.y);
            for (int i = 0; i < numberOfVoidHoles; ++i)
            {
                TileData randomTile = m_tiles[Random.Range(0, m_tiles.Count)];
                if (randomTile.TileType != ETileType.FixedGround)
                {
                    randomTile.TileType = ETileType.Void;
                }

                Obstacle obstacle;
                obstacle.center = randomTile.Position;
                obstacle.type = ETileType.Void;
                obstacle.size = Random.Range(m_sizeOfVoidHoles.x, m_sizeOfVoidHoles.y);
                m_obstacles.Add(obstacle);
            }

            yield return null;
            
            for(int i = 0; i < m_tiles.Count; ++i)
            {
                if(m_tiles[i].TileType != ETileType.FixedGround)
                {
                    for (int j = 0; j < m_obstacles.Count; ++j)
                    {
                        if ((m_obstacles[j].center - m_tiles[i].Position).magnitude < m_obstacles[j].size)
                        {
                            m_tiles[i].TileType = m_obstacles[j].type;
                        }
                    }
                }
            }

            yield return null;

            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < m_tiles.Count; ++i)
            {
                if(m_tiles[i].TileType == ETileType.Ground || m_tiles[i].TileType == ETileType.FixedGround)
                {
                    Instantiate(m_groundTile, m_tiles[i].Position, Quaternion.identity, m_roomParent);
                }
                else if(m_tiles[i].TileType == ETileType.Lava)
                {
                    tiles.Add(Instantiate(m_lavaTile, m_tiles[i].Position, Quaternion.identity, m_roomParent).GetComponent<Lava>());
                }
                else if(m_tiles[i].TileType == ETileType.Spikes)
                {
                    tiles.Add(Instantiate(m_spikeTile, m_tiles[i].Position, Quaternion.identity, m_roomParent).GetComponent<Spikes>());
                }
                else if(m_tiles[i].TileType == ETileType.Void)
                {
                    Instantiate(m_voidTile, m_tiles[i].Position, Quaternion.identity, m_roomParent);
                }
                else
                {
                    Debug.LogError("Incorrect tile type");
                }
            }
            yield return null;
            #endregion

            #region Creating NavMesh
            NavMeshSurface surface = m_roomParent.GetComponent<NavMeshSurface>();
            surface.buildHeightMesh = true;
            surface.BuildNavMesh();
            yield return null;
            #endregion

            yield return null;
            for(int i = 0; i < tiles.Count; ++i)
            {
                if(tiles[i] != null)
                {
                    tiles[i].Init();
                }
            }

            InstantiatePlayer();
            yield return null;
            #region Spawning Ennemies
            for (int i = 0; i < m_ennemiesToSpawnData.Count; ++i)
            {
                int numberOfEnnemiesToSpawn = Random.Range(m_ennemiesToSpawnData[i].NumberOfEnnemiesToSpawn.x, m_ennemiesToSpawnData[i].NumberOfEnnemiesToSpawn.y);
                for(int j = 0; j < numberOfEnnemiesToSpawn; ++j)
                {
                    TileData tileToSpawnOn = GetGroundTile();
                    m_ennemies.Add(Instantiate(m_ennemiesToSpawnData[i].EnnemyToSpawnPrefab, tileToSpawnOn.Position + Vector3.up, Quaternion.identity));
                }
            }
            #endregion
            yield return null;

            int randomPercentToSpawnMagePrison = Random.Range(1, 101);
            Debug.Log("PRISON SPAWNING: " + randomPercentToSpawnMagePrison + " for " + m_magePrisonChanceToSpawnInPercent);
            if(randomPercentToSpawnMagePrison < m_magePrisonChanceToSpawnInPercent)
            {
                Player.MageData mageDataToUse = m_magicianTeamController.GetRandomFreeMageData();
                if(mageDataToUse != null)
                {
                    TileData tileToSpawnPrisonOn = GetGroundTile();
                    MagePrison magePrison = Instantiate(m_magePrisonPrefab, tileToSpawnPrisonOn.Position + Vector3.up, Quaternion.identity);
                    magePrison.Inflate(mageDataToUse);
                    Debug.Log("Prison Spawned");
                    m_saveMeWidget.Show();
                }
            }

            yield return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_canLoadNextRoom = true;
        }

        private void InstantiatePlayer()
        {
            m_magicianTeamController = DunjeonManager.GetInstance().GetMagicianTeamController();
            m_magicianTeamController.SetPosition(m_playerSpawnPoint.position);
            m_magicianTeamController.InitAllMagicians();
        }

        internal void LoadNextRoom()
        {
            if(m_canLoadNextRoom)
            {
                DunjeonManager.GetInstance().IncrementRoomsPassed();
                m_roomSceneData.LoadLevel();
                m_canLoadNextRoom = false;
            }
        }

        internal void Lose()
        {
            SwitchToState(m_loseState);
        }
    }
}