using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour
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
            Debug.LogError("�����͸Ŵ��� �ν��Ͻ� ����");
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
