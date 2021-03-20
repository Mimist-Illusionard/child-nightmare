using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuDIOController : MonoBehaviour
{
    public List<AudioSettings> audios = new List<AudioSettings>();
    private void Start()
    {
        StartCoroutine(Timedate());
    }

    IEnumerator Timedate()
    {
        for (; ; )
        {
            for (int i = 0; i<audios.Count;i++)
            {
                audios[i].AllVoids();
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
