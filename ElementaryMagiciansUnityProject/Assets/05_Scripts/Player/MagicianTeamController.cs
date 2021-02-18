using ElementaryMagicians.Combat;
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

        [SerializeField]
        private CombatController m_combatController = null;
        internal CombatController CombatController => m_combatController;

        private void Start()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
            m_combatController.Init();
            RegisterInputs();
        }

        private void RegisterInputs()
        {
            m_actions.Gameplay.FirstMage.performed += FirstMage_performed;
            m_actions.Gameplay.SecondMage.performed += SecondMage_performed;
            m_actions.Gameplay.ThirdMage.performed += ThirdMage_performed;
            m_actions.Gameplay.FourthMage.performed += FourthMage_performed;
            m_actions.Gameplay.FifthMage.performed += FifthMage_performed;
            m_actions.Gameplay.SixthMage.performed += SixthMage_performed;
            m_actions.Gameplay.SeventhMAge.performed += SeventhMAge_performed;
        }

        #region Magicians Attacks
        private void SeventhMAge_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 7)
            {
                m_magiciansManager.Magicians[6].PrimaryAttack();
            }
        }

        private void SixthMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 6)
            {
                m_magiciansManager.Magicians[5].PrimaryAttack();
            }
        }

        private void FifthMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 5)
            {
                m_magiciansManager.Magicians[4].PrimaryAttack();
            }
        }

        private void FourthMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 4)
            {
                m_magiciansManager.Magicians[3].PrimaryAttack();
            }
        }

        private void ThirdMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 3)
            {
                m_magiciansManager.Magicians[2].PrimaryAttack();
            }
        }

        private void SecondMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_magiciansManager.Magicians.Count >= 2)
            {
                m_magiciansManager.Magicians[1].PrimaryAttack();
            }
        }

        private void FirstMage_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(m_magiciansManager.Magicians.Count >= 1)
            {
                m_magiciansManager.Magicians[0].PrimaryAttack();
            }
        }
        #endregion
        public void DoFixedUpdate()
        {
            SetDirection();
            Move();
            foreach(MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.DoFixedUpdate();
            }
            m_combatController.DoUpdate();
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


        #region Magicians Management
        public void AddMagician(MageData mageData)
        {
            m_magiciansManager.AddMagician(mageData).Init(this,
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed);
        }

        public void AddMagician(MageData mageData, Vector3 spawnPosition)
        {
            m_magiciansManager.AddMagician(mageData).Init(this,
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed,
                spawnPosition);
        }

        public void InitAllMagicians()
        {
            for(int i = 0; i < m_magiciansManager.Magicians.Count; ++i)
            {
                m_magiciansManager.Magicians[i].Init(this,
                    m_positionTargetsManager.PositionTargets[i],
                    m_speed);
            }
        }

        public MageData GetRandomFreeMageData()
        {
            return m_magiciansManager.GetRandomFreeMageData();
        }
        #endregion

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