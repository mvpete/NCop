﻿using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl() { }

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> funcBinding, IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> eventBroker = null, TArg1 arg1 = default(TArg1), TArg2 arg2 = default(TArg2), TArg3 arg3 = default(TArg3), TArg4 arg4 = default(TArg4), TArg5 arg5 = default(TArg5), TArg6 arg6 = default(TArg6), TArg7 arg7 = default(TArg7), TArg8 arg8 = default(TArg8)) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
            Arg7 = arg7;
            Arg8 = arg8;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Handler { get; set; }

        public IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> EventBroker { get; set; }

        public override void InvokeHanlder() {
            ReturnValue = Handler.Invoke(Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        }

        public override void ProceedAddHandler() {
            funcBinding.AddHandler(ref instance, Handler, this);
        }

        public override void ProceedInvokeHandler() {
            ReturnValue = funcBinding.InvokeHandler(ref instance, Handler, this);
        }

        public override void ProceedRemoveHandler() {
            funcBinding.RemoveHandler(ref instance, Handler, this);
        }
    }
}