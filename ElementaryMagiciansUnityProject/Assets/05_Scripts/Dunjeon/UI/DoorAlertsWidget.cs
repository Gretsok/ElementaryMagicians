using System.Collections;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class DoorAlertsWidget : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_doorLockedObject = null;
        [SerializeField]
        private float m_doorLockedDisplayDuration = 3f;
        [SerializeField]
        private GameObject m_doorUnlockedObject = null;
        [SerializeField]
        private float m_doorUnlockedDisplayDuration = 3f;

        private void Awake()
        {
            m_doorLockedObject.SetActive(false);
            m_doorUnlockedObject.SetActive(false);
        }

        public void AlertDoorLocked()
        {
            m_doorLockedObject.SetActive(true);
            StartCoroutine(DoorLockedAlertRoutine());
        }

        public void AlertDoorUnlocked()
        {
            m_doorUnlockedObject.SetActive(true);
            StartCoroutine(DoorUnlockedAlertRoutine());
        }

        private IEnumerator DoorLockedAlertRoutine()
        {
            yield return new WaitForSeconds(m_doorLockedDisplayDuration);
            m_doorLockedObject.SetActive(false);
        }

        private IEnumerator DoorUnlockedAlertRoutine()
        {
            yield return new WaitForSeconds(m_doorUnlockedDisplayDuration);
            m_doorUnlockedObject.SetActive(false);
        }
    }
}