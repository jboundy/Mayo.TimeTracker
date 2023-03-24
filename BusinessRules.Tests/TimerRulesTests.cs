using RulesEngine.Models;

namespace BusinessRules.Tests
{
    [TestClass]
    public class TimerRulesTests
    {
        [TestMethod]
        public void RuleExpressionCountLessThan3_Input4_AssertsFalse()
        {
            List<Rule> rules = new List<Rule>();

            Rule rule = RuleExpressionCountLessThan3();

            var workflows = new List<Workflow>();

            Workflow exampleWorkflow = new Workflow();
            exampleWorkflow.WorkflowName = "Example Workflow";
            exampleWorkflow.Rules = rules;

            workflows.Add(exampleWorkflow);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            List<RuleResultTree> responses = bre.ExecuteAllRulesAsync(exampleWorkflow.WorkflowName, 4).Result;

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsFalse(success.All(x => x == true));
        }

        private Rule RuleExpressionCountLessThan3()
        {
            Rule rule = new Rule();
            rule.RuleName = "Test Rule";
            rule.SuccessEvent = "Count is within tolerance.";
            rule.ErrorMessage = "Over expected.";
            rule.Expression = "count < 3";
            rule.RuleExpressionType = RuleExpressionType.LambdaExpression;
            return rule;
        }
    }
}