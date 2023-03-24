using RulesEngine.Models;

namespace BusinessRules.Tests
{
    [TestClass]
    public class TimerRulesTests
    {
        [TestMethod]
        public void RuleExpressionCountLessThan3_Input4_AssertsFalse()
        {
            List<Rule> rules = new List<Rule>
            {
                RuleExpressionCountLessThan3()
            };

            var workflows = new List<Workflow>();

            workflows = AddRuleToExampleWorkflow(workflows, rules);

            var input = new
            {
                count = 4
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsFalse(success.All(x => x == true));
        }


        [TestMethod]
        public void RuleExpressionCountLessThan3_Input2_AssertsTrue()
        {
            List<Rule> rules = new List<Rule>
            {
                RuleExpressionCountLessThan3()
            };

            var workflows = new List<Workflow>();

            workflows = AddRuleToExampleWorkflow(workflows, rules);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            var input = new
            {
                count = 2
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsTrue(success.All(x => x == true));
        }

        [TestMethod]
        public void RuleExpressionCountLessThan3_Input3_AssertsFalse()
        {
            List<Rule> rules = new List<Rule>()
            {
                RuleExpressionCountLessThan3()
            };

            var workflows = new List<Workflow>();

            workflows = AddRuleToExampleWorkflow(workflows, rules);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            var input = new
            {
                count = 3
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsFalse(success.All(x => x == true));
        }

        [TestMethod]
        public void RuleExpressionCountGreaterThan3_Input2_AssertsFalse()
        {
            List<Rule> rules = new List<Rule>()
            {
                RuleExpressionCountGreaterThan3()
            };

            var workflows = new List<Workflow>();

            workflows = workflows = AddRuleToExampleWorkflow(workflows, rules);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            var input = new
            {
                count = 2
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsFalse(success.All(x => x == true));
        }

        [TestMethod]
        public void RuleExpressionCountGreaterThan3_Input3_AssertsFalse()
        {
            List<Rule> rules = new List<Rule>()
            {
                RuleExpressionCountGreaterThan3()
            };

            var workflows = new List<Workflow>();

            workflows = workflows = AddRuleToExampleWorkflow(workflows, rules);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            var input = new
            {
                count = 3
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsFalse(success.All(x => x == true));
        }

        [TestMethod]
        public void RuleExpressionCountGreaterThan3_Input4_AssertsTrue()
        {
            List<Rule> rules = new List<Rule>()
            {
                RuleExpressionCountGreaterThan3()
            };

            var workflows = new List<Workflow>();

            workflows = AddRuleToExampleWorkflow(workflows, rules);

            var bre = new RulesEngine.RulesEngine(workflows.ToArray());

            var input = new
            {
                count = 4
            };
            List<RuleResultTree> responses = ExecuteAllRules(workflows, input);

            List<bool> success = new List<bool>();

            success.AddRange(responses.Select(x => x.IsSuccess));

            Assert.IsTrue(success.All(x => x == true));
        }


        private Rule RuleExpressionCountLessThan3()
        {
            Rule rule = new Rule
            {
                RuleName = "Test Rule",
                SuccessEvent = "Count is within tolerance.",
                ErrorMessage = "Over expected.",
                Expression = "count < 3",
                RuleExpressionType = RuleExpressionType.LambdaExpression
            };
            return rule;
        }

        private Rule RuleExpressionCountGreaterThan3()
        {
            Rule rule = new Rule
            {
                RuleName = "Test Rule",
                SuccessEvent = "Count is within tolerance.",
                ErrorMessage = "Over expected.",
                Expression = "count > 3",
                RuleExpressionType = RuleExpressionType.LambdaExpression
            };
            return rule;
        }

        private List<Workflow> AddRuleToExampleWorkflow(List<Workflow> workflows, List<Rule> rules)
        {
            Workflow exampleWorkflow = new Workflow();
            exampleWorkflow.WorkflowName = "Example Workflow";
            exampleWorkflow.Rules = rules;

            workflows.Add(exampleWorkflow);
            return workflows;
        }


        private static List<RuleResultTree> ExecuteAllRules(List<Workflow> workflows, object input)
        {
            var bre = new RulesEngine.RulesEngine(workflows.ToArray());
            List<RuleResultTree> responses = bre.ExecuteAllRulesAsync("Example Workflow", input).Result;
            return responses;
        }
    }
}