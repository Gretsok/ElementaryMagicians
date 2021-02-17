using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ElementaryMagicians.Dunjeon
{
    public class MageTeamHealthBarPanel : Panel
    {
        [SerializeField]
        private Slider m_healthSlider = null;

        public void SetHealth(float healthRatio)
        {
            m_healthSlider.value = healthRatio;
        }
    }
}