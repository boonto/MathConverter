﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace HexInnovation
{
    internal abstract class Operator
    {
        /// <summary>
        /// The binary "^" operator. This operator returns the first operand raised to the power of the second.
        /// If either operand is null, it will return null, and it only supports numeric types.
        /// It is designed explicitly different from the C# "^" (exclusive or) operator.
        /// </summary>
        public static readonly BinaryOperator Exponentiation = Op.Exponentiation;

        /// <summary>
        /// The binary "+" operator. This operator adds two operands together.
        /// It is designed to work like the "+" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#addition-operator"/>
        /// </summary>
        public static readonly BinaryOperator Addition = Op.Addition;

        /// <summary>
        /// The binary "-" operator. This operator subtracts one operand from another.
        /// It is designed to work like the "-" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#subtraction-operator"/>
        /// </summary>
        public static readonly BinaryOperator Subtraction = Op.Subtraction;

        /// <summary>
        /// The binary "*" operator. This operator multiplies one operand by another.
        /// It is designed to work like the "*" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#multiplication-operator"/>
        /// </summary>
        public static readonly BinaryOperator Multiplication = Op.Multiplication;

        /// <summary>
        /// The binary "/" operator. This operator divides one operand by another.
        /// It is designed to work like the "/" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#division-operator"/>
        /// </summary>
        public static readonly BinaryOperator Division = Op.Division;

        /// <summary>
        /// The binary "%" operator. This operator divides one operand by another and returns the remainder.
        /// It is designed to work like the "%" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#remainder-operator"/>
        /// </summary>
        public static readonly BinaryOperator Remainder = Op.Remainder;

        /// <summary>
        /// The binary "&&" operator. This operator explicitly does not do a bitwise-and, and is only applicable for boolean operands, or types that define a true operator.
        /// If the first operand is false, the second operand will not be evaluated.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#conditional-logical-operators"/>
        /// </summary>
        public static readonly BinaryOperator And = Op.And;

        /// <summary>
        /// The binary "||" operator. This operator explicitly does not do a bitwise-and, and is only applicable for boolean operands, or types that define a true operator.
        /// If the first operand is true, the second operand will not be evaluated.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#conditional-logical-operators"/>
        /// </summary>
        public static readonly BinaryOperator Or = Op.Or;

        /// <summary>
        /// The binary "??" operator.
        /// It is designed to work like the "??" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#the-null-coalescing-operator"/>
        /// </summary>
        public static readonly BinaryOperator NullCoalescing = Op.NullCoalescing;

        /// <summary>
        /// The binary "!=" operator.
        /// It is designed to work like the "!=" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator Inequality = Op.Inequality;

        /// <summary>
        /// The binary "==" operator.
        /// It is designed to work like the "==" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator Equality = Op.Equality;

        /// <summary>
        /// The binary "&lt;" operator.
        /// It is designed to work like the "&lt;" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator LessThan = Op.LessThan;

        /// <summary>
        /// The binary "&lt;=" operator.
        /// It is designed to work like the "&lt;=" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator LessThanOrEqual = Op.LessThanOrEqual;

        /// <summary>
        /// The binary ">" operator.
        /// It is designed to work like the ">" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator GreaterThan = Op.GreaterThan;

        /// <summary>
        /// The binary ">=" operator.
        /// It is designed to work like the ">=" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#relational-and-type-testing-operators"/>
        /// </summary>
        public static readonly BinaryOperator GreaterThanOrEqual = Op.GreaterThanOrEqual;

        /// <summary>
        /// The unary "!" operator.
        /// It is designed to work like the "!" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#logical-negation-operator" />
        /// </summary>
        public static readonly UnaryOperator LogicalNot = Op.LogicalNot;

        /// <summary>
        /// The unary "-" operator.
        /// It is designed to work like the "-" operator.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#unary-minus-operator"/>
        /// </summary>
        public static readonly UnaryOperator UnaryNegation = Op.UnaryNegation;

        // TODO: ADD SUPPORT FOR THE UNARY PLUS OPERATOR!

        public enum Op
        {
            Exponentiation,
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Remainder,
            And,
            Or,
            NullCoalescing,
            Inequality,
            Equality,
            LessThan,
            LessThanOrEqual,
            GreaterThan,
            GreaterThanOrEqual,
            LogicalNot,
            UnaryNegation,s
        }
        class OperatorInfo
        {
            public MethodInfo Method { get; set; }
            public ParameterInfo[] Parameters { get; set; }

            public bool IsApplicable(Type[] parameters)
            {
                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#applicable-function-member

                // This logic is simplified because operators cannot be called with ref/out or optional parameters.
                if (Parameters.Length != parameters.Length)
                    return false;

                // Can we implicitly convert the parameters to the necessary type?
                for (int i = 0; i < Parameters.Length; i++)
                {
                    if (!DoesImplicitConversionExist(parameters[i], Parameters[i].ParameterType, false))
                        return false;
                }

                return true;
            }
            public override string ToString() => $"{Method}";
        }
        [Flags]
        protected enum Operands
        {
            CompletelyCustom = 0,
            Number = 1,
            Boolean = 2,
            String = 4,
            StringObject = 8,
            Object = 16,
        }
        private static IEnumerable<Type> GetTypeAndSubtypes(Type type)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#base-types

            if (ReferenceEquals(type, null))
            {
                yield break;
            }

            type = Nullable.GetUnderlyingType(type) ?? type;

            yield return type;

            if (type.IsEnum)
            {
                yield return typeof(Enum);
            }

            if (type.IsValueType)
            {
                yield return typeof(ValueType);
                yield return typeof(object);
                yield break;
            }

            if (type.IsArray)
            {
                yield return typeof(Array);
                yield return typeof(object);
                yield break;
            }

            // Not sure what to do about delegate types.

            // Interface and classes...
            while ((type = type.BaseType) != null)
            {
                yield return type;
            }
        }
        private static IEnumerable<Type> GetTypeAndSubtypes(params Type[] parameters)
        {
            return parameters.SelectMany(GetTypeAndSubtypes).Distinct();
        }

        private static List<OperatorInfo> GetPossibleOperators(string operatorName, params Type[] parameterTypes)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#candidate-user-defined-operators
            return GetTypeAndSubtypes(parameterTypes).SelectMany(type =>
                    type.GetMethods(BindingFlags.Public | BindingFlags.Static)
                        .Where(method => method.Name == operatorName && method.DeclaringType != typeof(decimal)) // We explicitly ban decimal operations so that we convert our arguments to double.
                        .Select(method => new OperatorInfo
                        {
                            Method = method,
                            Parameters = method.GetParameters()
                        })
                        .Where(p => p.IsApplicable(parameterTypes))
                )
                .ToList();
        }
        private static List<OperatorInfo> GetPossibleOperators(string operatorName, params object[] parameters)
        {
            return GetPossibleOperators(operatorName, parameters.Select(p => p?.GetType() ?? typeof(object)).ToArray());
        }

        protected internal static List<MethodInfo> GetImplicitOperatorPath(string operatorName, Type typeFrom, Type typeTo)
        {
            var implicitOperators = GetPossibleOperators(operatorName, typeFrom)
                .ToDictionary(p => p.Method.ReturnType, p => new List<MethodInfo> { p.Method });
            var previousLevelOperators = implicitOperators.Keys.Distinct().ToList();
            var underlyingType = Nullable.GetUnderlyingType(typeTo);

            implicitOperators[typeFrom] = new List<MethodInfo>(0);

            if (previousLevelOperators.Any())
            {
                while (previousLevelOperators.Any())
                {
                    if (implicitOperators.ContainsKey(typeTo))
                    {
                        return implicitOperators[typeTo];
                    }
                    else if (underlyingType != null && implicitOperators.ContainsKey(underlyingType))
                    {
                        return implicitOperators[underlyingType];
                    }

                    var previousLevelOperatorsCopy = previousLevelOperators.ToList();
                    previousLevelOperators.Clear();

                    foreach (var type in previousLevelOperatorsCopy)
                    {
                        var possibleOperators = GetPossibleOperators(operatorName, type).ToList();

                        foreach (var nextLevelOperator in possibleOperators)
                        {
                            if (!implicitOperators.ContainsKey(nextLevelOperator.Method.ReturnType))
                            {
                                implicitOperators[nextLevelOperator.Method.ReturnType] = implicitOperators[type].Concat(new[] { nextLevelOperator.Method }).ToList();
                                previousLevelOperators.Add(nextLevelOperator.Method.ReturnType);
                            }
                        }
                    }
                }


                // Favor a path requiring as few implicit conversions as possible.
                foreach (var conversionPath in implicitOperators.OrderBy(p => p.Value.Count))
                {
                    // Prevent infinite recursion by refusing to implicitly convert again.
                    if (DoesImplicitConversionExist(conversionPath.Key, typeTo, false))
                    {
                        return conversionPath.Value;
                    }
                    else if (underlyingType != null && DoesImplicitConversionExist(conversionPath.Key, underlyingType, false))
                    {
                        return conversionPath.Value;
                    }
                }
            }

            // There's no implicit conversion from typeFrom to typeTo.
            return null;
        }
        protected internal static bool DoesImplicitConversionExist(Type typeFrom, Type typeTo, bool allowImplicitOperator)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/conversions#implicit-numeric-conversions
            if (ReferenceEquals(typeFrom, null))
            {
                // We're not worrying about nullable types.
                return true;
            }
            // For numeric types, we allow more conversion types. We implicitly convert from unsigned values to signed and from any type to itself.
            // Essentially, this method is here to see if we can call DoImplicitConversion to safely convert numeric types up to bigger types.
            else if (typeFrom == typeof(sbyte) || typeFrom == typeof(byte))
            {
                return typeTo == typeof(sbyte) || typeTo == typeof(short) || typeTo == typeof(ushort) ||
                       typeTo == typeof(int) || typeTo == typeof(uint) || typeTo == typeof(long) ||
                       typeTo == typeof(ulong) || typeTo == typeof(float) || typeTo == typeof(double) ||
                       typeTo == typeof(decimal);
            }
            else if (typeFrom == typeof(short) || typeFrom == typeof(ushort))
            {
                return typeTo == typeof(ushort) || typeTo == typeof(short) || typeTo == typeof(int) ||
                       typeTo == typeof(uint) || typeTo == typeof(long) || typeTo == typeof(ulong) ||
                       typeTo == typeof(float) || typeTo == typeof(double) || typeTo == typeof(decimal);
            }
            else if (typeFrom == typeof(int) || typeFrom == typeof(uint))
            {
                return typeTo == typeof(uint) || typeTo == typeof(int) || typeTo == typeof(long) ||
                       typeTo == typeof(ulong) || typeTo == typeof(float) || typeTo == typeof(double) ||
                       typeTo == typeof(decimal);
            }
            else if (typeFrom == typeof(long) || typeFrom == typeof(ulong))
            {
                return typeTo == typeof(long) || typeTo == typeof(ulong) || typeTo == typeof(float) ||
                       typeTo == typeof(double) || typeTo == typeof(decimal);
            }
            else if (typeFrom == typeof(char))
            {
                return typeTo == typeof(char) || typeTo == typeof(ushort) || typeTo == typeof(int) ||
                       typeTo == typeof(uint) || typeTo == typeof(long) || typeTo == typeof(ulong) ||
                       typeTo == typeof(float) || typeTo == typeof(double) || typeTo == typeof(decimal);
            }
            else if (typeFrom == typeof(float))
            {
                return typeTo == typeof(float) || typeTo == typeof(double);
            }
            else if (typeFrom == typeof(decimal))
            {
                return typeTo == typeof(decimal) || typeTo == typeof(double);
            }
            else if (typeFrom == typeof(double))
            {
                return typeTo == typeof(double);
            }
            // Ignoring Implicit enumeration conversions section...
            // Ignoring Implicit interpolated string conversions...
            // Ignoring Implicit nullable conversions...

            // Reference conversions!
            if (typeTo == typeof(object))
                return true;

            if (GetTypeAndSubtypes(typeFrom).Contains(typeTo))
                return true;

            if (typeTo.IsInterface && typeFrom.GetInterfaces().Contains(typeTo))
                return true;

            if (typeFrom.IsArray && typeTo.IsArray && typeFrom.GetArrayRank() == typeTo.GetArrayRank())
            {
                return !typeFrom.IsValueType && !typeTo.IsValueType && DoesImplicitConversionExist(typeFrom.GetElementType(), typeTo.GetElementType(), true);
            }
            if (typeFrom.IsArray && GetTypeAndSubtypes(typeof(Array)).Contains(typeTo))
            {
                return true;
            }
            if (typeFrom.IsArray && typeFrom.GetArrayRank() == 1 && GetTypeAndSubtypes(typeof(IList<>)).Contains(typeTo))
            {
                return DoesImplicitConversionExist(typeFrom.GetElementType(), typeTo.GenericTypeArguments[0], true);
            }
            // MathConverter doesn't support delegates.

            if (allowImplicitOperator && GetImplicitOperatorPath("op_Implicit", typeFrom, typeTo) != null)
            {
                return true;
            }

            // Check To/False operators.
            if (typeTo == typeof(bool) || typeTo == typeof(bool?))
            {
                var operators = GetImplicitOperatorPath("op_True", typeFrom, typeTo);
                if (operators != null)
                {
                    return true;
                }
            }

            // This is probably good enough???
            return false;
        }
        protected internal static object DoImplicitConversion(object from, Type typeTo)
        {
            // If we're trying to convert null to a nullable type, let's just return null.
            if (ReferenceEquals(from, null) && (!typeTo.IsValueType || Nullable.GetUnderlyingType(typeTo)?.IsValueType == true))
            {
                if (typeTo.IsValueType)
                {
                    // Nullable<T>.
                    return Activator.CreateInstance(typeTo);
                }
                else
                {
                    return null;
                }
            }

            var structTypeTo = Nullable.GetUnderlyingType(typeTo);
            if (structTypeTo != null && from != null && from.GetType() == structTypeTo)
            {
                return from;
            }

            // Check implicit casts.
            var implicitCasts = GetImplicitOperatorPath("op_Implicit", from?.GetType() ?? typeof(object), typeTo);

            if (implicitCasts?.Any() == true)
            {
                implicitCasts.ForEach(cast => from = cast.Invoke(null, new[] { from }));

                // After we finish the implicit operator(s), we may need to do another implicit conversion.
                return DoImplicitConversion(from, typeTo);
            }

            // Check true operator
            if (typeTo == typeof(bool) || typeTo == typeof(bool?))
            {
                var trueOperator = GetImplicitOperatorPath("op_True", from?.GetType() ?? typeof(object), typeTo);
                if (trueOperator?.Any() == true)
                {
                    trueOperator.ForEach(oper => from = oper.Invoke(null, new[] { from }));

                    return from;
                }
            }

            // We might have to convert to a non-nullable type.
            if (structTypeTo != null && !ReferenceEquals(from, null))
            {
                return Convert.ChangeType(from, structTypeTo);
            }

            return Convert.ChangeType(from, typeTo);
        }

        protected internal static bool? TryConvertToBool(object value)
        {
            if (value is bool b)
            {
                return b;
            }
            else if (ReferenceEquals(value, null))
            {
                return null;
            }

            if (DoesImplicitConversionExist(value.GetType(), typeof(bool?), true))
            {
                return (bool)DoImplicitConversion(value, typeof(bool?));
            }

            return null;
        }
        protected internal static InvalidOperationException InvalidOperator(string operatorSymbols, params object[] arguments)
        {
            var argTypes = arguments.Select(x => x == null ? "null" : $"'{x.GetType().FullName}'").ToList();

            return new InvalidOperationException($"Operator '{operatorSymbols}' cannot be applied to operand{(arguments.Length == 1 ? "" : "s")} of type {string.Join(" ", argTypes.Take(argTypes.Count - 1))}{(argTypes.Count == 1 ? "" : " and ")}{argTypes.Last()}");
        }
        protected MethodInfo GetUserDefinedOperator(params object[] parameters)
        {
            var candidateUserDefinedOperators = GetPossibleOperators(OperatorName, parameters);
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#binary-operator-overload-resolution

            switch (candidateUserDefinedOperators.Count)
            {
                case 0:
                    return null;
                case 1:
                    return candidateUserDefinedOperators[0].Method;
                default:
                    // We need to figure out which operator is the most specific!
                    for (var i = 0; i < candidateUserDefinedOperators.Count; i++)
                    {
                        // Loop through all candidates.
                        var thisCandidate = candidateUserDefinedOperators[i];

                        for (int j = i + 1; j < candidateUserDefinedOperators.Count; j++)
                        {
                            // Loop through the other candidates we haven't already compared to.
                            var otherCandidate = candidateUserDefinedOperators[j];

                            // 0 means equal, -1 means thisCandidate is better, 1 means otherCandidate is better, null means we can't decide.
                            int? betterCandidate = 0;

                            for (int k = 0; k < thisCandidate.Parameters.Length && betterCandidate.HasValue; k++)
                            {
                                var thisParameter = thisCandidate.Parameters[k].ParameterType;
                                var otherParameter = otherCandidate.Parameters[k].ParameterType;

                                if (thisParameter == otherParameter)
                                    continue;

                                if (DoesImplicitConversionExist(thisParameter, otherParameter, true))
                                {
                                    // thisCandidate is more specific (and is therefore a better match) for this parameter!
                                    switch (betterCandidate.Value)
                                    {
                                        case 0:
                                        case -1:
                                            betterCandidate = -1;
                                            break;
                                        case 1:
                                            betterCandidate = null;
                                            break;
                                    }
                                }
                                else if (DoesImplicitConversionExist(otherParameter, thisParameter, true))
                                {
                                    // otherCandidate is more specific (and is therefore a better match) for this parameter!
                                    switch (betterCandidate.Value)
                                    {
                                        case 0:
                                        case 1:
                                            betterCandidate = 1;
                                            break;
                                        case -1:
                                            betterCandidate = null;
                                            break;
                                    }
                                }
                            }

                            // After having looped through all of the parameters comparing thisCandidate and otherCandidate,
                            // we've figured out one of four possibilities:
                            switch (betterCandidate)
                            {
                                case null:
                                case 0:
                                    // Either they're both the same, or they're both better/worse than each other. Either way, there's no clear-cut winner, so we'll keep both options.
                                    break;
                                case -1:
                                    // This option is better! We'll remove the other candidate!
                                    candidateUserDefinedOperators.RemoveAt(j);
                                    j--;
                                    break;
                                case 1:
                                    // The other option is better! We need to remove this candidate!
                                    candidateUserDefinedOperators.RemoveAt(i);
                                    i--;
                                    j = candidateUserDefinedOperators.Count;
                                    break;
                                default:
                                    throw new Exception(
                                        $"MathConverter internal exception: {nameof(GetUserDefinedOperator)} is in an invalid state.");
                            }
                        }
                    }

                    switch (candidateUserDefinedOperators.Count)
                    {
                        case 1:
                            return candidateUserDefinedOperators[0].Method;
                        default:
                            throw new AmbiguousMatchException(
                                $"Could not identify which {OperatorType} operator to apply to type{(parameters.Length == 1 ? "" : "s")} {string.Join(" and ", parameters.Select(p => p.GetType().FullName ?? "null"))} between the following options:{string.Concat(candidateUserDefinedOperators.Select(p => $"{Environment.NewLine}{p}"))}");
                    }
            }
        }

        protected Operator(Op operatorType)
        {
            OperatorType = operatorType;

            if (!Type.IsInstanceOfType(this))
            {
                throw new InvalidCastException($"The {OperatorType} operator is a {Type.Name}, not a {GetType().Name}.");
            }
        }

        protected readonly Op OperatorType;
        protected string OperatorName
        {
            get
            {
                switch (OperatorType)
                {
                    case Op.Exponentiation:
                    case Op.NullCoalescing:
                        return null;
                    case Op.And:
                        return "op_BitwiseAnd";
                    case Op.Or:
                        return "op_BitwiseOr";
                    case Op.Addition:
                        return "op_Addition";
                    case Op.Subtraction:
                        return "op_Subtraction";
                    case Op.Multiplication:
                        return "op_Multiplication";
                    case Op.Division:
                        return "op_Division";
                    case Op.Remainder:
                        return "op_Modulus";
                    case Op.Inequality:
                        return "op_Inequality";
                    case Op.Equality:
                        return "op_Equality";
                    case Op.LessThan:
                        return "op_LessThan";
                    case Op.LessThanOrEqual:
                        return "op_LessThanOrEqual";
                    case Op.GreaterThan:
                        return "op_GreaterThan";
                    case Op.GreaterThanOrEqual:
                        return "op_GreaterThanOrEqual";
                    case Op.LogicalNot:
                        return "op_LogicalNot";
                    case Op.UnaryNegation:
                        return "op_UnaryNegation";
                    default:
                        throw new NotSupportedException($"The {OperatorType} operator is not supported");
                }
            }
        }
        protected Operands SupportedOperands
        {
            get
            {
                switch (OperatorType)
                {
                    case Op.NullCoalescing:
                    case Op.And:
                    case Op.Or:
                        return Operands.CompletelyCustom;
                    case Op.Addition:
                        return Operands.Number | Operands.String | Operands.StringObject;
                    case Op.Exponentiation:
                    case Op.Subtraction:
                    case Op.Multiplication:
                    case Op.Division:
                    case Op.Remainder:
                    case Op.LessThan:
                    case Op.LessThanOrEqual:
                    case Op.GreaterThan:
                    case Op.GreaterThanOrEqual:
                    case Op.UnaryNegation:
                        return Operands.Number;
                    case Op.Equality:
                    case Op.Inequality:
                        return Operands.Number | Operands.Boolean | Operands.String | Operands.Object;
                    case Op.LogicalNot:
                        return Operands.Boolean;
                    default:
                        throw new NotSupportedException($"The {OperatorType} operator is not supported");
                }
            }
        }
        private Type Type
        {
            get
            {
                switch (OperatorType)
                {
                    case Op.NullCoalescing:
                    case Op.And:
                    case Op.Or:
                    case Op.Addition:
                    case Op.Exponentiation:
                    case Op.Subtraction:
                    case Op.Multiplication:
                    case Op.Division:
                    case Op.Remainder:
                    case Op.LessThan:
                    case Op.LessThanOrEqual:
                    case Op.GreaterThan:
                    case Op.GreaterThanOrEqual:
                    case Op.Equality:
                    case Op.Inequality:
                        return typeof(BinaryOperator);
                    case Op.LogicalNot:
                    case Op.UnaryNegation:
                        return typeof(UnaryOperator);
                    default:
                        throw new NotSupportedException($"The {OperatorType} operator is not supported");
                }
            }
        }
        public string OperatorSymbols
        {
            get
            {
                switch (OperatorType)
                {
                    case Op.Exponentiation:
                        return "^";
                    case Op.Addition:
                        return "+";
                    case Op.Subtraction:
                        return "-";
                    case Op.Multiplication:
                        return "*";
                    case Op.Division:
                        return "/";
                    case Op.Remainder:
                        return "%";
                    case Op.And:
                        return "&&";
                    case Op.Or:
                        return "||";
                    case Op.NullCoalescing:
                        return "??";
                    case Op.Inequality:
                        return "!=";
                    case Op.Equality:
                        return "==";
                    case Op.LessThan:
                        return "<";
                    case Op.LessThanOrEqual:
                        return "<=";
                    case Op.GreaterThan:
                        return ">";
                    case Op.GreaterThanOrEqual:
                        return ">=";
                    case Op.LogicalNot:
                        return "!";
                    case Op.UnaryNegation:
                        return "!";
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        protected object EvaluateWithNullArguments()
        {
            switch (OperatorType)
            {
                case Op.Exponentiation:
                case Op.Addition:
                case Op.Subtraction:
                case Op.Multiplication:
                case Op.Division:
                case Op.Remainder:
                case Op.And:
                case Op.LessThan:
                case Op.LessThanOrEqual:
                case Op.GreaterThanOrEqual:
                case Op.GreaterThan:
                case Op.LogicalNot:
                case Op.UnaryNegation:
                    return null;
                case Op.Inequality:
                    return false;
                case Op.Equality:
                    return true;
                default:
                    throw new NotSupportedException();
            }
        }

        public sealed override string ToString() => OperatorSymbols;
    }
    internal sealed class UnaryOperator : Operator
    {
        private UnaryOperator(Op operatorType) : base(operatorType) { }

        public static implicit operator UnaryOperator(Op operatorType) => new UnaryOperator(operatorType);

        private double ApplyDefaultOperator(double operand)
        {
            switch (OperatorType)
            {
                case Op.UnaryNegation:
                    return -operand;
                default:
                    throw new NotSupportedException();
            }
        }
        private bool ApplyDefaultOperator(bool operand)
        {
            switch (OperatorType)
            {
                case Op.LogicalNot:
                    return !operand;
                default:
                    throw new NotSupportedException();
            }

        }

        internal object Evaluate(object operand)
        {
            if (ReferenceEquals(operand, null))
            {
                return EvaluateWithNullArguments();
            }

            var @operator = GetUserDefinedOperator(operand);

            if (@operator == null)
            {
                // Fall back to predefined operator.
                // We simply apply any numeric operations with values converted to doubles.
                if ((SupportedOperands & Operands.Number) == Operands.Number)
                {
                    // This operator supports two numeric arguments.
                    if (DoesImplicitConversionExist(operand.GetType(), typeof(double), true))
                    {
                        return ApplyDefaultOperator((double)DoImplicitConversion(operand, typeof(double)));
                    }
                }

                if ((SupportedOperands & Operands.Boolean) == Operands.Boolean)
                {
                    // This operator supports two boolean arguments.
                    if (operand is bool boolean)
                    {
                        return ApplyDefaultOperator(boolean);
                    }
                }

                throw InvalidOperator(OperatorSymbols, operand);
            }
            else
            {
                // Invoke the operator!
                return @operator.Invoke(null, new[] { operand });
            }
        }
    }
    internal sealed class BinaryOperator : Operator
    {
        private BinaryOperator(Op operatorType) : base(operatorType) { }

        public static implicit operator BinaryOperator(Op operatorType) => new BinaryOperator(operatorType);

        private object ApplyCustomOperator(object l, Func<object> evaluateRight)
        {
            switch (OperatorType)
            {
                case Op.NullCoalescing:
                    // There's really nothing special going on here with type conversion. This way we only evaluate the right syntax tree if the left returns null.
                    return l ?? evaluateRight();
                case Op.And:
                case Op.Or:
                    // "&" and "|" operators are special, because we're trying to evaluate them as though they were "&&" and "||" Operators.
                    // This means that we might not need to evaluate the right tree.
                    // See https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#conditional-logical-operators

                    object EvaluateRightAsBool(bool convertToBool)
                    {
                        var r = evaluateRight();
                        var tryConvert = TryConvertToBool(r);

                        if (tryConvert == null && !ReferenceEquals(r, null))
                        {
                            // We can't convert the operand to a boolean.
                            throw InvalidOperator(OperatorSymbols, l, r);
                        }
                        return convertToBool ? tryConvert : r;
                    }

                    var x = TryConvertToBool(l);

                    if (x.HasValue || l == null)
                    {
                        // We might need to evaluate the right operand.
                        if (l == null || x.Value == (OperatorType == Op.And))
                        {
                            var r = evaluateRight();

                            // Is there an "&" operator? If l is null, we'll check for an "&" operator between r & r.
                            var @operator = GetUserDefinedOperator(l ?? r, r);

                            if (@operator != null)
                            {
                                // If so, evaluate the operator.
                                return @operator.Invoke(null, new[] { l, r });
                            }
                        }

                        // If not, evaluate it 
                        switch (OperatorType)
                        {
                            case Op.And:
                                if (x.HasValue)
                                {
                                    return x.Value ? EvaluateRightAsBool(l is bool) : l;
                                }
                                else
                                {
                                    var r = EvaluateRightAsBool(false);
                                    return TryConvertToBool(r) == false ? r : null;
                                }
                            case Op.Or:
                                if (x.HasValue)
                                {
                                    return x.Value ? l : EvaluateRightAsBool(l is bool);
                                }
                                else
                                {
                                    var r = EvaluateRightAsBool(false);
                                    return TryConvertToBool(r) == true ? r : null;
                                }
                            default:
                                throw new NotSupportedException();
                        }
                    }
                    else
                    {
                        // The first operand doesn't convert to a boolean. We can't use "&&" on it.
                        throw InvalidOperator(OperatorSymbols, l, evaluateRight());
                    }
                default:
                    throw new NotSupportedException();
            }
        }
        private object ApplyDefaultOperator(double? x, double? y)
        {
            switch (OperatorType)
            {
                case Op.Exponentiation:
                    return (!x.HasValue || !y.HasValue) ? new double?() : Math.Pow(x.Value, y.Value);
                case Op.Addition:
                    return x + y;
                case Op.Subtraction:
                    return x - y;
                case Op.Multiplication:
                    return x * y;
                case Op.Division:
                    return x / y;
                case Op.Remainder:
                    return x % y;
                case Op.Equality:
                    return x == y;
                case Op.Inequality:
                    return x != y;
                case Op.LessThan:
                    return x < y;
                case Op.LessThanOrEqual:
                    return x <= y;
                case Op.GreaterThan:
                    return x > y;
                case Op.GreaterThanOrEqual:
                    return x >= y;
                default:
                    throw new NotSupportedException();
            }
        }
        private object ApplyDefaultOperator(string x, string y)
        {
            switch (OperatorType)
            {
                case Op.Addition:
                    return x + y;
                case Op.Inequality:
                    return x != y;
                case Op.Equality:
                    return x == y;
                default:
                    throw new NotSupportedException();
            }
        }
        private string ApplyDefaultOperator(object x, string y)
        {
            switch (OperatorType)
            {
                case Op.Addition:
                    return x + y;
                default:
                    throw new NotSupportedException();
            }
        }
        private string ApplyDefaultOperator(string x, object y)
        {
            switch (OperatorType)
            {
                case Op.Addition:
                    return x + y;
                default:
                    throw new NotSupportedException();
            }
        }
        private bool? ApplyDefaultOperator(bool? x, bool? y)
        {
            switch (OperatorType)
            {
                case Op.Inequality:
                    return x != y;
                case Op.Equality:
                    return x == y;
                default:
                    throw new NotSupportedException();
            }
        }
        private bool? ApplyDefaultOperator(object x, object y)
        {
            switch (OperatorType)
            {
                case Op.Inequality:
                    return x != y;
                case Op.Equality:
                    return x == y;
                default:
                    throw new NotSupportedException();
            }
        }

        private object Evaluate(object x, Func<object> evaluateRight)
        {
            if (SupportedOperands == Operands.CompletelyCustom)
            {
                return ApplyCustomOperator(x, evaluateRight);
            }

            var y = evaluateRight();

            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return EvaluateWithNullArguments();
            }

            var @operator = GetUserDefinedOperator(x, y);

            if (@operator == null)
            {
                // Fall back to predefined operator.
                // We simply apply any numeric operations with values converted to doubles.
                if ((SupportedOperands & Operands.Number) == Operands.Number)
                {
                    // This operator supports two numeric arguments.
                    if (DoesImplicitConversionExist(x?.GetType(), typeof(double), true) &&
                        DoesImplicitConversionExist(y?.GetType(), typeof(double), true))
                    {
                        return ApplyDefaultOperator(x == null ? null : (double?)DoImplicitConversion(x, typeof(double?)),
                            y == null ? null : (double?)DoImplicitConversion(y, typeof(double?)));
                    }
                }

                if ((SupportedOperands & Operands.Boolean) == Operands.Boolean)
                {
                    // This operator supports two boolean arguments.
                    if ((x is bool || x == null) && (y is bool || y == null))
                    {
                        return ApplyDefaultOperator((bool?)x, (bool?)y);
                    }
                }

                if (x is string || y is string)
                {
                    if ((SupportedOperands & Operands.String) == Operands.String && x is string xStr && y is string yStr)
                    {
                        // This operator supports two string arguments.
                        return ApplyDefaultOperator(xStr, yStr);
                    }

                    if ((SupportedOperands & Operands.StringObject) == Operands.StringObject)
                    {
                        // This operator supports one string and one object operand
                        if (x is string xStr2)
                        {
                            return ApplyDefaultOperator(xStr2, y);
                        }
                        else
                        {
                            return ApplyDefaultOperator(x, (string)y);
                        }
                    }
                }

                if ((SupportedOperands & Operands.Object) == Operands.Object)
                {
                    // This operator supports any arbitrary operands.
                    return ApplyDefaultOperator(x, y);
                }

                throw InvalidOperator(OperatorSymbols, x, y);
            }
            else
            {
                // Invoke the operator!
                return @operator.Invoke(null, new[] { x, y });
            }
        }
        public object Evaluate(object x, object y) => Evaluate(x, () => y);
        public object Evaluate(AbstractSyntaxTree left, AbstractSyntaxTree right, CultureInfo cultureInfo, object[] parameters)
        {
            return Evaluate(left.Evaluate(cultureInfo, parameters), () => right.Evaluate(cultureInfo, parameters));
        }
    }
    /// <summary>
    /// The ternary "?:" operator.
    /// It is designed to work like the "?:" operator.
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#conditional-operator"/>
    /// </summary>
    internal static class TernaryOperator
    {
        public static object Evaluate(AbstractSyntaxTree condition, AbstractSyntaxTree positive, AbstractSyntaxTree negative, CultureInfo cultureInfo, object[] parameters)
        {
            var conditionObj = condition.Evaluate(cultureInfo, parameters);
            var conditionBool = Operator.TryConvertToBool(conditionObj);

            if (conditionBool.HasValue)
            {
                return (conditionBool.Value ? positive : negative).Evaluate(cultureInfo, parameters);
            }
            else
            {
                throw Operator.InvalidOperator("?:", conditionObj, new object(), new object());
            }
        }
    }
}