using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int medKit;
    public int heal;
   
    // Start is called before the first frame update
    void Start()
    {
        medKit = GameManager.Instance.medManager.GetComponent<MedManager>().medKitNumber;
    }
    public void setHeal(int h)
    {
        heal = h;
     
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            GameManager.Instance.inventory.Add(heal);
        
            Destroy(this.gameObject);
         
        }
    }
}
