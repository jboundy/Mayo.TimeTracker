using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class BaseRules
    {
        public async Task<List<RuleResultTree>> ExecuteAllRules(List<Workflow> workflows, object input)
        {
            var responses = new List<RuleResultTree>();
            var bre = new RulesEngine.RulesEngine(workflows.ToArray());
            foreach (var workflow in workflows)
            {
                responses.AddRange(await bre.ExecuteAllRulesAsync(workflow.WorkflowName, input));
            }
   
            return responses;
        }


        public List<Workflow> AddRuleToExampleWorkflow(List<Workflow> workflows, List<Rule> rules)
        {
            Workflow exampleWorkflow = new Workflow();
            exampleWorkflow.WorkflowName = "Example Workflow";
            exampleWorkflow.Rules = rules;

            workflows.Add(exampleWorkflow);
            return workflows;
        }

        public Rule RuleExpressionCountGreaterThan3()
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
    }
}
