using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject1 : MonoBehaviour
{
    public string nextLevel;
    public void MoveToNextLevel()
    {
        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.SaveData();
        }
        else
        {
            Debug.LogError("데이터매니저 인스턴스 없음");
        }
        SceneManager.LoadScene(nextLevel);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveToNextLevel();
        }
    }
}
