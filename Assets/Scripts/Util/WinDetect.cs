using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinDetect : MonoBehaviour {

    public GameObject winnerPanel;

    public Player player;

    // Use this for initialization
    void Start () {
        HideWinPanel();
    }

    bool done = false;
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Poly").Length < 5 && !done) {
            winnerPanel.SetActive(true);
            Text score = winnerPanel.transform.GetChild(0).GetComponent<Text>();
            score.text = "Evolution Points: " + player.morphCount;

            Text time = winnerPanel.transform.GetChild(1).GetComponent<Text>();
            time.text = "Time Taken: " + Time.timeSinceLevelLoad + " seconds";
            done = true;
        }
        if (GameObject.FindGameObjectWithTag("Player") == null && !done) {
            winnerPanel.SetActive(true);
            Text title = winnerPanel.transform.GetChild(2).GetComponent<Text>();
            title.text = "You are not the Fittest...";

            Text score = winnerPanel.transform.GetChild(0).GetComponent<Text>();
            score.text = "Evolution Points: " + player.morphCount;

            Text time = winnerPanel.transform.GetChild(1).GetComponent<Text>();
            time.text = "Time Lasted: " + Time.timeSinceLevelLoad + " seconds";
            done = true;
        }
    }

    public void HideWinPanel() {
        winnerPanel.SetActive(false);
    }
}
