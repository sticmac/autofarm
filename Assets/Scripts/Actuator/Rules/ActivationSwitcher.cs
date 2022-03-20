using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationSwitcher : MonoBehaviour
{
    [SerializeField] Image _image;

    [Space(5)]
    [SerializeField] Sprite _activateSprite;
    [SerializeField] Sprite _deactivateSprite;

    private RuleEditor _ruleEditor;
    private bool _ruleActivating = true;

    private void Start() {
        _ruleEditor = GetComponentInParent<RuleEditor>();
    }

    public void Toggle() {
        _ruleActivating = !_ruleActivating;
        _ruleEditor.SetActivation(_ruleActivating);
        if (_ruleActivating) {
            _image.sprite = _activateSprite;
        } else {
            _image.sprite = _deactivateSprite;
        }
    }
}
