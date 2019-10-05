using UnityEngine;

[System.Serializable]
public class SpawnZone
{
    public EZoneTag Tag;
    public BoxCollider2D Area;

    public Vector2 GetRandomPointInZone()
    {
        return new Vector2(
            Random.Range(Area.bounds.min.x, Area.bounds.max.x),
            Random.Range(Area.bounds.min.y, Area.bounds.max.y)
        );
    }
}