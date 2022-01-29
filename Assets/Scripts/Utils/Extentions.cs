using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static Vector3 ToVector3(this Vector2 vector) => 
                        new Vector3(vector.x, vector.y, 0f);
    
    public static Vector3 ToVector3(this Vector2 vector, float z) => 
                        new Vector3(vector.x, vector.y, z);
    
    public static Vector3Int ToVector3Int(this Vector2Int vector, int z) => 
                            new Vector3Int(vector.x, vector.y, z);
    

    
    public static Vector2Int ToVector2Int(this Vector3 vector) => new Vector2Int
    {
        x = Mathf.RoundToInt(vector.x),
        y = Mathf.RoundToInt(vector.y),
    };
}
