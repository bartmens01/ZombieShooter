using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform Target;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;
    public Animator ani;
    GameObject Player;
    public GameObject spawn1;
    Vector3 spawnPosition;
    void Start()
    {
        spawn1 = GameObject.FindWithTag("Spawn1");
        Player = GameObject.FindWithTag("Player");
        spawnPosition = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
        Target = Player.transform;
    }
        void Update()
        {
           
        Vector3 targetPostition = new Vector3(Target.position.x,
                                        this.transform.position.y,
                                        Target.position.z);
        this.transform.LookAt(targetPostition);

        if (Vector3.Distance(transform.position, Target.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                ani.SetBool("attacking", false);
                ani.SetBool("Walking", true);

                if (Vector3.Distance(transform.position, Target.position) <= MaxDist)
                {
                    ani.SetBool("attacking", true);
                    ani.SetBool("Walking", false);
               
                }
               
            }
        }
    private void OnCollisionEnter(Collision other)
        
    {
        if (other.gameObject.tag == "Death")
        {
            transform.position = spawnPosition;

            print("Respawned");
        }
    }

}
