using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayonaraController : MonoBehaviour
{
    public float healthDepletionRate = 0.01f;
    public Image sayonaraBar1;
    public Image sayonaraBar2;
    public Image signPlus;
    public Image signMinus;

    [Header("Read me")]
    public float _sayonaraHealth = 0.6f;
    private void FixedUpdate() {
        sayonaraBar1.fillAmount = _sayonaraHealth;
        sayonaraBar2.fillAmount = _sayonaraHealth;

        if (_sayonaraHealth > 0f) {
            _sayonaraHealth -= Time.deltaTime * healthDepletionRate;
            _sayonaraHealth = Mathf.Clamp(_sayonaraHealth, 0f, 1f);
        }

        if (_sayonaraHealth <= 0f) {
            GameManager.KillPlayer();
        }
        if(_sayonaraHealth >= 0.99f) {
            GameManager.StopSayonara();
        }
    }
    public void GiveHealth() {
        _sayonaraHealth += 0.2f;
    }
    public void RemoveHealth() {
        _sayonaraHealth -= 0.1f;
    }

}
