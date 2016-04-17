using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {

    public static Material vertexColor;

    public static GameObject mpoly;

    public Material vertexColorMaterial;

    public GameObject morphingPolyPrefab;

    public int amountOfPolysToSpawn = 10;

    void Start() {
        vertexColor = vertexColorMaterial;
        mpoly = morphingPolyPrefab;

        GenerateLevel();
    }

    void GenerateLevel() {
        for (int i = 0; i < amountOfPolysToSpawn; i++) {
            GameObject gm = Instantiate(mpoly);
            gm.transform.position = new Vector3((Random.value * 50) - 25, (Random.value * 50) - 25);
        }
    }

}
