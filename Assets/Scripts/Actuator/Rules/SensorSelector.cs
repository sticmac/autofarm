using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorSelector : MonoBehaviour
{
    [SerializeField] Image _sensorSelectedImage;

    private GridManager _gridManager;
    private CanvasGroup _canvasGroup;
    private List<Parcel> _neighbours;
    private RuleEditor _ruleEditor;

    private void Start() {
        _neighbours = new List<Parcel>();
        _gridManager = GetComponentInParent<RulesCreator>().AttachedGridManager;
        _canvasGroup = GetComponentInParent<CanvasGroup>();
        _ruleEditor = GetComponentInParent<RuleEditor>();
    }

    public void Activate() {
        Parcel currentParcel = _gridManager.CurrentParcel;
        _neighbours.Clear();
        _neighbours.Add(_gridManager.ParcelNextToId(currentParcel.Id, Vector2.up));
        _neighbours.Add(_gridManager.ParcelNextToId(currentParcel.Id, Vector2.down));
        _neighbours.Add(_gridManager.ParcelNextToId(currentParcel.Id, Vector2.right));
        _neighbours.Add(_gridManager.ParcelNextToId(currentParcel.Id, Vector2.left));

        foreach (Parcel n in _neighbours)
        {
            SelectableSensor s = n.gameObject.GetComponentInChildren<SelectableSensor>();
            if (s != null) {
                s.MakeSelectable(true);

                // Make ui invisible
                _canvasGroup.interactable = false;
                _canvasGroup.alpha = 0;
                _canvasGroup.blocksRaycasts = false;

                StartCoroutine(SelectSensorCoroutine());
            }
        }
    }

    public IEnumerator SelectSensorCoroutine() {
        while (true) {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            RaycastHit2D res = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (res.collider != null && res.collider.CompareTag("Sensor")) {
                _ruleEditor.SetSensor(res.collider.GetComponent<SensorInstance>());
                _sensorSelectedImage.enabled = true;

                // Make ui invisible
                _canvasGroup.interactable = true;
                _canvasGroup.alpha = 1;
                _canvasGroup.blocksRaycasts = true;

                foreach (Parcel n in _neighbours)
                {
                    SelectableSensor s = n.gameObject.GetComponentInChildren<SelectableSensor>();
                    if (s != null) {
                        s.MakeSelectable(false);
                    }
                }

                break;
            } 
        }
    }
}
