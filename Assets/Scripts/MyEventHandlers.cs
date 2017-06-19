using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

//J'utilise pour ce fichier en particulier le fichier donné directement car il n'explique pas son code, et la version (ou les includes de librairie, je ne sais
// pas) produisent des différences. J'ai cependant pris le temps d'essayer de le comprendre, bien évidemment.

public class MyEventHandlers : MonoBehaviour, IPointerEnterHandler,
    IDragHandler, IPointerExitHandler{

    private bool pulse = false;
    private float time = 0;

    public void OnDrag(PointerEventData eventData)
    {
        this.gameObject.transform.position = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pulse = true;
        StartCoroutine(PulseObject());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pulse = false;
    }

    IEnumerator PulseObject()
    {
        float rate = 1f;
        float maxScale = 1.2f;
        float minScale = .8f;
        float scale = 0;
        //while pulsing, change the scale based on a sin wave
        while (pulse) 
        {
            scale = Mathf.Lerp(minScale, maxScale,
                (Mathf.Sin(time * (rate * 2 * Mathf.PI))
                 + 1f) / 2f);

            transform.localScale =
                new Vector3(scale, scale, scale);
            time += Time.deltaTime;
            yield return null;
        }
        //We’ll get here after we’re done with pulse,
        // this loop will continue to run the coroutine
        // until the object is back to its original scale,
        // meaning it’ll be a smooth transition
        while (scale - .05f > 1 || scale + .05f < 1)
        {
            scale = Mathf.Lerp(minScale, maxScale,
                (Mathf.Sin(time * (rate * 2 * Mathf.PI))
                + 1f) / 2f);

            transform.localScale = 
                new Vector3(scale, scale, scale);
            time += Time.deltaTime;
            yield return null;
        }
        //finally, reset the scale to 1 and
        // reset our time variable
        transform.localScale = new Vector3(1, 1, 1);
        time = 0;
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
