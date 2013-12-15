﻿using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TInstance> : InterceptionArgs, IActionArgs 
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, IActionBinding<TInstance> actionBinding) {
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            actionBinding.Invoke(ref instance);
        }
    }
}
