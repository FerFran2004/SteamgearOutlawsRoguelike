using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworldMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 target;
    private Vector3 targetPos;
    private bool CanMove;
    private bool IsMoving;
    

    void Start()
    {
        target = transform.position;
    }


    void Update()
    {

        if (CanMove == true)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Captures the position where the mouse clicked or when the mouse was created to a ScreenToWorldPoint
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        }

    }
    public void Move()
    {

        CanMove = true;
    }

    public void TargetPos(Vector3 pos)
    {
        targetPos = pos;

    }
}
