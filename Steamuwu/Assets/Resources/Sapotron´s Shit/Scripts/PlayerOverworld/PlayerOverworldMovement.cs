using UnityEngine;

public class PlayerOverworldMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 m_target;
    private Vector3 m_targetPos;
    private bool m_CanMove;
    private bool m_IsMoving;
    

    void Start()
    {
        m_target = transform.position;
    }
    void Update()
    {
        if (m_CanMove == true)
        {
            m_target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Captures the position where the mouse clicked or when the mouse was created to a ScreenToWorldPoint
            m_target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, m_targetPos, speed * Time.deltaTime);
        }
    }
    public void Move()
    {
        m_CanMove = true;
    }

    public void TargetPos(Vector3 pos)
    {
        m_targetPos = pos;
    }
}
