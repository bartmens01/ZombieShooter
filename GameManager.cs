using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    public GameObject enemyManager;
    public GameObject medManager;

    public List<int> inventory = new List<int>();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().Heal(inventory[0]);
            inventory[0] = 0;

        }
        if (Input.GetKeyDown("2"))
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().Heal(inventory[1]);
            inventory[1] = 0;

        }
        if (Input.GetKeyDown("3"))
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().Heal(inventory[2]);
            inventory[2] = 0;

        }
        if (Input.GetKeyDown("4"))
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().Heal(inventory[3]);
            inventory[3] = 0;

        }
    }
}
