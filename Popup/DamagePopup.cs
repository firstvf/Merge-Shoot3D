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

    private void Update()
    {
        transform.Translate(-Vector3.down * 1f * Time.deltaTime);
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
           // Random.Range(position.x - 0.25f, position.x + 0.25f),
           Random.Range(position.x - 0.5f, position.x + 0.5f),
            Random.Range(position.y - 0.15f, position.y + 0.55f),
            position.z);
    }
}