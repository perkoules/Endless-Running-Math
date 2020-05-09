using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtMath, txtOption1, txtOption2, txtOption3;

    private int randomForMin = 1;
    // Start is called before the first frame update
    void Start()
    {
        Addition(randomForMin);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Division(randomForMin);
        }
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
    public float Division(int randomMin)
    {
        float randomNumber1, randomNumber2, answer, optionNumber1, optionNumber2, optionNumber3, storeAnswerTo;
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

        txtMath.text = randomNumber1.ToString() + " / " + randomNumber2.ToString();
        return storeAnswerTo;
    }
}
