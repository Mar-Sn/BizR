using BizR;
using FluentAssertions;
using Moq;

namespace Test;

[TestFixture]
public class Test
{
    private IBusinessRules<TestInput, TestOutput> _rules = null!;

    [SetUp]
    public void Init()
    {
        var factory = Mock.Of<IBusinessFactory>(); //TODO replace with real factory
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

    private class TestNotNullHandler : IHandler<TestNotNull, TestOutput>
    {
        public Task<TestOutput> Handle(TestNotNull input)
        {
            return Task.FromResult(new TestOutput(true));
        }
    }

    private class TestIsNullHandler : IHandler<TestIsNull, TestOutput>
    {
        public Task<TestOutput> Handle(TestIsNull input)
        {
            return Task.FromResult(new TestOutput(true));
        }
    }

    private record TestNotNull(string Test);

    private record TestIsNull;

    private record TestInput(string? Test);

    private record TestOutput(bool Success);
}