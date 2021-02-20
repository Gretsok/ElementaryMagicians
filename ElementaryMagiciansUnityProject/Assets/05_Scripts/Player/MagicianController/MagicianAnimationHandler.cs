using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class MagicianAnimationHandler : MonoBehaviour
    {
        private int SPEEDRATIO = Animator.StringToHash("SpeedRatio");
        private int STARTPRIMARYATTACK = Animator.StringToHash("StartPrimaryAttack");
        private int STOPPRIMARYATTACK = Animator.StringToHash("StopPrimaryAttack");
        /*private int STARTSECONDARYATTACK = Animator.StringToHash("StartSecondaryAttack");
        private int STOPSECONDARYATTACK = Animator.StringToHash("StopSecondaryAttack");*/

        [SerializeField]
        private Animator m_animator = null;

        internal void SetSpeedRatio(float speedRatio)
        {
            m_animator.SetFloat(SPEEDRATIO, speedRatio);
        }

        internal void PrimaryAttack()
        {
            StartCoroutine(PrimaryAttackRoutine(0.5f));
        }

        IEnumerator PrimaryAttackRoutine(float timeToKeep)
        {
            m_animator.SetTrigger(STARTPRIMARYATTACK);
            yield return new WaitForSeconds(timeToKeep);
            m_animator.SetTrigger(STOPPRIMARYATTACK);
        }

        internal void SecondaryAttack()
        {

        }
    }
}