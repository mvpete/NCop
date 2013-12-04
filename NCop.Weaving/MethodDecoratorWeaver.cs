﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
		public MethodDecoratorWeaver(IWeavingSettings weavingSettings)
			: base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodDefintionWeaver = new MethodSignatureWeaver();
			MethodScopeWeaver = new MethodDecoratorScopeWeaver(weavingSettings);
        }

        public override MethodBuilder DefineMethod() {
            return MethodDefintionWeaver.Weave(MethodInfoImpl, TypeDefinition);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
            return MethodScopeWeaver.Weave(ilGenerator);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
        }
    }
}
