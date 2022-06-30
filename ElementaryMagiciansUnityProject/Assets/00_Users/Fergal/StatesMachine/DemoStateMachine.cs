using UnityEngine;

public class DemoStateMachine : MonoBehaviour
{
    private DemoState m_currentState = null;

    [SerializeField]
    private DemoState m_redState = null;
    [SerializeField]
    private DemoState m_blueState = null;
    [SerializeField]
    private DemoState m_greenState = null;

    private void Update()
    {
        m_currentState?.UpdateState();
    }

    public void SwitchToState(DemoState a_state)
    {
        m_currentState = a_state;
        m_currentState?.EnterState();
    }

    public void SwitchToRed()
    {
        SwitchToState(m_redState);
    }

    public void SwitchToBlue()
    {
        SwitchToState(m_blueState);
    }

    public void SwitchToGreen()
    {
        SwitchToState(m_greenState);
    }
}


#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(DemoStateMachine))]
public class DemoStateMachineEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Switch to red"))
        {
            (target as DemoStateMachine).SwitchToRed();
        }
        if (GUILayout.Button("Switch to blue"))
        {
            (target as DemoStateMachine).SwitchToBlue();
        }
        if (GUILayout.Button("Switch to green"))
        {
            (target as DemoStateMachine).SwitchToGreen();
        }
    }
}
#endif
