using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //the number of beats in each loop
    public float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    public float loopPositionInBeats;

    public float firstBeatOffset;

    //The current relative position of the song within the loop measured between 0 and 1.
    public float loopPositionInAnalog;

    public float timer = 2f;


    
    //Conductor instance
    public static Conductor instance;
    void Awake() {
        instance = this;
    }
    

    void Start() {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime + 1.6f;
        timer = 2f;
        //Start the music
        
    }
    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            if (!musicSource.isPlaying) {
                
                musicSource.volume = 1;
                musicSource.Play();
            }
        }  
        //if (GameObject.Find("BadassBar").GetComponent<BadassManager>().stopped) musicSource.Pause();
        
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop) completedLoops++;
        
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;

        
          
    }
    public IEnumerator fadeOut() {
        while (musicSource.volume > 0) {
            musicSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        musicSource.Stop();

    }

    
}
