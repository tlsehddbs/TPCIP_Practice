using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    //public CharacterController controller;
    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    public int itemAmount = 0;
    public int maxItemAmount = 5;

    private bool[] inputs;
    private float yVelocity = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity *= Time.deltaTime * Time.deltaTime;
        moveSpeed *= Time.fixedDeltaTime;
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;

        inputs = new bool[3];
    }

    public void FixedUpdate()
    {
        Vector2 _direction = Vector2.zero;
        if (inputs[0])  // w
        {
            var hit = Physics.Raycast(transform.position, Vector3.down, 0.7f);
            if (hit)
            {
                rb.velocity = jumpSpeed * Vector2.up;
            }
        }
        if (inputs[1])  // a
        {
            _direction.x -= 1;
        }
        if (inputs[2])  // d
        {
            _direction.x += 1;
        }

        Move(_direction);
    }

    private void Move(Vector2 _direction)
    {
        float x = _direction.x * moveSpeed;
        float y = _direction.y * moveSpeed;
        transform.position += new Vector3(x, y, 0);
        _direction *= moveSpeed;

        yVelocity += gravity;

        _direction.y = yVelocity;

        ServerSend.PlayerPosition(this);
    }

    public void SetInput(bool[] _inputs)
    {
        inputs = _inputs;
    }

    public bool AttempPickUpItem()
    {
        if(itemAmount >= maxItemAmount)
        {
            return false;
        }
        itemAmount++;
        return true;
    }
}
