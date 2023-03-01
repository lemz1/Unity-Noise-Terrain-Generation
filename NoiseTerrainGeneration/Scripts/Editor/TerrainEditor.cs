using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Terrain))]
public class TerrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Terrain terrain = (Terrain)target;
        if (DrawDefaultInspector() || GUILayout.Button("Generate"))
        {
            if (terrain.meshObject == null)
            {
                terrain.meshObject = new GameObject("Mesh");
                terrain.meshObject.transform.parent = terrain.transform;
                terrain.meshObject.AddComponent<MeshFilter>();
                terrain.meshObject.AddComponent<MeshRenderer>().sharedMaterial = terrain.meshMaterial;
            }
            terrain.meshObject.GetComponent<MeshFilter>().sharedMesh = MeshGenerator.GenerateMeshData(
                Noise.GenerateNoiseMap(terrain.meshWidth, terrain.meshHeight, terrain.seed, terrain.noiseScale,
                terrain.octaves, terrain.persitance, terrain.lacunarity, terrain.offset), terrain.heightMultiplier).CreateMesh();
        }
    }
}
