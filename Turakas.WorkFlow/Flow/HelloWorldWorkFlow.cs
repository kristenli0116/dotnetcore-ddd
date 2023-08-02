using Turakas.WorkFlow.Data;
using Turakas.WorkFlow.Step;
using WorkflowCore.Interface;

namespace Turakas.WorkFlow.Flow
{
    internal class HelloWorldWorkFlow : IWorkflow<EmployeeData>
    {
        public string Id => "HelloWorld";

        public int Version => 1;

        public void Build(IWorkflowBuilder<EmployeeData> builder)
        {
            builder.StartWith(context => Console.WriteLine("Hello World!"))
                .Then<SayHelloStep>()
                    .Input(step => step.Name, data => "lkx")
                    .Input(step => step.Description, data => "Ha Ha Ha")
                .Then(context => Console.WriteLine("The Workflow complete"));
        }
    }
}