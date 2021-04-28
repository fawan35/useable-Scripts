using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModeSelection : MonoBehaviour
{
    #region Public Variables
    //******* Mode Data **********
    //public Sprite[] sprt_UnlockMode;
    //public Sprite[] sprt_LockMode;
    public Button[] BTN_modes;
    public Button BTN_ModeNext;


    //****** Level Data ***********

    public Button[] Levels;
    public Button BTNLevelNext;
    public Sprite[] Sprt_lockMode;
    public Sprite[] Sprt_unlockMode;
    public Sprite sprt_lock, sprt_unlock;
    public string[] LevelDescription;
    public float time_TypingSpeed = 0.4f;
    #endregion

    #region Private Variables
    int CurrentLevel;
    int CurrentMode;
    #endregion

    #region Mono Methods
    private void Start()
    {

        //for (int i = 0; i < 15; i++)
        //{
        //    playerprefz.setCurrentLevel(i);
        //    playerprefz.setUnlockNextLevel();


        //}
        for (int i = 0; i < 3; i++)
        {
            playerprefz.setCurrentMode(i);
            playerprefz.setUnlockNextMode(i);

        }
        Initializations();
        ReseAllModes();
    }
    #endregion

    #region Custom Methods
    public void OnPanelOPen()
    {
        ReseAllModes();
    }
    void Initializations()
    {
        //**** Modes *********
        for (int i = 0; i < BTN_modes.Length; i++)
        {
            int a = i;

        BTN_modes[i].onClick.AddListener(() => {
            OnModeBtnClick(a);
        });

        }

        BTN_ModeNext.onClick.AddListener(() => {
            OnModeNextbtnClick();
        });


        //***** Levels ******

        for (int i = 0; i < Levels.Length; i++)
        {
            int a = i;
            Levels[i].onClick.AddListener(() => {
                OnLevelClickbtn(a);
            });
        }

        BTNLevelNext.onClick.AddListener(() => {
            OnNextBtnClick();
        });






    }

    void OnNextBtnClick()
    {
        print("Open GamePlay");
    }


    // ***************************** MODE DATA ***************************//

    void OnModeBtnClick(int modeno) {
        playerprefz.setCurrentMode(modeno);
        CurrentMode = modeno;
        BTN_ModeNext.gameObject.SetActive(true);
}
    void OnModeNextbtnClick()
    {
        GetComponent<MainMenuController>().GetScreen(Screens.LevelSelection);
        ResetAllLevels();
    }
    void ReseAllModes()
    {
        for (int i = 0; i < BTN_modes.Length; i++)
        {
            if (playerprefz.getUnlockedMode(i) == 1)
            {
                BTN_modes[i].transform.GetChild(0).gameObject.SetActive(true);
                BTN_modes[i].transform.GetChild(2).gameObject.SetActive(false);
                BTN_modes[i].interactable = true;
            }
            else
            {

                BTN_modes[i].transform.GetChild(0).gameObject.SetActive(false);
                BTN_modes[i].transform.GetChild(2).gameObject.SetActive(true);
                BTN_modes[i].interactable = false;
            }
        }
        BTN_ModeNext.gameObject.SetActive(false);

    }



    //************************************ LEVEL DATA ******************************//
    void OnLevelClickbtn(int currentLvl)
    {

        CurrentLevel = currentLvl;
        OpenInfoBox();
        BTNLevelNext.gameObject.SetActive(true);
    }
    IEnumerator OpenInfoBox()
    {
        ResetInfoBoxes();
        Levels[CurrentLevel].transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        Text textComponent = Levels[CurrentLevel].transform.GetChild(2).GetChild(0).GetComponent<Text>();
       
        foreach (char c in LevelDescription[CurrentLevel])
        {
            textComponent.text = textComponent.text + c;
            yield return new WaitForSeconds(.03f);
        }

        yield return null;



    }
    void ResetInfoBoxes()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    void ResetAllLevels()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = Sprt_lockMode[CurrentMode];
            Levels[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = sprt_lock;
            Levels[i].interactable = false;
            Levels[i].transform.GetChild(2).gameObject.SetActive(false);

        }
        for (int i = 0; i < playerprefz.getUnlockedLevel(CurrentMode); i++)
        {
            if (Levels.Length > i)
            {
                Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = Sprt_unlockMode[CurrentMode];
                Levels[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = sprt_unlock;
                Levels[i].interactable = true;
            }
        }
        BTNLevelNext.gameObject.SetActive(false);

    }


    #endregion
}
