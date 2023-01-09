using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro _damageText;
    private WaitForSeconds _hideTimer;

    private void Awake()
    {
        _damageText = GetComponent<TextMeshPro>();
        _hideTimer = new WaitForSeconds(0.45f);
    }

    private void OnEnable()
    {
        StartCoroutine(HideDamagePopup());
    }

    private IEnumerator HideDamagePopup()
    {
        yield return _hideTimer;
        gameObject.SetActive(false);
    }

    public void Setup(int damageAmount, Vector3 position)
    {
        _damageText.SetText(damageAmount.ToString());
        transform.position = new Vector3(
            Random.Range(position.x - 0.25f, position.x + 0.25f),
            Random.Range(position.y, position.y + 0.25f),
            position.z);
    }
}