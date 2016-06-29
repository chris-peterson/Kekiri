﻿using System;
using FluentAssertions;
using Kekiri.Impl.Exceptions;
using Kekiri.TestSupport.Scenarios.Exceptions;

namespace Kekiri.UnitTests.Exceptions
{
    [ScenarioBase(Feature.FixtureExceptionHandling)]
    class When_fixture_step_when_throws_exception : Test
    {
        [When, Throws]
        public void When()
        {
            new When_fixture_step_when_throws_exception_scenario().SetupScenario();
        }

        [Then]
        public void It_should_throw_proper_exception()
        {
            var ex = Catch<WhenFailed>();
            ex.InnerException.Should().BeOfType<ApplicationException>();
            ex.InnerException.Message.Should().Be("bad when");
        }
    }
}