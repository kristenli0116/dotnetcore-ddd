using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turakas.WorkFlow.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Turakas.WorkFlow.Step
{
    public class SayHelloStep : IStepBody
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            Type type = context.Workflow.Data.GetType();

            Console.WriteLine("The Name is {Name},The Description is {Description}");
            return Task.FromResult(ExecutionResult.Next());
        }
    }
}