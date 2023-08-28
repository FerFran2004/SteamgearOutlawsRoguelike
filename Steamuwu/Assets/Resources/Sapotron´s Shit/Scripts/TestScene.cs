using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    private void Start()
    {
        
    }

    //THE LOAD SCENE NUMBER IS THE INDEX FROM Build Settings > Scenes in Build
    public void EnemyScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(2);
    }

    public void PoliceScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(3);
    }

    public void CasinoScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(5);
    }

    public void ShopScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(4);
    }

    public void BossScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(6);
    }

    public void OcurrenceScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(7);
    }

    public void OverworldScene()
    {
        Debug.Log("CLIKCING");
        SceneManager.LoadScene(1);
    }

}
