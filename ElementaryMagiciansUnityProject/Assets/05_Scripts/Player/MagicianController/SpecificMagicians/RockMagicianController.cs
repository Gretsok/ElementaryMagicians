using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class RockMagicianController : MagicianController
    {
        [SerializeField]
        private RockWall m_rockWallPrefab = null;
        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                RockWall rockWall = Instantiate(m_rockWallPrefab, m_teamController.WorldCursorPosition, Quaternion.identity);
                rockWall.transform.LookAt(m_teamController.WorldCursorPosition + (m_teamController.WorldCursorPosition - m_teamController.TeamTargetPosition.position));
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