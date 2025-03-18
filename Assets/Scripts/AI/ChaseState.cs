using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChaseState : State<EnemyController>
{

    public override void Enter(EnemyController owner)
    {

        Debug.Log("Enter ChaseState enemy");


    }

    public override void Execute()
    {

        Debug.Log("Execute ChaseState enemy");
    }

    public override void Exit()
    {
        Debug.Log("Exit ChaseState enemy");
    }
}
