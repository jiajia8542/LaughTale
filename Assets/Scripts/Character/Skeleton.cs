using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    [SerializeField] PlayerInput playerinput;

    Transform attackTarget;

    Ray toClickPoint;
    RaycastHit selectedObj;


    Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        //playerinput.onSetTarget += ToMoveState;
    }

    private void OnDisable()
    {
        //playerinput.onSetTarget -= ToMoveState;
    }
    protected override void Start()
    {
        playerinput.EnableGamePlayInput();
    }

    private void Update()
    {
        MoveOrSelectAttack();
    }
    protected override Vector2 GetMoveTarget() => mainCamera.ScreenToWorldPoint(playerinput.CurrentMousePosition);


    Transform GetAttackTarget()
    {
        return null;
    }
    
    public void MoveOrSelectAttack()
    {
        if (playerinput.ClickIsOver)  //！ 希望通过点击事件触发
        {
            toClickPoint = mainCamera.ScreenPointToRay(playerinput.CurrentMousePosition);
            if(Physics.Raycast(toClickPoint,out RaycastHit hit))
            {
                SelectAndAttack();
            }else
            {
                ToMoveState();
                Move();
            }
        }
    }

    void SelectAndAttack()
    {
        Debug.Log("selectandattacl");
        // select 
        // attack
    }
    public void ToMoveState()
    {
        isMoving = true;
    }
    public void Move()
    {
        moveTarget = GetMoveTarget();
        base.Move(moveTarget);
    }

}
