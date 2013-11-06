﻿using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Builders;
using NCop.Weaving;
using NCop.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaverHandler : AbstractMethodWeaverHandler
    {
        public AspectMethodWeaverHandler(Type type)
            : base(type) {
        }

        public override IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            IAspectBuilder aspectBuilder = null;

            return new AspectStrategyWeaver(aspectBuilder);
        }
    }
}
