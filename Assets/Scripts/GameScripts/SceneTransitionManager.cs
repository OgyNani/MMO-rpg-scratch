using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    // ���������� ��� �������� ������ � ��������
    public static string lastScene;
    public static string spawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToScene(string sceneName, string pointName)
    {
        lastScene = SceneManager.GetActiveScene().name;
        spawnPoint = pointName;
        SceneManager.LoadScene(sceneName);
    }
}
