using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class TeamPositionTargetsManager : MonoBehaviour
    {
        [SerializeField]
        private Transform[] m_positionTargets = null;

        internal Transform[] PositionTargets => m_positionTargets;
    }
}