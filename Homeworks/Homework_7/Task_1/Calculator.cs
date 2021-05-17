using System;

namespace Task_1
{
    /// <summary>
    /// Calculator class.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// First number of expression.
        /// </summary>
        public decimal FirstNumber { get; private set; }

        /// <summary>
        /// Second number of expression.
        /// </summary>
        public decimal SecondNumber { get; private set; }

        /// <summary>
        /// Expression operation.
        /// </summary>
        public string Operation { get; private set; }

        /// <summary>
        /// Current value to show.
        /// </summary>
        public string CurrentValue { get; private set; }

        /// <summary>
        /// States of calculator work.
        /// </summary>
        public enum State
        {
            FirstNumber,
            Operation,
            SecondNumber,
            Equality
        }

        /// <summary>
        /// Current state of calculator work.
        /// </summary>
        private State currentState;

        /// <summary>
        /// Coefficient by which a number is multiplied when a new digit is added.
        /// </summary>
        private decimal numberCoefficient;

        /// <summary>
        /// Сoefficient by which the digit is multiplied.
        /// </summary>
        private decimal digitCoefficient;

        /// <summary>
        /// Creates a new calculator.
        /// </summary>
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

        private void TryAddDigit(bool toFirstNumber, int digit)
        {
            decimal newNumber = toFirstNumber ? FirstNumber : SecondNumber;
            try
            {
                newNumber = newNumber * numberCoefficient + digit * digitCoefficient;
                CurrentValue = newNumber.ToString();
                digitCoefficient = digitCoefficient < 1 ? digitCoefficient * 0.1m : 1;

                if (toFirstNumber)
                {
                    FirstNumber = newNumber;
                }
                else
                {
                    SecondNumber = newNumber;
                }
            }
            catch (OverflowException)
            {
                CurrentValue = "Value overflow";
                currentState = State.FirstNumber;
                FirstNumber = 0m;
            }
        }

        private void AddDigit(int digit)
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    TryAddDigit(true, digit);
                    break;
                case State.Operation:
                    currentState = State.SecondNumber;
                    SecondNumber = digit * digitCoefficient;
                    CurrentValue = SecondNumber.ToString();
                    break;
                case State.SecondNumber:
                    TryAddDigit(false, digit);
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
                    CurrentValue = SecondNumber.ToString();
                    numberCoefficient = 1m;
                    digitCoefficient = 0.1m;
                    break;
                case State.Equality:
                    currentState = State.FirstNumber;
                    FirstNumber = 0m;
                    CurrentValue = FirstNumber.ToString();
                    numberCoefficient = 1;
                    digitCoefficient = digitCoefficient == 1 ? 0.1m : digitCoefficient;
                    break;
            }
        }

        private void ChangeCoefficients()
        {
            if (digitCoefficient < 1)
            {
                digitCoefficient *= 10m;
                if (digitCoefficient <= 1)
                {
                    string helpLine = digitCoefficient.ToString();
                    digitCoefficient = Convert.ToDecimal(helpLine.Remove(helpLine.Length - 1));
                }
            }
            numberCoefficient = digitCoefficient == 1 ? 10m : 1m;
        }

        private void RemoveLastDigit()
        {
            switch (currentState)
            {
                case State.FirstNumber:
                    CurrentValue = CurrentValue.Length > 1 ?  CurrentValue.Remove(CurrentValue.Length - 1) : "0";
                    CurrentValue = CurrentValue == "-" ? "0" : CurrentValue;
                    FirstNumber = Convert.ToDecimal(CurrentValue);
                    ChangeCoefficients();
                    break;
                case State.SecondNumber:
                    CurrentValue = CurrentValue.Length > 1 ? CurrentValue.Remove(CurrentValue.Length - 1) : "0";
                    CurrentValue = CurrentValue == "-" ? "0" : CurrentValue;
                    SecondNumber = Convert.ToDecimal(CurrentValue);
                    ChangeCoefficients();
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

        /// <summary>
        /// Adds a new element to the current state of the calculator.
        /// </summary>
        /// <param name="line">New element.</param>
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

            switch (line)
            {
                case "=":
                    AddEquality();
                    break;
                case "±":
                    AddPlusMinus();
                    break;
                case ",":
                case ".":
                    AddDecimal();
                    break;
                case "⌫":
                    RemoveLastDigit();
                    break;
                case "CE":
                    ClearEntry();
                    break;
                case "C":
                    Clear();
                    break;
            }
        }
    }
}