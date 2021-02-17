using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class MagiciansManager : MonoBehaviour
    {
        [SerializeField]
        private List<MagicianController> m_magicians = new List<MagicianController>();

        internal List<MagicianController> Magicians => m_magicians;

        #region bool
        internal bool HasFireMagician = false;
        internal bool HasWaterMagician = false;
        internal bool HasWindMagician = false;
        internal bool HasIceMagician = false;
        internal bool HasPoisonMagician = false;
        internal bool HasRockMagician = false;
        internal bool HasPlantMagician = false;
        #endregion


        [SerializeField]
        private MageData[] m_magesData = null;


        internal MageData GetRandomFreeMageData()
        {
            List<MageData> magesData = new List<MageData>();
            foreach(MageData mageData in m_magesData)
            {
                if (mageData.MagicianPrefab is FireMagicianController && !HasFireMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is WaterMagicianController && !HasWaterMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is WindMagicianController && !HasWindMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is IceMagicianController && !HasIceMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is PoisonMagicianController && !HasPoisonMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is RockMagicianController && !HasRockMagician)
                {
                    magesData.Add(mageData);
                }
                else if (mageData.MagicianPrefab is PlantMagicianController && !HasPlantMagician)
                {
                    magesData.Add(mageData);
                }
            }
            if(magesData.Count == 0)
            {
                Debug.LogWarning("ALREADY HAVE ALL MAGES");
                return null;
            }
            int randomIndex = Random.Range(0, magesData.Count);
            return magesData[randomIndex];
            
        }

        internal MagicianController AddMagician(MageData mageData)
        {
            
            if(mageData.MagicianPrefab is FireMagicianController && !HasFireMagician)
            {
                HasFireMagician = true;
            }
            else if(mageData.MagicianPrefab is WaterMagicianController && !HasWaterMagician)
            {
                HasWaterMagician = true;
            }
            else if (mageData.MagicianPrefab is WindMagicianController && !HasWindMagician)
            {
                HasWindMagician = true;
            }
            else if (mageData.MagicianPrefab is IceMagicianController && !HasIceMagician)
            {
                HasIceMagician = true;
            }
            else if (mageData.MagicianPrefab is PoisonMagicianController && !HasPoisonMagician)
            {
                HasPoisonMagician = true;
            }
            else if (mageData.MagicianPrefab is RockMagicianController && !HasRockMagician)
            {
                HasRockMagician = true;
            }
            else if (mageData.MagicianPrefab is PlantMagicianController && !HasPlantMagician)
            {
                HasPlantMagician = true;
            }
            else
            {
                Debug.LogError("Error while trying to add a new magician");
                return null;
            }
            MagicianController magician = Instantiate(mageData.MagicianPrefab, transform);
            m_magicians.Add(magician);
            return magician;
        }
    }
}