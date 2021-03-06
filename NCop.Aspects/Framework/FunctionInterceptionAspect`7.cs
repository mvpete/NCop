﻿using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args) {
           args.Proceed();
        }
    }
}
