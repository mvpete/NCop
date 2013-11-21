﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Weaving.Extensions;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
	public class MethodDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        public MethodDecoratorScopeWeaver(MethodInfo methodInfo, Type implementationType, Type contractType)
			:base(methodInfo, implementationType, contractType) {
        }

        public override ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            FieldBuilder fieldBuilder = typeDefinition.GetFieldBuilder(ContractType);

            iLGenerator.EmitLoadArg(0);
            iLGenerator.Emit(OpCodes.Ldfld, fieldBuilder);

            MethodInfo.GetParameters()
                      .Select(p => p.ParameterType)
                      .ForEach(1, (paramType, i) => {
                          iLGenerator.EmitLoadArg(i);
                      });

            iLGenerator.Emit(OpCodes.Callvirt, MethodInfo);

            return iLGenerator;
        }
    }
}