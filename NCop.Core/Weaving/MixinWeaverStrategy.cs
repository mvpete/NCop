﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core.Weaving
{
    public class MixinWeaverStrategy : ITypeWeaver
    {
        public MixinWeaverStrategy(ITypeDefinitionWeaver typeDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers) {
            MethodWeavers = methodWeavers;
            TypeDefinitionWeaver = typeDefinitionWeaver;
        }

        public void Weave() {
            var typeDefinition = TypeDefinitionWeaver.Weave();

            MethodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod(typeDefinition);
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }

        public IEnumerable<IMethodWeaver> MethodWeavers { get; private set; }

        public ITypeDefinitionWeaver TypeDefinitionWeaver { get; private set; }
    }
}