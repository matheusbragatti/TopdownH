using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMuzzleFlashScript : MonoBehaviour
{
    public float muzzleFlashDuration;

    void Start()
    {
        muzzleFlashDuration = 10f;
        StartCoroutine(muzzleFlashPlay());
    }

    void Update()
    {
        
    }

    IEnumerator muzzleFlashPlay()
    {
        float duration = 0;

        while (duration <= muzzleFlashDuration)
        {
            duration++;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
