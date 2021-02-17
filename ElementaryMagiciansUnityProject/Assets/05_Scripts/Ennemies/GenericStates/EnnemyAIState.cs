using MOtter.StatesMachine;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAIState : State
    {
        [SerializeField]
        protected EnnemyAI m_owner = null;
    }
}