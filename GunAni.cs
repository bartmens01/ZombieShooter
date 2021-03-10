using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAni : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    public int isReload;
    public bool aimOut;
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        

      
       
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading == false)
            {
                ani.SetBool("Shoot", true);
                ani.SetBool("Aimout", false);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ani.SetBool("Shoot", false);

        }
        if (Input.GetMouseButtonDown(1) && GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading == false)
        {
          
            ani.SetBool("Aimout", false);
            ani.SetBool("AimIn", true);

        }
        if (Input.GetMouseButtonUp(1)&& GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading == false)
        {
           
            ani.SetBool("AimIn", false);
            ani.SetBool("Aimout", true);
        }
        if (Input.GetKey(KeyCode.R) &&  GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading == false && GameObject.FindWithTag("Player").GetComponent<GunScript>().ammo == 0)
        {
            
            StartCoroutine(Relode());
            
          
        }
        if (GameObject.FindWithTag("Player").GetComponent<GunScript>().ammo == 0)
        {
            ani.SetBool("Aimout", true);
            ani.SetBool("Shoot", false);
            
            ani.SetBool("AimIn", false);
           

        }
        IEnumerator Relode()
        {

            GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading = true;
            GameObject.FindWithTag("Player").GetComponent<GunScript>().canShoot = false;
            ani.SetBool("Aimout", false);
            ani.SetBool("Shoot", false);
          
            ani.SetBool("AimIn", false);
            ani.SetBool("magIn", false);
            ani.SetBool("magOut", true);
            isReload = 3;
            yield return new WaitForSeconds(0.50f);
            ani.SetBool("magIn", true);

            ani.SetBool("magOut", false);
            yield return new WaitForSeconds(0.90f);
            ani.SetBool("magOut", false);
            ani.SetBool("magIn", false);
            isReload = 2;
           
            GameObject.FindWithTag("Player").GetComponent<GunScript>().canShoot = true;
            yield return new WaitForSeconds(0.0f);
            GameObject.FindWithTag("Player").GetComponent<GunScript>().reloading = false;
        }
        if (isReload == 2)
        {
            
            GameObject.FindWithTag("Player").GetComponent<GunScript>().ammo = GameObject.FindWithTag("Player").GetComponent<GunScript>().ammoAmount;
            isReload = 1;
            
           
        }

    }

  
}
