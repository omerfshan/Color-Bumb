using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private Text cLevelText,nLevelText;
    private Image fill;
    private float startDistance,distance;
    private GameObject player,finish,hand;
    private TextMesh LevelNo;
    private int level;

    void Awake()
    {
        cLevelText=GameObject.Find("CurrentLevelText").GetComponent<Text>();
        nLevelText=GameObject.Find("NextLevelText").GetComponent<Text>();
        fill=GameObject.Find("Fill").GetComponent<Image>();

        player=GameObject.Find("Player");
        finish=GameObject.Find("Finish");
        hand=GameObject.Find("Tap");
        
        LevelNo=GameObject.Find("LevelNo").GetComponent<TextMesh>();
    }

   private void Start() {
    level=PlayerPrefs.GetInt("Level");
    LevelNo.text="LEVEL" +level;

    nLevelText.text=level+1+"";
    cLevelText.text=level.ToString();

    startDistance=Vector3.Distance(player.transform.position,finish.transform.position);
    // SceneManager.LoadScene("Level"+ level);
   }
    void Update()
    {
        distance=Vector3.Distance(player.transform.position,finish.transform.position);
        if(player.transform.position.z<finish.transform.position.z){
            fill.fillAmount=1-(distance/startDistance);

        }
    }
  public void RemoveUI()
  {
     hand.SetActive(false);
  }


}
