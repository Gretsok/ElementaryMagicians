using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class MagicianFXManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_waterHealedFX = null;

        internal void GetWaterHealed()
        {
            if(!m_waterHealedFX.gameObject.activeSelf)
            {
                Invoke("StopWaterHealing", 2.2f);
            }
            m_waterHealedFX.gameObject.SetActive(true);
            
        }

        private void StopWaterHealing()
        {
            m_waterHealedFX.gameObject.SetActive(false);
        }

        [SerializeField]
        private GameObject m_dashFX = null;

        internal void EnableDash()
        {
            m_dashFX.SetActive(true);
        }

        internal void DisableDash()
        {
            m_dashFX.SetActive(false);
        }

    }
}