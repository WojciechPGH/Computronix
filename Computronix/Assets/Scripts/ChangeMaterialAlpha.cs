using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeMaterialAlpha : MonoBehaviour
{
    [Range(0f, 1f)]
    public float alpha = 0.7f;
    void Start()
    {
        TilemapRenderer sr = GetComponent<TilemapRenderer>();
        if (sr != null)
        {
            sr.material.SetFloat("Vector1_DC9FB60D", alpha);
        }
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.material.SetFloat("Vector1_DC9FB60D", alpha);
        }
    }
}
