using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 持有所有状态 并能管理,切换,更新状态
public class BaseStateMachine : MonoBehaviour
{

    Istate currentsState;

    protected Dictionary<System.Type, PlayerState> stateTable;

    private void Update()
    {
        currentsState.LogicUpdate();
    }

    protected void SwitchOn(Istate newState)
    {
        currentsState = newState;
        currentsState.Enter();
    }

    public void SwitchState(Istate newState)
    {
        currentsState.Exit();
        SwitchOn(newState);
    }

    public void  SwitchState(System.Type stateType)
    {
        SwitchState(stateTable[stateType]);
    }
}
