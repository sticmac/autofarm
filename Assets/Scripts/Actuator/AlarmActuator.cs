using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmActuator : ActuatorInstance {
    [SerializeField] GameObject _alertNotification;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] Sprite _deactivatedSprite;
    [SerializeField] Sprite _activatedSprite;

    public override void Activate()
    {
        base.Activate();
        //_alertNotification.SetActive(true);
        _spriteRenderer.sprite = _activatedSprite;
    }

    public override void Desactivate()
    {
        base.Desactivate();
        //_alertNotification.SetActive(false);
        _spriteRenderer.sprite = _deactivatedSprite;
    }
}