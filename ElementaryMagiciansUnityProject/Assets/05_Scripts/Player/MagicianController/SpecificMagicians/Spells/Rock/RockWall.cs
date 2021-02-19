using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ElementaryMagicians.Player
{
    public class RockWall : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_wallModel = null;

        [SerializeField]
        private float m_startingLocalHeight = -3f;

        [SerializeField]
        private float m_finishingLocalHeight = 0f;

        [SerializeField]
        private float m_comingOutOfGroundDuration = 1f;
        [SerializeField]
        private float m_lifeSpan = 8f;
        [SerializeField]
        private float m_goingIntoGroundDuration = 1f;

        private void Awake()
        {
            Vector3 localPosition = m_wallModel.transform.localPosition;
            localPosition.y = m_startingLocalHeight;
            m_wallModel.transform.localPosition = localPosition;
            StartCoroutine(WallRoutine());
        }

        IEnumerator WallRoutine()
        {
            float timeOfLastIteration = Time.time;
            yield return null;
            while(m_wallModel.transform.localPosition.y < m_finishingLocalHeight)
            {
                m_wallModel.transform.localPosition += Vector3.up * (1 / m_comingOutOfGroundDuration) * (Time.time - timeOfLastIteration);
                timeOfLastIteration = Time.time;
                yield return null;
            }

            yield return new WaitForSeconds(m_lifeSpan);
            timeOfLastIteration = Time.time;
            yield return null;
            while (m_wallModel.transform.localPosition.y > m_startingLocalHeight)
            {
                m_wallModel.transform.localPosition += Vector3.down * (1 / m_goingIntoGroundDuration) * (Time.time - timeOfLastIteration);
                timeOfLastIteration = Time.time;
                yield return null;
            }
            Destroy(gameObject);
        }

    }
}