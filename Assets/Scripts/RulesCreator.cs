using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesCreator : MonoBehaviour
{
    [SerializeField] GridManager _gridManager;
    [SerializeField] GameObject _rulePrefab;
    [SerializeField] Transform _rulesUIContainer;

    private ActuatorInstance _instance;
    private Dictionary<RuleEditor, Rule> _rules;

    private void Start() {
        _rules = new Dictionary<RuleEditor, Rule>();
        _instance = _gridManager.CurrentParcel.GetComponentInChildren<ActuatorInstance>();
    }

    public void CreateRule() {
        Rule rule = _instance.CreateNewRule();
        GameObject ruleGo = Instantiate(_rulePrefab);
        ruleGo.transform.SetParent(_rulesUIContainer);
        ruleGo.transform.SetAsFirstSibling();
        ruleGo.transform.localScale = Vector3.one * 0.55f;

        RuleEditor ruleEditor = ruleGo.GetComponent<RuleEditor>();
        ruleEditor.Rule = rule;
        _rules.Add(ruleEditor, rule);
    }
}
