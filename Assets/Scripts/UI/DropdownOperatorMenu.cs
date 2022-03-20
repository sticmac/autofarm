using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownOperatorMenu : MonoBehaviour
{
    [SerializeField] GameObject _panelGO;
    [SerializeField] TextMeshProUGUI _dropdownText;
    [SerializeField] RuleEditor _ruleEditor;

    private Rule.LogicalOperators _selectedOperator;

    private void Start() {
        Select(Rule.LogicalOperators.Inf);
    }

    public void ToggleDropdown() {
        _panelGO.SetActive(!_panelGO.activeInHierarchy);
    }

    public void Select(string op) {
        switch(op) {
            case "=":
                Select(Rule.LogicalOperators.Egal);
                break;
            case "<":
                Select(Rule.LogicalOperators.Inf);
                break;
            case ">":
                Select(Rule.LogicalOperators.Sup);
                break;
        }
    }

    public void Select(Rule.LogicalOperators op) {
        _selectedOperator = op;

        switch(op) {
            case Rule.LogicalOperators.Egal:
                _dropdownText.text = "=";
                break;
            case Rule.LogicalOperators.Inf:
                _dropdownText.text = "<";
                break;
            case Rule.LogicalOperators.Sup:
                _dropdownText.text = ">";
                break;
        }

        _ruleEditor.SetRuleOperator(op);
    }
}