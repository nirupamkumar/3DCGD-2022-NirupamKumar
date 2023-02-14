using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlickering : MonoBehaviour
{
    private Light spotLight;

    public float minWaitTime;
    public float maxWaitTime;

    private void Start()
    {
        spotLight= GetComponent<Light>();
        StartCoroutine(Flickering());
    }

    IEnumerator Flickering()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            spotLight.enabled = ! spotLight.enabled;
        }
    }
}
