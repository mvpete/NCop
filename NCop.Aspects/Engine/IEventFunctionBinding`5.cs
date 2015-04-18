﻿
using System;
namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> handlelr);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> handlelr);
        TResult InvokeHndler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> args);
    }
}
