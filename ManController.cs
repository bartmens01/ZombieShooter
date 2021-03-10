using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManController : MonoBehaviour
{
    public bool inMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inMan == true)
        {

            Cursor.lockState = CursorLockMode.Confined;

        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            SceneManager.LoadScene("MainM");
        }
    }
    public void ZombieShooter()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void SpaceShooter()
    {
        SceneManager.LoadScene("InvadeGame");

    }
    public void Quit()
    {
        Application.Quit();

    }
}
