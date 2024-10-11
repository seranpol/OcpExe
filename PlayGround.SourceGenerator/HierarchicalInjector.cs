using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Data;
using System.Text;
namespace PlayGround.SourceGenerator;

[Generator]
public class HierarchicalInjector : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var compilationProvider = context.CompilationProvider;

        

        var classes = context.SyntaxProvider.CreateSyntaxProvider(static (node, _) => 
            node is ClassDeclarationSyntax, static (ctx, _) => (ClassDeclarationSyntax)ctx.Node);

        var compilationAndClasses = compilationProvider.Combine(classes.Collect());

        context.RegisterSourceOutput(compilationAndClasses, static (ctx, tuple) =>
        {
            var (compilation, classes) = tuple;
            foreach (var classDeclaration in classes)
            {
                var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
                Execute(ctx, classDeclaration, semanticModel);
            }
        });
    }

    private static void Execute(SourceProductionContext context, ClassDeclarationSyntax classDeclarationSyntax, SemanticModel semanticModel)
    {   
        if (ClassIsPartialDeclared(classDeclarationSyntax) == false)
            return;

        if (NamespaceContainsView(classDeclarationSyntax) == false)
            return;
                
        var namespaceName = GetFirstParent<BaseNamespaceDeclarationSyntax>(classDeclarationSyntax).Name.ToString();
        var className = classDeclarationSyntax.Identifier.Text;
        var fileName = $"{namespaceName}.{className}.g.cs";
        

        var source = GeneratePartialClass(namespaceName, className);
        context.AddSource(fileName, source);
    }

    private static string GeneratePartialClass(string namespaceName, string className)
    {
        StringBuilder sb = new();
        sb.Append($@"
namespace {namespaceName}
{{
    partial class {className}
    {{

        public static void Register()
        {{
            PlayGround.Bootstrap.Register(typeof( {namespaceName}.{className}));
        }}

        public {className}()
        {{
            // some comment
        }}
    }}
}}
");
        return sb.ToString();
    }



    #region private

    private static bool ClassIsPartialDeclared(ClassDeclarationSyntax classDeclarationSyntax) => classDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword);

    private static bool NamespaceContainsView(ClassDeclarationSyntax classDeclarationSyntax) => GetFirstParent<NamespaceDeclarationSyntax>(classDeclarationSyntax).Name.ToString().Contains("View");

    private static TNode GetFirstParent<TNode>(SyntaxNode child) where TNode : SyntaxNode
    {
        SyntaxNode currentNode = child; 
        while (currentNode.Parent != null)
        {
            currentNode = currentNode.Parent;
            if(currentNode is TNode node)
            {
                return node;
            }
        }

        throw new InvalidOperationException();
    }

    #endregion private
}
