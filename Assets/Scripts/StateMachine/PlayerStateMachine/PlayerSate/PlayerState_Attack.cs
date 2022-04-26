using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "PlayerState_Attack")]
public class PlayerState_Attack : PlayerState
{
    public override void Enter()
    {
        animator.Play("Attack");
    }

    public override void LogicUpdate()
    {
        
    }
}
