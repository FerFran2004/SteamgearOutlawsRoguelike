using UnityEngine;
using UnityEngine.SceneManagement;
public class TestScene : MonoBehaviour
{

    //THE LOAD SCENE NUMBER IS THE INDEX FROM Build Settings > Scenes in Build
    void ChangeLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void EnemyScene()
    {
        ChangeLevel(2);
    }

    public void PoliceScene()
    {
        ChangeLevel(3);
    }

    public void CasinoScene()
    {
        ChangeLevel(5);
    }

    public void ShopScene()
    {
        ChangeLevel(4);
    }

    public void BossScene()
    {
        ChangeLevel(6);
    }

    public void OcurrenceScene()
    {
        ChangeLevel(7);
    }

    public void OverworldScene()
    {
        ChangeLevel(1);
    }

}

    