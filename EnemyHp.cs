using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int hp;
    public GameObject Ragdoll;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        {
            if (hp <= 0)
            {
                Instantiate(Ragdoll, transform.position, transform.rotation);
                GameManager.Instance.enemyManager.GetComponent<EnemySpawn>().spawned--;
                GameManager.Instance.enemyManager.GetComponent<EnemySpawn>().spawnUpgrade++;
                Destroy(this.gameObject);
            }

        }
    }
}
