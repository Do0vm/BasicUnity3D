using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Vector2 timeRangeBetweenAttacks = new Vector2(1, 4);

    public static EnemyManager i { get; private set; }
    List<EnemyController> enemiesInRange = new List<EnemyController>();


    float notAttackingTimer = 2;

    private void Awake()
    {
        i = this;
    }



    public void AddEnemyInRange(EnemyController enemy)

    { if (!enemiesInRange.Contains(enemy))
            enemiesInRange.Add(enemy);

    }


    public void RemoveEnemyInRange(EnemyController enemy)
    {
        enemiesInRange.Remove(enemy);

    }

    private void Update()
    {
        if (enemiesInRange.Count == 0) return;

        if (!enemiesInRange.Any(e => e.IsInState(EnemyStates.Attack)))
        {
            if (notAttackingTimer > 0)
            {
                notAttackingTimer -= Time.deltaTime;  // ? Fix Timer
            }

            if (notAttackingTimer <= 0)
            {
                var attackingEnemy = SelectEnemyForAttack();
                if (attackingEnemy != null)  // ? Prevent null errors
                {
                    Debug.Log($"Enemy {attackingEnemy.name} is attacking!");
                    attackingEnemy.ChangeState(EnemyStates.Attack);
                }

                notAttackingTimer = Random.Range(timeRangeBetweenAttacks.x, timeRangeBetweenAttacks.y);
            }
        }
    
}


    EnemyController SelectEnemyForAttack()
    {
        var availableEnemies = enemiesInRange.Where(e => !e.IsInState(EnemyStates.Attack)).ToList();

        if (availableEnemies.Count == 0)
            return null;

        return availableEnemies[Random.Range(0, availableEnemies.Count)];

    }

}
