﻿using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4>, IEventActionArgs<TArg1, TArg2, TArg3, TArg4>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4> actionBinding = null;

        public EventActionInterceptionArgsImpl() { }

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1, TArg2, TArg3, TArg4> handler, IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4> actionBinding, IEventBroker<Action<TArg1, TArg2, TArg3, TArg4>> eventBroker = null, TArg1 arg1 = default(TArg1), TArg2 arg2 = default(TArg2), TArg3 arg3 = default(TArg3), TArg4 arg4 = default(TArg4)) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public Action<TArg1, TArg2, TArg3, TArg4> Handler { get; set; }

        public IEventBroker<Action<TArg1, TArg2, TArg3, TArg4>> EventBroker { get; set; }

        public override void InvokeHanlder() {
            Handler.Invoke(Arg1, Arg2, Arg3, Arg4);
        }

        public override void ProceedAddHandler() {
            actionBinding.AddHandler(ref instance, Handler, this);
        }

        public override void ProceedInvokeHandler() {
            actionBinding.InvokeHandler(ref instance, Handler, this);
        }

        public override void ProceedRemoveHandler() {
            actionBinding.RemoveHandler(ref instance, Handler, this);
        }
    }
}
