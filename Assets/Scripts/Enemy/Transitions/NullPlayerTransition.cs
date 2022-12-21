using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPlayerTransition : EnemyTransition
{
    private void Update()
    {
        if (Player == null)
            NeedTransit = true;
    }
}
