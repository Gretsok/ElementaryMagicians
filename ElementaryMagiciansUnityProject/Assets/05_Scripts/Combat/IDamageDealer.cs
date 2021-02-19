using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    public interface IDamageDealer
    {
        CombatController Owner { get; }
        Action<IDamageDealer> OnDisappeared { get; set; }
        DamageDealerType DealerType { get; }
        GameObject gameObject { get; }
    }
}