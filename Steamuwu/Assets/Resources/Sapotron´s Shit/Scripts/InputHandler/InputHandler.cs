using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    private Camera MainCamera;
    private GameObject PlayerRef;
    private Vector3 TargetRefPos;
    private Vector3 PlayerRefPos;
    private bool BlockedRef;
    private bool Move;
    private bool isMoving;

    [Header("NOT TOUCHING PLS")]
    [SerializeField] private GameObject EnemyRef;
    [SerializeField] private GameObject ShopRef;
    [SerializeField] private GameObject PoliceRef;
    [SerializeField] private GameObject CasinoRef;
    [SerializeField] private GameObject BossRef;

    private void Awake()
    {
        MainCamera = Camera.main;


        PlayerRef = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        PlayerRefPos = PlayerRef.transform.position;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;

        }
        if (PlayerRefPos == TargetRefPos) //CONSTANTLY CHECK IF THE PLAYER ISNT AT THE SAME POSITION AS ITS TARGET
        {
            Debug.Log("Arrived at Target");
            isMoving = false;
        }
        //MOVE PLAYER IN THE OVERWORLD
        if (rayHit.collider && rayHit.collider.tag == "Encounter") //IF THE CLICK IS A ENCOUNTER...
        {
            BlockedRef = rayHit.collider.GetComponent<GeneralEncounterBehaviour>().Blocked;

            if (BlockedRef == false) 
            {
                if (isMoving == false) //IF THE PLAYER IS NOT MOVING...
                {
                    TargetRefPos = rayHit.collider.transform.position;

                }
                if (PlayerRefPos != TargetRefPos) //IF THE PLAYER HASNT REACHED ITS TARGET...
                {
                    isMoving = true;
                    PlayerRef.GetComponent<PlayerOverworldMovement>().Move();
                    PlayerRef.GetComponent<PlayerOverworldMovement>().TargetPos(TargetRefPos);
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
