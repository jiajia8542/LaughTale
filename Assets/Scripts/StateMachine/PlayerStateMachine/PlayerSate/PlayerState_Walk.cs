using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Walk", fileName = "PlayerState_Walk")]
public class PlayerState_Walk : PlayerState
{
    public override void Enter()
    {
        animator.Play("Walk");
    }

    public override void LogicUpdate()
    {
        if (input.ClickIsOver)   // ¸Ð¾õÒª¸Ä 
        {
            player.Move();  
        }

        if (!player.IsMoving)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
