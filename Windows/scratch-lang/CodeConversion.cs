using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_lang
{
    /****
     * 
        [Blockly.Msg.OPERATORS_MATHOP_ABS, 'abs'],
        [Blockly.Msg.OPERATORS_MATHOP_FLOOR, 'floor'],
        [Blockly.Msg.OPERATORS_MATHOP_CEILING, 'ceiling'],
        [Blockly.Msg.OPERATORS_MATHOP_SQRT, 'sqrt'],
        [Blockly.Msg.OPERATORS_MATHOP_SIN, 'sin'],
        [Blockly.Msg.OPERATORS_MATHOP_COS, 'cos'],
        [Blockly.Msg.OPERATORS_MATHOP_TAN, 'tan'],
        [Blockly.Msg.OPERATORS_MATHOP_ASIN, 'asin'],
        [Blockly.Msg.OPERATORS_MATHOP_ACOS, 'acos'],
        [Blockly.Msg.OPERATORS_MATHOP_ATAN, 'atan'],
        [Blockly.Msg.OPERATORS_MATHOP_LN, 'ln'],
        [Blockly.Msg.OPERATORS_MATHOP_LOG, 'log'],
        [Blockly.Msg.OPERATORS_MATHOP_EEXP, 'e ^'],
        [Blockly.Msg.OPERATORS_MATHOP_10EXP, '10 ^']
     */
    public static class CodeConversion
    {
        public const string ARDUINO_PLATFORM = "arduino";
        public const string DEFAULT_PLATFORM = "default";
        public static Dictionary<string, string> Default { get; set; } =
                new Dictionary<string, string> {
            {"data_setvariableto", "\n{indentation}{child0}={child1}" },
            {"data_changevariableby" , "\n{indentation}{child0}+={child1}" },
            {"control_repeat", "\n{indentation}Repeat {child0}\n{next_indentation}{children}" },
            {"control_repeat_until",  "\n{indentation}Repeat\n{next_indentation}{children}\n{indentation}Until {child0}" },
            {"control_wait",  "\n{indentation}Wait {child0}" },
            {"control_wait_until",  "\n{indentation}Wait Until {child0}" },
            {"control_forever",  "\n{indentation}Forever {children}" },
            {"control_if_else",  "\n{indentation}if {child0}\n{next_indentation}{child1}\n{indentation}else\n{next_indentation}{child2}" },
            {"control_if", "\n{indentation}if {child0}\n{next_indentation}{child1}" },
            {"operator_equals", "(({child0})==({child1}))" },
            {"operator_random",  "Random(({child0}),({child1}))" },
            {"operator_subtract", "(({child0})-({child1}))" },
            {"operator_add", "(({child0})+({child1}))" },
            {"operator_join",  "(({child0})+({child1}))" },
            {"operator_contains", "(({child0}).contains({child1}))" },
            {"operator_letter_of", "(({child0})[({child1})])" },
            {"operator_length",  "(len({child0}))" },
            {"operator_multiply",  "(({child0})*({child1}))" },
            {"operator_divide",  "(({child0})/({child1}))" },
            {"operator_or",  "(({child0})|({child1}))" },
            {"operator_gt", "(({child0})>({child1}))" },
            {"operator_lt", "(({child0})<({child1}))" },
            {"operator_and",  "(({child0})&({child1}))" },
            {"operator_mod",  "(({child0})%({child1}))" },
            {"operator_round", "(Round({child0}))" },
            {"operator_mathop",  "({child0}({child1}))" },
            {"operator_not",  "!({child0}))" },
            {"data_variable",  "({child0})" },
            {"text", "({child0})" },
            {"math_whole_number",  "({child0})" },
            {"math_number",  "({child0})" },
            {"default",  "({children})" }
                };
        public static Dictionary<string, string> Arduino { get; set; } =
                new Dictionary<string, string> {
            {"data_setvariableto", "\n{indentation}{child0}={child1};" },
            {"data_changevariableby" , "\n{indentation}{child0}+={child1};" },
            {"control_repeat", "\n{indentation}for(int repeatCount=0; repeatCount<({child0});repeatCount++){\n{next_indentation}{children}\n{indentation}}" },
            {"control_repeat_until",  "\n{indentation}do{\n{next_indentation}{children}\n{indentation} }while ({child0});" },
            {"control_wait",  "\n{indentation}delay({child0}*1000);" },
            {"control_wait_until",  "\n{indentation}while({child0}){\n{indentation}delay(100);\n{indentation}}" },
            {"control_forever",  "\n{indentation}while(true){\n{indentation}{children}\n{indentation}}" },
            {"control_if_else",  "\n{indentation}if( {child0}){\n{next_indentation}{child1}\n{indentation}}else{\n{next_indentation}{child2}\n{indentation}}" },
            {"control_if", "\n{indentation}if({child0}){\n{next_indentation}{child1}\n{indentation}}" },
            {"operator_equals", "(({child0})==({child1}))" },
            {"operator_random",  "random(({child0}),({child1}))" },
            {"operator_subtract", "(({child0})-({child1}))" },
            {"operator_add", "(({child0})+({child1}))" },
            {"operator_join",  "(({child0})+({child1}))" },
            {"operator_contains", "(({child0}).indexOf({child1}) > 0)" },
            {"operator_letter_of", "(({child0}).charAt(({child1})))" },
            {"operator_length",  "(({child0}).length())" },
            {"operator_multiply",  "(({child0})*({child1}))" },
            {"operator_divide",  "(({child0})/({child1}))" },
            {"operator_or",  "(({child0})|+({child1}))" },
            {"operator_gt", "(({child0})>({child1}))" },
            {"operator_lt", "(({child0})<({child1}))" },
            {"operator_and",  "(({child0})&&({child1}))" },
            {"operator_mod",  "(({child0})%({child1}))" },
            {"operator_round", "(round({child0}))" },
            {"operator_mathop",  "({child0}({child1}))" },
            {"operator_not",  "!({child0}))" },
            {"data_variable",  "({child0})" },
            {"text", "(\"{child0}\")" },
            {"math_whole_number",  "({child0})" },
            {"math_number",  "({child0})" },
            {"default",  "({children})" }
                };
        public static Dictionary<string, Dictionary<string, string>> platforms = new Dictionary<string, Dictionary<string, string>> { {"arduino", Arduino },
            {"default", Default }};
        public static Dictionary<string, OpcodeParseInfo> opcodeToType =
        new Dictionary<string, OpcodeParseInfo> {
            {"data_setvariableto",new OpcodeParseInfo( new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"}  )},
            {"data_changevariableby",new OpcodeParseInfo(  new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"} ) },
            {"control_repeat",new OpcodeParseInfo(  new string[]{".inputs.TIMES.block", ".inputs.SUBSTACK.block"},1,-1)  },
            {"control_repeat_until",new OpcodeParseInfo(  new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block"},1,-1 ) },
            {"control_wait",new OpcodeParseInfo( new string[]{".inputs.DURATION.block"} )},
            {"control_wait_until",new OpcodeParseInfo(  new string[]{".inputs.CONDITION.block"}) },
            {"control_forever",new OpcodeParseInfo(  new string[]{".inputs.SUBSTACK.block"} ) },
            {"control_if_else",new OpcodeParseInfo(  new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block", ".inputs.SUBSTACK2.block"} ) },
            {"control_if",new OpcodeParseInfo(  new string[]{".inputs.CONDITION.block", ".inputs.SUBSTACK.block"} ) },
            {"operator_equals",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"} ) },
            {"operator_random",new OpcodeParseInfo( new string[]{".inputs.FROM.block", ".inputs.TO.block"}) },
            {"operator_subtract",new OpcodeParseInfo(  new string[]{ ".inputs.NUM1.block", ".inputs.NUM2.block"} ) },
            {"operator_add",new OpcodeParseInfo( new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"} ) },
            {"operator_join",new OpcodeParseInfo( new string[]{ ".inputs.STRING1.block", ".inputs.STRING2.block"} ) },
            {"operator_contains",new OpcodeParseInfo( new string[]{".inputs.STRING1.block", ".inputs.STRING2.block"} ) },
            {"operator_letter_of",new OpcodeParseInfo( new string[]{ ".inputs.LETTER.block", ".inputs.STRING.block"} ) },
            {"operator_length",new OpcodeParseInfo(  new string[]{".inputs.STRING.block"} ) },
            {"operator_multiply",new OpcodeParseInfo( new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"} ) },
            {"operator_divide",new OpcodeParseInfo(  new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"} ) },
            {"operator_or",new OpcodeParseInfo(  new string[]{ ".inputs.OPERAND1.block", ".inputs.OPERAND2.block"} ) },
            {"operator_gt",new OpcodeParseInfo( new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"} ) },
            {"operator_lt",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"} ) },
            {"operator_and",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"} ) },
            {"operator_mod",new OpcodeParseInfo(   new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"} ) },
            {"operator_round",new OpcodeParseInfo(  new string[]{".inputs.NUM.block" } ) },
            {"operator_mathop",new OpcodeParseInfo(  new string[]{ ".fields.OPERATOR.value", ".inputs.NUM.block" } ) },
            {"operator_not",new OpcodeParseInfo( new string[]{ ".inputs.OPERAND.block"} ) },
            {"data_variable",new OpcodeParseInfo(typeof(DataVariableASTTreeNode), new string[]{".fields.VARIABLE.value"} ) },
            {"text",new OpcodeParseInfo(typeof(TextASTTreeNode), new string[]{".fields.TEXT.value"} ) },
            {"math_whole_number",new OpcodeParseInfo(typeof(WholeNumberASTTreeNode), new string[]{".fields.NUM.value"} ) },
            {"math_number",new OpcodeParseInfo(typeof(NumberASTTreeNode), new string[]{".fields.NUM.value"} ) },
            {"default",new OpcodeParseInfo(typeof(ASTreeNode), new string[]{} ) }
        };
        public static OpcodeParseInfo GetOpcodeInfo(string opCode)
        {
            if (opcodeToType.ContainsKey(opCode))
            {
                return opcodeToType[opCode];
            }
            else
            {
                return opcodeToType["default"];
            }
        }
        public static string GetIndentation(int currentIndentation)
        {
            return new string(' ', currentIndentation);
        }
        public static IEnumerable<ASTreeNode> GetEffectiveChildren(ASTreeNode parent)
        {
            var children = parent.Children.AsEnumerable();
            if (parent.StartFrom > -1)
            {
                children = children.Skip(parent.StartFrom);
            }
            if (parent.EndAt > -1)
            {
                children = children.Take(parent.EndAt - (parent.StartFrom > -1 ? parent.StartFrom : 0));
            }
            return children;
        }
        public static void AsCode(StringBuilder code, ASTreeNode parentNode, int indentation, string platform)
        {
            var opcode = parentNode.OpCode;
            var nextIndentation = indentation + 1;
            if (opcode != null && opcodeToType.ContainsKey(opcode))
            {
                var info = opcodeToType[opcode];

                var conversion = CodeConversion.platforms[platform][opcode];
                var thisCode = conversion.Replace("{child0}", parentNode.Children[0].AsCode(nextIndentation, platform));
                if (parentNode.Children.Count > 1)
                {
                    thisCode = thisCode.Replace("{child1}", parentNode.Children[1].AsCode(nextIndentation, platform));
                }
                if (parentNode.Children.Count > 2)
                {
                    thisCode = thisCode.Replace("{child2}", parentNode.Children[2].AsCode(nextIndentation, platform));
                }
                thisCode = thisCode.Replace("{indentation}", GetIndentation(indentation));
                thisCode = thisCode.Replace("{next_indentation}", GetIndentation(nextIndentation));
                if (conversion.Contains("{children}"))
                {
                    StringBuilder codeChildren = new StringBuilder(); 
                    foreach (var node in CodeConversion.GetEffectiveChildren(parentNode))
                    {
                        AsCode(codeChildren, node, nextIndentation, platform);
                    }
                    thisCode = thisCode.Replace("{children}", codeChildren.ToString());
                }
                code.Append(thisCode);
            }
            else
            {
                var children = CodeConversion.GetEffectiveChildren(parentNode);
                if (children.Count() > 0)
                {
                    foreach (var node in children)
                    {
                        AsCode(code, node, nextIndentation, platform);
                    }
                }
                else
                {
                    code.Append(parentNode.ToString(0));
                }
            }
        }
    }
}
