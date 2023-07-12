using System.Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class Plane : MonoBehaviour
{
    private Terrain terrain;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
    }

    private void Start()
    {
        terrain.terrainData.terrainLayers[0].diffuseRemapMax = UnityEngine.Color.red;
    }

    public void SetPlaneColor()
    {
        terrain.terrainData.terrainLayers[0].diffuseRemapMax = UnityEngine.Color.white;
    }
}
