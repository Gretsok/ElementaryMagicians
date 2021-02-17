using ElementaryMagicians.Combat;
using System;
using UnityEngine;

public class SpikesDamageCollider : MonoBehaviour, IDamageDealer
{

    [SerializeField]
    private int m_damage = 20;
    [SerializeField]
    private float m_cooldown = 2f;

    public CombatController Owner => null;

    public int DamagePerHit => m_damage;

    public float CooldownDamage => m_cooldown;

    private Action<IDamageDealer> m_onDestroy = null;
    public Action<IDamageDealer> OnDestroy { get => m_onDestroy; set => m_onDestroy = value; }
}
