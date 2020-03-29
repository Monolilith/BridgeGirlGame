using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueChange : MonoBehaviour
{

    public int currentVal;
    public int newVal;

    private Slider bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MinusOne()
    {
        Minus();
    }

    public IEnumerator Minus()
    {
        for(float i = currentVal; i > newVal; i-= 0.1f)
        {
            bar.value = i;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
