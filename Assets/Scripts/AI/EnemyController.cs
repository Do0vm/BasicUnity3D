using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyStates {Idle, Chase, Attack }

public class EnemyController : MonoBehaviour
{
    [field: SerializeField] public float Fov { get; private set; } = 180f;

    public List<MeleeFighter> TargetsInRange { get; private set; } = new List<MeleeFighter>();
    public MeleeFighter Target { get; set; }
    public StateMachine<EnemyController> StateMachine {  get; private set; }

    Dictionary<EnemyStates, State<EnemyController>> stateDict;

    public NavMeshAgent NavAgent { get; private set; }
    public Animator animator { get; private set; }
    public MeleeFighter Fighter { get; private set; }

    private void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Fighter = GetComponent<MeleeFighter>();


        stateDict = new Dictionary<EnemyStates, State<EnemyController>>();

        stateDict[EnemyStates.Idle] = GetComponent<IdleState>();
        stateDict[EnemyStates.Chase] = GetComponent<ChaseState>();
        stateDict[EnemyStates.Attack] = GetComponent<AttackState>();

        StateMachine = new StateMachine<EnemyController>(this);
        StateMachine.ChangeState(stateDict[EnemyStates.Idle]);
    }

    public bool IsInState (EnemyStates state)
    {
        return StateMachine.CurrentState == stateDict[state];
    }

    public void ChangeState(EnemyStates state)
    {

        StateMachine.ChangeState(stateDict[state]);

    }

    private void Update()
    {

        StateMachine.Execute();

    }

}
