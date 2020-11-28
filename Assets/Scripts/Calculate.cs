using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Calculate : MonoBehaviour
{
    public Text _resultText;
    public InputField _x;
    public InputField _y;
    public Transform _content;
    [SerializeField]private GameObject LastInstance;
    [SerializeField]private int X;
    [SerializeField]private int Y;
    [SerializeField]private int _resultValue;
    [SerializeField]private List<int> _numbers;
    [SerializeField]private int _numberCount;
    [SerializeField]private string InstanceText;
    [SerializeField]private bool EmptyLine = false;

    public GameObject Nums;

    public void CalculateMethod()
    {
        if(_y.text != "")
        {
            X = int.Parse(_x.text);
        }
        if(_y.text != "")
        {
            Y = int.Parse(_y.text);
        }

        if(X != Y && _x.text != "" && _y.text != "" && X < Y && X >= 0 && Y >= 0)
        {
            _numbers = Enumerable.Range(X,Y).Cast<int>().ToList();
            _numberCount = _numbers.Count;
            _resultValue = ((X + Y)*_numberCount)/2;
            InstanceText = (X.ToString() + "+" + _numbers[1] + "+" + _numbers[2] + "+" + _numbers[3] + "..." + (_numberCount - 3) + "+" + (_numberCount - 2) + "+" + (_numberCount - 1) + "+" + Y.ToString() + "=" + _resultValue.ToString());
            _resultText.text = ("Result : " + (_resultValue.ToString()));
            if(InstanceText.Length > 36)
            {
                EmptyLine = true;
            }
            if(_numbers.Count > 7)
            {
                InstantiateObject();
            }
            else if(_numbers.Count < 8)
            {
                InstanceText = ("The size of the numbers is too small!");
                InstantiateObject();
            }
        }
        else if(X == Y)
        {
            _resultText.text = ("Result : Error");
            InstanceText = ("Numbers can't be the same!");
            InstantiateObject();
        }
        else if(X > Y)
        {
            _resultText.text = ("Result : Error");
            InstanceText = ("First number can't be bigger than the second one!");
            InstantiateObject();
        }
        else if(_x.text == "" || _y.text == "")
        {
            _resultText.text = ("Result : Error");
            InstanceText = ("Fields mustn't be empty!");
            InstantiateObject();
        }
        else if(X < 0 || Y < 0)
        {
            InstanceText = ("Negative numbers are not allowed!");
            InstantiateObject();
        }
    }
    void InstantiateObject()
    {
        LastInstance = Instantiate(Nums, Vector3.zero, Quaternion.identity, _content);
        LastInstance.GetComponent<Text>().text = InstanceText;

        if(EmptyLine)
        {
            LastInstance = Instantiate(Nums, Vector3.zero, Quaternion.identity, _content);
            LastInstance.GetComponent<Text>().text = " ";
            EmptyLine = false;
        }
    }
}