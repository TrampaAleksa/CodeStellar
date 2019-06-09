using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CodingGame : MonoBehaviour {

    public GameObject rocket;
    public GameObject EventSystem;
    public CodeManager codeManager;
    public Question currentQuestion;
    public GameObject bacgroundFrame;
    public Text[] Answers;
    public Text question;

    private AudioSource backgroundAudio;
    private AudioSource[] answerAudio;

    public void InitializeGame()
    {
        backgroundAudio = bacgroundFrame.GetComponent<AudioSource>();
        answerAudio = GetComponents<AudioSource>();
        answerAudio[2].Play();
        backgroundAudio.Stop();
        codeManager = EventSystem.GetComponent<CodeManager>();
        currentQuestion = codeManager.SelectRandomQuestionFromCurrentList();
        for(int i=0; i<4; i++)
        {
            Answers[i].text = currentQuestion.answers[i];
        }
        question.text = currentQuestion.questionText;
    }

    public void ClickedAnswer(int index)
    {
        answerAudio[2].Stop();
        if (index == currentQuestion.correctAnswerIndex)
        {
            answerAudio[1].Play();
            backgroundAudio.Play();
            codeManager.IncreaseDifficultyLevel();
            rocket.GetComponent<RocketCollisionManager>().Takeoff();
        }
        else
        {
            answerAudio[0].Play();
            Application.LoadLevel("Main Scene");
        }
    }

 
}
