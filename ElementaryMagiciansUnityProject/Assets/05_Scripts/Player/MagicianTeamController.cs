﻿using System.Collections.Generic;
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


        public void DoFixedUpdate()
        {
            SetDirection();
            Move();
            foreach(MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoFixedUpdate();
            }
        }

        public void DoLateUpdate()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoLateUpdate();
            }
        }

        public void DoUpdate()
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

        public void AddMagician(MageData mageData, Vector3 spawnPosition)
        {
            m_magiciansManager.AddMagician(mageData).Init(
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed,
                spawnPosition);
        }

        public void InitAllMagicians()
        {
            for(int i = 0; i < m_magiciansManager.Magicians.Count; ++i)
            {
                m_magiciansManager.Magicians[i].Init(
                    m_positionTargetsManager.PositionTargets[i],
                    m_speed);
            }
        }

        public MageData GetRandomFreeMageData()
        {
            return m_magiciansManager.GetRandomFreeMageData();
        }

        #region Walker
        private void SetDirection()
        {
            m_directionInputs = m_actions.Gameplay.Move.ReadValue<Vector2>();
            m_direction = new Vector3(m_directionInputs.x, 0, m_directionInputs.y);
        }

        internal void SetPosition(Vector3 position)
        {
            m_teamTargetPosition.position = position;
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