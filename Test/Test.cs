using BizR;
using BizR.Factory;
using BizR.Handler;
using BizR.Rules;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test;

[TestFixture]
public class Test
{
    private IBusinessRules<TestInput, TestOutput> _rules = null!;

    [SetUp]
    public void Init()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddBizR();
        serviceCollection.AddTransient<TestNotNullHandler>(); //TODO must be a nicer way
        serviceCollection.AddTransient<TestIsNullHandler>(); //TODO must be a nicer way

        var services = serviceCollection.BuildServiceProvider();

        var factory = services.GetRequiredService<IBusinessFactory>(); //TODO replace with real factory
        _rules = factory
            .Create<TestInput, TestOutput>()
            .RuleFor<TestNotNull>(i => i
                .When(e => e.Test != null)
                .Map(_ => new TestNotNull())
                .WithHandler<TestNotNullHandler>()) //TODO This might not be needed??
            .RuleFor<TestIsNull>(i => i
                .When(e => e.Test == null)
                .Map(_ => new TestIsNull())
                .WithHandler<TestIsNullHandler>());
    }

    [Test]
    public async Task TestWithInput()
    {
        var result = await _rules.Execute(new TestInput("sometest"));
        result.Success.Should().Be(1);
    }

    [Test]
    public async Task TestWithNull()
    {
        var result = await _rules.Execute(new TestInput(null));
        result.Success.Should().Be(2);
    }

    private class TestNotNullHandler : Handler<TestNotNull, TestOutput>
    {
        public override Task<TestOutput> Handle(TestNotNull input)
        {
            return Task.FromResult(new TestOutput(1));
        }
    }

    private class TestIsNullHandler : Handler<TestIsNull, TestOutput>
    {
        public override Task<TestOutput> Handle(TestIsNull input)
        {
            return Task.FromResult(new TestOutput(2));
        }
    }

    private record TestNotNull;

    private record TestIsNull;

    private record TestInput(string? Test);

    private record TestOutput(int Success);
}