using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1transform : MonoBehaviour
{
    RectTransform m_RectTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        m_RectTransform = GetComponent<RectTransform>();
        float h = canvas.GetComponent<RectTransform>().rect.height;
        float w = canvas.GetComponent<RectTransform>().rect.width;
        m_RectTransform.anchoredPosition = new Vector2(w*0.15f, h*(-0.415f));
    }
}
