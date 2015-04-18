﻿using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        void AddHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5> handlelr);
        void RemoveHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5> handlelr);
        void InvokeHndler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5> handler, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5> args);
    }
}
