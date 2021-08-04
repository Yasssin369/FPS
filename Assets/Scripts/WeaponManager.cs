using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject PlayerCam;
    public float range = 100f;
    public float damage = 20f;
    public Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        if(Physics.Raycast(PlayerCam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.hit(damage);
            }

           
        }

    }
}
