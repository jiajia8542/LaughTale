using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine
{

    [SerializeField] PlayerState[] playerState;

    [SerializeField] PlayerInput input;
    Animator animator;
    Skeleton player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Skeleton>();
        stateTable = new Dictionary<System.Type, PlayerState>(playerState.Length);
        foreach(var state in playerState)
        {
            state.Initialize(animator,player,input ,this);
            stateTable.Add(state.GetType(), state);
        }

    }

    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }


}
