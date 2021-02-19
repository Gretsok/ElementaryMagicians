using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ElementaryMagicians.Dunjeon
{

    public class SpellBar : Panel
    {
        [SerializeField] private List<SpellFrame> m_spellFrames = new List<SpellFrame>();
        public List<SpellFrame> SpellFrames => m_spellFrames;
        public void InflateNewMagicien(int magicianIndex, Player.MageData mageData)
        {
            m_spellFrames[magicianIndex].Inflate(mageData);
        }
    }

}
