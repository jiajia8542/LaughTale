using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,Istate
{
    protected Animator animator;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerInput input;
    protected Skeleton player;
    public void Initialize(Animator animator ,Skeleton player,PlayerInput playerinput, PlayerStateMachine playerStateMachine)
    {
        this.animator = animator;
        this.player = player;
        input = playerinput;
        this.playerStateMachine = playerStateMachine;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }
}




