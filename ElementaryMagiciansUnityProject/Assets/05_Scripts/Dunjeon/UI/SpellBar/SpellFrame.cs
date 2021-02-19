using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ElementaryMagicians.Dunjeon
{

    public class SpellFrame : MonoBehaviour
    {
        [SerializeField] private Image m_spellIcon = null;
        private Player.MageData m_mageData = null;

        [SerializeField]
        private GameObject m_cooldownLock = null;
        [SerializeField]
        private TextMeshProUGUI m_cooldownDisplay = null;

        public void Inflate(Player.MageData mageData)
        {
            m_mageData = mageData;
            m_spellIcon.sprite = mageData.PrimaryAttackIcon;
            gameObject.SetActive(true);
        }

        public void SetCooldown(float cooldown)
        {
            if(cooldown > 0)
            {
                m_cooldownLock.SetActive(true);
                m_cooldownDisplay.text = ((int)cooldown + 1).ToString();
            }
            else
            {
                m_cooldownLock.SetActive(false);
            }
        }
    }

}
