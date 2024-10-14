using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public static string selectedCharacter;
    public static int selectedSkinID;

    public void SelectMage()
    {
        selectedCharacter = "Mage";
        selectedSkinID = 1;
    }

    public void SelectDummy()
    {
        selectedCharacter = "Dummy";
        selectedSkinID = 0;
    }

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}
