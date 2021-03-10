using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunScript : MonoBehaviour
{
    public Transform Barrel;
    public Transform gunEnd;
    RaycastHit hit;
    Ray ray;
    public GameObject impact;
    public AudioSource shot;
    public AudioSource shotEmpty;
    public ParticleSystem muzzleFlash;

    public float size;
    public float fireRate;

    public int damge;
    public int ammo;
    public int ammoAmount;
    public int hitDis;

    public bool reloading;
    public bool headShot;
    public bool zombieShooter;
   public bool canShoot;
   
    void Start()
    {
        ammo = ammoAmount;
        canShoot = true;
        reloading = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (reloading == true)
        {
            muzzleFlash.Stop();
        }
        Debug.DrawRay(Barrel.transform.position, Barrel.transform.forward * size);
        if (reloading == false)
        {
            if (Input.GetMouseButton(0) && canShoot == true && ammo > 0)
            {
                StartCoroutine(FireRate());
              

            }      
            if (Input.GetMouseButtonUp(0) || ammo == 0)
            {

                
                muzzleFlash.Stop();
            }
            if (Input.GetMouseButtonDown(0) && ammo == 0)
            {

                shotEmpty.Play();
            }
        }
    }
   

    IEnumerator FireRate()
    {
        canShoot = false;
        ray = new Ray(Barrel.transform.position, Barrel.transform.forward);
        shot.Play();
        muzzleFlash.Play();
        ammo--;
        if (Physics.Raycast(ray, out hit, size))
        {           
           
            GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
            
            muzzleFlash.Play();
            if (hit.collider.CompareTag("Enemy"))
            {

                if (zombieShooter == false) // Shooter
                {
                    GameObject Enemy = hit.collider.gameObject;

                    if (Enemy.transform.tag == "Enemy")
                    {                                          
                                Enemy.GetComponent<EnemyIAShoot>().hp -= 1;   
                        
                    }                  
                }


                if (zombieShooter == true) // ZombieShooter
                {
                    GameObject Enemy = hit.collider.gameObject;

                    if (Enemy.transform.tag == "Enemy")
                    {
                        if (hit.distance >= 16f)
                        {
                          
                                Enemy.GetComponent<EnemyHp>().hp -= 10;
                            
                        }
                    }
                    if (Enemy.transform.tag == "Enemy")
                    {
                        if (hit.distance >= 70f)
                        {
                            
                                Enemy.GetComponent<EnemyHp>().hp -= 0;
                            
                        }
                    }
                    if (Enemy.transform.tag == "Enemy")
                    {
                        if (hit.distance <= 15f)
                        {
                           
                           
                            
                                Enemy.GetComponent<EnemyHp>().hp -= 25;
                            
                        }
                    }
                }
            }
          


        }
        
        yield return new WaitForSeconds(fireRate);
        
        canShoot = true;
    }

}
