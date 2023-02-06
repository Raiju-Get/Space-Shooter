using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingDown;

    Vector2 minBound;
    Vector2 maxBound;
    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    private void Start()
    {
        MainBound();
    }
    void Update()
    {
        Move();
    }


    void MainBound()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos;
        newPos.x = Mathf.Clamp(transform.position.x + delta.x,minBound.x + paddingLeft,maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y,minBound.y + paddingDown,maxBound.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput =  value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
