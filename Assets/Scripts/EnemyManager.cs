using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject Player;
    public Animator enemyAnimator;
    public bool isRunning;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;


    public void hit(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);

        }
    }
    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject == Player)
        {
            Player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
