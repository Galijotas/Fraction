using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Calculator : MonoBehaviour
{
    public TMP_InputField Numenator;
    public TMP_InputField Denominator;
    public TextMeshProUGUI OperatorSign;
    public string currentOperator;
    public string storedOperator;
    Fraction currentFraction, storedFraction1, resultFraction, storedFraction2;



    void Start()
    {
        ClickClear();
    }

    static bool typeCheckInt(string input1, string input2)
    {
        int number = 0;
        if ((int.TryParse(input1, out number) != true) &&
            (int.TryParse(input2, out number) != true))
        {
            throw new Exception("Please numerical values!");
        }
        return true;
    }

    public void FractionCalculation(string operatorSign)
    {
        bool fractionErr = true;

        switch (operatorSign)
        {
            case "÷":
                {
                    try
                    {
                        if (storedFraction2 != null)
                        {
                            resultFraction = storedFraction2.dividedBy(currentFraction).reduced();
                        }
                        else
                        {
                            resultFraction = storedFraction1.dividedBy(currentFraction).reduced();
                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Log(err.Message);
                        fractionErr = false;
                    }
                    break;
                }
            case "*":
                {
                    try
                    {
                        if (storedFraction2 != null)
                        {
                            resultFraction = storedFraction2.times(currentFraction).reduced();
                        }
                        else
                        {
                            resultFraction = storedFraction1.times(currentFraction).reduced();

                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Log(err.Message);
                        fractionErr = false;
                    }
                    break;
                }
            case "-":
                {
                    try
                    { 
                        if (storedFraction2 != null)
                        {
                            resultFraction = storedFraction2.minus(currentFraction).reduced();
                        }
                        else
                        {
                            resultFraction = storedFraction1.minus(currentFraction).reduced();
                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Log(err.Message);
                        fractionErr = false;
                    }
                    break;
                }
            case "+":
                {
                    try
                    {
                        if (storedFraction2 != null)
                        {
                            resultFraction = storedFraction2.plus(currentFraction).reduced();
                        }
                        else
                        {
                            resultFraction = storedFraction1.plus(currentFraction).reduced();
                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Log(err.Message);
                        fractionErr = false;
                    }
                    break;
                }
            default:
                Debug.Log("unknown: " + operatorSign);
                break;
        }
        if (fractionErr)
        {
            storedFraction2 = resultFraction;
            if (storedFraction2 != null)
            {
                string result = resultFraction.ToString();
                if (result != "0")
                {
                    string[] words = result.Split('/');
                    Numenator.text = $"{words[0]}";
                    Denominator.text = $"{words[1]}";

                }
                else
                {
                    Numenator.text = "0";
                    Denominator.text = "0";
                }

                if (currentOperator == "=")
                {
                    storedFraction1 = null;
                    storedFraction2 = null;
                    currentFraction = null;
                    storedOperator = "";
                    currentOperator = "";
                }
            }
        }
        else
        {
            Numenator.text = "Err";
            Denominator.text = "Err";
        }

    }

    public void ClickOperators(string inputOperators)
    {
        try
        {
            typeCheckInt(Numenator.text,  Denominator.text);

            int firstNumenatorValue = int.Parse(Numenator.text);
            int firstDenominatorValue = int.Parse(Denominator.text);

            currentFraction = new Fraction(firstNumenatorValue, firstDenominatorValue);
            OperatorSign.text = inputOperators;
            currentOperator = inputOperators;

            if (storedOperator != "")
            {
                FractionCalculation(storedOperator);
                storedOperator = "";
            }
           
            if (inputOperators != "=")
            {
                if (storedFraction1 == null)
                {
                    storedFraction1 = currentFraction;
                }
                storedOperator = inputOperators;
            }
        }
        catch(Exception err)
        {
            Debug.LogError(err.Message);
        }
    }
    public void ClickClear()
    {
        Numenator.text = "";
        Denominator.text = "";
        OperatorSign.text = "";
        storedFraction1 = null;
        storedFraction2 = null;
        currentFraction = null;
        storedOperator = "";
        currentOperator = "";
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void WindowedMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
