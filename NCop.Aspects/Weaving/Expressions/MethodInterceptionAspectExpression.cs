﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInterceptionAspectExpression : AbstractAspectExpression
    {
        internal MethodInterceptionAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition = null)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            var reducer = new AspectWeaverWithBinding(expression, aspectDefinition, settings);

            return reducer.Reduce(settings);
        }
    }
}
