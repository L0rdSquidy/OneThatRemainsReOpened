using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public RectTransform mapRectTransform; // The RectTransform of the map image
    public RectTransform playerIcon;       // The RectTransform of the player icon
    public Transform player;               // The player's transform

    // Define the boundaries of your game world
    public Vector2 worldSize; // X: width, Y: height

    void Update()
    {
        // Get the player's position relative to the world size
        Vector2 playerPosition = new Vector2(
            player.position.x / worldSize.x,
            player.position.z / worldSize.y
        );

        // Map this position to the map's coordinates
        float mapWidth = mapRectTransform.rect.width;
        float mapHeight = mapRectTransform.rect.height;

        Vector2 mapPosition = new Vector2(
            playerPosition.x * mapWidth,
            playerPosition.y * mapHeight
        );

        // Set the player icon's position
        playerIcon.anchoredPosition = mapPosition;
    }
}

