using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class menufunctions : MonoBehaviour
{

    public GameObject OptionsPanel;
    public GameObject Buttons;
    public AudioMixer mixer;
    public AudioMixer sfxmixer;

    public bool musicmute = false;
    public bool sfxmute = false;
    public Sprite spriteOn;
    public Sprite spriteOff;

    public Sprite HighOn;
    public Sprite HighOff;
    public Sprite MedOn;
    public Sprite MedOff;
    public Sprite LowOn;
    public Sprite LowOff;

    private float musicLevel;
    private void Start()
    {
        
    }

    public void HighSettings()
    {
        QualitySettings.SetQualityLevel(2);
        GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOn;
        GameObject.Find("medButton").GetComponent<Image>().sprite = MedOff;
        GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOff;
    }

    public void MedSettings()
    {
        QualitySettings.SetQualityLevel(1);
        GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOff;
        GameObject.Find("medButton").GetComponent<Image>().sprite = MedOn;
        GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOff;
    }

    public void LowSettings()
    {
        QualitySettings.SetQualityLevel(0);
        GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOff;
        GameObject.Find("medButton").GetComponent<Image>().sprite = MedOff;
        GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOn;
    }


    public void startGame()
    {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene("Main Scene");
    }

    public void backmenu()
    {
        StartCoroutine(backtomenu());
    }
    IEnumerator backtomenu()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene("menu");
    }

    public void gotocredits()
    {
        StartCoroutine(gocredits());
    }
    IEnumerator gocredits()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene("credits");
    }

    public void gotoabout()
    {
        StartCoroutine(goabout());
    }
    IEnumerator goabout()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene("about");
    }
    public void toggleOptions()
    {
        if (!OptionsPanel.activeSelf)
        {
            Buttons.SetActive(false);
            OptionsPanel.SetActive(true);
            int CurrentQuality = QualitySettings.GetQualityLevel();
            
            if (CurrentQuality == 0)
            {
                GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOff;
                GameObject.Find("medButton").GetComponent<Image>().sprite = MedOff;
                GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOn;
            }
            else if (CurrentQuality == 1)
            {
                GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOff;
                GameObject.Find("medButton").GetComponent<Image>().sprite = MedOn;
                GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOff;
            }
            else
            {
                GameObject.Find("HighButton").GetComponent<Image>().sprite = HighOn;
                GameObject.Find("medButton").GetComponent<Image>().sprite = MedOff;
                GameObject.Find("LowButton").GetComponent<Image>().sprite = LowOff;
            }
            mixer.GetFloat("volume", out musicLevel);
            if (musicLevel == -80)
                GameObject.Find("MusicToggle").GetComponent<Image>().sprite = spriteOff;
            else
                GameObject.Find("MusicToggle").GetComponent<Image>().sprite = spriteOn;
        }
        else
        {
            OptionsPanel.SetActive(false);
            Buttons.SetActive(true);
        }

    }
    public void toggleMusic()
    {
        mixer.GetFloat("volume", out musicLevel);
        if (musicLevel != -80)
        {
            mixer.SetFloat("volume", -80);
            Debug.Log("music muted");
            GameObject.Find("MusicToggle").GetComponent<Image>().sprite = spriteOff;
        }
        else
        {
            mixer.SetFloat("volume", 20);
            Debug.Log("music on");
            GameObject.Find("MusicToggle").GetComponent<Image>().sprite = spriteOn;
        }
    }
    public  void toggleSFX()
    {
        if (!sfxmute)
        {
            sfxmixer.SetFloat("volume", -80);
            GameObject.Find("SFXToggle").GetComponent<Image>().sprite = spriteOff;
        }
        else
        {
            sfxmixer.SetFloat("volume", 0);
            GameObject.Find("SFXToggle").GetComponent<Image>().sprite = spriteOn;
        }
        sfxmute = !sfxmute;
    }
}
