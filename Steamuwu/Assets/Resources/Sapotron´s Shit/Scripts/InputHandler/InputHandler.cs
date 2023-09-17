using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    private Camera m_MainCamera;
    private GameObject m_PlayerRef;
    private Vector3 m_TargetRefPos;
    private Vector3 m_PlayerRefPos;
    private bool m_BlockedRef;
    private bool m_Move;
    private bool m_isMoving;

    [Header("NOT TOUCHING PLS")]
    [SerializeField] private GameObject EnemyRef;
    [SerializeField] private GameObject ShopRef;
    [SerializeField] private GameObject PoliceRef;
    [SerializeField] private GameObject CasinoRef;
    [SerializeField] private GameObject BossRef;

    private void Awake()
    {
       m_MainCamera = Camera.main;
       m_PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        m_PlayerRefPos = m_PlayerRef.transform.position;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(m_MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (m_PlayerRefPos == m_TargetRefPos) //CONSTANTLY CHECK IF THE PLAYER ISNT AT THE SAME POSITION AS ITS TARGET
        {
            Debug.Log("Arrived at Target");
            m_isMoving = false;
        }
        //MOVE PLAYER IN THE OVERWORLD
        if (rayHit.collider && rayHit.collider.tag == "Encounter") //IF THE CLICK IS A ENCOUNTER...
        {
            m_BlockedRef = rayHit.collider.GetComponent<GeneralEncounterBehaviour>().Blocked;

            if (m_BlockedRef == false) 
            {
                if (m_isMoving == false) //IF THE PLAYER IS NOT MOVING...
                {
                    m_TargetRefPos = rayHit.collider.transform.position;
                }
                if (m_PlayerRefPos != m_TargetRefPos) //IF THE PLAYER HASNT REACHED ITS TARGET...
                {
                    m_isMoving = true;
                    var moveComp = m_PlayerRef.GetComponent<PlayerOverworldMovement>();
                    moveComp.Move();
                    moveComp.TargetPos(m_TargetRefPos);
                    //m_PlayerRef.GetComponent<PlayerOverworldMovement>().Move();
                    //m_PlayerRef.GetComponent<PlayerOverworldMovement>().TargetPos(m_TargetRefPos);
                    Debug.Log(rayHit.collider.gameObject.name + rayHit.collider.gameObject.tag);
                    Debug.Log("DETECTED A ENCOUNTER");
                }
            }
            else 
            {
                Debug.Log("ENCOUNTER IS BLOCKED SOWWY UnU");
            }
        }

    }
}
