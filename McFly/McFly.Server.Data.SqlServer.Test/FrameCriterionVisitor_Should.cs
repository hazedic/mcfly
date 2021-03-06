﻿using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Server.Data.Search;
using McFly.Server.Data.SqlServer.Test.Builders;
using Xunit;
using FramePredicateExpression =
    System.Linq.Expressions.Expression<System.Func<McFly.Server.Data.SqlServer.FrameEntity, bool>>;
namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameCriterionVisitor_Should
    {
        [Fact]
        public void Create_The_Correct_Expression_Tree_For_And()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria1 = new RegisterEqualsCriterion(Register.Rax, ((ulong)0).ToHexString());
            var criteria2 = new RegisterEqualsCriterion(Register.Rbx, ((ulong)1).ToHexString());
            var and = new AndCriterion(new[] {criteria1, criteria2});
            var f = visitor.Visit(and);
            
            var frame = new FrameEntity
            {
                Rax = ((ulong) 0).ToHexString(),
                Rbx = ((ulong) 1).ToHexString()
            };
            var frame2 = new FrameEntity
            {
                Rax = ((ulong) 1).ToHexString(),
                Rbx = ((ulong) 1).ToHexString()
            };
            
            var method = ((FramePredicateExpression)f).Compile();
            new[] {frame, frame2}.Single(x => method(x)).Should().Be(frame);
        }

        [Fact]
        public void Create_The_Correct_Expression_Tree_For_Or()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria1 = new RegisterEqualsCriterion(Register.Rax, ((ulong)0).ToHexString());
            var criteria2 = new RegisterEqualsCriterion(Register.Rbx, ((ulong)1).ToHexString());
            var and = new OrCriterion(new[] { criteria1, criteria2 });
            var f = visitor.Visit(and);
            var builder = new ContextFactoryBuilder();
            var frame = new FrameEntity
            {
                Rax = ((ulong)0).ToHexString(),
                Rbx = ((ulong)1).ToHexString()
            };
            var frame2 = new FrameEntity
            {
                Rax = ((ulong)1).ToHexString(),
                Rbx = ((ulong)1).ToHexString()
            };
            builder.WithFrame(frame).WithFrame(frame2);
            var method = ((FramePredicateExpression)f).Compile();
            new[] {frame, frame2}.Where(x => method(x)).SequenceEqual(new[] {frame, frame2}).Should().BeTrue();
        }
    }
}