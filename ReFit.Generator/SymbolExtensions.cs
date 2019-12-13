using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace ReFit.Generator
{
    internal static class SymbolExtensions
    {
        public static IEnumerable<IMethodSymbol> GetAllInterfaceMethods(this INamedTypeSymbol symbol)
        {
            foreach(var member in symbol.GetAllInterfaces(includeCurrent: false).SelectMany(GetAllInterfaceMethods))
            {
                yield return member;
            }

            foreach (var member in symbol.GetMethods())
            {
                yield return member;
            }
        }
    }
}
