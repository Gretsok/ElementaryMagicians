using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class WindMagicianController : MagicianController
    {
        [SerializeField]
        private float m_dashDuration = 1f;
        [SerializeField]
        private float m_dashSpeed = 10f;

        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                m_teamController.Dash(m_teamController.Direction * 10f + transform.position, m_dashSpeed, m_dashDuration);
            }
            catch (System.Exception e)
            {
                if (e is OnCooldownException)
                {
                    Debug.LogWarning("Spell is on cooldown");
                }
            }
        }

        internal override void SecondaryAttack()
        {
            base.SecondaryAttack();

        }
    }
}