using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collison Detected");
        if (collision.gameObject.CompareTag("Monster"))
        {
            //Debug.Log("Monster hit detected");
            MonsterController monsterController = collision.gameObject.GetComponent<MonsterController>();
            if (monsterController != null)
            {
                monsterController.Die();
            }

            Destroy(gameObject); // Destroy the rock after hitting the monster
        }
    }
}
