using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesCreator : MonoBehaviour
{
    [SerializeField] GridManager _gridManager;
    [SerializeField] GameObject _rulePrefab;
    [SerializeField] RectTransform _rulesUIContainer;

    private ActuatorInstance _instance;

    public GridManager AttachedGridManager => _gridManager;

    private void Start() {
        _instance = _gridManager.CurrentParcel.GetComponentInChildren<ActuatorInstance>();
    }

    public void CreateRule() {
        Rule rule = _instance.CreateNewRule();
        GameObject ruleGo = Instantiate(_rulePrefab);
        ruleGo.transform.SetParent(_rulesUIContainer);
        ruleGo.transform.SetAsFirstSibling();
        ruleGo.transform.localScale = Vector3.one * 0.55f;

        _rulesUIContainer.sizeDelta += new Vector2(0, 112);

        RuleEditor ruleEditor = ruleGo.GetComponent<RuleEditor>();
        ruleEditor.Rule = rule;
    }
}
