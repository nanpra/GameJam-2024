using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    public Image icon;
    public Font selectedFont;
    public Font normalFont;
    public ScriptManager scriptManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (scriptManager.instance.audioManager.checkSound == 1)
            UiManager.instance.tapSource.PlayOneShot(UiManager.instance.tapClip);
        text.color = Color.black;
        icon.gameObject.SetActive(true);
        text.font = selectedFont;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
        icon.gameObject.SetActive(false);
        text.font = normalFont;
    }

    private void Update()
    {
        icon.transform.Rotate(Vector3.back * Time.deltaTime * 20);
    }
}
