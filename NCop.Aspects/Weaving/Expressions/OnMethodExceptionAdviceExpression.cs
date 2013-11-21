﻿using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodExceptionAdviceExpression : AbstractAdviceExpression
    {
        public OnMethodExceptionAdviceExpression(MethodInfo adviceMethod)
            : base(adviceMethod) {
        }

        public override IMethodScopeWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}