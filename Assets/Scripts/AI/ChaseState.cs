using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChaseState : State<EnemyController>
{
    [SerializeField] float distance= 3f;

    EnemyController Enemy;

    public override void Enter(EnemyController owner)
    {

        Enemy = owner;

        Enemy.NavAgent.stoppingDistance = distance;
    }

    public override void Execute()
    {
        Enemy.NavAgent.SetDestination(Enemy.Target.transform.position);
        Enemy.animator.SetFloat("moveAmount",Enemy.NavAgent.velocity.magnitude/Enemy.NavAgent.speed);
    }

    public override void Exit()
    {
        Debug.Log("Exit ChaseState enemy");
    }
}
