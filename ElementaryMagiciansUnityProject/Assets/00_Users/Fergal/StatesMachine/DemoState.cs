using UnityEngine;

public class DemoState : MonoBehaviour
{
    [SerializeField]
    protected MeshRenderer m_renderer = null;

    [SerializeField]
    private Color32 m_color = default;
    [SerializeField]
    private float m_scale = 1f;

    public virtual void EnterState()
    {
        m_renderer.transform.localScale = Vector3.one * m_scale;
    }

    public virtual void UpdateState()
    {
        m_renderer.material.color = m_color;
    }
}
