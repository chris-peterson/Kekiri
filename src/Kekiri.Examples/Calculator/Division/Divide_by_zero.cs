﻿using System;
using Kekiri.TestRunner.NUnit;

namespace Kekiri.Examples.Calculator.Division
{
    class Divide_by_zero : Scenario
    {
        readonly Calculator _calculator = new Calculator();

        public Divide_by_zero()
        {
            Given(a_denominator_of_0);
            When(dividing).Throws();
            Then(an_exception_is_raised);
        }

        void a_denominator_of_0()
        {
            _calculator.Operand2 = 0;
        }

        void dividing()
        {
            _calculator.Divide();
        }

        void an_exception_is_raised()
        {
            Catch<DivideByZeroException>();
        }
    }

    class Calculator
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }

        public decimal Result { get; set; }

        public void Divide()
        {
            Result = Operand1/Operand2;
        }
    }
}