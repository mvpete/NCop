﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5> : ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5>, IActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5>
	{
	}
}
