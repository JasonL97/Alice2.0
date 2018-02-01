using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Graphic fade;

    private float alpha = 1;

    private void Start()
    {
    }

    private void Update()
    {
        if (alpha >= 0)
        {
            Color col = fade.color;
            col.a = alpha;
            fade.color = col;
            alpha -= Mathf.Clamp(Time.unscaledDeltaTime, 0, 0.1f);
        }
        Color color = fade.color;
        color.a = alpha;
        fade.color = color;
    }
}
