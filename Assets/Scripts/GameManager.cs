using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(Instance);
        }
    }
    #endregion

    public int CoordToId(Vector2 position, int width)
    {
        return Mathf.FloorToInt(position.y) * width + Mathf.FloorToInt(position.x);
    }
}
