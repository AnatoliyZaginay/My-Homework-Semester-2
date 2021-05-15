using System;
using System.Globalization;

namespace Task_1
{
    public class Calculator
    {
        public decimal FirstNumber { get; private set; }

        public decimal SecondNumber { get; private set; }

        public string Operation { get; private set; }

        public string CurrentValue { get; private set; }

        public enum State
        {
            FirstNumber,
            Operation,
            SecondNumber,
            Equality
        }

        private State currentState;

        private decimal numberCoefficient;

        private decimal digitCoefficient;

        public Calculator()
        {
            FirstNumber = 0m;
            SecondNumber = 0m;
            CurrentValue = "0";
            currentState = State.FirstNumber;
            numberCoefficient = 10m;
            digitCoefficient = 1m;
        }

        private bool IsOperation(string line)
            => line == "+" || line == "-" || line == "*" || line == "/";

        private void AddDigit(int digit)
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    try
                    {
                        FirstNumber = FirstNumber * numberCoefficient + digit * digitCoefficient;
                        CurrentValue = FirstNumber.ToString();
                        digitCoefficient = digitCoefficient < 1 ? digitCoefficient * 0.1m : 1;
                    }
                    catch (OverflowException)
                    {
                        CurrentValue = "Value overflow";
                        currentState = State.FirstNumber;
                        FirstNumber = 0m;
                    }
                    break;
                case State.Operation:
                    currentState = State.SecondNumber;
                    SecondNumber = digit * digitCoefficient;
                    CurrentValue = SecondNumber.ToString();
                    break;
                case State.SecondNumber:
                    try
                    {
                        SecondNumber = SecondNumber * numberCoefficient + digit * digitCoefficient;
                        CurrentValue = SecondNumber.ToString();
                        digitCoefficient = digitCoefficient < 1 ? digitCoefficient * 0.1m : 1;
                    }
                    catch (OverflowException)
                    {
                        CurrentValue = "Value overflow";
                        currentState = State.FirstNumber;
                        FirstNumber = 0m;
                    }
                    break;
                case State.Equality:
                    currentState = State.FirstNumber;
                    FirstNumber = digit * digitCoefficient;
                    CurrentValue = FirstNumber.ToString();
                    break;
            }
        }

        private void Calculate()
        {
            switch (Operation)
            {
                case "+":
                    FirstNumber = Decimal.Add(FirstNumber, SecondNumber);
                    break;
                case "-":
                    FirstNumber = Decimal.Subtract(FirstNumber, SecondNumber);
                    break;
                case "*":
                    FirstNumber = Decimal.Multiply(FirstNumber, SecondNumber);
                    break;
                case "/":
                    FirstNumber = Decimal.Divide(FirstNumber, SecondNumber);
                    break;
            }
        }

        private void TryCalculate(State nextState)
        {
            try
            {
                Calculate();
                CurrentValue = FirstNumber.ToString("G29");
                currentState = nextState;
            }
            catch (DivideByZeroException)
            {
                CurrentValue = "Division by zero";
                currentState = State.FirstNumber;
                FirstNumber = 0m;
            }
            catch (OverflowException)
            {
                CurrentValue = "Value overflow";
                currentState = State.FirstNumber;
                FirstNumber = 0m;
            }
        }

        private void AddOperation(string line)
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    SecondNumber = FirstNumber;
                    CurrentValue = $"{SecondNumber}";
                    currentState = State.Operation;
                    break;
                case State.Operation:
                    SecondNumber = FirstNumber;
                    CurrentValue = FirstNumber.ToString();
                    break;
                case State.SecondNumber:
                    TryCalculate(State.Operation);
                    SecondNumber = FirstNumber;
                    break;
                case State.Equality:
                    SecondNumber = FirstNumber;
                    currentState = State.Operation;
                    break;
            }
            Operation = line;
            numberCoefficient = 10m;
            digitCoefficient = 1m;
        }

        private void AddEquality()
        {
            TryCalculate(State.Equality);
            numberCoefficient = 10m;
            digitCoefficient = 1m;
        }

        private void AddPlusMinus()
        {
            switch (currentState)
            {
                case State.FirstNumber:
                case State.Equality:
                    FirstNumber *= -1m;
                    CurrentValue = FirstNumber.ToString("G29");
                    break;
                case State.Operation:
                case State.SecondNumber:
                    currentState = State.SecondNumber;
                    SecondNumber *= -1m;
                    CurrentValue = SecondNumber.ToString("G29");
                    break;
            }
        }

        private void AddDecimal()
        {
            switch (currentState)
            {
                case State.FirstNumber:
                case State.SecondNumber:
                    numberCoefficient = 1m;
                    digitCoefficient = digitCoefficient == 1m ? 0.1m : digitCoefficient;
                    break;
                case State.Operation:
                    currentState = State.SecondNumber;
                    SecondNumber = 0m;
                    CurrentValue = $"{SecondNumber}";
                    numberCoefficient = 1m;
                    digitCoefficient = 0.1m;
                    break;
                case State.Equality:
                    currentState = State.FirstNumber;
                    FirstNumber = 0m;
                    CurrentValue = $"{FirstNumber}";
                    numberCoefficient = 1;
                    digitCoefficient = digitCoefficient == 1 ? 0.1m : digitCoefficient;
                    break;
            }
        }

        private void RemoveLastDigit()
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    CurrentValue = CurrentValue.Length > 1 ?  CurrentValue.Remove(CurrentValue.Length - 1) : "0";
                    FirstNumber = Convert.ToDecimal(CurrentValue);
                    if (digitCoefficient < 1)
                    {
                        digitCoefficient *= 10m;
                        if (digitCoefficient <= 1)
                        {
                            string helpLine = digitCoefficient.ToString();
                            digitCoefficient = Convert.ToDecimal(helpLine.Remove(helpLine.Length - 1));
                        }
                    }
                    numberCoefficient = digitCoefficient == 1 ? 10m : numberCoefficient;
                    break;
                case State.SecondNumber:
                    CurrentValue = CurrentValue.Length > 1 ? CurrentValue.Remove(CurrentValue.Length - 1) : "0";
                    SecondNumber = Convert.ToDecimal(CurrentValue);
                    if (digitCoefficient < 1)
                    {
                        digitCoefficient *= 10m;
                        if (digitCoefficient <= 1)
                        {
                            string helpLine = digitCoefficient.ToString();
                            digitCoefficient = Convert.ToDecimal(helpLine.Remove(helpLine.Length - 1));
                        }
                    }
                    numberCoefficient = digitCoefficient == 1 ? 10m : numberCoefficient;
                    break;
            }

        }

        private void ClearEntry()
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    FirstNumber = 0m;
                    CurrentValue = FirstNumber.ToString();
                    break;
                case State.Operation:
                    currentState = State.SecondNumber;
                    SecondNumber = 0m;
                    CurrentValue = SecondNumber.ToString();
                    break;
                case State.SecondNumber:
                    SecondNumber = 0m;
                    CurrentValue = SecondNumber.ToString();
                    break;
                case State.Equality:
                    FirstNumber = 0m;
                    CurrentValue = FirstNumber.ToString();
                    break;
            }
        }

        private void Clear()
        {
            FirstNumber = 0m;
            SecondNumber = 0m;
            Operation = null;
            numberCoefficient = 10m;
            digitCoefficient = 1m;
            CurrentValue = "0";
            currentState = State.FirstNumber;
        }

        public void AddElement(string line)
        {
            if (int.TryParse(line, out int digit))
            {
                AddDigit(digit);
                return;
            }

            if (IsOperation(line))
            {
                AddOperation(line);
                return;
            }

            if (line == "=")
            {
                AddEquality();
            }

            if (line == "±")
            {
                AddPlusMinus();
            }

            if (line == ",")
            {
                AddDecimal();
            }

            if (line == "C")
            {
                Clear();
            }

            if (line == "⌫")
            {
                RemoveLastDigit();
            }

            if (line == "CE")
            {
                ClearEntry();
            }
        }
    }
}
