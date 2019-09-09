﻿using System.Collections.Generic;
using System.Linq;
using Kekiri.NUnit;
using NUnit.Framework;

namespace Kekiri.Examples.NUnit
{
    public class Typed_context : Scenarios<CalculatorContext>
    {
        [Scenario]
        public void Can_use_typed_context()
        {
            Given(Two_integers);
            When(Adding);
            Then(It_should_have_correct_result);
        }

        void Two_integers()
        {
            Context.PushOperand(1);
            Context.PushOperand(2);
        }

        void Adding()
        {
            Context.ComputeSum();
        }

        void It_should_have_correct_result()
        {
            Assert.That(Context.Result, Is.EqualTo(3));
        }
    }

    public class CalculatorContext
    {
        readonly List<int> _operands = new List<int>();

        public void PushOperand(int operand)
        {
            _operands.Add(operand);
        }

        public void ComputeSum()
        {
            Result = _operands.Sum();
        }

        public int Result { get; set; }
    }
}