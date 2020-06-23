﻿using EasyAbp.AbpHelper.Steps.Common;
using Elsa.Scripting.JavaScript;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Workflow.Generate.Crud
{
    public static class TestGenerationWorkflow
    {
        public static IActivityBuilder AddTestGenerationWorkflow(this IOutcomeBuilder builder)
        {
            return builder
                    /* Generate test files */
                    .Then<GroupGenerationStep>(
                        step =>
                        {
                            step.GroupName = "Test";
                            step.TargetDirectory = new JavaScriptExpression<string>("AspNetCoreDir");
                        }
                    )
                ;
        }
    }
}