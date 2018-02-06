using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_Controls : MonoBehaviour {

    public Graphic fade;
    public AudioSource sound;

    public void OnMouseButton()
    {
        sound.Play();
        StartCoroutine(DoFadeAndLoad());
    }
    private IEnumerator DoFadeAndLoad()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            Color color = fade.color;
            color.a = alpha;
            fade.color = color;
            yield return new WaitForFixedUpdate();
        }
        SceneManager.LoadScene("loadScene");

    }
}
