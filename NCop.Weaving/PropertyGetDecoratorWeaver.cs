﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyGetDecoratorWeaver : AbstractMethodWeaver, IPropertyGetWeaver
    {
		public PropertyGetDecoratorWeaver(IWeavingSettings weavingSettings)
			: base(weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodDefintionWeaver = new PropertyGetSignatureWeaver();
			MethodScopeWeaver = new PropertyGetDecoratorScopeWeaver(weavingSettings);
        }
    }
}
