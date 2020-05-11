using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtMath, txtOption1, txtOption2, txtOption3;
    [SerializeField] public Button[] btnDifficulty;

    public void DifficultyButtons(int toggle)
    {
        Color green = new Color(0, 1, 0);
        Color red = new Color(1, 0, 0);
        if (btnDifficulty[toggle].GetComponent<Image>().color != green)
        {
            btnDifficulty[toggle].GetComponent<Image>().color = green;
        }
        else
        {
            btnDifficulty[toggle].GetComponent<Image>().color = red;
        }
        if(btnDifficulty[0].GetComponent<Image>().color == red && btnDifficulty[1].GetComponent<Image>().color == red &&
            btnDifficulty[2].GetComponent<Image>().color == red &&btnDifficulty[3].GetComponent<Image>().color == red)
        {
            btnDifficulty[0].GetComponent<Image>().color = green;
        }       
    }

    public int ProblemChooser(int randomForMin)
    {
        int randomChooser = Random.Range(0, 4);
        Color green = new Color(0, 1, 0);
        print(randomChooser.ToString());

        if (randomChooser == 0)
        {
            if (btnDifficulty[0].GetComponent<Image>().color == green)
            {
                return Addition(randomForMin);
            }
            else
            {
                return 0;
            }
        }
        else if (randomChooser == 1)
        {
            if (btnDifficulty[1].GetComponent<Image>().color == green)
            {
                return Subtraction(randomForMin);
            }
            else
            {
                return 0;
            }
        }
        else if (randomChooser == 2)
        {
            if (btnDifficulty[2].GetComponent<Image>().color == green)
            {
                return Multiplication(randomForMin);
            }
            else
            {
                return 0;
            }
        }
        else if (randomChooser == 3)
        {
            if (btnDifficulty[3].GetComponent<Image>().color == green)
            {
                return Division(randomForMin);
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }
    public int Addition(int randomMin)
    {
        int randomNumber1, randomNumber2, answer, optionNumber1, optionNumber2, optionNumber3, storeAnswerTo;
        randomNumber1 = Random.Range(randomMin, 20);
        randomNumber2 = Random.Range(randomMin, 20);
        answer = randomNumber1 + randomNumber2;
        storeAnswerTo = Random.Range(1, 4);
        switch (storeAnswerTo)
        {
            case 1:
                optionNumber1 = answer;
                optionNumber2 = answer + Random.Range(1, 10);
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 2:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer;
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 3:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer - Random.Range(1, 10);
                optionNumber3 = answer;
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
        }           
                
        txtMath.text = randomNumber1.ToString() + " + " + randomNumber2.ToString();
        return storeAnswerTo;
    }
    public int Subtraction(int randomMin)
    {
        int randomNumber1, randomNumber2, answer, optionNumber1, optionNumber2, optionNumber3, storeAnswerTo;
        randomNumber1 = Random.Range(randomMin, 20);
        randomNumber2 = Random.Range(randomMin, 20);
        answer = randomNumber1 - randomNumber2;
        storeAnswerTo = Random.Range(1, 4);
        switch (storeAnswerTo)
        {
            case 1:
                optionNumber1 = answer;
                optionNumber2 = answer + Random.Range(1, 10);
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 2:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer;
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 3:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer - Random.Range(1, 10);
                optionNumber3 = answer;
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
        }

        txtMath.text = randomNumber1.ToString() + " - " + randomNumber2.ToString();
        return storeAnswerTo;
    }
    public int Multiplication(int randomMin)
    {
        int randomNumber1, randomNumber2, answer, optionNumber1, optionNumber2, optionNumber3, storeAnswerTo;
        randomNumber1 = Random.Range(randomMin, 10);
        randomNumber2 = Random.Range(randomMin, 10);
        answer = randomNumber1 * randomNumber2;
        storeAnswerTo = Random.Range(1, 4);
        switch (storeAnswerTo)
        {
            case 1:
                optionNumber1 = answer;
                optionNumber2 = answer + Random.Range(1, 10);
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 2:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer;
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
            case 3:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer - Random.Range(1, 10);
                optionNumber3 = answer;
                txtOption1.text = optionNumber1.ToString();
                txtOption2.text = optionNumber2.ToString();
                txtOption3.text = optionNumber3.ToString();
                break;
        }

        txtMath.text = randomNumber1.ToString() + " * " + randomNumber2.ToString();
        return storeAnswerTo;
    }
    public int Division(int randomMin)
    {
        float randomNumber1, randomNumber2, answer, optionNumber1, optionNumber2, optionNumber3;
        int storeAnswerTo;
        randomNumber1 = Random.Range(randomMin, 10);
        randomNumber2 = Random.Range(randomMin, 10);
        answer = randomNumber1 / randomNumber2;
        storeAnswerTo = Random.Range(1, 4);
        switch (storeAnswerTo)
        {
            case 1:
                optionNumber1 = answer;
                optionNumber2 = answer + Random.Range(1, 10);
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString("F2");
                txtOption2.text = optionNumber2.ToString("F2");
                txtOption3.text = optionNumber3.ToString("F2");
                break;
            case 2:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer;
                optionNumber3 = answer - Random.Range(1, 10);
                txtOption1.text = optionNumber1.ToString("F2");
                txtOption2.text = optionNumber2.ToString("F2");
                txtOption3.text = optionNumber3.ToString("F2");
                break;
            case 3:
                optionNumber1 = answer + Random.Range(1, 10);
                optionNumber2 = answer - Random.Range(1, 10);
                optionNumber3 = answer;
                txtOption1.text = optionNumber1.ToString("F2");
                txtOption2.text = optionNumber2.ToString("F2");
                txtOption3.text = optionNumber3.ToString("F2");
                break;
        }

        txtMath.text = randomNumber1.ToString() + " / " + randomNumber2.ToString();
        return storeAnswerTo;
    }
}
