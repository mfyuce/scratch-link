using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_lang
{
    public class ASTree : ASTreeNode
    {
        public static ASTree Traverse(JEnumerable<JToken> blockList, string startingBlockName)
        {
            ASTree tree = new ASTree();

            Traverse(tree, blockList, FindBlock(blockList, startingBlockName));
            return tree;
        }
        public static void Traverse(ASTreeNode parent, JEnumerable<JToken> blockList, dynamic startingBlock)
        {
            if (startingBlock == null)
            {
                return;
            }
            var curNode = ASTreeNode.Create(blockList, startingBlock);
            parent.Children.Add(curNode);
            string next = startingBlock.next;
            if (next == null)
            {
                return;
            }
            Traverse(parent, blockList, FindBlock(blockList, next));
        }
        public static JToken FindBlock(JEnumerable<JToken> blockList, string startingBlockName)
        {
            foreach (var block in blockList)
            {
                if (((JProperty)block).Name == startingBlockName)
                {
                    return ((JProperty)block).Value;
                }
            }
            return null;
        }
    } 
    public class DataVariableASTTreeNode : ASTreeNode
    {
        public ASTreeNode Variable { get { return Children[0]; } }
        public override string ToString(int currentIndentaion)
        {
            return Variable.ToString(0);
        }
    }
    public class TextASTTreeNode : ASTreeNode
    {
        public string Value { get; set; }
        public override string ToString(int currentIndentaion)
        {
            if (Children.Count > 0)
            {
               return base.ToString(0);
            }
            return  Value   ;
        }
    }
    public class WholeNumberASTTreeNode : ASTreeNode
    {
        public ASTreeNode Value { get { return Children[0]; } }
    }
    public class NumberASTTreeNode : ASTreeNode
    {
        public ASTreeNode Value { get { return Children[0]; } }
    }
    public class OpcodeParseInfo
    {
        public OpcodeParseInfo(Type typeIfo, string[] childInfo):this(typeIfo, childInfo, -1)
        {
             
        }
        public OpcodeParseInfo(string[] childInfo):this(typeof(ASTreeNode), childInfo, -1)
        {
             
        }
        public OpcodeParseInfo(Type typeIfo, string[] childInfo, string codeConversion) :this(typeIfo, childInfo, -1,-1, codeConversion)
        {
             
        }
        public OpcodeParseInfo(string[] childInfo, string codeConversion) :this(typeof(ASTreeNode), childInfo, -1,-1, codeConversion)
        {
             
        }
        public OpcodeParseInfo(Type typeIfo, string[] childInfo, int childrenStartFrom  ): this(typeIfo, childInfo, childrenStartFrom, -1, null)
        {
        }
        public OpcodeParseInfo(string[] childInfo, int childrenStartFrom  ): this(typeof(ASTreeNode), childInfo, childrenStartFrom, -1, null)
        {
        }
        public OpcodeParseInfo(Type typeIfo, string[] childInfo, int childrenStartFrom, int childrenEndAt,string codeConversion)
        {
            this.TypeIfo = typeIfo;
            this.ChildInfo = childInfo;
            this.ChildrenEndAt = childrenEndAt;
            this.ChildrenStartFrom = childrenStartFrom;
            this.DefaultCodeConversion = codeConversion;
        }
        public OpcodeParseInfo( string[] childInfo, int childrenStartFrom, int childrenEndAt, string codeConversion): this(typeof(ASTreeNode), childInfo, childrenStartFrom, childrenEndAt, codeConversion)
        {
           
        }
        public Type TypeIfo { get; set; }
        public string[] ChildInfo { get; set; }
        public int ChildrenStartFrom { get; set; }
        public int ChildrenEndAt { get; set; }
        public string DefaultCodeConversion { get; set; }
    }
    public class ASTreeNode
    {
        public static Dictionary<string, OpcodeParseInfo> opcodeToType =
        new Dictionary<string, OpcodeParseInfo> {
            {"data_setvariableto",new OpcodeParseInfo( new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"}, "\n{indentation}{child0}={child1}") },
            {"data_changevariableby",new OpcodeParseInfo(  new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"}, "\n{indentation}{child0}+={child1}") },
            {"control_repeat",new OpcodeParseInfo(  new string[]{".inputs.TIMES.block", ".inputs.SUBSTACK.block"},1,-1, "\n{indentation}Repeat {child0}\n{next_indentation}{children}") },
            {"control_repeat_until",new OpcodeParseInfo(  new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block"},1,-1, "\n{indentation}Repeat\n{next_indentation}{children}\n{indentation}Until {child0}") },
            {"control_wait",new OpcodeParseInfo( new string[]{".inputs.DURATION.block"}, "\n{indentation}Wait {child0}") },
            {"control_wait_until",new OpcodeParseInfo(  new string[]{".inputs.CONDITION.block"}, "\n{indentation}Wait Until {child0}") },
            {"control_forever",new OpcodeParseInfo(  new string[]{".inputs.SUBSTACK.block"}, "\n{indentation}Forever {children}") },
            {"control_if_else",new OpcodeParseInfo(  new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block", ".inputs.SUBSTACK2.block"}, "\n{indentation}if {child0}\n{next_indentation}{child1}\n{indentation}else\n{next_indentation}{child2}") },
            {"control_if",new OpcodeParseInfo(  new string[]{".inputs.CONDITION.block", ".inputs.SUBSTACK.block"}, "\n{indentation}if {child0}\n{next_indentation}{child1}") },
            {"operator_equals",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}, "(({child0})==({child1}))") },
            {"operator_random",new OpcodeParseInfo( new string[]{".inputs.FROM.block", ".inputs.TO.block"}, "Random(({child0}),({child1}))") },
            {"operator_subtract",new OpcodeParseInfo(  new string[]{ ".inputs.NUM1.block", ".inputs.NUM2.block"}, "(({child0})-({child1}))") },
            {"operator_add",new OpcodeParseInfo( new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}, "(({child0})+({child1}))") },
            {"operator_join",new OpcodeParseInfo( new string[]{ ".inputs.STRING1.block", ".inputs.STRING2.block"}, "(({child0})+({child1}))") },
            {"operator_contains",new OpcodeParseInfo( new string[]{".inputs.STRING1.block", ".inputs.STRING2.block"}, "(({child0}).contains({child1}))") },
            {"operator_letter_of",new OpcodeParseInfo( new string[]{ ".inputs.LETTER.block", ".inputs.STRING.block"}, "(({child0})[({child1})])") },
            {"operator_length",new OpcodeParseInfo(  new string[]{".inputs.STRING.block"}, "(len({child0}))") },
            {"operator_multiply",new OpcodeParseInfo( new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}, "(({child0})*({child1}))") },
            {"operator_divide",new OpcodeParseInfo(  new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}, "(({child0})/({child1}))") },
            {"operator_or",new OpcodeParseInfo(  new string[]{ ".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}, "(({child0})|({child1}))") },
            {"operator_gt",new OpcodeParseInfo( new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}, "(({child0})>({child1}))") },
            {"operator_lt",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}, "(({child0})<({child1}))") },
            {"operator_and",new OpcodeParseInfo(  new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}, "(({child0})&({child1}))") },
            {"operator_mod",new OpcodeParseInfo(   new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}, "(({child0})%({child1}))") },
            {"operator_round",new OpcodeParseInfo(  new string[]{".inputs.NUM.block" }, "(Round({child0}))") },
            {"operator_mathop",new OpcodeParseInfo(  new string[]{ ".fields.OPERATOR.value", ".inputs.NUM.block" }, "({child0}({child1}))") },
            {"operator_not",new OpcodeParseInfo( new string[]{ ".inputs.OPERAND.block"}, "!({child0}))") },
            {"data_variable",new OpcodeParseInfo(typeof(DataVariableASTTreeNode), new string[]{".fields.VARIABLE.value"}, "({child0})") },
            {"text",new OpcodeParseInfo(typeof(TextASTTreeNode), new string[]{".fields.TEXT.value"}, "({child0})") },
            {"math_whole_number",new OpcodeParseInfo(typeof(WholeNumberASTTreeNode), new string[]{".fields.NUM.value"}, "({child0})") },
            {"math_number",new OpcodeParseInfo(typeof(NumberASTTreeNode), new string[]{".fields.NUM.value"}, "({child0})") },
            {"default",new OpcodeParseInfo(typeof(ASTreeNode), new string[]{}, "({children})") }
        };
        public ASTreeNode()
        {

        }
        public ASTreeNode(int from, int to) : this()
        {
            this.StartFrom = from;
            this.EndAt = to;
        }
        public string OpCode { get; set; }
        public int StartFrom { get; set; } = -1;
        public int EndAt { get; set; } = -1;
        public List<ASTreeNode> Children { get; set; } = new List<ASTreeNode>();
        public static string GetIndentation(int currentIndentation)
        {
            return new string(' ', currentIndentation);
        }
        public override string ToString()
        {
            return ToString(true, 0);
        }
        public virtual string ToString(int currentIndentation)
        {
            return ToString(true, currentIndentation);
        }
        public string ToString(bool noSelf, int currentIndentation)
        {
            var ret = ""; // noSelf ? "" : this.OpCode;
            string indentationText = GetIndentation(currentIndentation);
            int nextIndentation = currentIndentation + 1;
            var children = Children.AsEnumerable();
            if (StartFrom > -1)
            {
                children = children.Skip(StartFrom);
            }
            if (EndAt > -1)
            {
                children = children.Take(EndAt - (StartFrom > -1 ? StartFrom : 0));
            }
            foreach (var c in children)
            {
                ret += indentationText + c.ToString(nextIndentation);
            }
            return ret;
        }

        public static ASTreeNode Create(JEnumerable<JToken> blockList, dynamic node)
        {
            string opCode = node.opcode;
            ASTreeNode treeNode = null;
            OpcodeParseInfo info = null;
            if (opcodeToType.ContainsKey(opCode))
            {
                info = opcodeToType[opCode];
            }
            else
            {
                info = opcodeToType["default"];
            }
            treeNode = (ASTreeNode)Activator.CreateInstance(info.TypeIfo); 
            foreach (var child in info.ChildInfo)
            {
                JToken jnode = ((JToken)node);
                var blockOrValue = (string)jnode.SelectToken("$" + child);
                var block = ASTree.FindBlock(blockList, blockOrValue);
                if (block == null)
                {
                    treeNode.Children.Add(new TextASTTreeNode() { Value = blockOrValue });
                }
                else {
                    treeNode.Children.Add(new ASTreeNode());
                    ASTree.Traverse(treeNode.Children.Last(), blockList, block);
                    // treeNode.Children.Add(Create(blockList, block));
                }
            }
            if (info.ChildrenStartFrom > -1)
            {
                treeNode.StartFrom = info.ChildrenStartFrom;
            }
            if (info.ChildrenEndAt > -1)
            {
                treeNode.EndAt = info.ChildrenEndAt;
            }
            treeNode.OpCode = node.opcode;

            return treeNode;
        }
         
        public string AsCode(int indentation)
        {
            StringBuilder code = new StringBuilder();
            AsCode(code, this, indentation);
            return code.ToString();
        }
        private static void AsCode(StringBuilder code, ASTreeNode parentNode, int indentation)
        {
            var opcode = parentNode.OpCode;
            var nextIndentation = indentation + 1;
            if (opcode != null && opcodeToType.ContainsKey(opcode))
            {
                var info = opcodeToType[opcode];

                var conversion = info.DefaultCodeConversion;
                var thisCode = conversion.Replace("{child0}", parentNode.Children[0].AsCode(nextIndentation));
                if (parentNode.Children.Count > 1)
                {
                    thisCode = thisCode.Replace("{child1}", parentNode.Children[1].AsCode(nextIndentation));
                }
                if (parentNode.Children.Count > 2)
                {
                    thisCode = thisCode.Replace("{child2}", parentNode.Children[2].AsCode(nextIndentation));
                }
                thisCode = thisCode.Replace("{indentation}", GetIndentation(indentation));
                thisCode = thisCode.Replace("{next_indentation}", GetIndentation(nextIndentation));
                if (conversion.Contains("{children}"))
                {
                    StringBuilder codeChildren = new StringBuilder();
                    foreach (var node in parentNode.Children)
                    {
                        AsCode(codeChildren, node, nextIndentation);
                    }
                    thisCode = thisCode.Replace("{children}", codeChildren.ToString());
                }
                code.Append(thisCode);
            }
            else
            {
                if (parentNode.Children.Count > 0)
                {
                    foreach (var node in parentNode.Children)
                    {
                        AsCode(code, node, nextIndentation);
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
