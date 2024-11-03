using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public static string selectedCharacter;
    public static int selectedSkinID;

    [SerializeField] private Animator mageAnimator;
    [SerializeField] private Animator dummyAnimator;

    public void SelectMage()
    {
        selectedCharacter = "Mage";
        selectedSkinID = 1;

        mageAnimator.SetTrigger("Selected");
    }

    public void SelectDummy()
    {
        selectedCharacter = "Dummy";
        selectedSkinID = 0;

        dummyAnimator.SetTrigger("Selected");
    }
    public void GoToMainWorldFromCity1()
    {
        SceneTransitionManager.Instance.TransitionToScene("MainWorld", "City1ToMainWorld");
    }

    public void GoToCity1FromMainWorld()
    {
        SceneTransitionManager.Instance.TransitionToScene("World", "MainWorldToCity1");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}