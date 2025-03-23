using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackStates { Idle, Windup, Impact, Cooldown}

public class MeleeFighter : MonoBehaviour
{
    [SerializeField] List<AttackData> attacks;
    [SerializeField] GameObject Sword;

    BoxCollider swordCollider;

    Animator animator;  
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
        if (Sword != null)
        {

            swordCollider = Sword.GetComponent<BoxCollider>();
            swordCollider.enabled = false;
        }


    }

    public AttackStates AttackStates { get; private set; }

    bool doCombo;
    int comboCount = 0;

    public bool InAction { get; private set; } = false;

    public void TryToAttack()
    {

        if (!InAction)
        {
            StartCoroutine(Attack());

            

        }


        else if (AttackStates == AttackStates.Impact || AttackStates == AttackStates.Cooldown)
        {

            doCombo = true;

        }
    }



    IEnumerator Attack()
    {
        InAction = true;
        AttackStates = AttackStates.Windup;





        animator.CrossFade(attacks[comboCount].AnimName, 0.2f);
        yield return null;



        var animState = animator.GetNextAnimatorStateInfo(1);

        float timer = 0f;
        while (timer <= animState.length)
        {

            timer += Time.deltaTime;
            float normalizedTime = timer / animState.length;


            if (AttackStates == AttackStates.Windup)
            {

                if (normalizedTime >= attacks[comboCount].ImpactStartTime)
                {

                    AttackStates = AttackStates.Impact;
                    swordCollider.enabled =true;
                }

            }
            else if (AttackStates == AttackStates.Impact)
            {

                if(normalizedTime >= attacks[comboCount].ImpactEndTime)
                {

                    AttackStates = AttackStates.Cooldown;
                    swordCollider.enabled = false;
                }

            }
            else if (AttackStates == AttackStates.Cooldown)
            {

                if (doCombo)
                {


                    doCombo = false;
                    comboCount = (comboCount + 1) % attacks.Count;

                    StartCoroutine(Attack());
                    yield break;
                }

            }
            yield return null;

        }


        AttackStates = AttackStates.Idle;
        comboCount = 0;
        InAction = false;


        animator.CrossFade("Locomotion", 0.2f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hitbox" && !InAction)

        {
        
            StartCoroutine (PlayHitReaction());
        }
    }

    IEnumerator PlayHitReaction()
    {
        InAction = true;
        animator.CrossFade("GetHit", 0.2f);
        yield return null;

        var animState = animator.GetNextAnimatorStateInfo(1);


        yield return new WaitForSeconds(animState.length*0.8f);

        InAction = false;

        Destroy(gameObject);


    }

}
