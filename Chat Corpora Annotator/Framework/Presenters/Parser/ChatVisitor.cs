//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Chat.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ChatParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IChatVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQuery([NotNull] ChatParser.QueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBody([NotNull] ChatParser.BodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.restriction_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRestriction_expr([NotNull] ChatParser.Restriction_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.restriction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRestriction([NotNull] ChatParser.RestrictionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] ChatParser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.hdict"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHdict([NotNull] ChatParser.HdictContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.huser"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHuser([NotNull] ChatParser.HuserContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ChatParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] ChatParser.NumberContext context);
}
