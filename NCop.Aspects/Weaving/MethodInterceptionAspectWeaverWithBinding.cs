﻿using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionAspectWeaverWithBinding : AbstractMethodInterceptionAspectWeaverWithBinding
    {
        internal MethodInterceptionAspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(expression, aspectDefinition, aspectWeavingSettings) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new MethodInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, WeavedType);
        }
    }
}