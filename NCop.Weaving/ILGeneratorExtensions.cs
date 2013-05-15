﻿using System;
using System.Reflection.Emit;
using NCop.Core.Extensions;

namespace NCop.Weaving.Extensions
{
    public static class ILGeneratorExtensions
    {
        public static void EmitCastIfNeeded(this  ILGenerator ilGenerator, Type sourceTarget, Type targetType) {
            if (sourceTarget != null && targetType != null) {
                if (sourceTarget.IsValueType && !targetType.IsValueType) {
                    ilGenerator.Emit(OpCodes.Box, sourceTarget);
                }
                else if (targetType.IsGenericParameter) {
                    ilGenerator.Emit(OpCodes.Unbox_Any, targetType);
                }
                else if (sourceTarget.IsGenericParameter) {
                    ilGenerator.Emit(OpCodes.Box, sourceTarget);
                }
                else if (targetType.IsGenericType && !sourceTarget.Equals(targetType)) {
                    ilGenerator.Emit(OpCodes.Castclass, targetType);
                }
                else if (targetType.IsSubclassOf(sourceTarget)) {
                    ilGenerator.Emit(OpCodes.Castclass, targetType);
                }
            }
        }

        public static void EmitLoadArg(this ILGenerator iLGenerator, int arg) {
            if (arg <= 3) {
                switch (arg) {
                    case 0:
                        iLGenerator.Emit(OpCodes.Ldarg_0);
                        break;

                    case 1:
                        iLGenerator.Emit(OpCodes.Ldarg_1);
                        break;

                    case 2:
                        iLGenerator.Emit(OpCodes.Ldarg_2);
                        break;

                    case 3:
                        iLGenerator.Emit(OpCodes.Ldarg_3);
                        break;
                }
            }
            else if (arg <= 255) {
                iLGenerator.Emit(OpCodes.Ldarg_S, arg);
            }
        }

        public static void EmitLoadLocal(this ILGenerator ILGenerator, LocalBuilder localBuilder, bool ignoreType = false) {
            bool isReferenceType = ignoreType || !localBuilder.LocalType.IsValueType;

            if (localBuilder.LocalIndex <= 255) {
                if (isReferenceType) {
                    ILGenerator.EmitLoadLocalShortForm(localBuilder);
                }
                else {
                    ILGenerator.Emit(OpCodes.Ldloca_S, localBuilder);
                }
            }
            else {
                ILGenerator.Emit(isReferenceType ? OpCodes.Ldloc : OpCodes.Ldloca, localBuilder);
            }
        }

        public static void EmitStoreArgument(this ILGenerator ILGenerator, int index) {
            ILGenerator.Emit(index > 255 ? OpCodes.Starg : OpCodes.Starg_S, index);
        }

        public static void EmitStoreLocal(this ILGenerator ILGenerator, LocalBuilder localBuilder) {
            if (localBuilder.LocalIndex <= 255) {
                ILGenerator.EmitStoreLocalShortTerm(localBuilder);
            }
            else {
                ILGenerator.Emit(OpCodes.Stloc, localBuilder);
            }
        }

        private static void EmitStoreLocalShortTerm(this ILGenerator ILGenerator, LocalBuilder localBuilder) {
            switch (localBuilder.LocalIndex) {
                case 0:

                    ILGenerator.Emit(OpCodes.Stloc_0);
                    break;

                case 1:

                    ILGenerator.Emit(OpCodes.Stloc_1);
                    break;

                case 2:

                    ILGenerator.Emit(OpCodes.Stloc_2);
                    break;

                case 3:

                    ILGenerator.Emit(OpCodes.Stloc_3);
                    break;

                default:

                    ILGenerator.Emit(OpCodes.Stloc_S, localBuilder);
                    break;
            }
        }

        public static void EmitPushInteger(this ILGenerator ILGenerator, int value) {
            if (value >= -128 && value <= 127) {
                ILGenerator.EmitPushIntegerShortTerm(value);
            }
            else {
                ILGenerator.Emit(OpCodes.Ldc_I4, value);
            }
        }

        public static void EmitDivision(this ILGenerator ILGenerator, Type leftType) {
            ILGenerator.EmitUnsignedByType(OpCodes.Div, OpCodes.Div_Un, leftType);
        }

        public static void EmitAddition(this ILGenerator ILGenerator, Type leftType, Type rightType, bool isChecked) {
            ILGenerator.EmitPossiblyOverflowOperation(OpCodes.Add, OpCodes.Add_Ovf_Un, OpCodes.Add_Ovf, leftType, rightType, isChecked);
        }

        public static void EmitSubtraction(this ILGenerator ILGenerator, Type leftType, Type rightType, bool isChecked) {
            ILGenerator.EmitPossiblyOverflowOperation(OpCodes.Sub, OpCodes.Sub_Ovf_Un, OpCodes.Sub_Ovf, leftType, rightType, isChecked);
        }

        public static void EmitMultiplication(this ILGenerator ILGenerator, Type leftType, Type rightType, bool isChecked) {
            ILGenerator.EmitPossiblyOverflowOperation(OpCodes.Mul, OpCodes.Mul_Ovf_Un, OpCodes.Mul_Ovf, leftType, rightType, isChecked);
        }

        public static void EmitGreaterThanOrEqual(this ILGenerator ILGenerator, Type leftType, Type rightType) {
            ILGenerator.EmitGreater_LessThanOrEqual(OpCodes.Clt, OpCodes.Clt_Un, leftType, rightType);
        }

        public static void EmitLessThanOrEqual(this ILGenerator ILGenerator, Type leftType, Type rightType) {
            ILGenerator.EmitGreater_LessThanOrEqual(OpCodes.Cgt, OpCodes.Cgt_Un, leftType, rightType);
        }

        public static void EmitLessThen(this ILGenerator ILGenerator, Type leftType) {
            ILGenerator.EmitUnsignedByType(OpCodes.Clt, OpCodes.Clt_Un, leftType);
        }

        public static void EmitGreaterThan(this ILGenerator ILGenerator, Type leftType) {
            ILGenerator.EmitUnsignedByType(OpCodes.Cgt, OpCodes.Cgt_Un, leftType);
        }

        public static void EmitModulu(this ILGenerator ILGenerator, Type leftType) {
            ILGenerator.EmitUnsignedByType(OpCodes.Rem, OpCodes.Rem_Un, leftType);
        }

        public static void EmitRightShift(this ILGenerator ILGenerator, Type leftType) {
            ILGenerator.EmitUnsignedByType(OpCodes.Shr, OpCodes.Shr_Un, leftType);
        }

        public static void EmitPostIncrement(this ILGenerator ILGenerator, Type type, bool isChecked) {
            ILGenerator.EmitPostIncrement_Decreament(OpCodes.Add, OpCodes.Add_Ovf_Un, OpCodes.Add_Ovf, type, isChecked);
        }

        public static void EmitPostDecrement(this ILGenerator ILGenerator, Type type, bool isChecked) {
            ILGenerator.EmitPostIncrement_Decreament(OpCodes.Sub, OpCodes.Sub_Ovf_Un, OpCodes.Sub_Ovf, type, isChecked);
        }

        private static void EmitPushIntegerShortTerm(this ILGenerator ILGenerator, int value) {
            switch (value) {
                case -1:

                    ILGenerator.Emit(OpCodes.Ldc_I4_M1);
                    break;

                case 0:

                    ILGenerator.Emit(OpCodes.Ldc_I4_0);
                    break;

                case 1:

                    ILGenerator.Emit(OpCodes.Ldc_I4_1);
                    break;

                case 2:

                    ILGenerator.Emit(OpCodes.Ldc_I4_2);
                    break;

                case 3:

                    ILGenerator.Emit(OpCodes.Ldc_I4_3);
                    break;

                case 4:

                    ILGenerator.Emit(OpCodes.Ldc_I4_4);
                    break;

                case 5:

                    ILGenerator.Emit(OpCodes.Ldc_I4_5);
                    break;

                case 6:

                    ILGenerator.Emit(OpCodes.Ldc_I4_6);
                    break;

                case 8:

                    ILGenerator.Emit(OpCodes.Ldc_I4_8);
                    break;

                default:

                    ILGenerator.Emit(OpCodes.Ldc_I4_S, (byte)value);
                    break;
            }
        }

        public static void EmitConversion(this ILGenerator ILGenerator, Type to, Type from) {
            switch (Type.GetTypeCode(to)) {
                case TypeCode.Decimal:

                    ILGenerator.Emit(OpCodes.Box, typeof(decimal));
                    break;

                case TypeCode.Int32:

                    ILGenerator.Emit(OpCodes.Conv_I4);
                    break;

                case TypeCode.UInt32:

                    ILGenerator.Emit(OpCodes.Conv_U4);
                    break;

                case TypeCode.Int64:

                    ILGenerator.Emit(OpCodes.Conv_I8);
                    break;

                case TypeCode.UInt64:

                    ILGenerator.Emit(OpCodes.Conv_U8);
                    break;

                case TypeCode.Single:

                    if (from.IsUnsigned()) {
                        ILGenerator.Emit(OpCodes.Conv_R_Un);
                    }

                    ILGenerator.Emit(OpCodes.Conv_R4);
                    break;

                case TypeCode.Double:

                    if (from.IsUnsigned()) {
                        ILGenerator.Emit(OpCodes.Conv_R_Un);
                    }

                    ILGenerator.Emit(OpCodes.Conv_R8);
                    return;
            }
        }

        private static void EmitLoadLocalShortForm(this ILGenerator ILGenerator, LocalBuilder localBuilder) {
            switch (localBuilder.LocalIndex) {
                case 0:

                    ILGenerator.Emit(OpCodes.Ldloc_0);
                    break;

                case 1:

                    ILGenerator.Emit(OpCodes.Ldloc_1);
                    break;

                case 2:

                    ILGenerator.Emit(OpCodes.Ldloc_2);
                    break;

                case 3:

                    ILGenerator.Emit(OpCodes.Ldloc_3);
                    break;

                default:

                    ILGenerator.Emit(OpCodes.Ldloc_S, localBuilder);
                    break;
            }
        }

        private static void EmitGreater_LessThanOrEqual(this ILGenerator ILGenerator, OpCode signedOpCode, OpCode unsignedOpCode, Type leftType, Type rightType) {
            if ((leftType.IsUnsigned() && rightType.IsUnsigned()) || leftType.IsFloatingPoint()) {
                ILGenerator.Emit(unsignedOpCode);
            }
            else {
                ILGenerator.Emit(signedOpCode);
            }

            ILGenerator.Emit(OpCodes.Ldc_I4_0);
            ILGenerator.Emit(OpCodes.Ceq);
        }

        private static void EmitPossiblyOverflowOperation(this ILGenerator ILGenerator, OpCode signedOpCode, OpCode unsignedOverflowOpCode, OpCode signedOverflowOpCode, Type leftType, Type rightType, bool isChecked) {
            if (isChecked) {
                if (leftType.IsUnsigned() && rightType.IsUnsigned()) {
                    ILGenerator.Emit(unsignedOverflowOpCode);
                }
                else if (leftType.IsFloatingPoint() || rightType.IsFloatingPoint()) {
                    ILGenerator.Emit(signedOpCode);
                }
                else {
                    ILGenerator.Emit(signedOverflowOpCode);
                }
            }
            else {
                ILGenerator.Emit(signedOpCode);
            }
        }

        private static void EmitPostIncrement_Decreament(this ILGenerator ILGenerator, OpCode signedOpCode, OpCode unsignedOverflowOpCode, OpCode signedOverflowOpCode, Type type, bool isChecked) {
            ILGenerator.Emit(OpCodes.Dup);
            ILGenerator.Emit(OpCodes.Ldc_I4_1);

            if (isChecked) {
                if (type.IsUnsigned()) {
                    ILGenerator.Emit(unsignedOverflowOpCode);
                }
                else if (type.IsFloatingPoint()) {
                    ILGenerator.Emit(signedOpCode);
                }
                else {
                    ILGenerator.Emit(signedOverflowOpCode);
                }
            }
            else {
                ILGenerator.Emit(signedOpCode);
            }
        }

        private static void EmitUnsignedByType(this ILGenerator ILGenerator, OpCode signedOpCode, OpCode unsignedOpCode, Type type) {
            if (type.IsUnsigned()) {
                ILGenerator.Emit(unsignedOpCode);
            }
            else {
                ILGenerator.Emit(signedOpCode);
            }
        }

        public static void EmitPrimitiveByTypeCode(this ILGenerator ILGenerator, object value, TypeCode typeCode) {
            switch (typeCode) {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.Char: {
                        int operand = Convert.ToInt32(value);

                        ILGenerator.EmitPushInteger(operand);
                        break;
                    }
                case TypeCode.Double: {
                        double operand = Convert.ToDouble(value);

                        ILGenerator.Emit(OpCodes.Ldc_R8, operand);
                        break;
                    }
                case TypeCode.Single: {
                        float operand = Convert.ToSingle(value);

                        ILGenerator.Emit(OpCodes.Ldc_R4, operand);
                        break;
                    }
                case TypeCode.String: {
                        string operand = value.ToString();

                        ILGenerator.Emit(OpCodes.Ldstr, operand);
                        break;
                    }
                case TypeCode.Int64: {
                        long operand = Convert.ToInt64(value);

                        PushIntegerOpCode(ILGenerator, operand);
                        break;
                    }
                case TypeCode.UInt64: {
                        ulong operand = Convert.ToUInt64(value);

                        PushIntegerOpCode(ILGenerator, operand);
                        break;
                    }
                case TypeCode.Boolean: {
                        bool operand = Convert.ToBoolean(value);

                        ILGenerator.Emit(operand ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
                        break;
                    }
            }
        }

        public static void EmitLoadElementByType(this ILGenerator ILGenerator, Type type) {
            var typeCode = Type.GetTypeCode(type);

            switch (typeCode) {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Boolean: {
                        ILGenerator.Emit(OpCodes.Ldelem_I);
                        break;
                    }
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Char: {
                        ILGenerator.Emit(OpCodes.Ldelem_I2);
                        break;
                    }
                case TypeCode.Int32:
                case TypeCode.UInt32: {
                        ILGenerator.Emit(OpCodes.Ldelem_I4);
                        break;
                    }
                case TypeCode.Int64:
                case TypeCode.UInt64: {
                        ILGenerator.Emit(OpCodes.Ldelem_I8);
                        break;
                    }
                case TypeCode.Single: {
                        ILGenerator.Emit(OpCodes.Ldelem_R4);
                        break;
                    }
                case TypeCode.Double: {
                        ILGenerator.Emit(OpCodes.Ldelem_R8);
                        break;
                    }
                case TypeCode.String:
                case TypeCode.Object: {
                        ILGenerator.Emit(OpCodes.Ldelem_Ref);
                        break;
                    }
            }
        }

        public static void EmitStoreElementByType(this ILGenerator ILGenerator, Type type) {
            if (type.IsEnum || type.IsPrimitive && !type.Equals(typeof(IntPtr))) {
                var typeCode = Type.GetTypeCode(type);

                EmitStorePrimitiveElementByTypeCode(ILGenerator, typeCode);
            }
            else if (type.IsValueType || type.IsGenericParameter) {
                ILGenerator.Emit(OpCodes.Stobj, type);
            }
            else {
                ILGenerator.Emit(OpCodes.Stind_Ref);
            }
        }

        public static void EmitLoadElementArrayIfNeeded(this ILGenerator ILGenerator, Type type) {
            if (!type.IsEnum && !type.IsPrimitive && !type.Equals(typeof(IntPtr))) {
                ILGenerator.Emit(OpCodes.Ldelema, type);
            }
        }

        private static void EmitStorePrimitiveElementByTypeCode(this ILGenerator ILGenerator, TypeCode typeCode) {
            switch (typeCode) {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Boolean: {
                        ILGenerator.Emit(OpCodes.Stelem_I1);
                        break;
                    }
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Char: {
                        ILGenerator.Emit(OpCodes.Stelem_I2);
                        break;
                    }
                case TypeCode.Int32:
                case TypeCode.UInt32: {
                        ILGenerator.Emit(OpCodes.Stelem_I4);
                        break;
                    }
                case TypeCode.Int64:
                case TypeCode.UInt64: {
                        ILGenerator.Emit(OpCodes.Stelem_I8);
                        break;
                    }
                case TypeCode.Single: {
                        ILGenerator.Emit(OpCodes.Stelem_R4);
                        break;
                    }
                case TypeCode.Double: {
                        ILGenerator.Emit(OpCodes.Stelem_R8);
                        break;
                    }
                case TypeCode.String: {
                        ILGenerator.Emit(OpCodes.Stelem_Ref);
                        break;
                    }
            }
        }

        public static void EmitPrimitiveAndStoreElementByType(this ILGenerator ILGenerator, object value, Type type) {
            var typeCode = Type.GetTypeCode(type);

            EmitPrimitiveByTypeCode(ILGenerator, value, typeCode);
            EmitStoreElementByType(ILGenerator, type);
        }

        private static void PushIntegerOpCode(this ILGenerator ilGenerator, long value) {
            int emittedValue = 0;

            if (value >= -128 && value <= 127) {
                emittedValue = (int)value;
                ilGenerator.EmitPushIntegerShortTerm(emittedValue);
                ilGenerator.Emit(OpCodes.Conv_I8);
            }
            else {
                if (value > int.MaxValue || value < int.MinValue) {
                    ilGenerator.Emit(OpCodes.Ldc_I8, value);
                }
                else {
                    emittedValue = (int)value;
                    ilGenerator.Emit(OpCodes.Ldc_I4, emittedValue);
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
            }
        }

        private static void PushIntegerOpCode(this ILGenerator ilGenerator, ulong value) {
            if (value <= 127) {
                ilGenerator.Emit(OpCodes.Ldc_I4_S, (byte)value);
                ilGenerator.Emit(OpCodes.Conv_I8);
            }
            else {
                if (value > int.MaxValue) {
                    if (value == ulong.MaxValue) {
                        ilGenerator.Emit(OpCodes.Ldc_I4_M1);
                    }
                    else {
                        ilGenerator.Emit(OpCodes.Ldc_I8, value);
                    }
                }
                else {
                    ilGenerator.Emit(OpCodes.Ldc_I4, (int)value);
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
            }
        }
    }
}