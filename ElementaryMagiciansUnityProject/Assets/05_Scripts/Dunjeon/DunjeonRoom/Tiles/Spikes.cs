using ElementaryMagicians.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private int IS_TRIGGERED = Animator.StringToHash("IsTriggered");
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Vector2 m_timeToWaitToTrigger = Vector2.zero;
    [SerializeField] private Vector2 m_timeToWaitToUntrigger = Vector2.zero;
    private float m_timeToWait = 0f;
    private bool m_isTriggered = false;
    private float m_timeOfLastSwitch = float.MinValue;


    // Start is called before the first frame update
    void Start()
    {
        m_timeToWait = UnityEngine.Random.Range(m_timeToWaitToTrigger.x, m_timeToWaitToTrigger.y);
        m_timeOfLastSwitch = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > m_timeOfLastSwitch + m_timeToWait)
        {
            if(m_isTriggered)
            {
                m_isTriggered = false;
                m_timeToWait = UnityEngine.Random.Range(m_timeToWaitToTrigger.x, m_timeToWaitToTrigger.y);

            }
            else
            {
                m_isTriggered = true;
                m_timeToWait = UnityEngine.Random.Range(m_timeToWaitToUntrigger.x, m_timeToWaitToUntrigger.y);
            }
            m_timeOfLastSwitch = Time.time;
            m_animator.SetBool(IS_TRIGGERED, m_isTriggered);
        }
    }
}
