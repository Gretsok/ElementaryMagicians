using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ElementaryMagicians.Dunjeon
{

    public class SpellFrame : MonoBehaviour
    {
        [SerializeField] private Image m_spellIcon = null;
        private Player.MageData m_mageData = null;

        public void Inflate(Player.MageData mageData)
        {
            m_mageData = mageData;
            m_spellIcon.sprite = mageData.PrimaryAttackIcon;
            gameObject.SetActive(true);
        }
    }

}
