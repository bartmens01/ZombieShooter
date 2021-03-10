using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertoryManager : MonoBehaviour
{
    public static InvertoryManager Instance { get; private set; }
    public int[] MedKitslots;
    public int medkits;
    public int medkitsAmount;
    public static List<Object> inventory = new List<Object>();
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
       
        MedKitslots[0] = medkitsAmount;
        MedKitslots[1] = 2;
        MedKitslots[2] = 3;
        MedKitslots[3] = 4;
        MedKitslots[4] = 5;


    }
}
