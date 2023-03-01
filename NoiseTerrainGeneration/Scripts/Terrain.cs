using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public int meshWidth;
    public int meshHeight;
    public int seed;
    public float noiseScale;
    public float heightMultiplier;
    public int octaves;
    public float persitance;
    public float lacunarity;
    public Vector2 offset;
    public Material meshMaterial;

    [HideInInspector]
    public GameObject meshObject;

}
