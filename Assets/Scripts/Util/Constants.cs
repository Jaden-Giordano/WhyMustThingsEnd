using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {

    public Material vertexColorMaterial;

    public GameObject morphingPolyPrefab;

    public static Material vertexColorMat;

    public static GameObject morphingPoly;

    public int amountOfPolysToSpawn = 10;

    void Start () {
        vertexColorMat = vertexColorMaterial;
        morphingPoly = morphingPolyPrefab;

        GenerateLevel();
    }

    void GenerateLevel() {
        for (int i = 0; i < amountOfPolysToSpawn; i++) {
            GameObject gm = Instantiate(morphingPolyPrefab);
            gm.transform.position = new Vector3((Random.value * 100) - 50, (Random.value * 100) - 50);
        }
    }

}
