using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class SaveMeWidget : MonoBehaviour
    {
        [SerializeField]
        private float m_displayDuration = 3f;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            StartCoroutine(ShowRoutine());
        }

        private IEnumerator ShowRoutine()
        {
            yield return new WaitForSeconds(m_displayDuration);
            gameObject.SetActive(false);
        }
    }
}