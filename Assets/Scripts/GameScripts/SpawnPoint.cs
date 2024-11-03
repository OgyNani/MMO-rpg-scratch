using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string pointName;

    private void Start()
    {
        if (SceneTransitionManager.spawnPoint == pointName)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = transform.position;
            }
        }
    }
}
