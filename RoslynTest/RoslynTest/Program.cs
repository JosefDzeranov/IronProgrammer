using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ConstructionCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceCode = @"int a = Convert.ToInt16(Console.ReadLine());
            int b = Convert.ToInt16(Console.ReadLine());
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
            ";

            //or parsefile etc
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            string[] identifierNames = syntaxTree.GetRoot().DescendantNodes()
                .OfType<VariableDeclaratorSyntax>().Select(v => v.Identifier.Text)
                .Concat(syntaxTree.GetRoot().DescendantNodes().OfType<ParameterSyntax>().Select(p => p.Identifier.Text))
                .ToArray();

            foreach (var VARIABLE in identifierNames)
            {
                Console.WriteLine(VARIABLE);
            }
        }

    }

}