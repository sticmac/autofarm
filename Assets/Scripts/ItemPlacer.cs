using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GridManager _grid;
    [SerializeField] Culture _culture;

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
            Vector2 parcelCoord = _grid.GetClosestParcelCoordinates(_camera.ScreenToWorldPoint(Input.mousePosition)) + Vector2.one * 0.5f;
            ghostItemGo.transform.position = parcelCoord;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Destroy(ghostItemGo);
                OnItemPlaced.Invoke();
                _grid.ParcelAtCoord(parcelCoord).AddCulture(_culture);
                _placementModeCoroutine = null;
                break;
            }

            yield return null;
        }
    }
}
