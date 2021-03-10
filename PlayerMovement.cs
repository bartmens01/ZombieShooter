using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Text Score_UIText;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public int hp;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioSource pickUp;
    Vector3 velocity;
    bool isGrounded;
   public bool ZombieShooter;

    // Start is called before the first frame update
    void Start()
    {
        Score_UIText.text = ("Hp " + hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieShooter == false)
        {
            if (hp >= 10)
            {
                hp = 10;
                Score_UIText.text = ("Hp " + hp);
            }
        }

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }
        if (hp <= 0)
        {

            SceneManager.LoadScene("GameOver");
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyD")
        {
            print("TakenDamage");
            Damage(2);
        
        }
        if (other.tag == "MedKit")
        {
            pickUp.Play();
        }
    }
   public void Damage(int d)
    {
        hp -= d;
        Score_UIText.text = ("Hp " + hp);
    }
    public void Heal(int d)
    {
        hp += d;
        Score_UIText.text = ("Hp " + hp);
    }
}


