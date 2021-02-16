using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class MagicianTeamController : MonoBehaviour
    {
        [SerializeField]
        private Transform m_teamTargetPosition = null;
        [SerializeField]
        private float m_speed = 5f;
        [SerializeField]
        private LayerMask m_movingMask = 1;
        private Vector3 m_direction = Vector3.zero;

        RaycastHit m_nextPositionInfos;

        #region Inputs
        private PlayerInputsActions m_actions = null;
        private Vector2 m_directionInputs = Vector2.zero;

        #endregion

        [SerializeField]
        private TeamPositionTargetsManager m_positionTargetsManager = null;
        [SerializeField]
        private MagiciansManager m_magiciansManager = null;

        private void Start()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
        }

        private void FixedUpdate()
        {
            DoFixedUpdate();
        }

        private void LateUpdate()
        {
            DoLateUpdate();
        }

        private void Update()
        {
            DoUpdate();
        }

        private void DoFixedUpdate()
        {
            SetDirection();
            Move();
            foreach(MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoFixedUpdate();
            }
        }

        private void DoLateUpdate()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoLateUpdate();
            }
        }

        private void DoUpdate()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoUpdate();
            }
        }

        public void AddMagician(MageData mageData)
        {
            m_magiciansManager.AddMagician(mageData).Init(
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed);
        }


        #region Walker
        private void SetDirection()
        {
            m_directionInputs = m_actions.Gameplay.Move.ReadValue<Vector2>();
            m_direction = new Vector3(m_directionInputs.x, 0, m_directionInputs.y);
        }

        private void Move()
        {

            if (Physics.Raycast(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {

                m_teamTargetPosition.position = m_nextPositionInfos.point;

                Debug.DrawLine(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                    m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f + Vector3.down * 3f,
                    Color.red, 10f);
            }
            else if(Physics.SphereCast(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                0.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {

                 m_teamTargetPosition.position = m_nextPositionInfos.point;

                Debug.DrawLine(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
        m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f + Vector3.down * 3f,
        Color.blue, 10f);

            }
        }
        #endregion
    }
}