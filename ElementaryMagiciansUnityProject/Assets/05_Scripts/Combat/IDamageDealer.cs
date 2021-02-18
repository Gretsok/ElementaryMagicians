using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    public interface IDamageDealer
    {
        CombatController Owner { get; }
        Action<IDamageDealer> OnDestroy { get; set; }
        DamageDealerType DealerType { get; }
    }
}