
#line  1 "cs.ATG" 
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using ICSharpCode.NRefactory.Parser;
using ICSharpCode.NRefactory.Ast;
using ASTAttribute = ICSharpCode.NRefactory.Ast.Attribute;
using Types = ICSharpCode.NRefactory.Ast.ClassType;
/*
  Parser.frame file for NRefactory.
 */
using System;
using System.Reflection;

namespace ICSharpCode.NRefactory.Parser.CSharp {



partial class Parser : AbstractParser
{
	const int maxT = 145;

	const  bool   T            = true;
	const  bool   x            = false;
	

#line  18 "cs.ATG" 


/*

*/

	void CS() {

#line  180 "cs.ATG" 
		lexer.NextToken(); // get the first token
		compilationUnit = new CompilationUnit();
		BlockStart(compilationUnit);
		
		while (la.kind == 71) {
			ExternAliasDirective();
		}
		while (la.kind == 121) {
			UsingDirective();
		}
		while (
#line  187 "cs.ATG" 
IsGlobalAttrTarget()) {
			GlobalAttributeSection();
		}
		while (StartOf(1)) {
			NamespaceMemberDecl();
		}
		Expect(0);
	}

	void ExternAliasDirective() {

#line  360 "cs.ATG" 
		ExternAliasDirective ead = new ExternAliasDirective { StartLocation = la.Location }; 
		Expect(71);
		Identifier();

#line  363 "cs.ATG" 
		if (t.val != "alias") Error("Expected 'extern alias'."); 
		Identifier();

#line  364 "cs.ATG" 
		ead.Name = t.val; 
		Expect(11);

#line  365 "cs.ATG" 
		ead.EndLocation = t.EndLocation; 

#line  366 "cs.ATG" 
		AddChild(ead); 
	}

	void UsingDirective() {

#line  194 "cs.ATG" 
		string qualident = null; TypeReference aliasedType = null;
		string alias = null;
		
		Expect(121);

#line  198 "cs.ATG" 
		Location startPos = t.Location; 
		if (
#line  199 "cs.ATG" 
IdentAndDoubleColon()) {
			Identifier();

#line  199 "cs.ATG" 
			alias = t.val; 
			Expect(10);
		}
		Qualident(
#line  200 "cs.ATG" 
out qualident);
		if (la.kind == 3) {
			lexer.NextToken();
			NonArrayType(
#line  201 "cs.ATG" 
out aliasedType);
		}
		Expect(11);

#line  203 "cs.ATG" 
		if (qualident != null && qualident.Length > 0) {
		 string name = (alias != null && alias != "global") ? alias + "." + qualident : qualident;
		 INode node;
		 if (aliasedType != null) {
		     node = new UsingDeclaration(name, aliasedType);
		 } else {
		     node = new UsingDeclaration(name);
		 }
		 node.StartLocation = startPos;
		 node.EndLocation   = t.EndLocation;
		 AddChild(node);
		}
		
	}

	void GlobalAttributeSection() {
		Expect(18);

#line  220 "cs.ATG" 
		Location startPos = t.Location; 
		Identifier();

#line  221 "cs.ATG" 
		if (t.val != "assembly" && t.val != "module") Error("global attribute target specifier (assembly or module) expected");
		string attributeTarget = t.val;
		List<ASTAttribute> attributes = new List<ASTAttribute>();
		ASTAttribute attribute;
		
		Expect(9);
		Attribute(
#line  226 "cs.ATG" 
out attribute);

#line  226 "cs.ATG" 
		attributes.Add(attribute); 
		while (
#line  227 "cs.ATG" 
NotFinalComma()) {
			Expect(14);
			Attribute(
#line  227 "cs.ATG" 
out attribute);

#line  227 "cs.ATG" 
			attributes.Add(attribute); 
		}
		if (la.kind == 14) {
			lexer.NextToken();
		}
		Expect(19);

#line  229 "cs.ATG" 
		AttributeSection section = new AttributeSection {
		   AttributeTarget = attributeTarget,
		   Attributes = attributes,
		   StartLocation = startPos,
		   EndLocation = t.EndLocation
		};
		AddChild(section);
		
	}

	void NamespaceMemberDecl() {

#line  333 "cs.ATG" 
		AttributeSection section;
		List<AttributeSection> attributes = new List<AttributeSection>();
		ModifierList m = new ModifierList();
		string qualident;
		
		if (la.kind == 88) {
			lexer.NextToken();

#line  339 "cs.ATG" 
			Location startPos = t.Location; 
			Qualident(
#line  340 "cs.ATG" 
out qualident);

#line  340 "cs.ATG" 
			INode node =  new NamespaceDeclaration(qualident);
			node.StartLocation = startPos;
			AddChild(node);
			BlockStart(node);
			
			Expect(16);
			while (la.kind == 71) {
				ExternAliasDirective();
			}
			while (la.kind == 121) {
				UsingDirective();
			}
			while (StartOf(1)) {
				NamespaceMemberDecl();
			}
			Expect(17);
			if (la.kind == 11) {
				lexer.NextToken();
			}

#line  350 "cs.ATG" 
			node.EndLocation   = t.EndLocation;
			BlockEnd();
			
		} else if (StartOf(2)) {
			while (la.kind == 18) {
				AttributeSection(
#line  354 "cs.ATG" 
out section);

#line  354 "cs.ATG" 
				attributes.Add(section); 
			}
			while (StartOf(3)) {
				TypeModifier(
#line  355 "cs.ATG" 
m);
			}
			TypeDecl(
#line  356 "cs.ATG" 
m, attributes);
		} else SynErr(146);
	}

	void Identifier() {
		switch (la.kind) {
		case 1: {
			lexer.NextToken();
			break;
		}
		case 126: {
			lexer.NextToken();
			break;
		}
		case 127: {
			lexer.NextToken();
			break;
		}
		case 128: {
			lexer.NextToken();
			break;
		}
		case 129: {
			lexer.NextToken();
			break;
		}
		case 130: {
			lexer.NextToken();
			break;
		}
		case 131: {
			lexer.NextToken();
			break;
		}
		case 132: {
			lexer.NextToken();
			break;
		}
		case 133: {
			lexer.NextToken();
			break;
		}
		case 134: {
			lexer.NextToken();
			break;
		}
		case 135: {
			lexer.NextToken();
			break;
		}
		case 136: {
			lexer.NextToken();
			break;
		}
		case 137: {
			lexer.NextToken();
			break;
		}
		case 138: {
			lexer.NextToken();
			break;
		}
		case 139: {
			lexer.NextToken();
			break;
		}
		case 140: {
			lexer.NextToken();
			break;
		}
		case 141: {
			lexer.NextToken();
			break;
		}
		case 142: {
			lexer.NextToken();
			break;
		}
		case 143: {
			lexer.NextToken();
			break;
		}
		case 144: {
			lexer.NextToken();
			break;
		}
		default: SynErr(147); break;
		}
	}

	void Qualident(
#line  490 "cs.ATG" 
out string qualident) {
		Identifier();

#line  492 "cs.ATG" 
		qualidentBuilder.Length = 0; qualidentBuilder.Append(t.val); 
		while (
#line  493 "cs.ATG" 
DotAndIdent()) {
			Expect(15);
			Identifier();

#line  493 "cs.ATG" 
			qualidentBuilder.Append('.');
			qualidentBuilder.Append(t.val); 
			
		}

#line  496 "cs.ATG" 
		qualident = qualidentBuilder.ToString(); 
	}

	void NonArrayType(
#line  608 "cs.ATG" 
out TypeReference type) {

#line  610 "cs.ATG" 
		Location startPos = la.Location;
		string name;
		int pointer = 0;
		type = null;
		
		if (StartOf(4)) {
			ClassType(
#line  616 "cs.ATG" 
out type, false);
		} else if (StartOf(5)) {
			SimpleType(
#line  617 "cs.ATG" 
out name);

#line  617 "cs.ATG" 
			type = new TypeReference(name, true); 
		} else if (la.kind == 123) {
			lexer.NextToken();
			Expect(6);

#line  618 "cs.ATG" 
			pointer = 1; type = new TypeReference("System.Void", true); 
		} else SynErr(148);
		if (la.kind == 12) {
			NullableQuestionMark(
#line  621 "cs.ATG" 
ref type);
		}
		while (
#line  623 "cs.ATG" 
IsPointer()) {
			Expect(6);

#line  624 "cs.ATG" 
			++pointer; 
		}

#line  626 "cs.ATG" 
		if (type != null) {
		type.PointerNestingLevel = pointer; 
		type.EndLocation = t.EndLocation;
		type.StartLocation = startPos;
		} 
		
	}

	void Attribute(
#line  239 "cs.ATG" 
out ASTAttribute attribute) {

#line  240 "cs.ATG" 
		string qualident;
		string alias = null;
		

#line  244 "cs.ATG" 
		Location startPos = la.Location; 
		if (
#line  245 "cs.ATG" 
IdentAndDoubleColon()) {
			Identifier();

#line  246 "cs.ATG" 
			alias = t.val; 
			Expect(10);
		}
		Qualident(
#line  249 "cs.ATG" 
out qualident);

#line  250 "cs.ATG" 
		List<Expression> positional = new List<Expression>();
		List<NamedArgumentExpression> named = new List<NamedArgumentExpression>();
		string name = (alias != null && alias != "global") ? alias + "." + qualident : qualident;
		
		if (la.kind == 20) {
			AttributeArguments(
#line  254 "cs.ATG" 
positional, named);
		}

#line  255 "cs.ATG" 
		attribute = new ASTAttribute(name, positional, named); 
		attribute.StartLocation = startPos;
		attribute.EndLocation = t.EndLocation;
		
	}

	void AttributeArguments(
#line  261 "cs.ATG" 
List<Expression> positional, List<NamedArgumentExpression> named) {
		Expect(20);
		if (StartOf(6)) {
			AttributeArgument(
#line  265 "cs.ATG" 
positional, named);
			while (la.kind == 14) {
				lexer.NextToken();
				AttributeArgument(
#line  268 "cs.ATG" 
positional, named);
			}
		}
		Expect(21);
	}

	void AttributeArgument(
#line  274 "cs.ATG" 
List<Expression> positional, List<NamedArgumentExpression> named) {

#line  275 "cs.ATG" 
		string name = null; bool isNamed = false; Expression expr; Location startLocation = la.Location; 
		if (
#line  278 "cs.ATG" 
IsAssignment()) {

#line  278 "cs.ATG" 
			isNamed = true; 
			Identifier();

#line  279 "cs.ATG" 
			name = t.val; 
			Expect(3);
		} else if (
#line  282 "cs.ATG" 
IdentAndColon()) {
			Identifier();

#line  283 "cs.ATG" 
			name = t.val; 
			Expect(9);
		} else if (StartOf(6)) {
		} else SynErr(149);
		Expr(
#line  287 "cs.ATG" 
out expr);

#line  289 "cs.ATG" 
		if (expr != null) {
		if (isNamed) {
			named.Add(new NamedArgumentExpression(name, expr) { StartLocation = startLocation, EndLocation = t.EndLocation });
		} else {
			if (named.Count > 0)
				Error("positional argument after named argument is not allowed");
			if (name != null)
				expr = new NamedArgumentExpression(name, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };
			positional.Add(expr);
		}
		}
		
	}

	void Expr(
#line  1788 "cs.ATG" 
out Expression expr) {

#line  1789 "cs.ATG" 
		expr = null; Expression expr1 = null, expr2 = null; AssignmentOperatorType op; 

#line  1791 "cs.ATG" 
		Location startLocation = la.Location; 
		UnaryExpr(
#line  1792 "cs.ATG" 
out expr);
		if (StartOf(7)) {
			AssignmentOperator(
#line  1795 "cs.ATG" 
out op);
			Expr(
#line  1795 "cs.ATG" 
out expr1);

#line  1795 "cs.ATG" 
			expr = new AssignmentExpression(expr, op, expr1); 
		} else if (
#line  1796 "cs.ATG" 
la.kind == Tokens.GreaterThan && Peek(1).kind == Tokens.GreaterEqual) {
			AssignmentOperator(
#line  1797 "cs.ATG" 
out op);
			Expr(
#line  1797 "cs.ATG" 
out expr1);

#line  1797 "cs.ATG" 
			expr = new AssignmentExpression(expr, op, expr1); 
		} else if (StartOf(8)) {
			ConditionalOrExpr(
#line  1799 "cs.ATG" 
ref expr);
			if (la.kind == 13) {
				lexer.NextToken();
				Expr(
#line  1800 "cs.ATG" 
out expr1);

#line  1800 "cs.ATG" 
				expr = new BinaryOperatorExpression(expr, BinaryOperatorType.NullCoalescing, expr1); 
			}
			if (la.kind == 12) {
				lexer.NextToken();
				Expr(
#line  1801 "cs.ATG" 
out expr1);
				Expect(9);
				Expr(
#line  1801 "cs.ATG" 
out expr2);

#line  1801 "cs.ATG" 
				expr = new ConditionalExpression(expr, expr1, expr2);  
			}
		} else SynErr(150);

#line  1804 "cs.ATG" 
		if (expr != null) {
		if (expr.StartLocation.IsEmpty)
			expr.StartLocation = startLocation;
		if (expr.EndLocation.IsEmpty)
			expr.EndLocation = t.EndLocation;
		}
		
	}

	void AttributeSection(
#line  303 "cs.ATG" 
out AttributeSection section) {

#line  305 "cs.ATG" 
		string attributeTarget = "";
		List<ASTAttribute> attributes = new List<ASTAttribute>();
		ASTAttribute attribute;
		
		
		Expect(18);

#line  311 "cs.ATG" 
		Location startPos = t.Location; 
		if (
#line  312 "cs.ATG" 
IsLocalAttrTarget()) {
			if (la.kind == 69) {
				lexer.NextToken();

#line  313 "cs.ATG" 
				attributeTarget = "event";
			} else if (la.kind == 101) {
				lexer.NextToken();

#line  314 "cs.ATG" 
				attributeTarget = "return";
			} else {
				Identifier();

#line  315 "cs.ATG" 
				attributeTarget = t.val; 
			}
			Expect(9);
		}
		Attribute(
#line  319 "cs.ATG" 
out attribute);

#line  319 "cs.ATG" 
		attributes.Add(attribute); 
		while (
#line  320 "cs.ATG" 
NotFinalComma()) {
			Expect(14);
			Attribute(
#line  320 "cs.ATG" 
out attribute);

#line  320 "cs.ATG" 
			attributes.Add(attribute); 
		}
		if (la.kind == 14) {
			lexer.NextToken();
		}
		Expect(19);

#line  322 "cs.ATG" 
		section = new AttributeSection {
		   AttributeTarget = attributeTarget,
		   Attributes = attributes,
		   StartLocation = startPos,
		   EndLocation = t.EndLocation
		};
		
	}

	void TypeModifier(
#line  693 "cs.ATG" 
ModifierList m) {
		switch (la.kind) {
		case 89: {
			lexer.NextToken();

#line  695 "cs.ATG" 
			m.Add(Modifiers.New, t.Location); 
			break;
		}
		case 98: {
			lexer.NextToken();

#line  696 "cs.ATG" 
			m.Add(Modifiers.Public, t.Location); 
			break;
		}
		case 97: {
			lexer.NextToken();

#line  697 "cs.ATG" 
			m.Add(Modifiers.Protected, t.Location); 
			break;
		}
		case 84: {
			lexer.NextToken();

#line  698 "cs.ATG" 
			m.Add(Modifiers.Internal, t.Location); 
			break;
		}
		case 96: {
			lexer.NextToken();

#line  699 "cs.ATG" 
			m.Add(Modifiers.Private, t.Location); 
			break;
		}
		case 119: {
			lexer.NextToken();

#line  700 "cs.ATG" 
			m.Add(Modifiers.Unsafe, t.Location); 
			break;
		}
		case 49: {
			lexer.NextToken();

#line  701 "cs.ATG" 
			m.Add(Modifiers.Abstract, t.Location); 
			break;
		}
		case 103: {
			lexer.NextToken();

#line  702 "cs.ATG" 
			m.Add(Modifiers.Sealed, t.Location); 
			break;
		}
		case 107: {
			lexer.NextToken();

#line  703 "cs.ATG" 
			m.Add(Modifiers.Static, t.Location); 
			break;
		}
		case 126: {
			lexer.NextToken();

#line  704 "cs.ATG" 
			m.Add(Modifiers.Partial, t.Location); 
			break;
		}
		default: SynErr(151); break;
		}
	}

	void TypeDecl(
#line  369 "cs.ATG" 
ModifierList m, List<AttributeSection> attributes) {

#line  371 "cs.ATG" 
		TypeReference type;
		List<TypeReference> names;
		List<ParameterDeclarationExpression> p = new List<ParameterDeclarationExpression>();
		string name;
		List<TemplateDefinition> templates;
		
		if (la.kind == 59) {

#line  377 "cs.ATG" 
			m.Check(Modifiers.Classes); 
			lexer.NextToken();

#line  378 "cs.ATG" 
			TypeDeclaration newType = new TypeDeclaration(m.Modifier, attributes);
			templates = newType.Templates;
			AddChild(newType);
			BlockStart(newType);
			newType.StartLocation = m.GetDeclarationLocation(t.Location);
			
			newType.Type = Types.Class;
			
			Identifier();

#line  386 "cs.ATG" 
			newType.Name = t.val; 
			if (la.kind == 23) {
				TypeParameterList(
#line  389 "cs.ATG" 
templates);
			}
			if (la.kind == 9) {
				ClassBase(
#line  391 "cs.ATG" 
out names);

#line  391 "cs.ATG" 
				newType.BaseTypes = names; 
			}
			while (la.kind == 127) {
				TypeParameterConstraintsClause(
#line  394 "cs.ATG" 
templates);
			}

#line  396 "cs.ATG" 
			newType.BodyStartLocation = t.EndLocation; 
			Expect(16);
			ClassBody();
			Expect(17);
			if (la.kind == 11) {
				lexer.NextToken();
			}

#line  400 "cs.ATG" 
			newType.EndLocation = t.EndLocation; 
			BlockEnd();
			
		} else if (StartOf(9)) {

#line  403 "cs.ATG" 
			m.Check(Modifiers.StructsInterfacesEnumsDelegates); 
			if (la.kind == 109) {
				lexer.NextToken();

#line  404 "cs.ATG" 
				TypeDeclaration newType = new TypeDeclaration(m.Modifier, attributes);
				templates = newType.Templates;
				newType.StartLocation = m.GetDeclarationLocation(t.Location);
				AddChild(newType);
				BlockStart(newType);
				newType.Type = Types.Struct; 
				
				Identifier();

#line  411 "cs.ATG" 
				newType.Name = t.val; 
				if (la.kind == 23) {
					TypeParameterList(
#line  414 "cs.ATG" 
templates);
				}
				if (la.kind == 9) {
					StructInterfaces(
#line  416 "cs.ATG" 
out names);

#line  416 "cs.ATG" 
					newType.BaseTypes = names; 
				}
				while (la.kind == 127) {
					TypeParameterConstraintsClause(
#line  419 "cs.ATG" 
templates);
				}

#line  422 "cs.ATG" 
				newType.BodyStartLocation = t.EndLocation; 
				StructBody();
				if (la.kind == 11) {
					lexer.NextToken();
				}

#line  424 "cs.ATG" 
				newType.EndLocation = t.EndLocation; 
				BlockEnd();
				
			} else if (la.kind == 83) {
				lexer.NextToken();

#line  428 "cs.ATG" 
				TypeDeclaration newType = new TypeDeclaration(m.Modifier, attributes);
				templates = newType.Templates;
				AddChild(newType);
				BlockStart(newType);
				newType.StartLocation = m.GetDeclarationLocation(t.Location);
				newType.Type = Types.Interface;
				
				Identifier();

#line  435 "cs.ATG" 
				newType.Name = t.val; 
				if (la.kind == 23) {
					TypeParameterList(
#line  438 "cs.ATG" 
templates);
				}
				if (la.kind == 9) {
					InterfaceBase(
#line  440 "cs.ATG" 
out names);

#line  440 "cs.ATG" 
					newType.BaseTypes = names; 
				}
				while (la.kind == 127) {
					TypeParameterConstraintsClause(
#line  443 "cs.ATG" 
templates);
				}

#line  445 "cs.ATG" 
				newType.BodyStartLocation = t.EndLocation; 
				InterfaceBody();
				if (la.kind == 11) {
					lexer.NextToken();
				}

#line  447 "cs.ATG" 
				newType.EndLocation = t.EndLocation; 
				BlockEnd();
				
			} else if (la.kind == 68) {
				lexer.NextToken();

#line  451 "cs.ATG" 
				TypeDeclaration newType = new TypeDeclaration(m.Modifier, attributes);
				AddChild(newType);
				BlockStart(newType);
				newType.StartLocation = m.GetDeclarationLocation(t.Location);
				newType.Type = Types.Enum;
				
				Identifier();

#line  457 "cs.ATG" 
				newType.Name = t.val; 
				if (la.kind == 9) {
					lexer.NextToken();
					IntegralType(
#line  458 "cs.ATG" 
out name);

#line  458 "cs.ATG" 
					newType.BaseTypes.Add(new TypeReference(name, true)); 
				}

#line  460 "cs.ATG" 
				newType.BodyStartLocation = t.EndLocation; 
				EnumBody();
				if (la.kind == 11) {
					lexer.NextToken();
				}

#line  462 "cs.ATG" 
				newType.EndLocation = t.EndLocation; 
				BlockEnd();
				
			} else {
				lexer.NextToken();

#line  466 "cs.ATG" 
				DelegateDeclaration delegateDeclr = new DelegateDeclaration(m.Modifier, attributes);
				templates = delegateDeclr.Templates;
				delegateDeclr.StartLocation = m.GetDeclarationLocation(t.Location);
				
				if (
#line  470 "cs.ATG" 
NotVoidPointer()) {
					Expect(123);

#line  470 "cs.ATG" 
					delegateDeclr.ReturnType = new TypeReference("System.Void", true); 
				} else if (StartOf(10)) {
					Type(
#line  471 "cs.ATG" 
out type);

#line  471 "cs.ATG" 
					delegateDeclr.ReturnType = type; 
				} else SynErr(152);
				Identifier();

#line  473 "cs.ATG" 
				delegateDeclr.Name = t.val; 
				if (la.kind == 23) {
					TypeParameterList(
#line  476 "cs.ATG" 
templates);
				}
				Expect(20);
				if (StartOf(11)) {
					FormalParameterList(
#line  478 "cs.ATG" 
p);

#line  478 "cs.ATG" 
					delegateDeclr.Parameters = p; 
				}
				Expect(21);
				while (la.kind == 127) {
					TypeParameterConstraintsClause(
#line  482 "cs.ATG" 
templates);
				}
				Expect(11);

#line  484 "cs.ATG" 
				delegateDeclr.EndLocation = t.EndLocation;
				AddChild(delegateDeclr);
				
			}
		} else SynErr(153);
	}

	void TypeParameterList(
#line  2360 "cs.ATG" 
List<TemplateDefinition> templates) {

#line  2362 "cs.ATG" 
		TemplateDefinition template;
		
		Expect(23);
		VariantTypeParameter(
#line  2366 "cs.ATG" 
out template);

#line  2366 "cs.ATG" 
		templates.Add(template); 
		while (la.kind == 14) {
			lexer.NextToken();
			VariantTypeParameter(
#line  2368 "cs.ATG" 
out template);

#line  2368 "cs.ATG" 
			templates.Add(template); 
		}
		Expect(22);
	}

	void ClassBase(
#line  499 "cs.ATG" 
out List<TypeReference> names) {

#line  501 "cs.ATG" 
		TypeReference typeRef;
		names = new List<TypeReference>();
		
		Expect(9);
		ClassType(
#line  505 "cs.ATG" 
out typeRef, false);

#line  505 "cs.ATG" 
		if (typeRef != null) { names.Add(typeRef); } 
		while (la.kind == 14) {
			lexer.NextToken();
			TypeName(
#line  506 "cs.ATG" 
out typeRef, false);

#line  506 "cs.ATG" 
			if (typeRef != null) { names.Add(typeRef); } 
		}
	}

	void TypeParameterConstraintsClause(
#line  2388 "cs.ATG" 
List<TemplateDefinition> templates) {

#line  2389 "cs.ATG" 
		string name = ""; TypeReference type; 
		Expect(127);
		Identifier();

#line  2392 "cs.ATG" 
		name = t.val; 
		Expect(9);
		TypeParameterConstraintsClauseBase(
#line  2394 "cs.ATG" 
out type);

#line  2395 "cs.ATG" 
		TemplateDefinition td = null;
		foreach (TemplateDefinition d in templates) {
			if (d.Name == name) {
				td = d;
				break;
			}
		}
		if ( td != null && type != null) { td.Bases.Add(type); }
		
		while (la.kind == 14) {
			lexer.NextToken();
			TypeParameterConstraintsClauseBase(
#line  2404 "cs.ATG" 
out type);

#line  2405 "cs.ATG" 
			td = null;
			foreach (TemplateDefinition d in templates) {
				if (d.Name == name) {
					td = d;
					break;
				}
			}
			if ( td != null && type != null) { td.Bases.Add(type); }
			
		}
	}

	void ClassBody() {

#line  510 "cs.ATG" 
		AttributeSection section; 
		while (StartOf(12)) {

#line  512 "cs.ATG" 
			List<AttributeSection> attributes = new List<AttributeSection>();
			ModifierList m = new ModifierList();
			
			while (!(StartOf(13))) {SynErr(154); lexer.NextToken(); }
			while (la.kind == 18) {
				AttributeSection(
#line  516 "cs.ATG" 
out section);

#line  516 "cs.ATG" 
				attributes.Add(section); 
			}
			MemberModifiers(
#line  517 "cs.ATG" 
m);
			ClassMemberDecl(
#line  518 "cs.ATG" 
m, attributes);
		}
	}

	void StructInterfaces(
#line  522 "cs.ATG" 
out List<TypeReference> names) {

#line  524 "cs.ATG" 
		TypeReference typeRef;
		names = new List<TypeReference>();
		
		Expect(9);
		TypeName(
#line  528 "cs.ATG" 
out typeRef, false);

#line  528 "cs.ATG" 
		if (typeRef != null) { names.Add(typeRef); } 
		while (la.kind == 14) {
			lexer.NextToken();
			TypeName(
#line  529 "cs.ATG" 
out typeRef, false);

#line  529 "cs.ATG" 
			if (typeRef != null) { names.Add(typeRef); } 
		}
	}

	void StructBody() {

#line  533 "cs.ATG" 
		AttributeSection section; 
		Expect(16);
		while (StartOf(14)) {

#line  536 "cs.ATG" 
			List<AttributeSection> attributes = new List<AttributeSection>();
			ModifierList m = new ModifierList();
			
			while (la.kind == 18) {
				AttributeSection(
#line  539 "cs.ATG" 
out section);

#line  539 "cs.ATG" 
				attributes.Add(section); 
			}
			MemberModifiers(
#line  540 "cs.ATG" 
m);
			StructMemberDecl(
#line  541 "cs.ATG" 
m, attributes);
		}
		Expect(17);
	}

	void InterfaceBase(
#line  546 "cs.ATG" 
out List<TypeReference> names) {

#line  548 "cs.ATG" 
		TypeReference typeRef;
		names = new List<TypeReference>();
		
		Expect(9);
		TypeName(
#line  552 "cs.ATG" 
out typeRef, false);

#line  552 "cs.ATG" 
		if (typeRef != null) { names.Add(typeRef); } 
		while (la.kind == 14) {
			lexer.NextToken();
			TypeName(
#line  553 "cs.ATG" 
out typeRef, false);

#line  553 "cs.ATG" 
			if (typeRef != null) { names.Add(typeRef); } 
		}
	}

	void InterfaceBody() {
		Expect(16);
		while (StartOf(15)) {
			while (!(StartOf(16))) {SynErr(155); lexer.NextToken(); }
			InterfaceMemberDecl();
		}
		Expect(17);
	}

	void IntegralType(
#line  715 "cs.ATG" 
out string name) {

#line  715 "cs.ATG" 
		name = ""; 
		switch (la.kind) {
		case 102: {
			lexer.NextToken();

#line  717 "cs.ATG" 
			name = "System.SByte"; 
			break;
		}
		case 54: {
			lexer.NextToken();

#line  718 "cs.ATG" 
			name = "System.Byte"; 
			break;
		}
		case 104: {
			lexer.NextToken();

#line  719 "cs.ATG" 
			name = "System.Int16"; 
			break;
		}
		case 120: {
			lexer.NextToken();

#line  720 "cs.ATG" 
			name = "System.UInt16"; 
			break;
		}
		case 82: {
			lexer.NextToken();

#line  721 "cs.ATG" 
			name = "System.Int32"; 
			break;
		}
		case 116: {
			lexer.NextToken();

#line  722 "cs.ATG" 
			name = "System.UInt32"; 
			break;
		}
		case 87: {
			lexer.NextToken();

#line  723 "cs.ATG" 
			name = "System.Int64"; 
			break;
		}
		case 117: {
			lexer.NextToken();

#line  724 "cs.ATG" 
			name = "System.UInt64"; 
			break;
		}
		case 57: {
			lexer.NextToken();

#line  725 "cs.ATG" 
			name = "System.Char"; 
			break;
		}
		default: SynErr(156); break;
		}
	}

	void EnumBody() {

#line  562 "cs.ATG" 
		FieldDeclaration f; 
		Expect(16);
		if (StartOf(17)) {
			EnumMemberDecl(
#line  565 "cs.ATG" 
out f);

#line  565 "cs.ATG" 
			AddChild(f); 
			while (
#line  566 "cs.ATG" 
NotFinalComma()) {
				Expect(14);
				EnumMemberDecl(
#line  567 "cs.ATG" 
out f);

#line  567 "cs.ATG" 
				AddChild(f); 
			}
			if (la.kind == 14) {
				lexer.NextToken();
			}
		}
		Expect(17);
	}

	void Type(
#line  573 "cs.ATG" 
out TypeReference type) {
		TypeWithRestriction(
#line  575 "cs.ATG" 
out type, true, false);
	}

	void FormalParameterList(
#line  645 "cs.ATG" 
List<ParameterDeclarationExpression> parameter) {

#line  648 "cs.ATG" 
		ParameterDeclarationExpression p;
		AttributeSection section;
		List<AttributeSection> attributes = new List<AttributeSection>();
		
		while (la.kind == 18) {
			AttributeSection(
#line  653 "cs.ATG" 
out section);

#line  653 "cs.ATG" 
			attributes.Add(section); 
		}
		FixedParameter(
#line  654 "cs.ATG" 
out p);

#line  654 "cs.ATG" 
		p.Attributes = attributes;
		parameter.Add(p);
		
		while (la.kind == 14) {
			lexer.NextToken();

#line  658 "cs.ATG" 
			attributes = new List<AttributeSection>(); 
			while (la.kind == 18) {
				AttributeSection(
#line  659 "cs.ATG" 
out section);

#line  659 "cs.ATG" 
				attributes.Add(section); 
			}
			FixedParameter(
#line  660 "cs.ATG" 
out p);

#line  660 "cs.ATG" 
			p.Attributes = attributes; parameter.Add(p); 
		}
	}

	void ClassType(
#line  707 "cs.ATG" 
out TypeReference typeRef, bool canBeUnbound) {

#line  708 "cs.ATG" 
		TypeReference r; typeRef = null; 
		if (StartOf(18)) {
			TypeName(
#line  710 "cs.ATG" 
out r, canBeUnbound);

#line  710 "cs.ATG" 
			typeRef = r; 
		} else if (la.kind == 91) {
			lexer.NextToken();

#line  711 "cs.ATG" 
			typeRef = new TypeReference("System.Object", true); typeRef.StartLocation = t.Location; 
		} else if (la.kind == 108) {
			lexer.NextToken();

#line  712 "cs.ATG" 
			typeRef = new TypeReference("System.String", true); typeRef.StartLocation = t.Location; 
		} else SynErr(157);
	}

	void TypeName(
#line  2301 "cs.ATG" 
out TypeReference typeRef, bool canBeUnbound) {

#line  2302 "cs.ATG" 
		List<TypeReference> typeArguments = null;
		string alias = null;
		string qualident;
		Location startLocation = la.Location;
		
		if (
#line  2308 "cs.ATG" 
IdentAndDoubleColon()) {
			Identifier();

#line  2309 "cs.ATG" 
			alias = t.val; 
			Expect(10);
		}
		Qualident(
#line  2312 "cs.ATG" 
out qualident);
		if (la.kind == 23) {
			TypeArgumentList(
#line  2313 "cs.ATG" 
out typeArguments, canBeUnbound);
		}

#line  2315 "cs.ATG" 
		if (alias == null) {
		typeRef = new TypeReference(qualident, typeArguments);
		} else if (alias == "global") {
			typeRef = new TypeReference(qualident, typeArguments);
			typeRef.IsGlobal = true;
		} else {
			typeRef = new TypeReference(alias + "." + qualident, typeArguments);
		}
		
		while (
#line  2324 "cs.ATG" 
DotAndIdent()) {
			Expect(15);

#line  2325 "cs.ATG" 
			typeArguments = null; 
			Qualident(
#line  2326 "cs.ATG" 
out qualident);
			if (la.kind == 23) {
				TypeArgumentList(
#line  2327 "cs.ATG" 
out typeArguments, canBeUnbound);
			}

#line  2328 "cs.ATG" 
			typeRef = new InnerClassTypeReference(typeRef, qualident, typeArguments); 
		}

#line  2330 "cs.ATG" 
		typeRef.StartLocation = startLocation; 
	}

	void MemberModifiers(
#line  728 "cs.ATG" 
ModifierList m) {
		while (StartOf(19)) {
			switch (la.kind) {
			case 49: {
				lexer.NextToken();

#line  731 "cs.ATG" 
				m.Add(Modifiers.Abstract, t.Location); 
				break;
			}
			case 71: {
				lexer.NextToken();

#line  732 "cs.ATG" 
				m.Add(Modifiers.Extern, t.Location); 
				break;
			}
			case 84: {
				lexer.NextToken();

#line  733 "cs.ATG" 
				m.Add(Modifiers.Internal, t.Location); 
				break;
			}
			case 89: {
				lexer.NextToken();

#line  734 "cs.ATG" 
				m.Add(Modifiers.New, t.Location); 
				break;
			}
			case 94: {
				lexer.NextToken();

#line  735 "cs.ATG" 
				m.Add(Modifiers.Override, t.Location); 
				break;
			}
			case 96: {
				lexer.NextToken();

#line  736 "cs.ATG" 
				m.Add(Modifiers.Private, t.Location); 
				break;
			}
			case 97: {
				lexer.NextToken();

#line  737 "cs.ATG" 
				m.Add(Modifiers.Protected, t.Location); 
				break;
			}
			case 98: {
				lexer.NextToken();

#line  738 "cs.ATG" 
				m.Add(Modifiers.Public, t.Location); 
				break;
			}
			case 99: {
				lexer.NextToken();

#line  739 "cs.ATG" 
				m.Add(Modifiers.ReadOnly, t.Location); 
				break;
			}
			case 103: {
				lexer.NextToken();

#line  740 "cs.ATG" 
				m.Add(Modifiers.Sealed, t.Location); 
				break;
			}
			case 107: {
				lexer.NextToken();

#line  741 "cs.ATG" 
				m.Add(Modifiers.Static, t.Location); 
				break;
			}
			case 74: {
				lexer.NextToken();

#line  742 "cs.ATG" 
				m.Add(Modifiers.Fixed, t.Location); 
				break;
			}
			case 119: {
				lexer.NextToken();

#line  743 "cs.ATG" 
				m.Add(Modifiers.Unsafe, t.Location); 
				break;
			}
			case 122: {
				lexer.NextToken();

#line  744 "cs.ATG" 
				m.Add(Modifiers.Virtual, t.Location); 
				break;
			}
			case 124: {
				lexer.NextToken();

#line  745 "cs.ATG" 
				m.Add(Modifiers.Volatile, t.Location); 
				break;
			}
			case 126: {
				lexer.NextToken();

#line  746 "cs.ATG" 
				m.Add(Modifiers.Partial, t.Location); 
				break;
			}
			}
		}
	}

	void ClassMemberDecl(
#line  1064 "cs.ATG" 
ModifierList m, List<AttributeSection> attributes) {

#line  1065 "cs.ATG" 
		BlockStatement stmt = null; 
		if (StartOf(20)) {
			StructMemberDecl(
#line  1067 "cs.ATG" 
m, attributes);
		} else if (la.kind == 27) {

#line  1068 "cs.ATG" 
			m.Check(Modifiers.Destructors); Location startPos = la.Location; 
			lexer.NextToken();
			Identifier();

#line  1069 "cs.ATG" 
			DestructorDeclaration d = new DestructorDeclaration(t.val, m.Modifier, attributes); 
			d.Modifier = m.Modifier;
			d.StartLocation = m.GetDeclarationLocation(startPos);
			
			Expect(20);
			Expect(21);

#line  1073 "cs.ATG" 
			d.EndLocation = t.EndLocation; 
			if (la.kind == 16) {
				Block(
#line  1073 "cs.ATG" 
out stmt);
			} else if (la.kind == 11) {
				lexer.NextToken();
			} else SynErr(158);

#line  1074 "cs.ATG" 
			d.Body = stmt;
			AddChild(d);
			
		} else SynErr(159);
	}

	void StructMemberDecl(
#line  750 "cs.ATG" 
ModifierList m, List<AttributeSection> attributes) {

#line  752 "cs.ATG" 
		string qualident = null;
		TypeReference type;
		Expression expr;
		List<ParameterDeclarationExpression> p = new List<ParameterDeclarationExpression>();
		BlockStatement stmt = null;
		List<TemplateDefinition> templates = new List<TemplateDefinition>();
		TypeReference explicitInterface = null;
		bool isExtensionMethod = false;
		
		if (la.kind == 60) {

#line  762 "cs.ATG" 
			m.Check(Modifiers.Constants); 
			lexer.NextToken();

#line  763 "cs.ATG" 
			Location startPos = t.Location; 
			Type(
#line  764 "cs.ATG" 
out type);
			Identifier();

#line  764 "cs.ATG" 
			FieldDeclaration fd = new FieldDeclaration(attributes, type, m.Modifier | Modifiers.Const);
			fd.StartLocation = m.GetDeclarationLocation(startPos);
			VariableDeclaration f = new VariableDeclaration(t.val);
			f.StartLocation = t.Location;
			f.TypeReference = type;
			SafeAdd(fd, fd.Fields, f);
			
			Expect(3);
			Expr(
#line  771 "cs.ATG" 
out expr);

#line  771 "cs.ATG" 
			f.Initializer = expr; 
			while (la.kind == 14) {
				lexer.NextToken();
				Identifier();

#line  772 "cs.ATG" 
				f = new VariableDeclaration(t.val);
				f.StartLocation = t.Location;
				f.TypeReference = type;
				SafeAdd(fd, fd.Fields, f);
				
				Expect(3);
				Expr(
#line  777 "cs.ATG" 
out expr);

#line  777 "cs.ATG" 
				f.EndLocation = t.EndLocation; f.Initializer = expr; 
			}
			Expect(11);

#line  778 "cs.ATG" 
			fd.EndLocation = t.EndLocation; AddChild(fd); 
		} else if (
#line  782 "cs.ATG" 
NotVoidPointer()) {

#line  782 "cs.ATG" 
			m.Check(Modifiers.PropertysEventsMethods); 
			Expect(123);

#line  783 "cs.ATG" 
			Location startPos = t.Location; 
			if (
#line  784 "cs.ATG" 
IsExplicitInterfaceImplementation()) {
				TypeName(
#line  785 "cs.ATG" 
out explicitInterface, false);

#line  786 "cs.ATG" 
				if (la.kind != Tokens.Dot || Peek(1).kind != Tokens.This) {
				qualident = TypeReference.StripLastIdentifierFromType(ref explicitInterface);
				 } 
			} else if (StartOf(18)) {
				Identifier();

#line  789 "cs.ATG" 
				qualident = t.val; 
			} else SynErr(160);
			if (la.kind == 23) {
				TypeParameterList(
#line  792 "cs.ATG" 
templates);
			}
			Expect(20);
			if (la.kind == 111) {
				lexer.NextToken();

#line  795 "cs.ATG" 
				isExtensionMethod = true; /* C# 3.0 */ 
			}
			if (StartOf(11)) {
				FormalParameterList(
#line  796 "cs.ATG" 
p);
			}
			Expect(21);

#line  797 "cs.ATG" 
			MethodDeclaration methodDeclaration = new MethodDeclaration {
			Name = qualident,
			Modifier = m.Modifier,
			TypeReference = new TypeReference("System.Void", true),
			Parameters = p,
			Attributes = attributes,
			StartLocation = m.GetDeclarationLocation(startPos),
			EndLocation = t.EndLocation,
			Templates = templates,
			IsExtensionMethod = isExtensionMethod
			};
			if (explicitInterface != null)
				SafeAdd(methodDeclaration, methodDeclaration.InterfaceImplementations, new InterfaceImplementation(explicitInterface, qualident));
			AddChild(methodDeclaration);
			BlockStart(methodDeclaration);
			
			while (la.kind == 127) {
				TypeParameterConstraintsClause(
#line  815 "cs.ATG" 
templates);
			}
			if (la.kind == 16) {
				Block(
#line  817 "cs.ATG" 
out stmt);
			} else if (la.kind == 11) {
				lexer.NextToken();
			} else SynErr(161);

#line  817 "cs.ATG" 
			BlockEnd();
			methodDeclaration.Body  = (BlockStatement)stmt;
			
		} else if (la.kind == 69) {

#line  821 "cs.ATG" 
			m.Check(Modifiers.PropertysEventsMethods); 
			lexer.NextToken();

#line  823 "cs.ATG" 
			EventDeclaration eventDecl = new EventDeclaration {
			Modifier = m.Modifier, 
			Attributes = attributes,
			StartLocation = t.Location
			};
			AddChild(eventDecl);
			BlockStart(eventDecl);
			EventAddRegion addBlock = null;
			EventRemoveRegion removeBlock = null;
			
			Type(
#line  833 "cs.ATG" 
out type);

#line  833 "cs.ATG" 
			eventDecl.TypeReference = type; 
			if (
#line  834 "cs.ATG" 
IsExplicitInterfaceImplementation()) {
				TypeName(
#line  835 "cs.ATG" 
out explicitInterface, false);

#line  836 "cs.ATG" 
				qualident = TypeReference.StripLastIdentifierFromType(ref explicitInterface); 

#line  837 "cs.ATG" 
				eventDecl.InterfaceImplementations.Add(new InterfaceImplementation(explicitInterface, qualident)); 
			} else if (StartOf(18)) {
				Identifier();

#line  839 "cs.ATG" 
				qualident = t.val; 
			} else SynErr(162);

#line  841 "cs.ATG" 
			eventDecl.Name = qualident; eventDecl.EndLocation = t.EndLocation; 
			if (la.kind == 3) {
				lexer.NextToken();
				Expr(
#line  842 "cs.ATG" 
out expr);

#line  842 "cs.ATG" 
				eventDecl.Initializer = expr; 
			}
			if (la.kind == 16) {
				lexer.NextToken();

#line  843 "cs.ATG" 
				eventDecl.BodyStart = t.Location; 
				EventAccessorDecls(
#line  844 "cs.ATG" 
out addBlock, out removeBlock);
				Expect(17);

#line  845 "cs.ATG" 
				eventDecl.BodyEnd   = t.EndLocation; 
			}
			if (la.kind == 11) {
				lexer.NextToken();
			}

#line  848 "cs.ATG" 
			BlockEnd();
			eventDecl.AddRegion = addBlock;
			eventDecl.RemoveRegion = removeBlock;
			
		} else if (
#line  854 "cs.ATG" 
IdentAndLPar()) {

#line  854 "cs.ATG" 
			m.Check(Modifiers.Constructors | Modifiers.StaticConstructors); 
			Identifier();

#line  855 "cs.ATG" 
			string name = t.val; Location startPos = t.Location; 
			Expect(20);
			if (StartOf(11)) {

#line  855 "cs.ATG" 
				m.Check(Modifiers.Constructors); 
				FormalParameterList(
#line  856 "cs.ATG" 
p);
			}
			Expect(21);

#line  858 "cs.ATG" 
			ConstructorInitializer init = null;  
			if (la.kind == 9) {

#line  859 "cs.ATG" 
				m.Check(Modifiers.Constructors); 
				ConstructorInitializer(
#line  860 "cs.ATG" 
out init);
			}

#line  862 "cs.ATG" 
			ConstructorDeclaration cd = new ConstructorDeclaration(name, m.Modifier, p, init, attributes);
			cd.StartLocation = startPos;
			cd.EndLocation   = t.EndLocation;
			
			if (la.kind == 16) {
				Block(
#line  867 "cs.ATG" 
out stmt);
			} else if (la.kind == 11) {
				lexer.NextToken();
			} else SynErr(163);

#line  867 "cs.ATG" 
			cd.Body = (BlockStatement)stmt; AddChild(cd); 
		} else if (la.kind == 70 || la.kind == 80) {

#line  870 "cs.ATG" 
			m.Check(Modifiers.Operators);
			if (m.isNone) Error("at least one modifier must be set"); 
			bool isImplicit = true;
			Location startPos = Location.Empty;
			
			if (la.kind == 80) {
				lexer.NextToken();

#line  875 "cs.ATG" 
				startPos = t.Location; 
			} else {
				lexer.NextToken();

#line  875 "cs.ATG" 
				isImplicit = false; startPos = t.Location; 
			}
			Expect(92);
			Type(
#line  876 "cs.ATG" 
out type);

#line  876 "cs.ATG" 
			TypeReference operatorType = type; 
			Expect(20);
			Type(
#line  877 "cs.ATG" 
out type);
			Identifier();

#line  877 "cs.ATG" 
			string varName = t.val; 
			Expect(21);

#line  878 "cs.ATG" 
			Location endPos = t.Location; 
			if (la.kind == 16) {
				Block(
#line  879 "cs.ATG" 
out stmt);
			} else if (la.kind == 11) {
				lexer.NextToken();

#line  879 "cs.ATG" 
				stmt = null; 
			} else SynErr(164);

#line  882 "cs.ATG" 
			List<ParameterDeclarationExpression> parameters = new List<ParameterDeclarationExpression>();
			parameters.Add(new ParameterDeclarationExpression(type, varName));
			OperatorDeclaration operatorDeclaration = new OperatorDeclaration {
				Name = (isImplicit ? "op_Implicit" : "op_Explicit"),
				Modifier = m.Modifier,
				Attributes = attributes, 
				Parameters = parameters, 
				TypeReference = operatorType,
				ConversionType = isImplicit ? ConversionType.Implicit : ConversionType.Explicit,
				Body = (BlockStatement)stmt,
				StartLocation = m.GetDeclarationLocation(startPos),
				EndLocation = endPos
			};
			AddChild(operatorDeclaration);
			
		} else if (StartOf(21)) {
			TypeDecl(
#line  900 "cs.ATG" 
m, attributes);
		} else if (StartOf(10)) {
			Type(
#line  902 "cs.ATG" 
out type);

#line  902 "cs.ATG" 
			Location startPos = t.Location;  
			if (la.kind == 92) {

#line  904 "cs.ATG" 
				OverloadableOperatorType op;
				m.Check(Modifiers.Operators);
				if (m.isNone) Error("at least one modifier must be set");
				
				lexer.NextToken();
				OverloadableOperator(
#line  908 "cs.ATG" 
out op);

#line  908 "cs.ATG" 
				TypeReference firstType, secondType = null; string secondName = null; 
				Expect(20);

#line  909 "cs.ATG" 
				Location firstStart = la.Location, secondStart = Location.Empty, secondEnd = Location.Empty; 
				Type(
#line  909 "cs.ATG" 
out firstType);
				Identifier();

#line  909 "cs.ATG" 
				string firstName = t.val; Location firstEnd = t.EndLocation; 
				if (la.kind == 14) {
					lexer.NextToken();

#line  910 "cs.ATG" 
					secondStart = la.Location; 
					Type(
#line  910 "cs.ATG" 
out secondType);
					Identifier();

#line  910 "cs.ATG" 
					secondName = t.val; secondEnd = t.EndLocation; 
				} else if (la.kind == 21) {
				} else SynErr(165);

#line  918 "cs.ATG" 
				Location endPos = t.Location; 
				Expect(21);
				if (la.kind == 16) {
					Block(
#line  919 "cs.ATG" 
out stmt);
				} else if (la.kind == 11) {
					lexer.NextToken();
				} else SynErr(166);

#line  921 "cs.ATG" 
				if (op == OverloadableOperatorType.Add && secondType == null)
				op = OverloadableOperatorType.UnaryPlus;
				if (op == OverloadableOperatorType.Subtract && secondType == null)
					op = OverloadableOperatorType.UnaryMinus;
				OperatorDeclaration operatorDeclaration = new OperatorDeclaration {
					Modifier = m.Modifier,
					Attributes = attributes,
					TypeReference = type,
					OverloadableOperator = op,
					Name = GetReflectionNameForOperator(op),
					Body = (BlockStatement)stmt,
					StartLocation = m.GetDeclarationLocation(startPos),
					EndLocation = endPos
				};
				SafeAdd(operatorDeclaration, operatorDeclaration.Parameters, new ParameterDeclarationExpression(firstType, firstName) { StartLocation = firstStart, EndLocation = firstEnd });
				if (secondType != null) {
					SafeAdd(operatorDeclaration, operatorDeclaration.Parameters, new ParameterDeclarationExpression(secondType, secondName) { StartLocation = secondStart, EndLocation = secondEnd });
				}
				AddChild(operatorDeclaration);
				
			} else if (
#line  943 "cs.ATG" 
IsVarDecl()) {

#line  944 "cs.ATG" 
				m.Check(Modifiers.Fields);
				FieldDeclaration fd = new FieldDeclaration(attributes, type, m.Modifier);
				fd.StartLocation = m.GetDeclarationLocation(startPos); 
				
				if (
#line  948 "cs.ATG" 
m.Contains(Modifiers.Fixed)) {
					VariableDeclarator(
#line  949 "cs.ATG" 
fd);
					Expect(18);
					Expr(
#line  951 "cs.ATG" 
out expr);

#line  951 "cs.ATG" 
					if (fd.Fields.Count > 0)
					fd.Fields[fd.Fields.Count-1].FixedArrayInitialization = expr; 
					Expect(19);
					while (la.kind == 14) {
						lexer.NextToken();
						VariableDeclarator(
#line  955 "cs.ATG" 
fd);
						Expect(18);
						Expr(
#line  957 "cs.ATG" 
out expr);

#line  957 "cs.ATG" 
						if (fd.Fields.Count > 0)
						fd.Fields[fd.Fields.Count-1].FixedArrayInitialization = expr; 
						Expect(19);
					}
				} else if (StartOf(18)) {
					VariableDeclarator(
#line  962 "cs.ATG" 
fd);
					while (la.kind == 14) {
						lexer.NextToken();
						VariableDeclarator(
#line  963 "cs.ATG" 
fd);
					}
				} else SynErr(167);
				Expect(11);

#line  965 "cs.ATG" 
				fd.EndLocation = t.EndLocation; AddChild(fd); 
			} else if (la.kind == 111) {

#line  968 "cs.ATG" 
				m.Check(Modifiers.Indexers); 
				lexer.NextToken();
				Expect(18);
				FormalParameterList(
#line  969 "cs.ATG" 
p);
				Expect(19);

#line  969 "cs.ATG" 
				Location endLocation = t.EndLocation; 
				Expect(16);

#line  970 "cs.ATG" 
				PropertyDeclaration indexer = new PropertyDeclaration(m.Modifier | Modifiers.Default, attributes, "Item", p);
				indexer.StartLocation = startPos;
				indexer.EndLocation   = endLocation;
				indexer.BodyStart     = t.Location;
				indexer.TypeReference = type;
				PropertyGetRegion getRegion;
				PropertySetRegion setRegion;
				
				AccessorDecls(
#line  978 "cs.ATG" 
out getRegion, out setRegion);
				Expect(17);

#line  979 "cs.ATG" 
				indexer.BodyEnd    = t.EndLocation;
				indexer.GetRegion = getRegion;
				indexer.SetRegion = setRegion;
				AddChild(indexer);
				
			} else if (
#line  984 "cs.ATG" 
IsIdentifierToken(la)) {
				if (
#line  985 "cs.ATG" 
IsExplicitInterfaceImplementation()) {
					TypeName(
#line  986 "cs.ATG" 
out explicitInterface, false);

#line  987 "cs.ATG" 
					if (la.kind != Tokens.Dot || Peek(1).kind != Tokens.This) {
					qualident = TypeReference.StripLastIdentifierFromType(ref explicitInterface);
					 } 
				} else if (StartOf(18)) {
					Identifier();

#line  990 "cs.ATG" 
					qualident = t.val; 
				} else SynErr(168);

#line  992 "cs.ATG" 
				Location qualIdentEndLocation = t.EndLocation; 
				if (la.kind == 16 || la.kind == 20 || la.kind == 23) {
					if (la.kind == 20 || la.kind == 23) {

#line  996 "cs.ATG" 
						m.Check(Modifiers.PropertysEventsMethods); 
						if (la.kind == 23) {
							TypeParameterList(
#line  998 "cs.ATG" 
templates);
						}
						Expect(20);
						if (la.kind == 111) {
							lexer.NextToken();

#line  1000 "cs.ATG" 
							isExtensionMethod = true; 
						}
						if (StartOf(11)) {
							FormalParameterList(
#line  1001 "cs.ATG" 
p);
						}
						Expect(21);

#line  1003 "cs.ATG" 
						MethodDeclaration methodDeclaration = new MethodDeclaration {
						Name = qualident,
						Modifier = m.Modifier,
						TypeReference = type,
						Parameters = p, 
						Attributes = attributes
						};
						if (explicitInterface != null)
							methodDeclaration.InterfaceImplementations.Add(new InterfaceImplementation(explicitInterface, qualident));
						methodDeclaration.StartLocation = m.GetDeclarationLocation(startPos);
						methodDeclaration.EndLocation   = t.EndLocation;
						methodDeclaration.IsExtensionMethod = isExtensionMethod;
						methodDeclaration.Templates = templates;
						AddChild(methodDeclaration);
						                                      
						while (la.kind == 127) {
							TypeParameterConstraintsClause(
#line  1018 "cs.ATG" 
templates);
						}
						if (la.kind == 16) {
							Block(
#line  1019 "cs.ATG" 
out stmt);
						} else if (la.kind == 11) {
							lexer.NextToken();
						} else SynErr(169);

#line  1019 "cs.ATG" 
						methodDeclaration.Body  = (BlockStatement)stmt; 
					} else {
						lexer.NextToken();

#line  1022 "cs.ATG" 
						PropertyDeclaration pDecl = new PropertyDeclaration(qualident, type, m.Modifier, attributes); 
						if (explicitInterface != null)
						pDecl.InterfaceImplementations.Add(new InterfaceImplementation(explicitInterface, qualident));
						      pDecl.StartLocation = m.GetDeclarationLocation(startPos);
						      pDecl.EndLocation   = qualIdentEndLocation;
						      pDecl.BodyStart   = t.Location;
						      PropertyGetRegion getRegion;
						      PropertySetRegion setRegion;
						   
						AccessorDecls(
#line  1031 "cs.ATG" 
out getRegion, out setRegion);
						Expect(17);

#line  1033 "cs.ATG" 
						pDecl.GetRegion = getRegion;
						pDecl.SetRegion = setRegion;
						pDecl.BodyEnd = t.EndLocation;
						AddChild(pDecl);
						
					}
				} else if (la.kind == 15) {

#line  1041 "cs.ATG" 
					m.Check(Modifiers.Indexers); 
					lexer.NextToken();
					Expect(111);
					Expect(18);
					FormalParameterList(
#line  1042 "cs.ATG" 
p);
					Expect(19);

#line  1043 "cs.ATG" 
					PropertyDeclaration indexer = new PropertyDeclaration(m.Modifier | Modifiers.Default, attributes, "Item", p);
					indexer.StartLocation = m.GetDeclarationLocation(startPos);
					indexer.EndLocation   = t.EndLocation;
					indexer.TypeReference = type;
					if (explicitInterface != null)
					SafeAdd(indexer, indexer.InterfaceImplementations, new InterfaceImplementation(explicitInterface, "this"));
					      PropertyGetRegion getRegion;
					      PropertySetRegion setRegion;
					    
					Expect(16);

#line  1052 "cs.ATG" 
					Location bodyStart = t.Location; 
					AccessorDecls(
#line  1053 "cs.ATG" 
out getRegion, out setRegion);
					Expect(17);

#line  1054 "cs.ATG" 
					indexer.BodyStart = bodyStart;
					indexer.BodyEnd   = t.EndLocation;
					indexer.GetRegion = getRegion;
					indexer.SetRegion = setRegion;
					AddChild(indexer);
					
				} else SynErr(170);
			} else SynErr(171);
		} else SynErr(172);
	}

	void InterfaceMemberDecl() {

#line  1081 "cs.ATG" 
		TypeReference type;
		
		AttributeSection section;
		Modifiers mod = Modifiers.None;
		List<AttributeSection> attributes = new List<AttributeSection>();
		List<ParameterDeclarationExpression> parameters = new List<ParameterDeclarationExpression>();
		string name;
		PropertyGetRegion getBlock;
		PropertySetRegion setBlock;
		Location startLocation = new Location(-1, -1);
		List<TemplateDefinition> templates = new List<TemplateDefinition>();
		
		while (la.kind == 18) {
			AttributeSection(
#line  1094 "cs.ATG" 
out section);

#line  1094 "cs.ATG" 
			attributes.Add(section); 
		}
		if (la.kind == 89) {
			lexer.NextToken();

#line  1095 "cs.ATG" 
			mod = Modifiers.New; startLocation = t.Location; 
		}
		if (
#line  1098 "cs.ATG" 
NotVoidPointer()) {
			Expect(123);

#line  1098 "cs.ATG" 
			if (startLocation.IsEmpty) startLocation = t.Location; 
			Identifier();

#line  1099 "cs.ATG" 
			name = t.val; 
			if (la.kind == 23) {
				TypeParameterList(
#line  1100 "cs.ATG" 
templates);
			}
			Expect(20);
			if (StartOf(11)) {
				FormalParameterList(
#line  1101 "cs.ATG" 
parameters);
			}
			Expect(21);
			while (la.kind == 127) {
				TypeParameterConstraintsClause(
#line  1102 "cs.ATG" 
templates);
			}
			Expect(11);

#line  1104 "cs.ATG" 
			MethodDeclaration md = new MethodDeclaration {
			Name = name, Modifier = mod, TypeReference = new TypeReference("System.Void", true), 
			Parameters = parameters, Attributes = attributes, Templates = templates,
			StartLocation = startLocation, EndLocation = t.EndLocation
			};
			AddChild(md);
			
		} else if (StartOf(22)) {
			if (StartOf(10)) {
				Type(
#line  1112 "cs.ATG" 
out type);

#line  1112 "cs.ATG" 
				if (startLocation.IsEmpty) startLocation = t.Location; 
				if (StartOf(18)) {
					Identifier();

#line  1114 "cs.ATG" 
					name = t.val; Location qualIdentEndLocation = t.EndLocation; 
					if (la.kind == 20 || la.kind == 23) {
						if (la.kind == 23) {
							TypeParameterList(
#line  1118 "cs.ATG" 
templates);
						}
						Expect(20);
						if (StartOf(11)) {
							FormalParameterList(
#line  1119 "cs.ATG" 
parameters);
						}
						Expect(21);
						while (la.kind == 127) {
							TypeParameterConstraintsClause(
#line  1121 "cs.ATG" 
templates);
						}
						Expect(11);

#line  1122 "cs.ATG" 
						MethodDeclaration md = new MethodDeclaration {
						Name = name, Modifier = mod, TypeReference = type,
						Parameters = parameters, Attributes = attributes, Templates = templates,
						StartLocation = startLocation, EndLocation = t.EndLocation
						};
						AddChild(md);
						
					} else if (la.kind == 16) {

#line  1131 "cs.ATG" 
						PropertyDeclaration pd = new PropertyDeclaration(name, type, mod, attributes);
						AddChild(pd); 
						lexer.NextToken();

#line  1134 "cs.ATG" 
						Location bodyStart = t.Location;
						InterfaceAccessors(
#line  1135 "cs.ATG" 
out getBlock, out setBlock);
						Expect(17);

#line  1136 "cs.ATG" 
						pd.GetRegion = getBlock; pd.SetRegion = setBlock; pd.StartLocation = startLocation; pd.EndLocation = qualIdentEndLocation; pd.BodyStart = bodyStart; pd.BodyEnd = t.EndLocation; 
					} else SynErr(173);
				} else if (la.kind == 111) {
					lexer.NextToken();
					Expect(18);
					FormalParameterList(
#line  1139 "cs.ATG" 
parameters);
					Expect(19);

#line  1140 "cs.ATG" 
					Location bracketEndLocation = t.EndLocation; 

#line  1141 "cs.ATG" 
					PropertyDeclaration id = new PropertyDeclaration(mod | Modifiers.Default, attributes, "Item", parameters);
					id.TypeReference = type;
					  AddChild(id); 
					Expect(16);

#line  1144 "cs.ATG" 
					Location bodyStart = t.Location;
					InterfaceAccessors(
#line  1145 "cs.ATG" 
out getBlock, out setBlock);
					Expect(17);

#line  1147 "cs.ATG" 
					id.GetRegion = getBlock; id.SetRegion = setBlock; id.StartLocation = startLocation;  id.EndLocation = bracketEndLocation; id.BodyStart = bodyStart; id.BodyEnd = t.EndLocation;
				} else SynErr(174);
			} else {
				lexer.NextToken();

#line  1150 "cs.ATG" 
				if (startLocation.IsEmpty) startLocation = t.Location; 
				Type(
#line  1151 "cs.ATG" 
out type);
				Identifier();

#line  1152 "cs.ATG" 
				EventDeclaration ed = new EventDeclaration {
				TypeReference = type, Name = t.val, Modifier = mod, Attributes = attributes
				};
				AddChild(ed);
				
				Expect(11);

#line  1158 "cs.ATG" 
				ed.StartLocation = startLocation; ed.EndLocation = t.EndLocation; 
			}
		} else SynErr(175);
	}

	void EnumMemberDecl(
#line  1163 "cs.ATG" 
out FieldDeclaration f) {

#line  1165 "cs.ATG" 
		Expression expr = null;
		List<AttributeSection> attributes = new List<AttributeSection>();
		AttributeSection section = null;
		VariableDeclaration varDecl = null;
		
		while (la.kind == 18) {
			AttributeSection(
#line  1171 "cs.ATG" 
out section);

#line  1171 "cs.ATG" 
			attributes.Add(section); 
		}
		Identifier();

#line  1172 "cs.ATG" 
		f = new FieldDeclaration(attributes);
		varDecl         = new VariableDeclaration(t.val);
		f.Fields.Add(varDecl);
		f.StartLocation = t.Location;
		f.EndLocation = t.EndLocation;
		
		if (la.kind == 3) {
			lexer.NextToken();
			Expr(
#line  1178 "cs.ATG" 
out expr);

#line  1178 "cs.ATG" 
			varDecl.Initializer = expr; 
		}
	}

	void TypeWithRestriction(
#line  578 "cs.ATG" 
out TypeReference type, bool allowNullable, bool canBeUnbound) {

#line  580 "cs.ATG" 
		Location startPos = la.Location;
		string name;
		int pointer = 0;
		type = null;
		
		if (StartOf(4)) {
			ClassType(
#line  586 "cs.ATG" 
out type, canBeUnbound);
		} else if (StartOf(5)) {
			SimpleType(
#line  587 "cs.ATG" 
out name);

#line  587 "cs.ATG" 
			type = new TypeReference(name, true); 
		} else if (la.kind == 123) {
			lexer.NextToken();
			Expect(6);

#line  588 "cs.ATG" 
			pointer = 1; type = new TypeReference("System.Void", true); 
		} else SynErr(176);

#line  589 "cs.ATG" 
		List<int> r = new List<int>(); 
		if (
#line  591 "cs.ATG" 
allowNullable && la.kind == Tokens.Question) {
			NullableQuestionMark(
#line  591 "cs.ATG" 
ref type);
		}
		while (
#line  593 "cs.ATG" 
IsPointerOrDims()) {

#line  593 "cs.ATG" 
			int i = 0; 
			if (la.kind == 6) {
				lexer.NextToken();

#line  594 "cs.ATG" 
				++pointer; 
			} else if (la.kind == 18) {
				lexer.NextToken();
				while (la.kind == 14) {
					lexer.NextToken();

#line  595 "cs.ATG" 
					++i; 
				}
				Expect(19);

#line  595 "cs.ATG" 
				r.Add(i); 
			} else SynErr(177);
		}

#line  598 "cs.ATG" 
		if (type != null) {
		type.RankSpecifier = r.ToArray();
		type.PointerNestingLevel = pointer;
		type.EndLocation = t.EndLocation;
		type.StartLocation = startPos;
		}
		
	}

	void SimpleType(
#line  634 "cs.ATG" 
out string name) {

#line  635 "cs.ATG" 
		name = String.Empty; 
		if (StartOf(23)) {
			IntegralType(
#line  637 "cs.ATG" 
out name);
		} else if (la.kind == 75) {
			lexer.NextToken();

#line  638 "cs.ATG" 
			name = "System.Single"; 
		} else if (la.kind == 66) {
			lexer.NextToken();

#line  639 "cs.ATG" 
			name = "System.Double"; 
		} else if (la.kind == 62) {
			lexer.NextToken();

#line  640 "cs.ATG" 
			name = "System.Decimal"; 
		} else if (la.kind == 52) {
			lexer.NextToken();

#line  641 "cs.ATG" 
			name = "System.Boolean"; 
		} else SynErr(178);
	}

	void NullableQuestionMark(
#line  2334 "cs.ATG" 
ref TypeReference typeRef) {

#line  2335 "cs.ATG" 
		List<TypeReference> typeArguments = new List<TypeReference>(1); 
		Expect(12);

#line  2339 "cs.ATG" 
		if (typeRef != null) typeArguments.Add(typeRef);
		typeRef = new TypeReference("System.Nullable", typeArguments) { IsKeyword = true };
		
	}

	void FixedParameter(
#line  664 "cs.ATG" 
out ParameterDeclarationExpression p) {

#line  666 "cs.ATG" 
		TypeReference type;
		ParameterModifiers mod = ParameterModifiers.In;
		Location start = la.Location;
		Expression expr;
		
		if (la.kind == 93 || la.kind == 95 || la.kind == 100) {
			if (la.kind == 100) {
				lexer.NextToken();

#line  673 "cs.ATG" 
				mod = ParameterModifiers.Ref; 
			} else if (la.kind == 93) {
				lexer.NextToken();

#line  674 "cs.ATG" 
				mod = ParameterModifiers.Out; 
			} else {
				lexer.NextToken();

#line  675 "cs.ATG" 
				mod = ParameterModifiers.Params; 
			}
		}
		Type(
#line  677 "cs.ATG" 
out type);
		Identifier();

#line  678 "cs.ATG" 
		p = new ParameterDeclarationExpression(type, t.val, mod); 
		if (la.kind == 3) {
			lexer.NextToken();
			Expr(
#line  679 "cs.ATG" 
out expr);

#line  679 "cs.ATG" 
			p.DefaultValue = expr; p.ParamModifier |= ParameterModifiers.Optional; 
		}

#line  680 "cs.ATG" 
		p.StartLocation = start; p.EndLocation = t.EndLocation; 
	}

	void AccessorModifiers(
#line  683 "cs.ATG" 
out ModifierList m) {

#line  684 "cs.ATG" 
		m = new ModifierList(); 
		if (la.kind == 96) {
			lexer.NextToken();

#line  686 "cs.ATG" 
			m.Add(Modifiers.Private, t.Location); 
		} else if (la.kind == 97) {
			lexer.NextToken();

#line  687 "cs.ATG" 
			m.Add(Modifiers.Protected, t.Location); 
			if (la.kind == 84) {
				lexer.NextToken();

#line  688 "cs.ATG" 
				m.Add(Modifiers.Internal, t.Location); 
			}
		} else if (la.kind == 84) {
			lexer.NextToken();

#line  689 "cs.ATG" 
			m.Add(Modifiers.Internal, t.Location); 
			if (la.kind == 97) {
				lexer.NextToken();

#line  690 "cs.ATG" 
				m.Add(Modifiers.Protected, t.Location); 
			}
		} else SynErr(179);
	}

	void Block(
#line  1298 "cs.ATG" 
out BlockStatement stmt) {
		Expect(16);

#line  1300 "cs.ATG" 
		BlockStatement blockStmt = new BlockStatement();
		blockStmt.StartLocation = t.Location;
		BlockStart(blockStmt);
		if (!ParseMethodBodies) lexer.SkipCurrentBlock(0);
		
		while (StartOf(24)) {
			Statement();
		}
		while (!(la.kind == 0 || la.kind == 17)) {SynErr(180); lexer.NextToken(); }
		Expect(17);

#line  1308 "cs.ATG" 
		stmt = blockStmt;
		blockStmt.EndLocation = t.EndLocation;
		BlockEnd();
		
	}

	void EventAccessorDecls(
#line  1235 "cs.ATG" 
out EventAddRegion addBlock, out EventRemoveRegion removeBlock) {

#line  1236 "cs.ATG" 
		AttributeSection section;
		List<AttributeSection> attributes = new List<AttributeSection>();
		BlockStatement stmt;
		addBlock = null;
		removeBlock = null;
		
		while (la.kind == 18) {
			AttributeSection(
#line  1243 "cs.ATG" 
out section);

#line  1243 "cs.ATG" 
			attributes.Add(section); 
		}
		if (la.kind == 130) {

#line  1245 "cs.ATG" 
			addBlock = new EventAddRegion(attributes); 
			AddAccessorDecl(
#line  1246 "cs.ATG" 
out stmt);

#line  1246 "cs.ATG" 
			attributes = new List<AttributeSection>(); addBlock.Block = stmt; 
			while (la.kind == 18) {
				AttributeSection(
#line  1247 "cs.ATG" 
out section);

#line  1247 "cs.ATG" 
				attributes.Add(section); 
			}
			RemoveAccessorDecl(
#line  1248 "cs.ATG" 
out stmt);

#line  1248 "cs.ATG" 
			removeBlock = new EventRemoveRegion(attributes); removeBlock.Block = stmt; 
		} else if (la.kind == 131) {
			RemoveAccessorDecl(
#line  1250 "cs.ATG" 
out stmt);

#line  1250 "cs.ATG" 
			removeBlock = new EventRemoveRegion(attributes); removeBlock.Block = stmt; attributes = new List<AttributeSection>(); 
			while (la.kind == 18) {
				AttributeSection(
#line  1251 "cs.ATG" 
out section);

#line  1251 "cs.ATG" 
				attributes.Add(section); 
			}
			AddAccessorDecl(
#line  1252 "cs.ATG" 
out stmt);

#line  1252 "cs.ATG" 
			addBlock = new EventAddRegion(attributes); addBlock.Block = stmt; 
		} else SynErr(181);
	}

	void ConstructorInitializer(
#line  1328 "cs.ATG" 
out ConstructorInitializer ci) {

#line  1329 "cs.ATG" 
		Expression expr; ci = new ConstructorInitializer(); 
		Expect(9);
		if (la.kind == 51) {
			lexer.NextToken();

#line  1333 "cs.ATG" 
			ci.ConstructorInitializerType = ConstructorInitializerType.Base; 
		} else if (la.kind == 111) {
			lexer.NextToken();

#line  1334 "cs.ATG" 
			ci.ConstructorInitializerType = ConstructorInitializerType.This; 
		} else SynErr(182);
		Expect(20);
		if (StartOf(25)) {
			Argument(
#line  1337 "cs.ATG" 
out expr);

#line  1337 "cs.ATG" 
			SafeAdd(ci, ci.Arguments, expr); 
			while (la.kind == 14) {
				lexer.NextToken();
				Argument(
#line  1338 "cs.ATG" 
out expr);

#line  1338 "cs.ATG" 
				SafeAdd(ci, ci.Arguments, expr); 
			}
		}
		Expect(21);
	}

	void OverloadableOperator(
#line  1351 "cs.ATG" 
out OverloadableOperatorType op) {

#line  1352 "cs.ATG" 
		op = OverloadableOperatorType.None; 
		switch (la.kind) {
		case 4: {
			lexer.NextToken();

#line  1354 "cs.ATG" 
			op = OverloadableOperatorType.Add; 
			break;
		}
		case 5: {
			lexer.NextToken();

#line  1355 "cs.ATG" 
			op = OverloadableOperatorType.Subtract; 
			break;
		}
		case 24: {
			lexer.NextToken();

#line  1357 "cs.ATG" 
			op = OverloadableOperatorType.Not; 
			break;
		}
		case 27: {
			lexer.NextToken();

#line  1358 "cs.ATG" 
			op = OverloadableOperatorType.BitNot; 
			break;
		}
		case 31: {
			lexer.NextToken();

#line  1360 "cs.ATG" 
			op = OverloadableOperatorType.Increment; 
			break;
		}
		case 32: {
			lexer.NextToken();

#line  1361 "cs.ATG" 
			op = OverloadableOperatorType.Decrement; 
			break;
		}
		case 113: {
			lexer.NextToken();

#line  1363 "cs.ATG" 
			op = OverloadableOperatorType.IsTrue; 
			break;
		}
		case 72: {
			lexer.NextToken();

#line  1364 "cs.ATG" 
			op = OverloadableOperatorType.IsFalse; 
			break;
		}
		case 6: {
			lexer.NextToken();

#line  1366 "cs.ATG" 
			op = OverloadableOperatorType.Multiply; 
			break;
		}
		case 7: {
			lexer.NextToken();

#line  1367 "cs.ATG" 
			op = OverloadableOperatorType.Divide; 
			break;
		}
		case 8: {
			lexer.NextToken();

#line  1368 "cs.ATG" 
			op = OverloadableOperatorType.Modulus; 
			break;
		}
		case 28: {
			lexer.NextToken();

#line  1370 "cs.ATG" 
			op = OverloadableOperatorType.BitwiseAnd; 
			break;
		}
		case 29: {
			lexer.NextToken();

#line  1371 "cs.ATG" 
			op = OverloadableOperatorType.BitwiseOr; 
			break;
		}
		case 30: {
			lexer.NextToken();

#line  1372 "cs.ATG" 
			op = OverloadableOperatorType.ExclusiveOr; 
			break;
		}
		case 37: {
			lexer.NextToken();

#line  1374 "cs.ATG" 
			op = OverloadableOperatorType.ShiftLeft; 
			break;
		}
		case 33: {
			lexer.NextToken();

#line  1375 "cs.ATG" 
			op = OverloadableOperatorType.Equality; 
			break;
		}
		case 34: {
			lexer.NextToken();

#line  1376 "cs.ATG" 
			op = OverloadableOperatorType.InEquality; 
			break;
		}
		case 23: {
			lexer.NextToken();

#line  1377 "cs.ATG" 
			op = OverloadableOperatorType.LessThan; 
			break;
		}
		case 35: {
			lexer.NextToken();

#line  1378 "cs.ATG" 
			op = OverloadableOperatorType.GreaterThanOrEqual; 
			break;
		}
		case 36: {
			lexer.NextToken();

#line  1379 "cs.ATG" 
			op = OverloadableOperatorType.LessThanOrEqual; 
			break;
		}
		case 22: {
			lexer.NextToken();

#line  1380 "cs.ATG" 
			op = OverloadableOperatorType.GreaterThan; 
			if (la.kind == 22) {
				lexer.NextToken();

#line  1380 "cs.ATG" 
				op = OverloadableOperatorType.ShiftRight; 
			}
			break;
		}
		default: SynErr(183); break;
		}
	}

	void VariableDeclarator(
#line  1290 "cs.ATG" 
FieldDeclaration parentFieldDeclaration) {

#line  1291 "cs.ATG" 
		Expression expr = null; 
		Identifier();

#line  1293 "cs.ATG" 
		VariableDeclaration f = new VariableDeclaration(t.val); f.StartLocation = t.Location; 
		if (la.kind == 3) {
			lexer.NextToken();
			VariableInitializer(
#line  1294 "cs.ATG" 
out expr);

#line  1294 "cs.ATG" 
			f.Initializer = expr; 
		}

#line  1295 "cs.ATG" 
		f.EndLocation = t.EndLocation; SafeAdd(parentFieldDeclaration, parentFieldDeclaration.Fields, f); 
	}

	void AccessorDecls(
#line  1182 "cs.ATG" 
out PropertyGetRegion getBlock, out PropertySetRegion setBlock) {

#line  1184 "cs.ATG" 
		List<AttributeSection> attributes = new List<AttributeSection>(); 
		AttributeSection section;
		getBlock = null;
		setBlock = null; 
		ModifierList modifiers = null;
		
		while (la.kind == 18) {
			AttributeSection(
#line  1191 "cs.ATG" 
out section);

#line  1191 "cs.ATG" 
			attributes.Add(section); 
		}
		if (la.kind == 84 || la.kind == 96 || la.kind == 97) {
			AccessorModifiers(
#line  1192 "cs.ATG" 
out modifiers);
		}
		if (la.kind == 128) {
			GetAccessorDecl(
#line  1194 "cs.ATG" 
out getBlock, attributes);

#line  1195 "cs.ATG" 
			if (modifiers != null) {getBlock.Modifier = modifiers.Modifier; } 
			if (StartOf(26)) {

#line  1196 "cs.ATG" 
				attributes = new List<AttributeSection>(); modifiers = null; 
				while (la.kind == 18) {
					AttributeSection(
#line  1197 "cs.ATG" 
out section);

#line  1197 "cs.ATG" 
					attributes.Add(section); 
				}
				if (la.kind == 84 || la.kind == 96 || la.kind == 97) {
					AccessorModifiers(
#line  1198 "cs.ATG" 
out modifiers);
				}
				SetAccessorDecl(
#line  1199 "cs.ATG" 
out setBlock, attributes);

#line  1200 "cs.ATG" 
				if (modifiers != null) {setBlock.Modifier = modifiers.Modifier; } 
			}
		} else if (la.kind == 129) {
			SetAccessorDecl(
#line  1203 "cs.ATG" 
out setBlock, attributes);

#line  1204 "cs.ATG" 
			if (modifiers != null) {setBlock.Modifier = modifiers.Modifier; } 
			if (StartOf(27)) {

#line  1205 "cs.ATG" 
				attributes = new List<AttributeSection>(); modifiers = null; 
				while (la.kind == 18) {
					AttributeSection(
#line  1206 "cs.ATG" 
out section);

#line  1206 "cs.ATG" 
					attributes.Add(section); 
				}
				if (la.kind == 84 || la.kind == 96 || la.kind == 97) {
					AccessorModifiers(
#line  1207 "cs.ATG" 
out modifiers);
				}
				GetAccessorDecl(
#line  1208 "cs.ATG" 
out getBlock, attributes);

#line  1209 "cs.ATG" 
				if (modifiers != null) {getBlock.Modifier = modifiers.Modifier; } 
			}
		} else if (StartOf(18)) {
			Identifier();

#line  1211 "cs.ATG" 
			Error("get or set accessor declaration expected"); 
		} else SynErr(184);
	}

	void InterfaceAccessors(
#line  1256 "cs.ATG" 
out PropertyGetRegion getBlock, out PropertySetRegion setBlock) {

#line  1258 "cs.ATG" 
		AttributeSection section;
		List<AttributeSection> attributes = new List<AttributeSection>();
		getBlock = null; setBlock = null;
		PropertyGetSetRegion lastBlock = null;
		
		while (la.kind == 18) {
			AttributeSection(
#line  1264 "cs.ATG" 
out section);

#line  1264 "cs.ATG" 
			attributes.Add(section); 
		}

#line  1265 "cs.ATG" 
		Location startLocation = la.Location; 
		if (la.kind == 128) {
			lexer.NextToken();

#line  1267 "cs.ATG" 
			getBlock = new PropertyGetRegion(null, attributes); 
		} else if (la.kind == 129) {
			lexer.NextToken();

#line  1268 "cs.ATG" 
			setBlock = new PropertySetRegion(null, attributes); 
		} else SynErr(185);
		Expect(11);

#line  1271 "cs.ATG" 
		if (getBlock != null) { getBlock.StartLocation = startLocation; getBlock.EndLocation = t.EndLocation; }
		if (setBlock != null) { setBlock.StartLocation = startLocation; setBlock.EndLocation = t.EndLocation; }
		attributes = new List<AttributeSection>(); 
		if (la.kind == 18 || la.kind == 128 || la.kind == 129) {
			while (la.kind == 18) {
				AttributeSection(
#line  1275 "cs.ATG" 
out section);

#line  1275 "cs.ATG" 
				attributes.Add(section); 
			}

#line  1276 "cs.ATG" 
			startLocation = la.Location; 
			if (la.kind == 128) {
				lexer.NextToken();

#line  1278 "cs.ATG" 
				if (getBlock != null) Error("get already declared");
				                 else { getBlock = new PropertyGetRegion(null, attributes); lastBlock = getBlock; }
				              
			} else if (la.kind == 129) {
				lexer.NextToken();

#line  1281 "cs.ATG" 
				if (setBlock != null) Error("set already declared");
				                 else { setBlock = new PropertySetRegion(null, attributes); lastBlock = setBlock; }
				              
			} else SynErr(186);
			Expect(11);

#line  1286 "cs.ATG" 
			if (lastBlock != null) { lastBlock.StartLocation = startLocation; lastBlock.EndLocation = t.EndLocation; } 
		}
	}

	void GetAccessorDecl(
#line  1215 "cs.ATG" 
out PropertyGetRegion getBlock, List<AttributeSection> attributes) {

#line  1216 "cs.ATG" 
		BlockStatement stmt = null; 
		Expect(128);

#line  1219 "cs.ATG" 
		Location startLocation = t.Location; 
		if (la.kind == 16) {
			Block(
#line  1220 "cs.ATG" 
out stmt);
		} else if (la.kind == 11) {
			lexer.NextToken();
		} else SynErr(187);

#line  1221 "cs.ATG" 
		getBlock = new PropertyGetRegion(stmt, attributes); 

#line  1222 "cs.ATG" 
		getBlock.StartLocation = startLocation; getBlock.EndLocation = t.EndLocation; 
	}

	void SetAccessorDecl(
#line  1225 "cs.ATG" 
out PropertySetRegion setBlock, List<AttributeSection> attributes) {

#line  1226 "cs.ATG" 
		BlockStatement stmt = null; 
		Expect(129);

#line  1229 "cs.ATG" 
		Location startLocation = t.Location; 
		if (la.kind == 16) {
			Block(
#line  1230 "cs.ATG" 
out stmt);
		} else if (la.kind == 11) {
			lexer.NextToken();
		} else SynErr(188);

#line  1231 "cs.ATG" 
		setBlock = new PropertySetRegion(stmt, attributes); 

#line  1232 "cs.ATG" 
		setBlock.StartLocation = startLocation; setBlock.EndLocation = t.EndLocation; 
	}

	void AddAccessorDecl(
#line  1314 "cs.ATG" 
out BlockStatement stmt) {

#line  1315 "cs.ATG" 
		stmt = null;
		Expect(130);
		Block(
#line  1318 "cs.ATG" 
out stmt);
	}

	void RemoveAccessorDecl(
#line  1321 "cs.ATG" 
out BlockStatement stmt) {

#line  1322 "cs.ATG" 
		stmt = null;
		Expect(131);
		Block(
#line  1325 "cs.ATG" 
out stmt);
	}

	void VariableInitializer(
#line  1343 "cs.ATG" 
out Expression initializerExpression) {

#line  1344 "cs.ATG" 
		TypeReference type = null; Expression expr = null; initializerExpression = null; 
		if (StartOf(6)) {
			Expr(
#line  1346 "cs.ATG" 
out initializerExpression);
		} else if (la.kind == 16) {
			CollectionInitializer(
#line  1347 "cs.ATG" 
out initializerExpression);
		} else if (la.kind == 106) {
			lexer.NextToken();
			Type(
#line  1348 "cs.ATG" 
out type);
			Expect(18);
			Expr(
#line  1348 "cs.ATG" 
out expr);
			Expect(19);

#line  1348 "cs.ATG" 
			initializerExpression = new StackAllocExpression(type, expr); 
		} else SynErr(189);
	}

	void Statement() {

#line  1505 "cs.ATG" 
		Statement stmt = null;
		Location startPos = la.Location;
		
		while (!(StartOf(28))) {SynErr(190); lexer.NextToken(); }
		if (
#line  1512 "cs.ATG" 
IsLabel()) {
			Identifier();

#line  1512 "cs.ATG" 
			AddChild(new LabelStatement(t.val)); 
			Expect(9);
			Statement();
		} else if (la.kind == 60) {
			lexer.NextToken();
			LocalVariableDecl(
#line  1516 "cs.ATG" 
out stmt);

#line  1517 "cs.ATG" 
			if (stmt != null) { ((LocalVariableDeclaration)stmt).Modifier |= Modifiers.Const; } 
			Expect(11);

#line  1518 "cs.ATG" 
			AddChild(stmt); 
		} else if (
#line  1520 "cs.ATG" 
IsLocalVarDecl()) {
			LocalVariableDecl(
#line  1520 "cs.ATG" 
out stmt);
			Expect(11);

#line  1520 "cs.ATG" 
			AddChild(stmt); 
		} else if (StartOf(29)) {
			EmbeddedStatement(
#line  1522 "cs.ATG" 
out stmt);

#line  1522 "cs.ATG" 
			AddChild(stmt); 
		} else SynErr(191);

#line  1528 "cs.ATG" 
		if (stmt != null) {
		stmt.StartLocation = startPos;
		stmt.EndLocation = t.EndLocation;
		}
		
	}

	void Argument(
#line  1383 "cs.ATG" 
out Expression argumentexpr) {

#line  1384 "cs.ATG" 
		argumentexpr = null; 
		if (
#line  1386 "cs.ATG" 
IdentAndColon()) {

#line  1387 "cs.ATG" 
			Token ident; Expression expr; 
			Identifier();

#line  1388 "cs.ATG" 
			ident = t; 
			Expect(9);
			ArgumentValue(
#line  1390 "cs.ATG" 
out expr);

#line  1391 "cs.ATG" 
			argumentexpr = new NamedArgumentExpression(ident.val, expr) { StartLocation = ident.Location, EndLocation = t.EndLocation }; 
		} else if (StartOf(25)) {
			ArgumentValue(
#line  1393 "cs.ATG" 
out argumentexpr);
		} else SynErr(192);
	}

	void CollectionInitializer(
#line  1427 "cs.ATG" 
out Expression outExpr) {

#line  1429 "cs.ATG" 
		Expression expr = null;
		CollectionInitializerExpression initializer = new CollectionInitializerExpression();
		
		Expect(16);

#line  1433 "cs.ATG" 
		initializer.StartLocation = t.Location; 
		if (StartOf(30)) {
			VariableInitializer(
#line  1434 "cs.ATG" 
out expr);

#line  1435 "cs.ATG" 
			SafeAdd(initializer, initializer.CreateExpressions, expr); 
			while (
#line  1436 "cs.ATG" 
NotFinalComma()) {
				Expect(14);
				VariableInitializer(
#line  1437 "cs.ATG" 
out expr);

#line  1438 "cs.ATG" 
				SafeAdd(initializer, initializer.CreateExpressions, expr); 
			}
			if (la.kind == 14) {
				lexer.NextToken();
			}
		}
		Expect(17);

#line  1442 "cs.ATG" 
		initializer.EndLocation = t.Location; outExpr = initializer; 
	}

	void ArgumentValue(
#line  1396 "cs.ATG" 
out Expression argumentexpr) {

#line  1398 "cs.ATG" 
		Expression expr;
		FieldDirection fd = FieldDirection.None;
		
		if (la.kind == 93 || la.kind == 100) {
			if (la.kind == 100) {
				lexer.NextToken();

#line  1403 "cs.ATG" 
				fd = FieldDirection.Ref; 
			} else {
				lexer.NextToken();

#line  1404 "cs.ATG" 
				fd = FieldDirection.Out; 
			}
		}
		Expr(
#line  1406 "cs.ATG" 
out expr);

#line  1407 "cs.ATG" 
		argumentexpr = fd != FieldDirection.None ? argumentexpr = new DirectionExpression(fd, expr) : expr; 
	}

	void AssignmentOperator(
#line  1410 "cs.ATG" 
out AssignmentOperatorType op) {

#line  1411 "cs.ATG" 
		op = AssignmentOperatorType.None; 
		if (la.kind == 3) {
			lexer.NextToken();

#line  1413 "cs.ATG" 
			op = AssignmentOperatorType.Assign; 
		} else if (la.kind == 38) {
			lexer.NextToken();

#line  1414 "cs.ATG" 
			op = AssignmentOperatorType.Add; 
		} else if (la.kind == 39) {
			lexer.NextToken();

#line  1415 "cs.ATG" 
			op = AssignmentOperatorType.Subtract; 
		} else if (la.kind == 40) {
			lexer.NextToken();

#line  1416 "cs.ATG" 
			op = AssignmentOperatorType.Multiply; 
		} else if (la.kind == 41) {
			lexer.NextToken();

#line  1417 "cs.ATG" 
			op = AssignmentOperatorType.Divide; 
		} else if (la.kind == 42) {
			lexer.NextToken();

#line  1418 "cs.ATG" 
			op = AssignmentOperatorType.Modulus; 
		} else if (la.kind == 43) {
			lexer.NextToken();

#line  1419 "cs.ATG" 
			op = AssignmentOperatorType.BitwiseAnd; 
		} else if (la.kind == 44) {
			lexer.NextToken();

#line  1420 "cs.ATG" 
			op = AssignmentOperatorType.BitwiseOr; 
		} else if (la.kind == 45) {
			lexer.NextToken();

#line  1421 "cs.ATG" 
			op = AssignmentOperatorType.ExclusiveOr; 
		} else if (la.kind == 46) {
			lexer.NextToken();

#line  1422 "cs.ATG" 
			op = AssignmentOperatorType.ShiftLeft; 
		} else if (
#line  1423 "cs.ATG" 
la.kind == Tokens.GreaterThan && Peek(1).kind == Tokens.GreaterEqual) {
			Expect(22);
			Expect(35);

#line  1424 "cs.ATG" 
			op = AssignmentOperatorType.ShiftRight; 
		} else SynErr(193);
	}

	void CollectionOrObjectInitializer(
#line  1445 "cs.ATG" 
out Expression outExpr) {

#line  1447 "cs.ATG" 
		Expression expr = null;
		CollectionInitializerExpression initializer = new CollectionInitializerExpression();
		
		Expect(16);

#line  1451 "cs.ATG" 
		initializer.StartLocation = t.Location; 
		if (StartOf(30)) {
			ObjectPropertyInitializerOrVariableInitializer(
#line  1452 "cs.ATG" 
out expr);

#line  1453 "cs.ATG" 
			SafeAdd(initializer, initializer.CreateExpressions, expr); 
			while (
#line  1454 "cs.ATG" 
NotFinalComma()) {
				Expect(14);
				ObjectPropertyInitializerOrVariableInitializer(
#line  1455 "cs.ATG" 
out expr);

#line  1456 "cs.ATG" 
				SafeAdd(initializer, initializer.CreateExpressions, expr); 
			}
			if (la.kind == 14) {
				lexer.NextToken();
			}
		}
		Expect(17);

#line  1460 "cs.ATG" 
		initializer.EndLocation = t.Location; outExpr = initializer; 
	}

	void ObjectPropertyInitializerOrVariableInitializer(
#line  1463 "cs.ATG" 
out Expression expr) {

#line  1464 "cs.ATG" 
		expr = null; 
		if (
#line  1466 "cs.ATG" 
IdentAndAsgn()) {
			Identifier();

#line  1468 "cs.ATG" 
			MemberInitializerExpression mie = new MemberInitializerExpression(t.val, null);
			mie.StartLocation = t.Location;
			mie.IsKey = true;
			Expression r = null; 
			Expect(3);
			if (la.kind == 16) {
				CollectionOrObjectInitializer(
#line  1473 "cs.ATG" 
out r);
			} else if (StartOf(30)) {
				VariableInitializer(
#line  1474 "cs.ATG" 
out r);
			} else SynErr(194);

#line  1475 "cs.ATG" 
			mie.Expression = r; mie.EndLocation = t.EndLocation; expr = mie; 
		} else if (StartOf(30)) {
			VariableInitializer(
#line  1477 "cs.ATG" 
out expr);
		} else SynErr(195);
	}

	void LocalVariableDecl(
#line  1481 "cs.ATG" 
out Statement stmt) {

#line  1483 "cs.ATG" 
		TypeReference type;
		VariableDeclaration      var = null;
		LocalVariableDeclaration localVariableDeclaration; 
		Location startPos = la.Location;
		
		Type(
#line  1489 "cs.ATG" 
out type);

#line  1489 "cs.ATG" 
		localVariableDeclaration = new LocalVariableDeclaration(type); localVariableDeclaration.StartLocation = startPos; 
		LocalVariableDeclarator(
#line  1490 "cs.ATG" 
out var);

#line  1490 "cs.ATG" 
		SafeAdd(localVariableDeclaration, localVariableDeclaration.Variables, var); 
		while (la.kind == 14) {
			lexer.NextToken();
			LocalVariableDeclarator(
#line  1491 "cs.ATG" 
out var);

#line  1491 "cs.ATG" 
			SafeAdd(localVariableDeclaration, localVariableDeclaration.Variables, var); 
		}

#line  1492 "cs.ATG" 
		stmt = localVariableDeclaration; stmt.EndLocation = t.EndLocation; 
	}

	void LocalVariableDeclarator(
#line  1495 "cs.ATG" 
out VariableDeclaration var) {

#line  1496 "cs.ATG" 
		Expression expr = null; 
		Identifier();

#line  1498 "cs.ATG" 
		var = new VariableDeclaration(t.val); var.StartLocation = t.Location; 
		if (la.kind == 3) {
			lexer.NextToken();
			VariableInitializer(
#line  1499 "cs.ATG" 
out expr);

#line  1499 "cs.ATG" 
			var.Initializer = expr; 
		}

#line  1500 "cs.ATG" 
		var.EndLocation = t.EndLocation; 
	}

	void EmbeddedStatement(
#line  1535 "cs.ATG" 
out Statement statement) {

#line  1537 "cs.ATG" 
		TypeReference type = null;
		Expression expr = null;
		Statement embeddedStatement = null;
		BlockStatement block = null;
		statement = null;
		

#line  1544 "cs.ATG" 
		Location startLocation = la.Location; 
		if (la.kind == 16) {
			Block(
#line  1546 "cs.ATG" 
out block);

#line  1546 "cs.ATG" 
			statement = block; 
		} else if (la.kind == 11) {
			lexer.NextToken();

#line  1549 "cs.ATG" 
			statement = new EmptyStatement(); 
		} else if (
#line  1552 "cs.ATG" 
UnCheckedAndLBrace()) {

#line  1552 "cs.ATG" 
			bool isChecked = true; 
			if (la.kind == 58) {
				lexer.NextToken();
			} else if (la.kind == 118) {
				lexer.NextToken();

#line  1553 "cs.ATG" 
				isChecked = false;
			} else SynErr(196);
			Block(
#line  1554 "cs.ATG" 
out block);

#line  1554 "cs.ATG" 
			statement = isChecked ? (Statement)new CheckedStatement(block) : (Statement)new UncheckedStatement(block); 
		} else if (la.kind == 79) {
			IfStatement(
#line  1557 "cs.ATG" 
out statement);
		} else if (la.kind == 110) {
			lexer.NextToken();

#line  1559 "cs.ATG" 
			List<SwitchSection> switchSections = new List<SwitchSection>(); 
			Expect(20);
			Expr(
#line  1560 "cs.ATG" 
out expr);
			Expect(21);
			Expect(16);
			SwitchSections(
#line  1561 "cs.ATG" 
switchSections);
			Expect(17);

#line  1563 "cs.ATG" 
			statement = new SwitchStatement(expr, switchSections); 
		} else if (la.kind == 125) {
			lexer.NextToken();
			Expect(20);
			Expr(
#line  1566 "cs.ATG" 
out expr);
			Expect(21);
			EmbeddedStatement(
#line  1567 "cs.ATG" 
out embeddedStatement);

#line  1568 "cs.ATG" 
			statement = new DoLoopStatement(expr, embeddedStatement, ConditionType.While, ConditionPosition.Start);
		} else if (la.kind == 65) {
			lexer.NextToken();
			EmbeddedStatement(
#line  1570 "cs.ATG" 
out embeddedStatement);
			Expect(125);
			Expect(20);
			Expr(
#line  1571 "cs.ATG" 
out expr);
			Expect(21);
			Expect(11);

#line  1572 "cs.ATG" 
			statement = new DoLoopStatement(expr, embeddedStatement, ConditionType.While, ConditionPosition.End); 
		} else if (la.kind == 76) {
			lexer.NextToken();

#line  1574 "cs.ATG" 
			List<Statement> initializer = null; List<Statement> iterator = null; 
			Expect(20);
			if (StartOf(6)) {
				ForInitializer(
#line  1575 "cs.ATG" 
out initializer);
			}
			Expect(11);
			if (StartOf(6)) {
				Expr(
#line  1576 "cs.ATG" 
out expr);
			}
			Expect(11);
			if (StartOf(6)) {
				ForIterator(
#line  1577 "cs.ATG" 
out iterator);
			}
			Expect(21);
			EmbeddedStatement(
#line  1578 "cs.ATG" 
out embeddedStatement);

#line  1579 "cs.ATG" 
			statement = new ForStatement(initializer, expr, iterator, embeddedStatement); 
		} else if (la.kind == 77) {
			lexer.NextToken();
			Expect(20);
			Type(
#line  1581 "cs.ATG" 
out type);
			Identifier();

#line  1581 "cs.ATG" 
			string varName = t.val; 
			Expect(81);
			Expr(
#line  1582 "cs.ATG" 
out expr);
			Expect(21);
			EmbeddedStatement(
#line  1583 "cs.ATG" 
out embeddedStatement);

#line  1584 "cs.ATG" 
			statement = new ForeachStatement(type, varName , expr, embeddedStatement); 
		} else if (la.kind == 53) {
			lexer.NextToken();
			Expect(11);

#line  1587 "cs.ATG" 
			statement = new BreakStatement(); 
		} else if (la.kind == 61) {
			lexer.NextToken();
			Expect(11);

#line  1588 "cs.ATG" 
			statement = new ContinueStatement(); 
		} else if (la.kind == 78) {
			GotoStatement(
#line  1589 "cs.ATG" 
out statement);
		} else if (
#line  1591 "cs.ATG" 
IsYieldStatement()) {
			Expect(132);
			if (la.kind == 101) {
				lexer.NextToken();
				Expr(
#line  1592 "cs.ATG" 
out expr);

#line  1592 "cs.ATG" 
				statement = new YieldStatement(new ReturnStatement(expr)); 
			} else if (la.kind == 53) {
				lexer.NextToken();

#line  1593 "cs.ATG" 
				statement = new YieldStatement(new BreakStatement()); 
			} else SynErr(197);
			Expect(11);
		} else if (la.kind == 101) {
			lexer.NextToken();
			if (StartOf(6)) {
				Expr(
#line  1596 "cs.ATG" 
out expr);
			}
			Expect(11);

#line  1596 "cs.ATG" 
			statement = new ReturnStatement(expr); 
		} else if (la.kind == 112) {
			lexer.NextToken();
			if (StartOf(6)) {
				Expr(
#line  1597 "cs.ATG" 
out expr);
			}
			Expect(11);

#line  1597 "cs.ATG" 
			statement = new ThrowStatement(expr); 
		} else if (StartOf(6)) {
			StatementExpr(
#line  1600 "cs.ATG" 
out statement);
			while (!(la.kind == 0 || la.kind == 11)) {SynErr(198); lexer.NextToken(); }
			Expect(11);
		} else if (la.kind == 114) {
			TryStatement(
#line  1603 "cs.ATG" 
out statement);
		} else if (la.kind == 86) {
			lexer.NextToken();
			Expect(20);
			Expr(
#line  1606 "cs.ATG" 
out expr);
			Expect(21);
			EmbeddedStatement(
#line  1607 "cs.ATG" 
out embeddedStatement);

#line  1607 "cs.ATG" 
			statement = new LockStatement(expr, embeddedStatement); 
		} else if (la.kind == 121) {

#line  1610 "cs.ATG" 
			Statement resourceAcquisitionStmt = null; 
			lexer.NextToken();
			Expect(20);
			ResourceAcquisition(
#line  1612 "cs.ATG" 
out resourceAcquisitionStmt);
			Expect(21);
			EmbeddedStatement(
#line  1613 "cs.ATG" 
out embeddedStatement);

#line  1613 "cs.ATG" 
			statement = new UsingStatement(resourceAcquisitionStmt, embeddedStatement); 
		} else if (la.kind == 119) {
			lexer.NextToken();
			Block(
#line  1616 "cs.ATG" 
out block);

#line  1616 "cs.ATG" 
			statement = new UnsafeStatement(block); 
		} else if (la.kind == 74) {

#line  1618 "cs.ATG" 
			Statement pointerDeclarationStmt = null; 
			lexer.NextToken();
			Expect(20);
			ResourceAcquisition(
#line  1620 "cs.ATG" 
out pointerDeclarationStmt);
			Expect(21);
			EmbeddedStatement(
#line  1621 "cs.ATG" 
out embeddedStatement);

#line  1621 "cs.ATG" 
			statement = new FixedStatement(pointerDeclarationStmt, embeddedStatement); 
		} else SynErr(199);

#line  1623 "cs.ATG" 
		if (statement != null) {
		statement.StartLocation = startLocation;
		statement.EndLocation = t.EndLocation;
		}
		
	}

	void IfStatement(
#line  1630 "cs.ATG" 
out Statement statement) {

#line  1632 "cs.ATG" 
		Expression expr = null;
		Statement embeddedStatement = null;
		statement = null;
		
		Expect(79);
		Expect(20);
		Expr(
#line  1638 "cs.ATG" 
out expr);
		Expect(21);
		EmbeddedStatement(
#line  1639 "cs.ATG" 
out embeddedStatement);

#line  1640 "cs.ATG" 
		Statement elseStatement = null; 
		if (la.kind == 67) {
			lexer.NextToken();
			EmbeddedStatement(
#line  1641 "cs.ATG" 
out elseStatement);
		}

#line  1642 "cs.ATG" 
		statement = elseStatement != null ? new IfElseStatement(expr, embeddedStatement, elseStatement) : new IfElseStatement(expr, embeddedStatement); 

#line  1643 "cs.ATG" 
		if (elseStatement is IfElseStatement && (elseStatement as IfElseStatement).TrueStatement.Count == 1) {
		/* else if-section (otherwise we would have a BlockStatment) */
		(statement as IfElseStatement).ElseIfSections.Add(
		             new ElseIfSection((elseStatement as IfElseStatement).Condition,
		                               (elseStatement as IfElseStatement).TrueStatement[0]));
		(statement as IfElseStatement).ElseIfSections.AddRange((elseStatement as IfElseStatement).ElseIfSections);
		(statement as IfElseStatement).FalseStatement = (elseStatement as IfElseStatement).FalseStatement;
		}
		
	}

	void SwitchSections(
#line  1673 "cs.ATG" 
List<SwitchSection> switchSections) {

#line  1675 "cs.ATG" 
		SwitchSection switchSection = new SwitchSection();
		CaseLabel label;
		
		SwitchLabel(
#line  1679 "cs.ATG" 
out label);

#line  1679 "cs.ATG" 
		SafeAdd(switchSection, switchSection.SwitchLabels, label); 

#line  1680 "cs.ATG" 
		BlockStart(switchSection); 
		while (StartOf(31)) {
			if (la.kind == 55 || la.kind == 63) {
				SwitchLabel(
#line  1682 "cs.ATG" 
out label);

#line  1683 "cs.ATG" 
				if (label != null) {
				if (switchSection.Children.Count > 0) {
					// open new section
					BlockEnd(); switchSections.Add(switchSection);
					switchSection = new SwitchSection();
					BlockStart(switchSection);
				}
				SafeAdd(switchSection, switchSection.SwitchLabels, label);
				}
				
			} else {
				Statement();
			}
		}

#line  1695 "cs.ATG" 
		BlockEnd(); switchSections.Add(switchSection); 
	}

	void ForInitializer(
#line  1654 "cs.ATG" 
out List<Statement> initializer) {

#line  1656 "cs.ATG" 
		Statement stmt; 
		initializer = new List<Statement>();
		
		if (
#line  1660 "cs.ATG" 
IsLocalVarDecl()) {
			LocalVariableDecl(
#line  1660 "cs.ATG" 
out stmt);

#line  1660 "cs.ATG" 
			initializer.Add(stmt);
		} else if (StartOf(6)) {
			StatementExpr(
#line  1661 "cs.ATG" 
out stmt);

#line  1661 "cs.ATG" 
			initializer.Add(stmt);
			while (la.kind == 14) {
				lexer.NextToken();
				StatementExpr(
#line  1661 "cs.ATG" 
out stmt);

#line  1661 "cs.ATG" 
				initializer.Add(stmt);
			}
		} else SynErr(200);
	}

	void ForIterator(
#line  1664 "cs.ATG" 
out List<Statement> iterator) {

#line  1666 "cs.ATG" 
		Statement stmt; 
		iterator = new List<Statement>();
		
		StatementExpr(
#line  1670 "cs.ATG" 
out stmt);

#line  1670 "cs.ATG" 
		iterator.Add(stmt);
		while (la.kind == 14) {
			lexer.NextToken();
			StatementExpr(
#line  1670 "cs.ATG" 
out stmt);

#line  1670 "cs.ATG" 
			iterator.Add(stmt); 
		}
	}

	void GotoStatement(
#line  1752 "cs.ATG" 
out Statement stmt) {

#line  1753 "cs.ATG" 
		Expression expr; stmt = null; 
		Expect(78);
		if (StartOf(18)) {
			Identifier();

#line  1757 "cs.ATG" 
			stmt = new GotoStatement(t.val); 
			Expect(11);
		} else if (la.kind == 55) {
			lexer.NextToken();
			Expr(
#line  1758 "cs.ATG" 
out expr);
			Expect(11);

#line  1758 "cs.ATG" 
			stmt = new GotoCaseStatement(expr); 
		} else if (la.kind == 63) {
			lexer.NextToken();
			Expect(11);

#line  1759 "cs.ATG" 
			stmt = new GotoCaseStatement(null); 
		} else SynErr(201);
	}

	void StatementExpr(
#line  1779 "cs.ATG" 
out Statement stmt) {

#line  1780 "cs.ATG" 
		Expression expr; 
		Expr(
#line  1782 "cs.ATG" 
out expr);

#line  1785 "cs.ATG" 
		stmt = new ExpressionStatement(expr); 
	}

	void TryStatement(
#line  1705 "cs.ATG" 
out Statement tryStatement) {

#line  1707 "cs.ATG" 
		BlockStatement blockStmt = null, finallyStmt = null;
		CatchClause catchClause = null;
		List<CatchClause> catchClauses = new List<CatchClause>();
		
		Expect(114);
		Block(
#line  1712 "cs.ATG" 
out blockStmt);
		while (la.kind == 56) {
			CatchClause(
#line  1714 "cs.ATG" 
out catchClause);

#line  1715 "cs.ATG" 
			if (catchClause != null) catchClauses.Add(catchClause); 
		}
		if (la.kind == 73) {
			lexer.NextToken();
			Block(
#line  1717 "cs.ATG" 
out finallyStmt);
		}

#line  1719 "cs.ATG" 
		tryStatement = new TryCatchStatement(blockStmt, catchClauses, finallyStmt);
		if (catchClauses != null) {
			foreach (CatchClause cc in catchClauses) cc.Parent = tryStatement;
		}
		
	}

	void ResourceAcquisition(
#line  1763 "cs.ATG" 
out Statement stmt) {

#line  1765 "cs.ATG" 
		stmt = null;
		Expression expr;
		
		if (
#line  1770 "cs.ATG" 
IsLocalVarDecl()) {
			LocalVariableDecl(
#line  1770 "cs.ATG" 
out stmt);
		} else if (StartOf(6)) {
			Expr(
#line  1771 "cs.ATG" 
out expr);

#line  1775 "cs.ATG" 
			stmt = new ExpressionStatement(expr); 
		} else SynErr(202);
	}

	void SwitchLabel(
#line  1698 "cs.ATG" 
out CaseLabel label) {

#line  1699 "cs.ATG" 
		Expression expr = null; label = null; 
		if (la.kind == 55) {
			lexer.NextToken();
			Expr(
#line  1701 "cs.ATG" 
out expr);
			Expect(9);

#line  1701 "cs.ATG" 
			label =  new CaseLabel(expr); 
		} else if (la.kind == 63) {
			lexer.NextToken();
			Expect(9);

#line  1702 "cs.ATG" 
			label =  new CaseLabel(); 
		} else SynErr(203);
	}

	void CatchClause(
#line  1726 "cs.ATG" 
out CatchClause catchClause) {
		Expect(56);

#line  1728 "cs.ATG" 
		string identifier;
		BlockStatement stmt;
		TypeReference typeRef;
		Location startPos = t.Location;
		catchClause = null;
		
		if (la.kind == 16) {
			Block(
#line  1736 "cs.ATG" 
out stmt);

#line  1736 "cs.ATG" 
			catchClause = new CatchClause(stmt);  
		} else if (la.kind == 20) {
			lexer.NextToken();
			ClassType(
#line  1739 "cs.ATG" 
out typeRef, false);

#line  1739 "cs.ATG" 
			identifier = null; 
			if (StartOf(18)) {
				Identifier();

#line  1740 "cs.ATG" 
				identifier = t.val; 
			}
			Expect(21);
			Block(
#line  1741 "cs.ATG" 
out stmt);

#line  1742 "cs.ATG" 
			catchClause = new CatchClause(typeRef, identifier, stmt); 
		} else SynErr(204);

#line  1745 "cs.ATG" 
		if (catchClause != null) {
		catchClause.StartLocation = startPos;
		catchClause.EndLocation = t.Location;
		}
		
	}

	void UnaryExpr(
#line  1814 "cs.ATG" 
out Expression uExpr) {

#line  1816 "cs.ATG" 
		TypeReference type = null;
		Expression expr = null;
		ArrayList expressions = new ArrayList();
		uExpr = null;
		
		while (StartOf(32) || 
#line  1838 "cs.ATG" 
IsTypeCast()) {
			if (la.kind == 4) {
				lexer.NextToken();

#line  1825 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Plus)); 
			} else if (la.kind == 5) {
				lexer.NextToken();

#line  1826 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Minus)); 
			} else if (la.kind == 24) {
				lexer.NextToken();

#line  1827 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Not)); 
			} else if (la.kind == 27) {
				lexer.NextToken();

#line  1828 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.BitNot)); 
			} else if (la.kind == 6) {
				lexer.NextToken();

#line  1829 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Dereference)); 
			} else if (la.kind == 31) {
				lexer.NextToken();

#line  1830 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Increment)); 
			} else if (la.kind == 32) {
				lexer.NextToken();

#line  1831 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.Decrement)); 
			} else if (la.kind == 28) {
				lexer.NextToken();

#line  1832 "cs.ATG" 
				expressions.Add(new UnaryOperatorExpression(UnaryOperatorType.AddressOf)); 
			} else {
				Expect(20);
				Type(
#line  1838 "cs.ATG" 
out type);
				Expect(21);

#line  1838 "cs.ATG" 
				expressions.Add(new CastExpression(type)); 
			}
		}
		if (
#line  1843 "cs.ATG" 
LastExpressionIsUnaryMinus(expressions) && IsMostNegativeIntegerWithoutTypeSuffix()) {
			Expect(2);

#line  1846 "cs.ATG" 
			expressions.RemoveAt(expressions.Count - 1);
			if (t.literalValue is uint) {
				expr = new PrimitiveExpression(int.MinValue, int.MinValue.ToString());
			} else if (t.literalValue is ulong) {
				expr = new PrimitiveExpression(long.MinValue, long.MinValue.ToString());
			} else {
				throw new Exception("t.literalValue must be uint or ulong");
			}
			
		} else if (StartOf(33)) {
			PrimaryExpr(
#line  1855 "cs.ATG" 
out expr);
		} else SynErr(205);

#line  1857 "cs.ATG" 
		for (int i = 0; i < expressions.Count; ++i) {
		Expression nextExpression = i + 1 < expressions.Count ? (Expression)expressions[i + 1] : expr;
		if (expressions[i] is CastExpression) {
			((CastExpression)expressions[i]).Expression = nextExpression;
		} else {
			((UnaryOperatorExpression)expressions[i]).Expression = nextExpression;
		}
		}
		if (expressions.Count > 0) {
			uExpr = (Expression)expressions[0];
		} else {
			uExpr = expr;
		}
		
	}

	void ConditionalOrExpr(
#line  2167 "cs.ATG" 
ref Expression outExpr) {

#line  2168 "cs.ATG" 
		Expression expr; Location startLocation = la.Location; 
		ConditionalAndExpr(
#line  2170 "cs.ATG" 
ref outExpr);
		while (la.kind == 26) {
			lexer.NextToken();
			UnaryExpr(
#line  2170 "cs.ATG" 
out expr);
			ConditionalAndExpr(
#line  2170 "cs.ATG" 
ref expr);

#line  2170 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, BinaryOperatorType.LogicalOr, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void PrimaryExpr(
#line  1874 "cs.ATG" 
out Expression pexpr) {

#line  1876 "cs.ATG" 
		TypeReference type = null;
		Expression expr;
		pexpr = null;
		

#line  1881 "cs.ATG" 
		Location startLocation = la.Location; 
		if (la.kind == 113) {
			lexer.NextToken();

#line  1883 "cs.ATG" 
			pexpr = new PrimitiveExpression(true, "true");  
		} else if (la.kind == 72) {
			lexer.NextToken();

#line  1884 "cs.ATG" 
			pexpr = new PrimitiveExpression(false, "false"); 
		} else if (la.kind == 90) {
			lexer.NextToken();

#line  1885 "cs.ATG" 
			pexpr = new PrimitiveExpression(null, "null");  
		} else if (la.kind == 2) {
			lexer.NextToken();

#line  1886 "cs.ATG" 
			pexpr = new PrimitiveExpression(t.literalValue, t.val) { LiteralFormat = t.literalFormat };  
		} else if (
#line  1887 "cs.ATG" 
StartOfQueryExpression()) {
			QueryExpression(
#line  1888 "cs.ATG" 
out pexpr);
		} else if (
#line  1889 "cs.ATG" 
IdentAndDoubleColon()) {
			Identifier();

#line  1890 "cs.ATG" 
			type = new TypeReference(t.val); 
			Expect(10);

#line  1891 "cs.ATG" 
			pexpr = new TypeReferenceExpression(type); 
			Identifier();

#line  1892 "cs.ATG" 
			if (type.Type == "global") { type.IsGlobal = true; type.Type = t.val ?? "?"; } else type.Type += "." + (t.val ?? "?"); 
		} else if (StartOf(18)) {
			Identifier();

#line  1896 "cs.ATG" 
			pexpr = new IdentifierExpression(t.val); 
			if (la.kind == 48 || 
#line  1899 "cs.ATG" 
IsGenericInSimpleNameOrMemberAccess()) {
				if (la.kind == 48) {
					ShortedLambdaExpression(
#line  1898 "cs.ATG" 
(IdentifierExpression)pexpr, out pexpr);
				} else {

#line  1900 "cs.ATG" 
					List<TypeReference> typeList; 
					TypeArgumentList(
#line  1901 "cs.ATG" 
out typeList, false);

#line  1902 "cs.ATG" 
					((IdentifierExpression)pexpr).TypeArguments = typeList; 
				}
			}
		} else if (
#line  1904 "cs.ATG" 
IsLambdaExpression()) {
			LambdaExpression(
#line  1905 "cs.ATG" 
out pexpr);
		} else if (la.kind == 20) {
			lexer.NextToken();
			Expr(
#line  1908 "cs.ATG" 
out expr);
			Expect(21);

#line  1908 "cs.ATG" 
			pexpr = new ParenthesizedExpression(expr); 
		} else if (StartOf(34)) {

#line  1911 "cs.ATG" 
			string val = null; 
			switch (la.kind) {
			case 52: {
				lexer.NextToken();

#line  1912 "cs.ATG" 
				val = "System.Boolean"; 
				break;
			}
			case 54: {
				lexer.NextToken();

#line  1913 "cs.ATG" 
				val = "System.Byte"; 
				break;
			}
			case 57: {
				lexer.NextToken();

#line  1914 "cs.ATG" 
				val = "System.Char"; 
				break;
			}
			case 62: {
				lexer.NextToken();

#line  1915 "cs.ATG" 
				val = "System.Decimal"; 
				break;
			}
			case 66: {
				lexer.NextToken();

#line  1916 "cs.ATG" 
				val = "System.Double"; 
				break;
			}
			case 75: {
				lexer.NextToken();

#line  1917 "cs.ATG" 
				val = "System.Single"; 
				break;
			}
			case 82: {
				lexer.NextToken();

#line  1918 "cs.ATG" 
				val = "System.Int32"; 
				break;
			}
			case 87: {
				lexer.NextToken();

#line  1919 "cs.ATG" 
				val = "System.Int64"; 
				break;
			}
			case 91: {
				lexer.NextToken();

#line  1920 "cs.ATG" 
				val = "System.Object"; 
				break;
			}
			case 102: {
				lexer.NextToken();

#line  1921 "cs.ATG" 
				val = "System.SByte"; 
				break;
			}
			case 104: {
				lexer.NextToken();

#line  1922 "cs.ATG" 
				val = "System.Int16"; 
				break;
			}
			case 108: {
				lexer.NextToken();

#line  1923 "cs.ATG" 
				val = "System.String"; 
				break;
			}
			case 116: {
				lexer.NextToken();

#line  1924 "cs.ATG" 
				val = "System.UInt32"; 
				break;
			}
			case 117: {
				lexer.NextToken();

#line  1925 "cs.ATG" 
				val = "System.UInt64"; 
				break;
			}
			case 120: {
				lexer.NextToken();

#line  1926 "cs.ATG" 
				val = "System.UInt16"; 
				break;
			}
			case 123: {
				lexer.NextToken();

#line  1927 "cs.ATG" 
				val = "System.Void"; 
				break;
			}
			}

#line  1929 "cs.ATG" 
			pexpr = new TypeReferenceExpression(new TypeReference(val, true)) { StartLocation = t.Location, EndLocation = t.EndLocation }; 
		} else if (la.kind == 111) {
			lexer.NextToken();

#line  1932 "cs.ATG" 
			pexpr = new ThisReferenceExpression(); pexpr.StartLocation = t.Location; pexpr.EndLocation = t.EndLocation; 
		} else if (la.kind == 51) {
			lexer.NextToken();

#line  1934 "cs.ATG" 
			pexpr = new BaseReferenceExpression(); pexpr.StartLocation = t.Location; pexpr.EndLocation = t.EndLocation; 
		} else if (la.kind == 89) {
			NewExpression(
#line  1937 "cs.ATG" 
out pexpr);
		} else if (la.kind == 115) {
			lexer.NextToken();
			Expect(20);
			if (
#line  1941 "cs.ATG" 
NotVoidPointer()) {
				Expect(123);

#line  1941 "cs.ATG" 
				type = new TypeReference("System.Void", true); 
			} else if (StartOf(10)) {
				TypeWithRestriction(
#line  1942 "cs.ATG" 
out type, true, true);
			} else SynErr(206);
			Expect(21);

#line  1944 "cs.ATG" 
			pexpr = new TypeOfExpression(type); 
		} else if (la.kind == 63) {
			lexer.NextToken();
			Expect(20);
			Type(
#line  1946 "cs.ATG" 
out type);
			Expect(21);

#line  1946 "cs.ATG" 
			pexpr = new DefaultValueExpression(type); 
		} else if (la.kind == 105) {
			lexer.NextToken();
			Expect(20);
			Type(
#line  1947 "cs.ATG" 
out type);
			Expect(21);

#line  1947 "cs.ATG" 
			pexpr = new SizeOfExpression(type); 
		} else if (la.kind == 58) {
			lexer.NextToken();
			Expect(20);
			Expr(
#line  1948 "cs.ATG" 
out expr);
			Expect(21);

#line  1948 "cs.ATG" 
			pexpr = new CheckedExpression(expr); 
		} else if (la.kind == 118) {
			lexer.NextToken();
			Expect(20);
			Expr(
#line  1949 "cs.ATG" 
out expr);
			Expect(21);

#line  1949 "cs.ATG" 
			pexpr = new UncheckedExpression(expr); 
		} else if (la.kind == 64) {
			lexer.NextToken();
			AnonymousMethodExpr(
#line  1950 "cs.ATG" 
out expr);

#line  1950 "cs.ATG" 
			pexpr = expr; 
		} else SynErr(207);

#line  1952 "cs.ATG" 
		if (pexpr != null) {
		if (pexpr.StartLocation.IsEmpty)
			pexpr.StartLocation = startLocation;
		if (pexpr.EndLocation.IsEmpty)
			pexpr.EndLocation = t.EndLocation;
		}
		
		while (StartOf(35)) {

#line  1960 "cs.ATG" 
			startLocation = la.Location; 
			switch (la.kind) {
			case 31: {
				lexer.NextToken();

#line  1962 "cs.ATG" 
				pexpr = new UnaryOperatorExpression(pexpr, UnaryOperatorType.PostIncrement); 
				break;
			}
			case 32: {
				lexer.NextToken();

#line  1964 "cs.ATG" 
				pexpr = new UnaryOperatorExpression(pexpr, UnaryOperatorType.PostDecrement); 
				break;
			}
			case 47: {
				PointerMemberAccess(
#line  1966 "cs.ATG" 
out pexpr, pexpr);
				break;
			}
			case 15: {
				MemberAccess(
#line  1967 "cs.ATG" 
out pexpr, pexpr);
				break;
			}
			case 20: {
				lexer.NextToken();

#line  1971 "cs.ATG" 
				List<Expression> parameters = new List<Expression>(); 

#line  1972 "cs.ATG" 
				pexpr = new InvocationExpression(pexpr, parameters); 
				if (StartOf(25)) {
					Argument(
#line  1973 "cs.ATG" 
out expr);

#line  1973 "cs.ATG" 
					SafeAdd(pexpr, parameters, expr); 
					while (la.kind == 14) {
						lexer.NextToken();
						Argument(
#line  1974 "cs.ATG" 
out expr);

#line  1974 "cs.ATG" 
						SafeAdd(pexpr, parameters, expr); 
					}
				}
				Expect(21);
				break;
			}
			case 18: {

#line  1980 "cs.ATG" 
				List<Expression> indices = new List<Expression>();
				pexpr = new IndexerExpression(pexpr, indices);
				
				lexer.NextToken();
				Expr(
#line  1983 "cs.ATG" 
out expr);

#line  1983 "cs.ATG" 
				SafeAdd(pexpr, indices, expr); 
				while (la.kind == 14) {
					lexer.NextToken();
					Expr(
#line  1984 "cs.ATG" 
out expr);

#line  1984 "cs.ATG" 
					SafeAdd(pexpr, indices, expr); 
				}
				Expect(19);
				break;
			}
			}

#line  1987 "cs.ATG" 
			if (pexpr != null) {
			if (pexpr.StartLocation.IsEmpty)
				pexpr.StartLocation = startLocation;
			if (pexpr.EndLocation.IsEmpty)
				pexpr.EndLocation = t.EndLocation;
			}
			
		}
	}

	void QueryExpression(
#line  2425 "cs.ATG" 
out Expression outExpr) {

#line  2426 "cs.ATG" 
		QueryExpression q = new QueryExpression(); outExpr = q; q.StartLocation = la.Location; 
		QueryExpressionFromClause fromClause;
		
		QueryExpressionFromClause(
#line  2430 "cs.ATG" 
out fromClause);

#line  2430 "cs.ATG" 
		q.FromClause = fromClause; 
		QueryExpressionBody(
#line  2431 "cs.ATG" 
ref q);

#line  2432 "cs.ATG" 
		q.EndLocation = t.EndLocation; 
		outExpr = q; /* set outExpr to q again if QueryExpressionBody changed it (can happen with 'into' clauses) */ 
		
	}

	void ShortedLambdaExpression(
#line  2101 "cs.ATG" 
IdentifierExpression ident, out Expression pexpr) {

#line  2102 "cs.ATG" 
		LambdaExpression lambda = new LambdaExpression(); pexpr = lambda; 
		Expect(48);

#line  2107 "cs.ATG" 
		lambda.StartLocation = ident.StartLocation;
		SafeAdd(lambda, lambda.Parameters, new ParameterDeclarationExpression(null, ident.Identifier));
		lambda.Parameters[0].StartLocation = ident.StartLocation;
		lambda.Parameters[0].EndLocation = ident.EndLocation;
		
		LambdaExpressionBody(
#line  2112 "cs.ATG" 
lambda);
	}

	void TypeArgumentList(
#line  2344 "cs.ATG" 
out List<TypeReference> types, bool canBeUnbound) {

#line  2346 "cs.ATG" 
		types = new List<TypeReference>();
		TypeReference type = null;
		
		Expect(23);
		if (
#line  2351 "cs.ATG" 
canBeUnbound && (la.kind == Tokens.GreaterThan || la.kind == Tokens.Comma)) {

#line  2352 "cs.ATG" 
			types.Add(TypeReference.Null); 
			while (la.kind == 14) {
				lexer.NextToken();

#line  2353 "cs.ATG" 
				types.Add(TypeReference.Null); 
			}
		} else if (StartOf(10)) {
			Type(
#line  2354 "cs.ATG" 
out type);

#line  2354 "cs.ATG" 
			if (type != null) { types.Add(type); } 
			while (la.kind == 14) {
				lexer.NextToken();
				Type(
#line  2355 "cs.ATG" 
out type);

#line  2355 "cs.ATG" 
				if (type != null) { types.Add(type); } 
			}
		} else SynErr(208);
		Expect(22);
	}

	void LambdaExpression(
#line  2081 "cs.ATG" 
out Expression outExpr) {

#line  2083 "cs.ATG" 
		LambdaExpression lambda = new LambdaExpression();
		lambda.StartLocation = la.Location;
		ParameterDeclarationExpression p;
		outExpr = lambda;
		
		Expect(20);
		if (StartOf(36)) {
			LambdaExpressionParameter(
#line  2091 "cs.ATG" 
out p);

#line  2091 "cs.ATG" 
			SafeAdd(lambda, lambda.Parameters, p); 
			while (la.kind == 14) {
				lexer.NextToken();
				LambdaExpressionParameter(
#line  2093 "cs.ATG" 
out p);

#line  2093 "cs.ATG" 
				SafeAdd(lambda, lambda.Parameters, p); 
			}
		}
		Expect(21);
		Expect(48);
		LambdaExpressionBody(
#line  2098 "cs.ATG" 
lambda);
	}

	void NewExpression(
#line  2028 "cs.ATG" 
out Expression pexpr) {

#line  2029 "cs.ATG" 
		pexpr = null;
		List<Expression> parameters = new List<Expression>();
		TypeReference type = null;
		Expression expr;
		
		Expect(89);
		if (StartOf(10)) {
			NonArrayType(
#line  2036 "cs.ATG" 
out type);
		}
		if (la.kind == 16 || la.kind == 20) {
			if (la.kind == 20) {

#line  2042 "cs.ATG" 
				ObjectCreateExpression oce = new ObjectCreateExpression(type, parameters); 
				lexer.NextToken();

#line  2043 "cs.ATG" 
				if (type == null) Error("Cannot use an anonymous type with arguments for the constructor"); 
				if (StartOf(25)) {
					Argument(
#line  2044 "cs.ATG" 
out expr);

#line  2044 "cs.ATG" 
					SafeAdd(oce, parameters, expr); 
					while (la.kind == 14) {
						lexer.NextToken();
						Argument(
#line  2045 "cs.ATG" 
out expr);

#line  2045 "cs.ATG" 
						SafeAdd(oce, parameters, expr); 
					}
				}
				Expect(21);

#line  2047 "cs.ATG" 
				pexpr = oce; 
				if (la.kind == 16) {
					CollectionOrObjectInitializer(
#line  2048 "cs.ATG" 
out expr);

#line  2048 "cs.ATG" 
					oce.ObjectInitializer = (CollectionInitializerExpression)expr; 
				}
			} else {

#line  2049 "cs.ATG" 
				ObjectCreateExpression oce = new ObjectCreateExpression(type, parameters); 
				CollectionOrObjectInitializer(
#line  2050 "cs.ATG" 
out expr);

#line  2050 "cs.ATG" 
				oce.ObjectInitializer = (CollectionInitializerExpression)expr; 

#line  2051 "cs.ATG" 
				pexpr = oce; 
			}
		} else if (la.kind == 18) {
			lexer.NextToken();

#line  2056 "cs.ATG" 
			ArrayCreateExpression ace = new ArrayCreateExpression(type);
			/* we must not change RankSpecifier on the null type reference*/
			if (ace.CreateType.IsNull) { ace.CreateType = new TypeReference(""); }
			pexpr = ace;
			int dims = 0; List<int> ranks = new List<int>();
			
			if (la.kind == 14 || la.kind == 19) {
				while (la.kind == 14) {
					lexer.NextToken();

#line  2063 "cs.ATG" 
					dims += 1; 
				}
				Expect(19);

#line  2064 "cs.ATG" 
				ranks.Add(dims); dims = 0; 
				while (la.kind == 18) {
					lexer.NextToken();
					while (la.kind == 14) {
						lexer.NextToken();

#line  2065 "cs.ATG" 
						++dims; 
					}
					Expect(19);

#line  2065 "cs.ATG" 
					ranks.Add(dims); dims = 0; 
				}

#line  2066 "cs.ATG" 
				ace.CreateType.RankSpecifier = ranks.ToArray(); 
				CollectionInitializer(
#line  2067 "cs.ATG" 
out expr);

#line  2067 "cs.ATG" 
				ace.ArrayInitializer = (CollectionInitializerExpression)expr; 
			} else if (StartOf(6)) {
				Expr(
#line  2068 "cs.ATG" 
out expr);

#line  2068 "cs.ATG" 
				if (expr != null) parameters.Add(expr); 
				while (la.kind == 14) {
					lexer.NextToken();

#line  2069 "cs.ATG" 
					dims += 1; 
					Expr(
#line  2070 "cs.ATG" 
out expr);

#line  2070 "cs.ATG" 
					if (expr != null) parameters.Add(expr); 
				}
				Expect(19);

#line  2072 "cs.ATG" 
				ranks.Add(dims); ace.Arguments = parameters; dims = 0; 
				while (la.kind == 18) {
					lexer.NextToken();
					while (la.kind == 14) {
						lexer.NextToken();

#line  2073 "cs.ATG" 
						++dims; 
					}
					Expect(19);

#line  2073 "cs.ATG" 
					ranks.Add(dims); dims = 0; 
				}

#line  2074 "cs.ATG" 
				ace.CreateType.RankSpecifier = ranks.ToArray(); 
				if (la.kind == 16) {
					CollectionInitializer(
#line  2075 "cs.ATG" 
out expr);

#line  2075 "cs.ATG" 
					ace.ArrayInitializer = (CollectionInitializerExpression)expr; 
				}
			} else SynErr(209);
		} else SynErr(210);
	}

	void AnonymousMethodExpr(
#line  2148 "cs.ATG" 
out Expression outExpr) {

#line  2150 "cs.ATG" 
		AnonymousMethodExpression expr = new AnonymousMethodExpression();
		expr.StartLocation = t.Location;
		BlockStatement stmt;
		List<ParameterDeclarationExpression> p = new List<ParameterDeclarationExpression>();
		outExpr = expr;
		
		if (la.kind == 20) {
			lexer.NextToken();
			if (StartOf(11)) {
				FormalParameterList(
#line  2159 "cs.ATG" 
p);

#line  2159 "cs.ATG" 
				expr.Parameters = p; 
			}
			Expect(21);

#line  2161 "cs.ATG" 
			expr.HasParameterList = true; 
		}
		Block(
#line  2163 "cs.ATG" 
out stmt);

#line  2163 "cs.ATG" 
		expr.Body = stmt; 

#line  2164 "cs.ATG" 
		expr.EndLocation = t.Location; 
	}

	void PointerMemberAccess(
#line  2016 "cs.ATG" 
out Expression expr, Expression target) {

#line  2017 "cs.ATG" 
		List<TypeReference> typeList; 
		Expect(47);
		Identifier();

#line  2021 "cs.ATG" 
		expr = new PointerReferenceExpression(target, t.val); expr.StartLocation = t.Location; expr.EndLocation = t.EndLocation; 
		if (
#line  2022 "cs.ATG" 
IsGenericInSimpleNameOrMemberAccess()) {
			TypeArgumentList(
#line  2023 "cs.ATG" 
out typeList, false);

#line  2024 "cs.ATG" 
			((MemberReferenceExpression)expr).TypeArguments = typeList; 
		}
	}

	void MemberAccess(
#line  1997 "cs.ATG" 
out Expression expr, Expression target) {

#line  1998 "cs.ATG" 
		List<TypeReference> typeList; 

#line  2000 "cs.ATG" 
		if (ShouldConvertTargetExpressionToTypeReference(target)) {
		TypeReference type = GetTypeReferenceFromExpression(target);
		if (type != null) {
			target = new TypeReferenceExpression(type) { StartLocation = t.Location, EndLocation = t.EndLocation };
		}
		}
		
		Expect(15);

#line  2007 "cs.ATG" 
		Location startLocation = t.Location; 
		Identifier();

#line  2009 "cs.ATG" 
		expr = new MemberReferenceExpression(target, t.val); expr.StartLocation = startLocation; expr.EndLocation = t.EndLocation; 
		if (
#line  2010 "cs.ATG" 
IsGenericInSimpleNameOrMemberAccess()) {
			TypeArgumentList(
#line  2011 "cs.ATG" 
out typeList, false);

#line  2012 "cs.ATG" 
			((MemberReferenceExpression)expr).TypeArguments = typeList; 
		}
	}

	void LambdaExpressionParameter(
#line  2115 "cs.ATG" 
out ParameterDeclarationExpression p) {

#line  2116 "cs.ATG" 
		Location start = la.Location; p = null;
		TypeReference type;
		ParameterModifiers mod = ParameterModifiers.In;
		
		if (
#line  2121 "cs.ATG" 
Peek(1).kind == Tokens.Comma || Peek(1).kind == Tokens.CloseParenthesis) {
			Identifier();

#line  2123 "cs.ATG" 
			p = new ParameterDeclarationExpression(null, t.val);
			p.StartLocation = start; p.EndLocation = t.EndLocation;
			
		} else if (StartOf(36)) {
			if (la.kind == 93 || la.kind == 100) {
				if (la.kind == 100) {
					lexer.NextToken();

#line  2126 "cs.ATG" 
					mod = ParameterModifiers.Ref; 
				} else {
					lexer.NextToken();

#line  2127 "cs.ATG" 
					mod = ParameterModifiers.Out; 
				}
			}
			Type(
#line  2129 "cs.ATG" 
out type);
			Identifier();

#line  2131 "cs.ATG" 
			p = new ParameterDeclarationExpression(type, t.val, mod);
			p.StartLocation = start; p.EndLocation = t.EndLocation;
			
		} else SynErr(211);
	}

	void LambdaExpressionBody(
#line  2137 "cs.ATG" 
LambdaExpression lambda) {

#line  2138 "cs.ATG" 
		Expression expr; BlockStatement stmt; 
		if (la.kind == 16) {
			Block(
#line  2141 "cs.ATG" 
out stmt);

#line  2141 "cs.ATG" 
			lambda.StatementBody = stmt; 
		} else if (StartOf(6)) {
			Expr(
#line  2142 "cs.ATG" 
out expr);

#line  2142 "cs.ATG" 
			lambda.ExpressionBody = expr; 
		} else SynErr(212);

#line  2144 "cs.ATG" 
		lambda.EndLocation = t.EndLocation; 

#line  2145 "cs.ATG" 
		lambda.ExtendedEndLocation = la.Location; 
	}

	void ConditionalAndExpr(
#line  2173 "cs.ATG" 
ref Expression outExpr) {

#line  2174 "cs.ATG" 
		Expression expr; Location startLocation = la.Location; 
		InclusiveOrExpr(
#line  2176 "cs.ATG" 
ref outExpr);
		while (la.kind == 25) {
			lexer.NextToken();
			UnaryExpr(
#line  2176 "cs.ATG" 
out expr);
			InclusiveOrExpr(
#line  2176 "cs.ATG" 
ref expr);

#line  2176 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, BinaryOperatorType.LogicalAnd, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void InclusiveOrExpr(
#line  2179 "cs.ATG" 
ref Expression outExpr) {

#line  2180 "cs.ATG" 
		Expression expr; Location startLocation = la.Location; 
		ExclusiveOrExpr(
#line  2182 "cs.ATG" 
ref outExpr);
		while (la.kind == 29) {
			lexer.NextToken();
			UnaryExpr(
#line  2182 "cs.ATG" 
out expr);
			ExclusiveOrExpr(
#line  2182 "cs.ATG" 
ref expr);

#line  2182 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, BinaryOperatorType.BitwiseOr, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void ExclusiveOrExpr(
#line  2185 "cs.ATG" 
ref Expression outExpr) {

#line  2186 "cs.ATG" 
		Expression expr; Location startLocation = la.Location; 
		AndExpr(
#line  2188 "cs.ATG" 
ref outExpr);
		while (la.kind == 30) {
			lexer.NextToken();
			UnaryExpr(
#line  2188 "cs.ATG" 
out expr);
			AndExpr(
#line  2188 "cs.ATG" 
ref expr);

#line  2188 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, BinaryOperatorType.ExclusiveOr, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void AndExpr(
#line  2191 "cs.ATG" 
ref Expression outExpr) {

#line  2192 "cs.ATG" 
		Expression expr; Location startLocation = la.Location; 
		EqualityExpr(
#line  2194 "cs.ATG" 
ref outExpr);
		while (la.kind == 28) {
			lexer.NextToken();
			UnaryExpr(
#line  2194 "cs.ATG" 
out expr);
			EqualityExpr(
#line  2194 "cs.ATG" 
ref expr);

#line  2194 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, BinaryOperatorType.BitwiseAnd, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void EqualityExpr(
#line  2197 "cs.ATG" 
ref Expression outExpr) {

#line  2199 "cs.ATG" 
		Expression expr;
		BinaryOperatorType op = BinaryOperatorType.None;
		Location startLocation = la.Location;
		
		RelationalExpr(
#line  2204 "cs.ATG" 
ref outExpr);
		while (la.kind == 33 || la.kind == 34) {
			if (la.kind == 34) {
				lexer.NextToken();

#line  2207 "cs.ATG" 
				op = BinaryOperatorType.InEquality; 
			} else {
				lexer.NextToken();

#line  2208 "cs.ATG" 
				op = BinaryOperatorType.Equality; 
			}
			UnaryExpr(
#line  2210 "cs.ATG" 
out expr);
			RelationalExpr(
#line  2210 "cs.ATG" 
ref expr);

#line  2210 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, op, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void RelationalExpr(
#line  2214 "cs.ATG" 
ref Expression outExpr) {

#line  2216 "cs.ATG" 
		TypeReference type;
		Expression expr;
		BinaryOperatorType op = BinaryOperatorType.None;
		Location startLocation = la.Location;
		
		ShiftExpr(
#line  2222 "cs.ATG" 
ref outExpr);
		while (StartOf(37)) {
			if (StartOf(38)) {
				if (la.kind == 23) {
					lexer.NextToken();

#line  2224 "cs.ATG" 
					op = BinaryOperatorType.LessThan; 
				} else if (la.kind == 22) {
					lexer.NextToken();

#line  2225 "cs.ATG" 
					op = BinaryOperatorType.GreaterThan; 
				} else if (la.kind == 36) {
					lexer.NextToken();

#line  2226 "cs.ATG" 
					op = BinaryOperatorType.LessThanOrEqual; 
				} else if (la.kind == 35) {
					lexer.NextToken();

#line  2227 "cs.ATG" 
					op = BinaryOperatorType.GreaterThanOrEqual; 
				} else SynErr(213);
				UnaryExpr(
#line  2229 "cs.ATG" 
out expr);
				ShiftExpr(
#line  2230 "cs.ATG" 
ref expr);

#line  2231 "cs.ATG" 
				outExpr = new BinaryOperatorExpression(outExpr, op, expr) { StartLocation = startLocation, EndLocation = t.EndLocation }; 
			} else {
				if (la.kind == 85) {
					lexer.NextToken();
					TypeWithRestriction(
#line  2234 "cs.ATG" 
out type, false, false);
					if (
#line  2235 "cs.ATG" 
la.kind == Tokens.Question && !IsPossibleExpressionStart(Peek(1).kind)) {
						NullableQuestionMark(
#line  2236 "cs.ATG" 
ref type);
					}

#line  2237 "cs.ATG" 
					outExpr = new TypeOfIsExpression(outExpr, type)  { StartLocation = startLocation, EndLocation = t.EndLocation }; 
				} else if (la.kind == 50) {
					lexer.NextToken();
					TypeWithRestriction(
#line  2239 "cs.ATG" 
out type, false, false);
					if (
#line  2240 "cs.ATG" 
la.kind == Tokens.Question && !IsPossibleExpressionStart(Peek(1).kind)) {
						NullableQuestionMark(
#line  2241 "cs.ATG" 
ref type);
					}

#line  2242 "cs.ATG" 
					outExpr = new CastExpression(type, outExpr, CastType.TryCast) { StartLocation = startLocation, EndLocation = t.EndLocation }; 
				} else SynErr(214);
			}
		}
	}

	void ShiftExpr(
#line  2247 "cs.ATG" 
ref Expression outExpr) {

#line  2249 "cs.ATG" 
		Expression expr;
		BinaryOperatorType op = BinaryOperatorType.None;
		Location startLocation = la.Location;
		
		AdditiveExpr(
#line  2254 "cs.ATG" 
ref outExpr);
		while (la.kind == 37 || 
#line  2257 "cs.ATG" 
IsShiftRight()) {
			if (la.kind == 37) {
				lexer.NextToken();

#line  2256 "cs.ATG" 
				op = BinaryOperatorType.ShiftLeft; 
			} else {
				Expect(22);
				Expect(22);

#line  2258 "cs.ATG" 
				op = BinaryOperatorType.ShiftRight; 
			}
			UnaryExpr(
#line  2261 "cs.ATG" 
out expr);
			AdditiveExpr(
#line  2261 "cs.ATG" 
ref expr);

#line  2261 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, op, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void AdditiveExpr(
#line  2265 "cs.ATG" 
ref Expression outExpr) {

#line  2267 "cs.ATG" 
		Expression expr;
		BinaryOperatorType op = BinaryOperatorType.None;
		Location startLocation = la.Location;
		
		MultiplicativeExpr(
#line  2272 "cs.ATG" 
ref outExpr);
		while (la.kind == 4 || la.kind == 5) {
			if (la.kind == 4) {
				lexer.NextToken();

#line  2275 "cs.ATG" 
				op = BinaryOperatorType.Add; 
			} else {
				lexer.NextToken();

#line  2276 "cs.ATG" 
				op = BinaryOperatorType.Subtract; 
			}
			UnaryExpr(
#line  2278 "cs.ATG" 
out expr);
			MultiplicativeExpr(
#line  2278 "cs.ATG" 
ref expr);

#line  2278 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, op, expr) { StartLocation = startLocation, EndLocation = t.EndLocation };  
		}
	}

	void MultiplicativeExpr(
#line  2282 "cs.ATG" 
ref Expression outExpr) {

#line  2284 "cs.ATG" 
		Expression expr;
		BinaryOperatorType op = BinaryOperatorType.None;
		Location startLocation = la.Location;
		
		while (la.kind == 6 || la.kind == 7 || la.kind == 8) {
			if (la.kind == 6) {
				lexer.NextToken();

#line  2291 "cs.ATG" 
				op = BinaryOperatorType.Multiply; 
			} else if (la.kind == 7) {
				lexer.NextToken();

#line  2292 "cs.ATG" 
				op = BinaryOperatorType.Divide; 
			} else {
				lexer.NextToken();

#line  2293 "cs.ATG" 
				op = BinaryOperatorType.Modulus; 
			}
			UnaryExpr(
#line  2295 "cs.ATG" 
out expr);

#line  2295 "cs.ATG" 
			outExpr = new BinaryOperatorExpression(outExpr, op, expr) { StartLocation = startLocation, EndLocation = t.EndLocation }; 
		}
	}

	void VariantTypeParameter(
#line  2373 "cs.ATG" 
out TemplateDefinition typeParameter) {

#line  2375 "cs.ATG" 
		typeParameter = new TemplateDefinition();
		AttributeSection section;
		
		while (la.kind == 18) {
			AttributeSection(
#line  2379 "cs.ATG" 
out section);

#line  2379 "cs.ATG" 
			typeParameter.Attributes.Add(section); 
		}
		if (la.kind == 81 || la.kind == 93) {
			if (la.kind == 81) {
				lexer.NextToken();

#line  2381 "cs.ATG" 
				typeParameter.VarianceModifier = VarianceModifier.Contravariant; 
			} else {
				lexer.NextToken();

#line  2382 "cs.ATG" 
				typeParameter.VarianceModifier = VarianceModifier.Covariant; 
			}
		}
		Identifier();

#line  2384 "cs.ATG" 
		typeParameter.Name = t.val; typeParameter.StartLocation = t.Location; 

#line  2385 "cs.ATG" 
		typeParameter.EndLocation = t.EndLocation; 
	}

	void TypeParameterConstraintsClauseBase(
#line  2416 "cs.ATG" 
out TypeReference type) {

#line  2417 "cs.ATG" 
		TypeReference t; type = null; 
		if (la.kind == 109) {
			lexer.NextToken();

#line  2419 "cs.ATG" 
			type = TypeReference.StructConstraint; 
		} else if (la.kind == 59) {
			lexer.NextToken();

#line  2420 "cs.ATG" 
			type = TypeReference.ClassConstraint; 
		} else if (la.kind == 89) {
			lexer.NextToken();
			Expect(20);
			Expect(21);

#line  2421 "cs.ATG" 
			type = TypeReference.NewConstraint; 
		} else if (StartOf(10)) {
			Type(
#line  2422 "cs.ATG" 
out t);

#line  2422 "cs.ATG" 
			type = t; 
		} else SynErr(215);
	}

	void QueryExpressionFromClause(
#line  2437 "cs.ATG" 
out QueryExpressionFromClause fc) {

#line  2438 "cs.ATG" 
		fc = new QueryExpressionFromClause();
		fc.StartLocation = la.Location;
		CollectionRangeVariable variable;
		
		Expect(137);
		QueryExpressionFromOrJoinClause(
#line  2444 "cs.ATG" 
out variable);

#line  2445 "cs.ATG" 
		fc.EndLocation = t.EndLocation;
		fc.Sources.Add(variable);
		
	}

	void QueryExpressionBody(
#line  2481 "cs.ATG" 
ref QueryExpression q) {

#line  2482 "cs.ATG" 
		QueryExpressionFromClause fromClause;     QueryExpressionWhereClause whereClause;
		QueryExpressionLetClause letClause;       QueryExpressionJoinClause joinClause;
		QueryExpressionOrderClause orderClause;
		QueryExpressionSelectClause selectClause; QueryExpressionGroupClause groupClause;
		
		while (StartOf(39)) {
			if (la.kind == 137) {
				QueryExpressionFromClause(
#line  2488 "cs.ATG" 
out fromClause);

#line  2488 "cs.ATG" 
				SafeAdd<QueryExpressionClause>(q, q.MiddleClauses, fromClause); 
			} else if (la.kind == 127) {
				QueryExpressionWhereClause(
#line  2489 "cs.ATG" 
out whereClause);

#line  2489 "cs.ATG" 
				SafeAdd<QueryExpressionClause>(q, q.MiddleClauses, whereClause); 
			} else if (la.kind == 141) {
				QueryExpressionLetClause(
#line  2490 "cs.ATG" 
out letClause);

#line  2490 "cs.ATG" 
				SafeAdd<QueryExpressionClause>(q, q.MiddleClauses, letClause); 
			} else if (la.kind == 142) {
				QueryExpressionJoinClause(
#line  2491 "cs.ATG" 
out joinClause);

#line  2491 "cs.ATG" 
				SafeAdd<QueryExpressionClause>(q, q.MiddleClauses, joinClause); 
			} else {
				QueryExpressionOrderByClause(
#line  2492 "cs.ATG" 
out orderClause);

#line  2492 "cs.ATG" 
				SafeAdd<QueryExpressionClause>(q, q.MiddleClauses, orderClause); 
			}
		}
		if (la.kind == 133) {
			QueryExpressionSelectClause(
#line  2494 "cs.ATG" 
out selectClause);

#line  2494 "cs.ATG" 
			q.SelectOrGroupClause = selectClause; 
		} else if (la.kind == 134) {
			QueryExpressionGroupClause(
#line  2495 "cs.ATG" 
out groupClause);

#line  2495 "cs.ATG" 
			q.SelectOrGroupClause = groupClause; 
		} else SynErr(216);
		if (la.kind == 136) {
			QueryExpressionIntoClause(
#line  2497 "cs.ATG" 
ref q);
		}
	}

	void QueryExpressionFromOrJoinClause(
#line  2471 "cs.ATG" 
out CollectionRangeVariable variable) {

#line  2472 "cs.ATG" 
		TypeReference type; Expression expr; variable = new CollectionRangeVariable(); 

#line  2474 "cs.ATG" 
		variable.Type = null; 
		if (
#line  2475 "cs.ATG" 
IsLocalVarDecl()) {
			Type(
#line  2475 "cs.ATG" 
out type);

#line  2475 "cs.ATG" 
			variable.Type = type; 
		}
		Identifier();

#line  2476 "cs.ATG" 
		variable.Identifier = t.val; 
		Expect(81);
		Expr(
#line  2478 "cs.ATG" 
out expr);

#line  2478 "cs.ATG" 
		variable.Expression = expr; 
	}

	void QueryExpressionJoinClause(
#line  2450 "cs.ATG" 
out QueryExpressionJoinClause jc) {

#line  2451 "cs.ATG" 
		jc = new QueryExpressionJoinClause(); jc.StartLocation = la.Location; 
		Expression expr;
		CollectionRangeVariable variable;
		
		Expect(142);
		QueryExpressionFromOrJoinClause(
#line  2457 "cs.ATG" 
out variable);
		Expect(143);
		Expr(
#line  2459 "cs.ATG" 
out expr);

#line  2459 "cs.ATG" 
		jc.OnExpression = expr; 
		Expect(144);
		Expr(
#line  2461 "cs.ATG" 
out expr);

#line  2461 "cs.ATG" 
		jc.EqualsExpression = expr; 
		if (la.kind == 136) {
			lexer.NextToken();
			Identifier();

#line  2463 "cs.ATG" 
			jc.IntoIdentifier = t.val; 
		}

#line  2466 "cs.ATG" 
		jc.EndLocation = t.EndLocation;
		jc.Source = variable;
		
	}

	void QueryExpressionWhereClause(
#line  2500 "cs.ATG" 
out QueryExpressionWhereClause wc) {

#line  2501 "cs.ATG" 
		Expression expr; wc = new QueryExpressionWhereClause(); wc.StartLocation = la.Location; 
		Expect(127);
		Expr(
#line  2504 "cs.ATG" 
out expr);

#line  2504 "cs.ATG" 
		wc.Condition = expr; 

#line  2505 "cs.ATG" 
		wc.EndLocation = t.EndLocation; 
	}

	void QueryExpressionLetClause(
#line  2508 "cs.ATG" 
out QueryExpressionLetClause wc) {

#line  2509 "cs.ATG" 
		Expression expr; wc = new QueryExpressionLetClause(); wc.StartLocation = la.Location; 
		Expect(141);
		Identifier();

#line  2512 "cs.ATG" 
		wc.Identifier = t.val; 
		Expect(3);
		Expr(
#line  2514 "cs.ATG" 
out expr);

#line  2514 "cs.ATG" 
		wc.Expression = expr; 

#line  2515 "cs.ATG" 
		wc.EndLocation = t.EndLocation; 
	}

	void QueryExpressionOrderByClause(
#line  2518 "cs.ATG" 
out QueryExpressionOrderClause oc) {

#line  2519 "cs.ATG" 
		QueryExpressionOrdering ordering; oc = new QueryExpressionOrderClause(); oc.StartLocation = la.Location; 
		Expect(140);
		QueryExpressionOrdering(
#line  2522 "cs.ATG" 
out ordering);

#line  2522 "cs.ATG" 
		SafeAdd(oc, oc.Orderings, ordering); 
		while (la.kind == 14) {
			lexer.NextToken();
			QueryExpressionOrdering(
#line  2524 "cs.ATG" 
out ordering);

#line  2524 "cs.ATG" 
			SafeAdd(oc, oc.Orderings, ordering); 
		}

#line  2526 "cs.ATG" 
		oc.EndLocation = t.EndLocation; 
	}

	void QueryExpressionSelectClause(
#line  2539 "cs.ATG" 
out QueryExpressionSelectClause sc) {

#line  2540 "cs.ATG" 
		Expression expr; sc = new QueryExpressionSelectClause(); sc.StartLocation = la.Location; 
		Expect(133);
		Expr(
#line  2543 "cs.ATG" 
out expr);

#line  2543 "cs.ATG" 
		sc.Projection = expr; 

#line  2544 "cs.ATG" 
		sc.EndLocation = t.EndLocation; 
	}

	void QueryExpressionGroupClause(
#line  2547 "cs.ATG" 
out QueryExpressionGroupClause gc) {

#line  2548 "cs.ATG" 
		Expression expr; gc = new QueryExpressionGroupClause(); gc.StartLocation = la.Location; 
		Expect(134);
		Expr(
#line  2551 "cs.ATG" 
out expr);

#line  2551 "cs.ATG" 
		gc.Projection = expr; 
		Expect(135);
		Expr(
#line  2553 "cs.ATG" 
out expr);

#line  2553 "cs.ATG" 
		gc.GroupBy = expr; 

#line  2554 "cs.ATG" 
		gc.EndLocation = t.EndLocation; 
	}

	void QueryExpressionIntoClause(
#line  2557 "cs.ATG" 
ref QueryExpression q) {

#line  2558 "cs.ATG" 
		QueryExpression firstQuery = q;
		QueryExpression continuedQuery = new QueryExpression(); 
		continuedQuery.StartLocation = q.StartLocation;
		firstQuery.EndLocation = la.Location;
		continuedQuery.FromClause = new QueryExpressionFromClause();
		CollectionRangeVariable fromVariable = new CollectionRangeVariable();
		continuedQuery.FromClause.Sources.Add(fromVariable);
		fromVariable.StartLocation = la.Location;
		// nest firstQuery inside continuedQuery.
		fromVariable.Expression = firstQuery;
		continuedQuery.IsQueryContinuation = true;
		q = continuedQuery;
		
		Expect(136);
		Identifier();

#line  2573 "cs.ATG" 
		fromVariable.Identifier = t.val; 

#line  2574 "cs.ATG" 
		continuedQuery.FromClause.EndLocation = t.EndLocation; 
		QueryExpressionBody(
#line  2575 "cs.ATG" 
ref q);
	}

	void QueryExpressionOrdering(
#line  2529 "cs.ATG" 
out QueryExpressionOrdering ordering) {

#line  2530 "cs.ATG" 
		Expression expr; ordering = new QueryExpressionOrdering(); ordering.StartLocation = la.Location; 
		Expr(
#line  2532 "cs.ATG" 
out expr);

#line  2532 "cs.ATG" 
		ordering.Criteria = expr; 
		if (la.kind == 138 || la.kind == 139) {
			if (la.kind == 138) {
				lexer.NextToken();

#line  2533 "cs.ATG" 
				ordering.Direction = QueryExpressionOrderingDirection.Ascending; 
			} else {
				lexer.NextToken();

#line  2534 "cs.ATG" 
				ordering.Direction = QueryExpressionOrderingDirection.Descending; 
			}
		}

#line  2536 "cs.ATG" 
		ordering.EndLocation = t.EndLocation; 
	}


	
	void ParseRoot()
	{
		CS();

	}
	
	protected override void SynErr(int line, int col, int errorNumber)
	{
		string s;
		switch (errorNumber) {
			case 0: s = "EOF expected"; break;
			case 1: s = "ident expected"; break;
			case 2: s = "Literal expected"; break;
			case 3: s = "\"=\" expected"; break;
			case 4: s = "\"+\" expected"; break;
			case 5: s = "\"-\" expected"; break;
			case 6: s = "\"*\" expected"; break;
			case 7: s = "\"/\" expected"; break;
			case 8: s = "\"%\" expected"; break;
			case 9: s = "\":\" expected"; break;
			case 10: s = "\"::\" expected"; break;
			case 11: s = "\";\" expected"; break;
			case 12: s = "\"?\" expected"; break;
			case 13: s = "\"??\" expected"; break;
			case 14: s = "\",\" expected"; break;
			case 15: s = "\".\" expected"; break;
			case 16: s = "\"{\" expected"; break;
			case 17: s = "\"}\" expected"; break;
			case 18: s = "\"[\" expected"; break;
			case 19: s = "\"]\" expected"; break;
			case 20: s = "\"(\" expected"; break;
			case 21: s = "\")\" expected"; break;
			case 22: s = "\">\" expected"; break;
			case 23: s = "\"<\" expected"; break;
			case 24: s = "\"!\" expected"; break;
			case 25: s = "\"&&\" expected"; break;
			case 26: s = "\"||\" expected"; break;
			case 27: s = "\"~\" expected"; break;
			case 28: s = "\"&\" expected"; break;
			case 29: s = "\"|\" expected"; break;
			case 30: s = "\"^\" expected"; break;
			case 31: s = "\"++\" expected"; break;
			case 32: s = "\"--\" expected"; break;
			case 33: s = "\"==\" expected"; break;
			case 34: s = "\"!=\" expected"; break;
			case 35: s = "\">=\" expected"; break;
			case 36: s = "\"<=\" expected"; break;
			case 37: s = "\"<<\" expected"; break;
			case 38: s = "\"+=\" expected"; break;
			case 39: s = "\"-=\" expected"; break;
			case 40: s = "\"*=\" expected"; break;
			case 41: s = "\"/=\" expected"; break;
			case 42: s = "\"%=\" expected"; break;
			case 43: s = "\"&=\" expected"; break;
			case 44: s = "\"|=\" expected"; break;
			case 45: s = "\"^=\" expected"; break;
			case 46: s = "\"<<=\" expected"; break;
			case 47: s = "\"->\" expected"; break;
			case 48: s = "\"=>\" expected"; break;
			case 49: s = "\"abstract\" expected"; break;
			case 50: s = "\"as\" expected"; break;
			case 51: s = "\"base\" expected"; break;
			case 52: s = "\"bool\" expected"; break;
			case 53: s = "\"break\" expected"; break;
			case 54: s = "\"byte\" expected"; break;
			case 55: s = "\"case\" expected"; break;
			case 56: s = "\"catch\" expected"; break;
			case 57: s = "\"char\" expected"; break;
			case 58: s = "\"checked\" expected"; break;
			case 59: s = "\"class\" expected"; break;
			case 60: s = "\"const\" expected"; break;
			case 61: s = "\"continue\" expected"; break;
			case 62: s = "\"decimal\" expected"; break;
			case 63: s = "\"default\" expected"; break;
			case 64: s = "\"delegate\" expected"; break;
			case 65: s = "\"do\" expected"; break;
			case 66: s = "\"double\" expected"; break;
			case 67: s = "\"else\" expected"; break;
			case 68: s = "\"enum\" expected"; break;
			case 69: s = "\"event\" expected"; break;
			case 70: s = "\"explicit\" expected"; break;
			case 71: s = "\"extern\" expected"; break;
			case 72: s = "\"false\" expected"; break;
			case 73: s = "\"finally\" expected"; break;
			case 74: s = "\"fixed\" expected"; break;
			case 75: s = "\"float\" expected"; break;
			case 76: s = "\"for\" expected"; break;
			case 77: s = "\"foreach\" expected"; break;
			case 78: s = "\"goto\" expected"; break;
			case 79: s = "\"if\" expected"; break;
			case 80: s = "\"implicit\" expected"; break;
			case 81: s = "\"in\" expected"; break;
			case 82: s = "\"int\" expected"; break;
			case 83: s = "\"interface\" expected"; break;
			case 84: s = "\"internal\" expected"; break;
			case 85: s = "\"is\" expected"; break;
			case 86: s = "\"lock\" expected"; break;
			case 87: s = "\"long\" expected"; break;
			case 88: s = "\"namespace\" expected"; break;
			case 89: s = "\"new\" expected"; break;
			case 90: s = "\"null\" expected"; break;
			case 91: s = "\"object\" expected"; break;
			case 92: s = "\"operator\" expected"; break;
			case 93: s = "\"out\" expected"; break;
			case 94: s = "\"override\" expected"; break;
			case 95: s = "\"params\" expected"; break;
			case 96: s = "\"private\" expected"; break;
			case 97: s = "\"protected\" expected"; break;
			case 98: s = "\"public\" expected"; break;
			case 99: s = "\"readonly\" expected"; break;
			case 100: s = "\"ref\" expected"; break;
			case 101: s = "\"return\" expected"; break;
			case 102: s = "\"sbyte\" expected"; break;
			case 103: s = "\"sealed\" expected"; break;
			case 104: s = "\"short\" expected"; break;
			case 105: s = "\"sizeof\" expected"; break;
			case 106: s = "\"stackalloc\" expected"; break;
			case 107: s = "\"static\" expected"; break;
			case 108: s = "\"string\" expected"; break;
			case 109: s = "\"struct\" expected"; break;
			case 110: s = "\"switch\" expected"; break;
			case 111: s = "\"this\" expected"; break;
			case 112: s = "\"throw\" expected"; break;
			case 113: s = "\"true\" expected"; break;
			case 114: s = "\"try\" expected"; break;
			case 115: s = "\"typeof\" expected"; break;
			case 116: s = "\"uint\" expected"; break;
			case 117: s = "\"ulong\" expected"; break;
			case 118: s = "\"unchecked\" expected"; break;
			case 119: s = "\"unsafe\" expected"; break;
			case 120: s = "\"ushort\" expected"; break;
			case 121: s = "\"using\" expected"; break;
			case 122: s = "\"virtual\" expected"; break;
			case 123: s = "\"void\" expected"; break;
			case 124: s = "\"volatile\" expected"; break;
			case 125: s = "\"while\" expected"; break;
			case 126: s = "\"partial\" expected"; break;
			case 127: s = "\"where\" expected"; break;
			case 128: s = "\"get\" expected"; break;
			case 129: s = "\"set\" expected"; break;
			case 130: s = "\"add\" expected"; break;
			case 131: s = "\"remove\" expected"; break;
			case 132: s = "\"yield\" expected"; break;
			case 133: s = "\"select\" expected"; break;
			case 134: s = "\"group\" expected"; break;
			case 135: s = "\"by\" expected"; break;
			case 136: s = "\"into\" expected"; break;
			case 137: s = "\"from\" expected"; break;
			case 138: s = "\"ascending\" expected"; break;
			case 139: s = "\"descending\" expected"; break;
			case 140: s = "\"orderby\" expected"; break;
			case 141: s = "\"let\" expected"; break;
			case 142: s = "\"join\" expected"; break;
			case 143: s = "\"on\" expected"; break;
			case 144: s = "\"equals\" expected"; break;
			case 145: s = "??? expected"; break;
			case 146: s = "invalid NamespaceMemberDecl"; break;
			case 147: s = "invalid Identifier"; break;
			case 148: s = "invalid NonArrayType"; break;
			case 149: s = "invalid AttributeArgument"; break;
			case 150: s = "invalid Expr"; break;
			case 151: s = "invalid TypeModifier"; break;
			case 152: s = "invalid TypeDecl"; break;
			case 153: s = "invalid TypeDecl"; break;
			case 154: s = "this symbol not expected in ClassBody"; break;
			case 155: s = "this symbol not expected in InterfaceBody"; break;
			case 156: s = "invalid IntegralType"; break;
			case 157: s = "invalid ClassType"; break;
			case 158: s = "invalid ClassMemberDecl"; break;
			case 159: s = "invalid ClassMemberDecl"; break;
			case 160: s = "invalid StructMemberDecl"; break;
			case 161: s = "invalid StructMemberDecl"; break;
			case 162: s = "invalid StructMemberDecl"; break;
			case 163: s = "invalid StructMemberDecl"; break;
			case 164: s = "invalid StructMemberDecl"; break;
			case 165: s = "invalid StructMemberDecl"; break;
			case 166: s = "invalid StructMemberDecl"; break;
			case 167: s = "invalid StructMemberDecl"; break;
			case 168: s = "invalid StructMemberDecl"; break;
			case 169: s = "invalid StructMemberDecl"; break;
			case 170: s = "invalid StructMemberDecl"; break;
			case 171: s = "invalid StructMemberDecl"; break;
			case 172: s = "invalid StructMemberDecl"; break;
			case 173: s = "invalid InterfaceMemberDecl"; break;
			case 174: s = "invalid InterfaceMemberDecl"; break;
			case 175: s = "invalid InterfaceMemberDecl"; break;
			case 176: s = "invalid TypeWithRestriction"; break;
			case 177: s = "invalid TypeWithRestriction"; break;
			case 178: s = "invalid SimpleType"; break;
			case 179: s = "invalid AccessorModifiers"; break;
			case 180: s = "this symbol not expected in Block"; break;
			case 181: s = "invalid EventAccessorDecls"; break;
			case 182: s = "invalid ConstructorInitializer"; break;
			case 183: s = "invalid OverloadableOperator"; break;
			case 184: s = "invalid AccessorDecls"; break;
			case 185: s = "invalid InterfaceAccessors"; break;
			case 186: s = "invalid InterfaceAccessors"; break;
			case 187: s = "invalid GetAccessorDecl"; break;
			case 188: s = "invalid SetAccessorDecl"; break;
			case 189: s = "invalid VariableInitializer"; break;
			case 190: s = "this symbol not expected in Statement"; break;
			case 191: s = "invalid Statement"; break;
			case 192: s = "invalid Argument"; break;
			case 193: s = "invalid AssignmentOperator"; break;
			case 194: s = "invalid ObjectPropertyInitializerOrVariableInitializer"; break;
			case 195: s = "invalid ObjectPropertyInitializerOrVariableInitializer"; break;
			case 196: s = "invalid EmbeddedStatement"; break;
			case 197: s = "invalid EmbeddedStatement"; break;
			case 198: s = "this symbol not expected in EmbeddedStatement"; break;
			case 199: s = "invalid EmbeddedStatement"; break;
			case 200: s = "invalid ForInitializer"; break;
			case 201: s = "invalid GotoStatement"; break;
			case 202: s = "invalid ResourceAcquisition"; break;
			case 203: s = "invalid SwitchLabel"; break;
			case 204: s = "invalid CatchClause"; break;
			case 205: s = "invalid UnaryExpr"; break;
			case 206: s = "invalid PrimaryExpr"; break;
			case 207: s = "invalid PrimaryExpr"; break;
			case 208: s = "invalid TypeArgumentList"; break;
			case 209: s = "invalid NewExpression"; break;
			case 210: s = "invalid NewExpression"; break;
			case 211: s = "invalid LambdaExpressionParameter"; break;
			case 212: s = "invalid LambdaExpressionBody"; break;
			case 213: s = "invalid RelationalExpr"; break;
			case 214: s = "invalid RelationalExpr"; break;
			case 215: s = "invalid TypeParameterConstraintsClauseBase"; break;
			case 216: s = "invalid QueryExpressionBody"; break;

			default: s = "error " + errorNumber; break;
		}
		this.Errors.Error(line, col, s);
	}
	
	private bool StartOf(int s)
	{
		return set[s, lexer.LookAhead.kind];
	}
	
	static bool[,] set = {
	{T,T,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,T,T,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,T, T,T,T,x, x,T,T,T, T,T,T,T, T,T,T,x, T,T,T,T, T,x,T,T, T,T,T,T, T,x,T,T, T,x,T,T, x,T,T,T, x,x,T,x, T,T,T,T, x,T,T,T, T,T,x,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,x,x, T,T,x,x, x,x,x,x, T,T,T,x, x,x,x,T, x,x,x,T, x,T,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,x,x, x,T,x,x, x,x,x,x, T,T,T,x, x,x,x,T, x,x,x,T, x,T,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,T,x,x, x,x,x,x, T,T,T,x, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, x,x,x,x, x,x,x,x, T,T,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,T,x, x,T,T,x, x,x,T,T, T,x,T,x, x,x,x,x, T,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,T,T, x,x,x,x, x,x,x,x, x,x,T,x, T,T,x,x, T,x,x,T, x,T,x,T, T,T,T,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, T,T,T,T, T,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,T, T,T,T,T, T,T,x,T, T,T,T,T, T,T,T,T, T,T,T,T, x,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, x,T,T,x, T,x,T,x, x,T,x,T, T,x,T,x, T,x,T,x, T,T,T,T, x,x,T,T, x,x,x,x, T,x,T,T, T,T,x,T, x,T,x,T, x,x,T,x, T,T,T,T, x,x,T,T, T,x,x,T, T,T,x,x, x,x,x,x, T,T,x,T, T,x,T,T, T,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,T, x,T,x,T, x,x,x,x, T,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, T,x,T,x, x,T,x,T, T,x,T,x, T,x,T,x, T,T,T,T, x,x,T,T, x,x,x,x, T,x,T,T, T,x,x,T, x,T,x,T, x,x,T,x, T,T,T,T, x,x,T,T, T,x,x,T, T,T,x,x, x,x,x,x, T,T,x,T, T,x,T,T, T,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{T,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, T,x,T,x, x,T,x,T, T,x,T,x, T,x,T,x, T,T,T,T, x,x,T,T, x,x,x,x, T,x,T,T, T,x,x,T, x,T,x,T, x,x,T,x, T,T,T,T, x,x,T,T, T,x,x,T, T,T,x,x, x,x,x,x, T,T,x,T, T,x,T,T, T,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, T,x,T,x, x,T,x,T, T,x,T,x, T,x,T,x, T,T,T,T, x,x,T,T, x,x,x,x, T,x,T,T, T,x,x,T, x,T,x,T, x,x,T,x, T,T,T,T, x,x,T,T, T,x,x,T, T,T,x,x, x,x,x,x, T,T,x,T, T,x,T,T, T,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,T,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{T,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,T,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,T,x, x,x,x,x, x,x,x,x, T,x,x,x, x,T,x,x, x,x,T,x, T,T,T,T, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,T, x,x,T,x, T,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,T, T,x,T,x, T,x,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,x,T,T, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,T,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,T,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, x,x,x,x, x,x,x,x, T,T,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,T,T,x, x,T,T,x, T,T,T,T, T,T,T,x, x,x,x,x, T,x,T,T, T,T,T,T, x,x,T,x, x,x,T,T, x,T,T,T, x,x,x,x, x,x,x,x, x,T,T,x, T,T,x,x, T,x,T,T, T,T,T,T, T,T,T,T, T,T,x,T, x,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,T,x, x,T,T,x, x,x,T,T, T,x,T,x, x,x,x,x, T,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,T,T, x,T,x,x, x,x,x,x, T,x,T,x, T,T,x,x, T,x,x,T, x,T,x,T, T,T,T,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, T,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, T,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{T,T,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,T,T,x, x,T,T,x, T,T,T,T, T,T,T,x, x,x,x,x, T,x,T,T, T,T,T,T, x,x,T,x, x,x,T,T, x,T,T,T, x,x,x,x, x,x,x,x, x,T,T,x, T,T,x,x, T,x,T,T, T,T,T,T, T,T,T,T, T,T,x,T, x,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,T,T,x, x,T,T,x, x,T,T,T, T,T,T,x, x,x,x,x, T,x,T,T, T,T,T,T, x,x,T,x, x,x,T,T, x,T,T,T, x,x,x,x, x,x,x,x, x,T,T,x, T,T,x,x, T,x,T,T, T,T,T,T, T,T,T,T, T,T,x,T, x,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,x, x,x,x,x, T,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,T,x, x,T,T,x, x,x,T,T, T,x,T,x, x,x,x,x, T,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,T,T, x,x,x,x, x,x,x,x, x,x,T,x, T,T,T,x, T,x,x,T, x,T,x,T, T,T,T,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,T,T,x, T,T,T,x, x,x,x,T, x,x,x,x, T,x,x,x, T,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,T,T,T, x,T,T,x, T,T,T,T, T,T,T,x, x,x,x,x, T,x,T,T, T,T,T,T, x,x,T,x, x,x,T,T, x,T,T,T, x,x,x,x, x,x,x,x, x,T,T,x, T,T,x,x, T,x,T,T, T,T,T,T, T,T,T,T, T,T,x,T, x,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, T,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,T, T,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, T,x,T,x, x,T,T,x, x,x,T,T, T,x,T,x, x,x,x,x, T,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,T,T,T, x,x,x,x, x,x,x,x, x,x,T,x, T,T,x,x, T,x,x,T, x,T,x,T, T,T,T,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,T, x,x,x,x, x,x,x,x, x,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,T,x, T,x,x,x, x,x,x,x, x,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,T,x, x,T,x,x, x,x,T,x, x,x,T,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,T,x, x,x,x,T, x,x,x,T, x,T,x,x, x,x,x,x, T,x,T,x, T,x,x,x, T,x,x,x, x,x,x,x, T,T,x,x, T,x,x,T, x,x,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,T,T,T, T,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, x,x,x,x, x,x,x,x, x,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,T,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,T,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,T,T, x,x,x,x, x,x,x,x, x,x,x,T, T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x},
	{x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,T, x,x,x,x, x,x,x,x, x,T,x,x, T,T,T,x, x,x,x}

	};
} // end Parser

}