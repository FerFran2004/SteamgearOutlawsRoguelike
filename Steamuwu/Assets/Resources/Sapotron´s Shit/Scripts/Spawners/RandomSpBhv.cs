using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RandomSpBhv : MonoBehaviour
{
    ////Prefabs to spawn 
    //[SerializeField] private GameObject Enemy;
    //[SerializeField] private GameObject Shop;
    //[SerializeField] private GameObject Police;
    //[SerializeField] private GameObject Casino;


    //Percetage shit
    [System.Serializable] 
    public class EncounterManager
    {
        [SerializeField] public string Name;
        [SerializeField] public GameObject Encounter;
        [SerializeField] public int spawnRarity;

    }

    [SerializeField]
    private List <EncounterManager> EncounterList = new List <EncounterManager>(); //Show encounter list in Editor
    [SerializeField]
    public int dropChance;

    void Start()
    {
        // Spawn();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
           Spawn();
           // CalculateEvents();
        }
        
    }

   public void CalculateEvents() //NOT CURRENTLY ACTIVATED
    {

        int calc_dropChance = Random.Range(0, 101);
        if (calc_dropChance > dropChance )
        {
            Debug.Log("NO LOOT");
            return;
        }
        if (calc_dropChance <= dropChance ) //IMPORTANT SHIT!!!!!
        {
            int encounterWeight = 0;
            for (int i = 0; i < EncounterList.Count; i++)
            {
                encounterWeight += EncounterList[i].spawnRarity; //Sum of all rarities of encounters

            }
            Debug.Log("ENCOUNTER WEIGHT: " +  encounterWeight);

            int randomValue = Random.Range (0, encounterWeight);

            for (int j = 0;j < EncounterList.Count;j++)
            {

                if (randomValue <= EncounterList[j].spawnRarity)
                {
                    Instantiate(EncounterList[j].Encounter, transform.position, Quaternion.identity);
                    return; //Stop the loop
                }
                randomValue -= EncounterList[j].spawnRarity;
                Debug.Log("RANDOM VALUE DECREASED");
            }
        }
    }    

    public void Spawn()
    {
        ////1ST TRY---
        //int SpawnDir = Random.Range(1,5);
        //
        //if (SpawnDir == 1)
        //{
        //    Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
        //}
        //if (SpawnDir == 2)
        //{
        //    Instantiate(Shop, gameObject.transform.position, Quaternion.identity);
        //}
        //if (SpawnDir == 3)
        //{
        //    Instantiate(Police, gameObject.transform.position, Quaternion.identity);
        //}
        //if (SpawnDir == 4)
        //{
        //    Instantiate(Casino, gameObject.transform.position, Quaternion.identity);
        //}
        //Debug.Log ("OBJECT INSTANTIATED: " +  SpawnDir);

        //2ND TRY----

        int chanceNumber = Random.Range(0, 101); //100 percentage
        Debug.Log("CHANCE NUMBER: " + chanceNumber);

        for (int i = 0; i < EncounterList.Count; i++)
        {
            if (chanceNumber <= EncounterList[i].spawnRarity)
            {
                Instantiate(EncounterList[i].Encounter, transform.position, Quaternion.identity);
                Debug.Log("ITEM: " + EncounterList[i].Encounter + ", PROVIDED BY: " +  gameObject.name);
                return;
            }
   
           
             
        }

    }



}
