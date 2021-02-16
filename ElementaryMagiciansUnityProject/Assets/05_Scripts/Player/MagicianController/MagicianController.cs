﻿using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElementaryMagicians.Player
{
    public class MagicianController : StatesMachine
    {
        private Transform m_positionTarget = null;
        internal Transform PositionTarget => m_positionTarget;
        [SerializeField]
        private NavMeshAgent m_agent = null;
        internal NavMeshAgent Agent => m_agent;

        internal void Init(Transform positionTarget, float speed)
        {
            m_positionTarget = positionTarget;
            m_agent.speed = speed;
            EnterStateMachine();
        }

        internal void CleanUp()
        {
            ExitStateMachine();
        }
    }
}