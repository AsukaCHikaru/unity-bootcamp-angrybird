using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageBaseState
{
    public abstract void EnterState(StageStateManager stage);

    public abstract void UpdateState(StageStateManager stage);
}
