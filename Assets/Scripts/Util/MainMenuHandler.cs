using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

	public void PlayClicked() {
        SceneManager.LoadScene("main");
    }

    public void QuitClicked() {
        Application.Quit();
    }

    public void MenuClicked() {
        SceneManager.LoadScene("menu");
    }

}
