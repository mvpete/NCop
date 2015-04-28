﻿using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult>, IEventFunctionArgs<TArg1, TArg2, TArg3, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TArg2, TArg3, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, IEventBroker<Func<TArg1, TArg2, TArg3, TResult>> eventBroker = null) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }
        public Func<TArg1, TArg2, TArg3, TResult> Handler { get; set; }

        public IEventBroker<Func<TArg1, TArg2, TArg3, TResult>> EventBroker { get; set; }

        public override void ProceedAddHandler() {
            funcBinding.AddHandler(ref instance, Handler, this);
        }

        public override void ProceedInvokeHandler() {
            funcBinding.InvokeHandler(ref instance, Handler, this);
        }

        public override void ProceedRemoveHandler() {
            funcBinding.RemoveHandler(ref instance, Handler, this);
        }
    }
}