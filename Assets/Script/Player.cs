using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;

    public Boolean encostando = false;

    public BoxCollider jumpTrigger;

    public Rigidbody rb;

    public float speed;

    public float jumpPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
        player.TryGetComponent<Rigidbody>(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (rb.position.y == 0.0f)
            {
                Pula();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ParaDireita();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ParaEsquerda();
        }


    }
    void Pula()
    {
        rb.AddForce(new Vector3(0, jumpPower, 0));
    }
    void ParaDireita()
    {
        rb.AddForce(new Vector3(speed, 0, 0));
    }

    void ParaEsquerda()
    {
        rb.AddForce(new Vector3(-speed, 0, 0));
    }


}
