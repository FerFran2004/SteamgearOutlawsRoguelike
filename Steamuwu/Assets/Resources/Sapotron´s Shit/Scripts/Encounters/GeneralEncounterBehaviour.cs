using UnityEngine;

public class GeneralEncounterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject Marker;
    public bool Blocked;


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
