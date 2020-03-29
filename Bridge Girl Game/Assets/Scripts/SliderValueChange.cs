using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueChange : MonoBehaviour
{

    public int currentVal;
    private int pushVal;
    //public int newVal;

    private Slider bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
    }


    public void MinusOne()
    {
        pushVal = currentVal - 1;
        StartCoroutine(Minus(pushVal));
        Debug.Log("PushVal: " + pushVal);
    }

    public void RestoreTotal(int total)
    {
        Restore(total);
    }

    public IEnumerator Minus(int newVal)
    {
        Debug.Log("Minus coroutine running!");
        for(float i = currentVal; i > newVal; i-= 0.1f)
        {
            bar.value = i;
            yield return new WaitForSeconds(0.01f);
        }
        currentVal = newVal;
    }

    public IEnumerator Restore(int restoreValue)
    {
        for (float i = currentVal; i < restoreValue; i += 0.2f)
        {
            bar.value = i;
            yield return new WaitForSeconds(0.01f);
        }
        currentVal = restoreValue;
    }
}
