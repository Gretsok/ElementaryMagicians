using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ElementaryMagicians.Dunjeon
{

    public class SpellBar : MonoBehaviour
    {
        [SerializeField] private List<SpellFrame> m_spellFrames = new List<SpellFrame>();

        public void InflateNewMagicien(int magicianIndex, Player.MageData mageData)
        {
            m_spellFrames[magicianIndex].Inflate(mageData);
        }
    }

}
