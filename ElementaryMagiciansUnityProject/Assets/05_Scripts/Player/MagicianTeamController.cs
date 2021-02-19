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
        private float m_baseSpeed = 5f;
        [SerializeField]
        private LayerMask m_movingMask = 1;
        private Vector3 m_direction = Vector3.zero;
        internal Vector3 Direction => m_direction;

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

        [SerializeField]
        private LayerMask m_cursorLayerMask = 1;

        private Vector3 m_worldCursorPosition = Vector3.zero;
        internal Vector3 WorldCursorPosition => m_worldCursorPosition;

        private delegate void MoveMethod();
        private MoveMethod m_move = null;

        #region SpecificBehaviours Attributes
        private Vector3 m_dashingDirection = Vector3.zero;

        #endregion

        private Dunjeon.SpellBar m_spellBar = null;

        public void SetSpellBar(Dunjeon.SpellBar spellbar)
        {
            m_spellBar = spellbar;
            for(int i = 0; i < m_magiciansManager.Magicians.Count; ++i)
            {
                m_spellBar.InflateNewMagicien(i, m_magiciansManager.Magicians[i].MageData);
                m_magiciansManager.Magicians[i].SetSpellFrame(m_spellBar.SpellFrames[i]);
            }
        }

        private void Start()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
            m_combatController.Init();
            RegisterInputs();
            m_move = NormallyMove;
            m_baseSpeed = m_speed;
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
            m_move();
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
            m_combatController.DoUpdate();
            ManageWorldCursorPosition();
        }

        private void ManageWorldCursorPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f, m_cursorLayerMask, QueryTriggerInteraction.Ignore))
            {
                m_worldCursorPosition = hit.point;
            }
        }

        #region FXPlaying
        internal void GetWaterHealed()
        {
            foreach(MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.FXManager.GetWaterHealed();
            }
        }

        internal void StartDash()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.FXManager.EnableDash();
            }
        }

        internal void StopDash()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.FXManager.DisableDash();
            }
        }
        #endregion

        #region Magicians Common Actions
        internal void Dash(Vector3 directionPoint, float dashSpeed, float dashDuration)
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.transform.LookAt(directionPoint);
                mage.Agent.speed = dashSpeed;
            }
            m_baseSpeed = m_speed;
            m_speed = dashSpeed;
            m_move = DashingMove;
            m_dashingDirection = (directionPoint - m_teamTargetPosition.transform.position).normalized;
            Invoke("EndDash", dashDuration);
            StartDash();
        }

        private void EndDash()
        {
            foreach (MagicianController mage in m_magiciansManager.Magicians)
            {
                mage.Agent.speed = m_baseSpeed;
            }
            m_speed = m_baseSpeed;
            m_move = NormallyMove;
            StopDash();
        }
        #endregion

        #region Magicians Management
        public void AddMagician(MageData mageData)
        {
            m_magiciansManager.AddMagician(mageData).Init(this,
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed);
            if (m_spellBar != null)
            {
                m_spellBar?.InflateNewMagicien(m_magiciansManager.Magicians.Count - 1,
                mageData);
                m_magiciansManager.Magicians[m_magiciansManager.Magicians.Count - 1].SetSpellFrame(
                m_spellBar.SpellFrames[m_magiciansManager.Magicians.Count - 1]);
            }
        }

        public void AddMagician(MageData mageData, Vector3 spawnPosition)
        {
            m_magiciansManager.AddMagician(mageData).Init(this,
                m_positionTargetsManager.PositionTargets[m_magiciansManager.Magicians.Count - 1],
                m_speed,
                spawnPosition);
           
            if(m_spellBar != null)
            {
                m_spellBar?.InflateNewMagicien(m_magiciansManager.Magicians.Count - 1,
                mageData);
                m_magiciansManager.Magicians[m_magiciansManager.Magicians.Count - 1].SetSpellFrame(
                m_spellBar.SpellFrames[m_magiciansManager.Magicians.Count - 1]);
            }
            
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

        public MagicianController GetRandomMagician()
        {
            int randomIndex = Random.Range(0, m_magiciansManager.Magicians.Count);
            return m_magiciansManager.Magicians[randomIndex];
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

        private void NormallyMove()
        {

            if (Physics.Raycast(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {

                m_teamTargetPosition.position = m_nextPositionInfos.point;

                /*Debug.DrawLine(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                    m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f + Vector3.down * 3f,
                    Color.red, 10f);*/
            }
            else if(Physics.SphereCast(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                0.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {

                 m_teamTargetPosition.position = m_nextPositionInfos.point;

                /*Debug.DrawLine(m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
        m_teamTargetPosition.position + m_direction * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f + Vector3.down * 3f,
        Color.blue, 10f);*/

            }
        }

        private void DashingMove()
        {
            if (Physics.Raycast(m_teamTargetPosition.position + m_dashingDirection * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {
                m_teamTargetPosition.position = m_nextPositionInfos.point;
            }
            else if (Physics.SphereCast(m_teamTargetPosition.position + m_dashingDirection * m_speed * Time.fixedDeltaTime + Vector3.up * 1.5f,
                0.5f,
                Vector3.down, out m_nextPositionInfos, 3f, m_movingMask))
            {
                m_teamTargetPosition.position = m_nextPositionInfos.point;
            }
        }
        #endregion
    }
}