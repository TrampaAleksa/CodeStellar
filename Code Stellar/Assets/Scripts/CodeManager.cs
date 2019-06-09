using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour {


	// DETERMINES WHAT TYPE OF CODES WILL BE SELECTED
	public string[] difficulties = {"Novice", "Normal", "Advanced", "Expert"};
	
	//ACCESS THIS LIST AND USE SELECT RANDOM QUESTION TO GET A QUESTION VARIABLE
	public List<Question> currentQuestionsList;

	// VARIABLE CHANGES WITH THE CALL OF CHANGE DIFFICULTY LEVEL
	public int currentDifficulty;


	void Start()
	{
		//initial filling of the list
		currentQuestionsList = GetQuestionsWithDifficulty(difficulties[currentDifficulty]);
		currentDifficulty++;	

	}

	/// <summary>
    /// Call whenever there is a need to increase the difficulty level
    /// </summary>
	public void IncreaseDifficultyLevel(){
			if(currentDifficulty < difficulties.Length)
			currentQuestionsList = GetQuestionsWithDifficulty(difficulties[currentDifficulty]);			
			currentDifficulty++;
	}

    /// <summary>
    /// Select one question from the current question list loaded in the class the method is 
    /// called from and remove the question from the list so it doesn't repeat
    /// </summary>
    /// <returns>
    /// a question with an id, text, answers and correct answer index
    /// </returns>
	public Question SelectRandomQuestionFromCurrentList(){

        // if the list isnt empty
			if(currentQuestionsList!= null && currentQuestionsList.Count != 0){

            //memorise the index so we can get the component and return it, and also remove it from the list
			int index = Random.Range(0, currentQuestionsList.Count);	
			Question currentQuestion = new Question();
			currentQuestion = currentQuestionsList[index];
            // remove the question from the list to pervent repeatable questions
			currentQuestionsList.RemoveAt(index);
			return currentQuestion;
			}
			else{
				print("Questions list was null");
				 return null;
			}
	}
	

    /// <summary>
    /// Read from a file to get the questions list passed as a parameter of the coresponding difficulty
    /// </summary>
    /// <param name="difficulty"> name of the file representing the difficulty of the questions in the list</param>
    /// <returns> list of questions with the coresponding diffculty</returns>
	public List<Question> GetQuestionsWithDifficulty(string difficulty){

			// HERE SHOULD CALL READ FILE METHOD FOR THE FILE OF THE NAME OF THE PASSED DIFFICULTY
			// - nema jos uvek metode za citanje fajla bajo

			// dummy data hardcoded, should read from file instead
			List<Question> questionsListOfSpecifiedDifficulty = new List<Question>();
		questionsListOfSpecifiedDifficulty = new List<Question>();
			Question testQuestion = new Question();
		testQuestion.id = 0;
		testQuestion.questionText = difficulty + " 1";
        testQuestion.answers[0] = "Answer1";
        testQuestion.answers[1] = "Answer2";
        testQuestion.answers[2] = "Answer3";
        testQuestion.answers[3] = "Answer4";
        testQuestion.correctAnswerIndex = 1;
        questionsListOfSpecifiedDifficulty.Add(testQuestion);
			Question testQuestion2 = new Question();
		testQuestion2.id = 1;
		testQuestion2.questionText = difficulty + " 2";
        testQuestion2.answers[0] = "Answer1";
        testQuestion2.answers[1] = "Answer2";
        testQuestion2.answers[2] = "Answer3";
        testQuestion2.answers[3] = "Answer4";
        testQuestion2.correctAnswerIndex = 1;
        questionsListOfSpecifiedDifficulty.Add(testQuestion2);
			Question testQuestion3 = new Question();
		testQuestion3.id = 2;
		testQuestion3.questionText = difficulty + " 3";
        testQuestion3.answers[0] = "Answer1";
        testQuestion3.answers[1] = "Answer2";
        testQuestion3.answers[2] = "Answer3";
        testQuestion3.answers[3] = "Answer4";
        testQuestion3.correctAnswerIndex = 1;
        questionsListOfSpecifiedDifficulty.Add(testQuestion3);
			Question testQuestion4 = new Question();
		testQuestion4.id = 3;
		testQuestion4.questionText = difficulty + " 4";
        testQuestion4.answers[0] = "Answer1";
        testQuestion4.answers[1] = "Answer2";
        testQuestion4.answers[2] = "Answer3";
        testQuestion4.answers[3] = "Answer4";
        testQuestion4.correctAnswerIndex = 1;
        questionsListOfSpecifiedDifficulty.Add(testQuestion4);

		return questionsListOfSpecifiedDifficulty;
	}




}
