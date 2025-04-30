using UnityEngine;
using UnityEngine.Tilemaps;

public class TogglePlatformGroup : MonoBehaviour
{
    private Tilemap tilemap;
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider;
    public bool isActive = true;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    public void Toggle(bool state)
    {
        isActive = state;

        // Toggle both rendering and collision
        if (tilemap != null) tilemap.enabled = state;
        if (tilemapRenderer != null) tilemapRenderer.enabled = state;
        if (tilemapCollider != null) tilemapCollider.enabled = state;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
