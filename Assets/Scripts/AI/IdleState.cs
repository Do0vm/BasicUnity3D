using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<EnemyController>  
{
    EnemyController Enemy;

        public override void Enter (EnemyController owner)
    {
        Enemy = owner;
        Debug.Log("IdleState enemy");


    }

    public override void Execute()
    {

        Enemy.ChangeState(EnemyStates.Chase);
    }

    public override void Exit()
    {
        base.Exit();
    }


}
