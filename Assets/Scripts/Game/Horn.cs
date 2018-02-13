using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour {
    public AudioClip HornClip, LongHornClip;  
    AudioSource AS;
    bool isHorning;
   
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.clip = HornClip;
	}
	
    public void Sing(bool state)
    {
        if (state)
        {
            AS.clip = HornClip;
            AS.loop = false;
            AS.Play();
            isHorning = true;
            Invoke("SingMore", 0.8f);
        }
        else
        {
            if (!isHorning)
            {
                AS.loop = false;
            }
            isHorning = false;
            CancelInvoke("SingMore");
        }
    }
    void SingMore()
    {
        isHorning = false;
        AS.clip = LongHornClip;
        AS.loop = true;
        AS.Play();
    }
	// Update is called once per frame
	void Update () {
        //if (isHorning)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > 0.8f && !isHolding)
        //    {
        //        isHolding = true;
        //        SingMore();
        //    }
        //}
	}
}
