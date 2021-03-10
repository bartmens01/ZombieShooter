using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MedManager : MonoBehaviour
{
    public static MedManager Instance { get; private set; }
    public int spawnAmountMed;
    public int spawnedMed;
    public int medKitNumber;
    public float spawnHeight;
    public GameObject[] medKitArr;
    public GameObject medKit;
    int x;
    int z;
    
 
    // Start is called before the first frame update
    void Start()
    {
        medKitArr = new GameObject[spawnAmountMed];

    }
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
    // Update is called once per frame
    void Update()
    {
        if (spawnedMed == 0)
        {
            StartCoroutine(Medspawn());

        }

    }
    IEnumerator Medspawn()
    {

        for (int i = 0; i < spawnAmountMed; i++)
        {
            spawnedMed++;
            yield return new WaitForSeconds(0.2f);
            x = Random.Range(-3, 10);

            z = Random.Range(-3, 10);
             GameObject r = Instantiate(medKit, new Vector3(i * x, spawnHeight, z), Quaternion.identity) as GameObject;
            r.GetComponent<MedKit>().setHeal(i + 1);
            medKitArr[i] = r;
            medKitNumber = i;

        }


    }
}
