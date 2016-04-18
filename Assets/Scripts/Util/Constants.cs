using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {

    public Material vertexColorMaterial;

    public GameObject morphingPolyPrefab;

    public static Material vertexColorMat;

    public static GameObject morphingPoly;

    public AudioSource music;

    public int amountOfPolysToSpawn = 10;

    void Start () {
        vertexColorMat = vertexColorMaterial;
        morphingPoly = morphingPolyPrefab;

        GenerateLevel();

        music.volume = 0;

        StartCoroutine(MusicFade(music));
    }

    IEnumerator MusicFade (AudioSource a) {
        while (a.volume < .275f) {
            a.volume = Mathf.Lerp(a.volume, .28f, .01f);
            yield return null;
        }
    }

    void GenerateLevel() {
        for (int i = 0; i < amountOfPolysToSpawn; i++) {
            GameObject gm = Instantiate(morphingPolyPrefab);
            gm.transform.position = new Vector3((Random.value * 100) - 50, (Random.value * 100) - 50);
        }
    }

    public void MuteAudio() {
        if (music.volume != 0) {
            music.volume = 0;
        }
        else {
            music.volume = .28f;
        }
    }

}
