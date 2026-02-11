using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MathCalculator;

public partial class MainPage : ContentPage
{
    private ObservableCollection<string> _expList;

    public MainPage()
    {
        InitializeComponent();
        _expList = new ObservableCollection<string>();

        _lstExpHistory.ItemsSource = _expList;
    }
    //adds a list of the history of expressions
    private void OnCalculate (object sender, EventArgs e)
    {
        //obtain the input from the user: left,right and operation
        string leftOpInput = _txtLeftOp.Text;
        double leftOperand = double.Parse(leftOpInput);

        double rightOperand = double.Parse(_txtRightOp.Text);

        string opInput = (string)_pckOperand.SelectedItem;
        char op = opInput[0];
        //check the chosen operator and calaculate it
        double result = PerformArithmeticOperation(op, leftOperand, rightOperand);

        //display the result
      
        string expression = $"{leftOperand} {op} {rightOperand} = {result}";
        _txtMathExp.Text = expression;
        _expList.Add(expression);
        

    }

    private double PerformArithmeticOperation(char op, double leftOperand, double rightOperand)
    {
        //check the type of operand and perform calculations
        double result;
        switch (op)
        {
            case '+':
                 result = PerformAddition(leftOperand, rightOperand);
                 break;
                
            case '-':
                 result = PerformSubtraction(leftOperand, rightOperand);
                 break;

            case '*':
                result = PerformMultiplication(leftOperand,rightOperand);
                break;
            case '/':
                result = PerformDivision(leftOperand, rightOperand);
                break;
            case '%':
                result = PerformModule(leftOperand, rightOperand);
                break;

            default:
                Debug.Assert(false, "Unknown Operation");
                result = 0;
                break;

        }
        return result;
        
    }

   

    private double PerformAddition(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand + rightOperand;
        return result;
    }
    private double PerformSubtraction(double leftOperand, double rightOperand)
    {
        double result = leftOperand - rightOperand;
        return result;
    }
    private double PerformMultiplication(double leftOperand, double rightOperand)
    {
        return leftOperand * rightOperand;
       
    }
    private double PerformDivision(double leftOperand, double rightOperand)
    {
        //check whether the division is int or real
        string divOp = (string)_pckOperand.SelectedItem;
        if (divOp.Contains("int", StringComparison.OrdinalIgnoreCase)){
            //perform int division
            int leftIntOp = (int)leftOperand;
            int rightIntOp = (int)rightOperand;
            int result = leftIntOp / rightIntOp;
            return result;
        }
        else
        {
            double result = leftOperand / rightOperand;
            return result;
        }

    }
    private double PerformModule(double leftOperand, double rightOperand)
    {
        return leftOperand % rightOperand;
        
    }

   
}