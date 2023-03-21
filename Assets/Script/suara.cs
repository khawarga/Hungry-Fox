using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suara : MonoBehaviour
{

    public static AudioClip lompat, menang, kalah, kena,ambil, door;
    static AudioSource sumber;

    // Start is called before the first frame update
    void Start()
    {
        lompat = Resources.Load<AudioClip>("lompat");
        menang = Resources.Load<AudioClip>("FinishSFX");
        kalah = Resources.Load<AudioClip>("LoseSFX");
        kena = Resources.Load<AudioClip>("DamagedSFX");
        ambil = Resources.Load<AudioClip>("CollectSFX");
        door = Resources.Load<AudioClip>("door");
        sumber = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playsound(string clip)
    {
        if (clip.Equals("lompat"))
        {
            sumber.PlayOneShot(lompat);
        }
        if (clip.Equals("menang"))
        {
            sumber.PlayOneShot(menang);
        }
        if (clip.Equals("kalah"))
        {
            sumber.PlayOneShot(kalah);
        }
        if (clip.Equals("kena"))
        {
            sumber.PlayOneShot(kena);
        }
        if (clip.Equals("ambil"))
        {
            sumber.PlayOneShot(ambil);
        }
        if (clip.Equals("door"))
        {
            sumber.PlayOneShot(door);
        }
    }

}
