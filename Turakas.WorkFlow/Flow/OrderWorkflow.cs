using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turakas.WorkFlow.Data;
using Turakas.WorkFlow.Step;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Turakas.WorkFlow.Flow
{
    public class OrderWorkflow : IWorkflow<Order>
    {
        public string Id => "OrderWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<Order> builder)
        {
            builder
                .StartWith(content => ExecutionResult.Next())
                .Then<CreateOrderStep>()
                .Then<ReviewOrderStep>()
                .Then<ProcessOrderStep>()
                .Then<ShipOrderStep>()
                .EndWorkflow();
        }
    }
}