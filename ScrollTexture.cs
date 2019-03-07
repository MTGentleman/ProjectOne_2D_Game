using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.5f;
    public Material rendMaterial;

    void Start()
    {
        rendMaterial = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
       float offset = Time.time * scrollSpeed;
        rendMaterial = GetComponent<SpriteRenderer>().material;
        rendMaterial.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}