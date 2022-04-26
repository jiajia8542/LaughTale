using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dead", fileName = "PlayerState_Dead")]
public class PlayerState_Dead : PlayerState
{
    public override void Enter()
    {
        animator.Play("Dead");
        
    }

    
}
