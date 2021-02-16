using ElementaryMagicians.Player;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonManager : MonoBehaviour
    {
        private void Awake()
        {
            s_instance = this;
            DontDestroyOnLoad(s_instance);
        }

        private static DunjeonManager s_instance = null;
        internal static DunjeonManager GetInstance()
        {
            if(s_instance == null)
            {
                var app_GO = Instantiate(Resources.Load<GameObject>("DunjeonManager"));
                s_instance = app_GO.GetComponent<DunjeonManager>();
                DontDestroyOnLoad(app_GO);
            }
            return s_instance;
        }

        [SerializeField]
        private MagicianTeamController m_magicianTeamControllerPrefab = null;
        [SerializeField]
        private MageData m_defaultMageData = null;
        private MagicianTeamController m_teamController = null;

        internal MagicianTeamController GetMagicianTeamController()
        {
            if(m_teamController == null)
            {
                m_teamController = Instantiate(m_magicianTeamControllerPrefab, transform);
                m_teamController.AddMagician(m_defaultMageData);
            }
            return m_teamController;
        }
    }
}