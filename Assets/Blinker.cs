using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blinker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Material openTex;
    [SerializeField] Material closedTex;

    public float timer;
    public float currentRandom;

    bool blinking;

    Renderer rend;

    void Start()
    {
        currentRandom = Random.Range(2, 6);
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!blinking && timer> currentRandom)
        {
            blinking = true;
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        rend.material = closedTex;
        yield return new WaitForSeconds(.1f);
        rend.material = openTex;
        currentRandom = Random.Range(2, 6);
        timer = 0;
        blinking = false;
    }
}
