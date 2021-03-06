﻿using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TArg2, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
        TResult InvokeHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
    }
}
