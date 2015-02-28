﻿using NCop.Aspects.Engine;
// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by NCop Copyright © 2015
//    Changes to this file may cause incorrect behavior and will be lost if
//    the code is regenerated.
// </auto-generated
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Extensions
{
	internal static class MethodBindingResolver
	{
		private static readonly IDictionary<int, Type> funcBindingMap = null;
		private static readonly IDictionary<int, Type> actionBindingMap = null;

		static MethodBindingResolver() {
			funcBindingMap = new Dictionary<int, Type>();
			actionBindingMap = new Dictionary<int, Type>();

			actionBindingMap.Add(0, typeof(IActionBinding<>));				

			funcBindingMap.Add(1, typeof(IFunctionBinding<,>));	
			actionBindingMap.Add(1, typeof(IActionBinding<,>));	

			funcBindingMap.Add(2, typeof(IFunctionBinding<,,>));	
			actionBindingMap.Add(2, typeof(IActionBinding<,,>));	

			funcBindingMap.Add(3, typeof(IFunctionBinding<,,,>));	
			actionBindingMap.Add(3, typeof(IActionBinding<,,,>));	

			funcBindingMap.Add(4, typeof(IFunctionBinding<,,,,>));	
			actionBindingMap.Add(4, typeof(IActionBinding<,,,,>));	

			funcBindingMap.Add(5, typeof(IFunctionBinding<,,,,,>));	
			actionBindingMap.Add(5, typeof(IActionBinding<,,,,,>));	

			funcBindingMap.Add(6, typeof(IFunctionBinding<,,,,,,>));	
			actionBindingMap.Add(6, typeof(IActionBinding<,,,,,,>));	

			funcBindingMap.Add(7, typeof(IFunctionBinding<,,,,,,,>));	
			actionBindingMap.Add(7, typeof(IActionBinding<,,,,,,,>));	

			funcBindingMap.Add(8, typeof(IFunctionBinding<,,,,,,,,>));	
			actionBindingMap.Add(8, typeof(IActionBinding<,,,,,,,,>));	

			funcBindingMap.Add(9, typeof(IFunctionBinding<,,,,,,,,,>));	
		}

		internal static Type MakeGenericFunctionBinding(this Type argumentsType, params Type[] typeArguments) {
			int parametersCount = argumentsType.GetGenericArguments().Length;

			return funcBindingMap[parametersCount].MakeGenericType(typeArguments);
		}
		
		internal static Type MakeGenericActionBinding(this Type argumentsType, params Type[] typeArguments) {
			int parametersCount = argumentsType.GetGenericArguments().Length;

			return actionBindingMap[parametersCount].MakeGenericType(typeArguments);
		}
		
		internal static Type MakeGenericPropertyBinding(this Type argumentsType, params Type[] typeArguments) {
			return typeof(IPropertyBinding<,>).MakeGenericType(typeArguments);
		}	
	}
}