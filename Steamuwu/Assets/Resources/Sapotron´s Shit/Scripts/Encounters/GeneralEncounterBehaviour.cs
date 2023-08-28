using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GeneralEncounterBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Marker;
    public bool Blocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER WITH ME");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(Marker, gameObject.transform.position, Quaternion.identity);
            Debug.Log("PLAYER LEFT ME");
            Blocked = true;
        }
    }
}
