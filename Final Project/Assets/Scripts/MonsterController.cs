using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
        monsterCollider = GetComponent<Collider>();
    }

    private Animator animator;
    private bool isAlive = true;

    private Collider monsterCollider;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die(){
        animator.SetTrigger("Death");

        if (monsterCollider != null)
        {
            monsterCollider.enabled = false;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            //Debug.Log("Attack Triggered");

            float attackInterval = Random.Range(3f, 6f);

            yield return new WaitForSeconds(attackInterval);

            animator.SetTrigger("Attack");

        }
    }
}
