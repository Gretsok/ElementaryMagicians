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