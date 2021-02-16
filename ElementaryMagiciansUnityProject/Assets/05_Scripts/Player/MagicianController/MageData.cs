using UnityEngine;

namespace ElementaryMagicians.Player
{
    [CreateAssetMenu(fileName = "MageData", menuName = "ElementaryMagicians/MageData")]
    public class MageData : ScriptableObject
    {
        [SerializeField]
        private MagicianController m_magicianPrefab = null;

        internal MagicianController MagicianPrefab => m_magicianPrefab;
    }
}