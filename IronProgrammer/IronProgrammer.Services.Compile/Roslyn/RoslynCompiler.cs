﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronProgrammer.Common;
using IronProgrammer.Services.Compile.Helpers;
using IronProgrammer.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace IronProgrammer.Services.Compile.Roslyn
{
    /// <inheritdoc />
    /// <summary>
    /// Компилятор, который использует компилятор Roslyn. (<see cref="T:Microsoft.CodeAnalysis.CSharp.CSharpCompilation" />).
    /// </summary>
    public class RoslynCompiler : ICompiler
    {
        /// <summary>
        /// Получает параметры компиляции.
        /// </summary>
        private static readonly CSharpCompilationOptions Options = new CSharpCompilationOptions(
                 OutputKind.ConsoleApplication)
             .WithOverflowChecks(true)
             .WithOptimizationLevel(OptimizationLevel.Release)
             .WithUsings(DefaultValues.SystemNamespaces);

        /// <inheritdoc />
        /// <summary>
        /// Компилирует указанный код в указанные места сборки.
        /// </summary>
        /// <param name="source">Исходный код</param>
        /// <param name="exeName">Имя полученного исполняемого файла</param>
        ///  <param name="assemblyLocations">Расположение сборок, которые нужны при компиляции исходного кода</param>
        /// <returns />
        /// Результат компиляции
        /// <exception cref="T:IronProgrammer.Services.Compile.Roslyn.RoslynCompilationException">Assembly could not be created.</exception>
        public CompileResult Compile(string source, string exeName, List<string> assemblyLocations)
        {
            assemblyLocations.AddRange(DefaultValues.DefaultAssemblies);
            var references = assemblyLocations.Select(l => MetadataReference.CreateFromFile(string.Format(DefaultValues.RuntimePath, l)));

            var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6));

            var compilation = CSharpCompilation.Create(exeName, new SyntaxTree[] { parsedSyntaxTree }, references, Options);
            try
            {
                return compilation.Emit(DefaultValues.CompilePath + exeName).ToCompileResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Строит синтаксическое дерево.
        /// </summary>
        /// <param name="text">Исходный код</param>
        /// <param name="filename">Имя файла</param>
        /// <param name="options">Дополнительный опции</param>
        /// <returns>Синтакическое дерево</returns>
        private static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text, Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }
    }
}
