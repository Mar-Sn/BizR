using BizR;
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
        serviceCollection.AddTransient<TestIsNullHandler>();//TODO must be a nicer way

        var services = serviceCollection.BuildServiceProvider();
        
        var factory = services.GetRequiredService<IBusinessFactory>(); //TODO replace with real factory
        _rules = factory
            .Create<TestInput, TestOutput>()
            .RuleFor<TestNotNull>(i => i
                .When(e => e.Test != null)
                .Map(e => new TestNotNull(e.Test!))
                .WithHandler<TestNotNullHandler>()) //TODO This might not be needed??
            .RuleFor<TestIsNull>(i => i
                .When(e => e.Test == null)
                .Map(_ => new TestIsNull())
                .WithHandler<TestIsNullHandler>());
    }

    [Test]
    public async Task TestMethod()
    {
        var result = await _rules.Execute(new TestInput("sometest"));
        result.Success.Should().BeTrue();
    }

    private class TestNotNullHandler : Handler<TestNotNull, TestOutput>
    {
        public override Task<TestOutput> Handle(TestNotNull input)
        {
            return Task.FromResult(new TestOutput(true));
        }
    }

    private class TestIsNullHandler : Handler<TestIsNull, TestOutput>
    {
        public override Task<TestOutput> Handle(TestIsNull input)
        {
            return Task.FromResult(new TestOutput(true));
        }
    }

    private record TestNotNull(string Test);

    private record TestIsNull;

    private record TestInput(string? Test);

    private record TestOutput(bool Success);
}