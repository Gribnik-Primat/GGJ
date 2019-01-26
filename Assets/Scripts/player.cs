using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Experimental.UIElements;

public class player : MonoBehaviour
{
    public GameObject map;
    public GameObject eventMessage;
    public GameObject UICanvas;
    public GameObject UISettings;
    public Button buttonEMYes;
    public Button buttonEMNo;
    public Sprite ass;
    public Sprite litso;
    public Sprite pravo;
    public Sprite levo;
    public Slider sldr;
    public Text tStrength;
    public Text tDexterity;
    public Text tCute;
    public int start_tile_x=0, start_tile_y=0;
    private int cur_tile_x, cur_tile_y;
    private bool flag_show_event = false;
    public int hp;
    public int strength;
    public int dexterity;
    public int cute;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = litso;
        eventMessage.SetActive(false);
        cur_tile_x = start_tile_x;
        cur_tile_y = start_tile_y;
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.x,
                                              map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.y,
                                              (float)(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.z + 0.1));
        hp = PlayerPrefs.GetInt("hp");
        strength = PlayerPrefs.GetInt("strength");
        dexterity = PlayerPrefs.GetInt("dexterity");
        cute = PlayerPrefs.GetInt("cute");
    }

    // Update is called once per frame
    void Update()
    {
        UIHandler();
        if (Input.GetKeyDown(KeyCode.W)) {
            if (cur_tile_y < 19 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y + 1] != 1 && eventMessage.active == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = ass;
                cur_tile_y++;
                flag_show_event = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (cur_tile_x > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x - 1, cur_tile_y] != 1 && eventMessage.active == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = levo;
                cur_tile_x--;
                flag_show_event = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (cur_tile_y > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y - 1] != 1 && eventMessage.active == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = litso;
                cur_tile_y--;
                flag_show_event = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (cur_tile_x < 19 && map.GetComponent<map_generator>().map_id[cur_tile_x + 1, cur_tile_y] != 1 && eventMessage.active == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = pravo;
                cur_tile_x++;
                flag_show_event = false;
            }
        }
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.x,
                                             map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.y,
                                             (float)(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.z - 0.1));
        if(flag_show_event == false && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 2)
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
        } 

    }

    public void buttonEMNoClick()
    {
        eventMessage.SetActive(false);
    }

    public void buttonUISettings()
    {
        UISettings.SetActive(true);
    }

    public void buttonResumeUISettings()
    {
        UISettings.SetActive(false);
    }

    public void UIHandler()
    {
        sldr.value = hp;
        tStrength.text = strength.ToString();
        tDexterity.text = dexterity.ToString();
        tCute.text = cute.ToString();
}
}
