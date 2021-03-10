using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        

     yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
