using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GridManager _grid;

    public UnityEvent OnItemPlaced;

    private void Reset()
    {
        _camera = Camera.main;
    }

    private Coroutine _placementModeCoroutine = null;

    public void ActivatePlacementModeForItem(GameObject itemGo)
    {
        GameObject ghostItemGo = Instantiate(itemGo);
        ghostItemGo.SetActive(false);
        ghostItemGo.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // half opacity
        _placementModeCoroutine = StartCoroutine(PlacementModeCoroutine(ghostItemGo)); // launch placement mode
    }

    // The game object is half visible and follows the mouse
    // When the player clicks, it becomes fully visible and stays where the click happens
    private IEnumerator PlacementModeCoroutine(GameObject ghostItemGo)
    {
        while (true)
        {
            ghostItemGo.SetActive(true);
            ghostItemGo.transform.position = _grid.GetClosestParcelCoordinates(_camera.ScreenToWorldPoint(Input.mousePosition)) + Vector2.one * 0.5f;

            if (Input.GetMouseButtonDown(0))
            {
                // Let's place the item if the mouse is in the grid (the ghost is activated)
                if (ghostItemGo.activeInHierarchy)
                {
                    ghostItemGo.GetComponentInChildren<SpriteRenderer>().color = Color.white; // fully visible
                }

                OnItemPlaced.Invoke();
                // Stop coroutine
                _placementModeCoroutine = null;
                break;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(ghostItemGo);
                OnItemPlaced.Invoke();
                _placementModeCoroutine = null;
                break;
            }

            yield return null;
        }
    }
}
