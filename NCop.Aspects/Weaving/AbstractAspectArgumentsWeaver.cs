﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectArgumentsWeaver : AbstractArgumentsWeaver, IAspectArgumentsWeaver
    {
        public AbstractAspectArgumentsWeaver(Type argumentType, Type[] parameters, IWeavingSettings weavingSettings, ILocalBuilderRepository localBuilderRepository)
            : base(argumentType, parameters, weavingSettings, localBuilderRepository) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator, Parameters);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
    }
}
