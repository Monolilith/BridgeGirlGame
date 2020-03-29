using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //public AK.Wwise.Event BGM;
    //public static List<AK.Wwise.State> ListOfMusic = new List<AK.Wwise.State>();

    //public AK.Wwise.State EnterState;
    //public AK.Wwise.State ExitState;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        ListOfMusic.Insert(0, EnterState);
    //        ListOfMusic[0].SetValue();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        ListOfMusic.Remove(EnterState);
    //        if(ListOfMusic.Count > 0)
    //        {
    //            ListOfMusic[0].SetValue();
    //        }
    //        else
    //        {
    //            ExitState.SetValue();
    //        }
    //    }
    //}

    public AK.Wwise.Event BGM;

    public AK.Wwise.Event CurrentTrack;

    public AK.Wwise.State OnTriggerEnterState;
    public AK.Wwise.State OnTriggerExitState;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Player"))
        {
            Debug.Log("I'm in");
            //AkSoundEngine.SetSwitch("Corridor_State", "Corridor", gameObject);
           // AkSoundEngine.PostEvent("Gameplay_Theme", gameObject);
            OnTriggerEnterState.SetValue();

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("I'm out");
            OnTriggerExitState.SetValue();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //CurrentTrack.SetValue();
        CurrentTrack.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
