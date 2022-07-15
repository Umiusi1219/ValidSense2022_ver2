using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelectData : MonoBehaviour
{
    [HeaderAttribute ("MusicData")]
    public Text name;
    public Text artistName, bPM, chartDesigner, illustor;
    [HeaderAttribute ("Level")]
    public Text easyLevel;
    public Text normalLevel; 
    public Text hardLevel;

    public JsonReader jsonReader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var songdata = jsonReader._songList.songdata;
        var difflist = jsonReader._songList.difflist;
        name.text = songdata.name;
        artistName.text = songdata.artist;
        bPM.text = "BPM:" + songdata.bpm;
        easyLevel.text = difflist.natural.level.ToString();
        normalLevel.text = difflist.highSense.level.ToString();
        hardLevel.text = difflist.sixthSense.level.ToString();
        
    }
}
