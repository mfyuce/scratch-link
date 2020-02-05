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
        public static ASTree traverse(JEnumerable<JToken> blockList, string startingBlockName)
        {
            ASTree tree = new ASTree();

            traverse(tree, blockList, findBlock(blockList, startingBlockName));
            return tree;
        }
        public static void traverse(ASTreeNode parent, JEnumerable<JToken> blockList, dynamic startingBlock)
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
            traverse(parent, blockList, findBlock(blockList, next));
        }
        public static JToken findBlock(JEnumerable<JToken> blockList, string startingBlockName)
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
    public class SetVariableToASTreeNode : ASTreeNode
    {
        public ASTreeNode VariableName { get { return Children[0]; } }
        public ASTreeNode VariableValue { get { return Children[1]; } }
        public override string ToString(int currentIndentation)
        {
            var indentationText = GetIndentation(currentIndentation);
            return "\n" + indentationText + this.VariableName.ToString(0) + "=" + this.VariableValue.ToString(0);
        }
    }
    public class SetVariableByASTreeNode : ASTreeNode
    {
        public ASTreeNode VariableName { get { return Children[0]; } }
        public ASTreeNode VariableValue { get { return Children[1]; } }
        public override string ToString(int currentIndentaion)
        {
            return "\n" + GetIndentation(currentIndentaion) + this.VariableName.ToString(0) + "+=" + this.VariableValue.ToString(0);
        }
    }
    public class RepeaToASTreeNode : ASTreeNode
    {
        public ASTreeNode Times { get { return Children[0]; } }
        public override string ToString(int currentIndentaion)
        {
            String ret = GetIndentation(currentIndentaion);
            return "\n" + ret + "Repeat " + base.ToString(currentIndentaion + 1);
        }
    }
    public class RepeatUntilASTreeNode : ASTreeNode
    {
        public RepeatUntilASTreeNode() : base(1, -1)
        {

        }
        public ASTreeNode Condition { get { return Children[0]; } }
        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            String ret = indentationText + "Repeat " + base.ToString(currentIndentaion);
            return "\n" + ret + indentationText + "until " + this.Condition.ToString(0);
        }
    }
    public class ForeverASTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            String ret = "Forever ";
            return "\n" + indentationText + ret + base.ToString(currentIndentaion + 1);
        }
    }
    public class WaitUntilASTreeNode : ASTreeNode
    {
        public ASTreeNode Condition { get { return Children[0]; } }
        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            return "\n" + indentationText + "Wait Until" + Condition.ToString(0);
        }
    }
    public class WaitASTreeNode : ASTreeNode
    {
        public ASTreeNode Duration { get { return Children[0]; } }
        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            return "\n" + indentationText + "Wait " + Duration.ToString(0);
        }
    }
    public class IfElseASTTreeNode : ASTreeNode
    {

        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            int nextIndentaion = currentIndentaion + 1;
            String ret = "\n" + indentationText + "if " + Children[0].ToString(0);
            ret += "\n" + " " + (Children.Count > 1 ? Children[1].ToString(nextIndentaion) : "");
            ret += "\n" + indentationText + "else\n" + " " + (Children.Count > 2 ? Children[2].ToString(nextIndentaion) : "");
            return ret;
        }
    }
    public class IfASTTreeNode : ASTreeNode
    {

        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            int nextIndentation = currentIndentaion + 1;
            String ret = "\n" + indentationText + "if " + Children[0].ToString(0);
            ret += "\n " + (Children.Count > 1 ? Children[1].ToString(nextIndentation) : "");
            return ret;
        }
    }
    public class EqualsASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "==" + Children[1].ToString(0);
            return ret;
        }
    }
    public class RandomFromToASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "->" + Children[1].ToString(0);
            return ret;
        }
    }
    public class AddASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "+" + Children[1].ToString(0);
            return ret;
        }
    }
    public class JoinASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "+" + Children[1].ToString(0);
            return ret;
        }
    }
    public class ContainsASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + ".contains(" + Children[1].ToString(0) + ")";
            return ret;
        }
    }
    public class LetterOfASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[1].ToString(0) + "[" + Children[1].ToString(0) + "]";
            return ret;
        }
    }
    public class LenOfASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = "len(" + Children[0].ToString(0) + ")";
            return ret;
        }
    }
    public class SubtractASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "-" + Children[1].ToString(0);
            return ret;
        }
    }
    public class MultiplyASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "*" + Children[1].ToString(0);
            return ret;
        }
    }
    public class DevideASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "/" + Children[1].ToString(0);
            return ret;
        }
    }
    public class OrASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "|" + Children[1].ToString(0);
            return ret;
        }
    }
    public class GTASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + ">" + Children[1].ToString(0);
            return ret;
        }
    }
    public class LTASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            string indentationText = GetIndentation(currentIndentaion);
            String ret = indentationText + Children[0].ToString(currentIndentaion) + "<" + Children[1].ToString(currentIndentaion);
            return ret;
        }
    }
    public class MathOpASTTreeNode : ASTreeNode
    {
        public string Operator { get; set; }
        public override string ToString(int currentIndentaion)
        {
            string ret = Operator + "(" + Children[0].ToString(0) + ")";
            return ret;
        }
    }
    public class AndASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "&" + Children[1].ToString(0);
            return ret;
        }
    }
    public class ModASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = Children[0].ToString(0) + "%" + Children[1].ToString(0);
            return ret;
        }
    }
    public class RoundASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = "round(" + Children[0].ToString(0) + ")";
            return ret;
        }
    }
    public class NotASTTreeNode : ASTreeNode
    {
        public override string ToString(int currentIndentaion)
        {
            String ret = "!" + Children[0].ToString(0);
            return ret;
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
        public String Value { get; set; }
        public override string ToString(int currentIndentaion)
        {
            return Value;
        }
    }
    public class WholeNumberASTTreeNode : ASTreeNode
    {
        public String Value { get; set; }
        public override string ToString(int currentIndentaion)
        {
            return Value;
        }
    }
    public class NumberASTTreeNode : ASTreeNode
    {
        public String Value { get; set; }
        public override string ToString(int currentIndentaion)
        {
            return Value;
        }
    }
    public class OpcodeParseInfo
    {
        public OpcodeParseInfo(Type typeIfo, string[] childInfo)
        {
            this.TypeIfo = typeIfo;
            this.ChildInfo = childInfo;
        }
        public Type TypeIfo { get; set; }
        public string[] ChildInfo { get; set; }
    }
    public class ASTreeNode
    {
        public Dictionary<string, OpcodeParseInfo> opcodeToType =
        new Dictionary<string, OpcodeParseInfo> {
            {"data_setvariableto",new OpcodeParseInfo( typeof(SetVariableToASTreeNode), new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"}) },
            {"data_changevariableby",new OpcodeParseInfo(typeof(SetVariableByASTreeNode), new string[]{".fields.VARIABLE.value", ".inputs.VALUE.block"}) },
            {"control_repeat",new OpcodeParseInfo(typeof(RepeaToASTreeNode), new string[]{".inputs.TIMES.block", ".inputs.SUBSTACK.block"}) },
            {"control_repeat_until",new OpcodeParseInfo(typeof(RepeatUntilASTreeNode), new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block"}) },
            {"control_wait",new OpcodeParseInfo(typeof(WaitASTreeNode), new string[]{".inputs.DURATION.block"}) },
            {"control_wait_until",new OpcodeParseInfo(typeof(WaitUntilASTreeNode), new string[]{".inputs.CONDITION.block"}) },
            {"control_forever",new OpcodeParseInfo(typeof(ForeverASTreeNode), new string[]{".inputs.SUBSTACK.block"}) },
            {"control_if_else",new OpcodeParseInfo(typeof(IfElseASTTreeNode), new string[]{ ".inputs.CONDITION.block", ".inputs.SUBSTACK.block", ".inputs.SUBSTACK2.block"}) },
            {"control_if",new OpcodeParseInfo(typeof(IfASTTreeNode), new string[]{".inputs.CONDITION.block", ".inputs.SUBSTACK.block"}) },
            {"operator_equals",new OpcodeParseInfo(typeof(EqualsASTTreeNode), new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}) },
            {"operator_random",new OpcodeParseInfo(typeof(RandomFromToASTTreeNode), new string[]{".inputs.FROM.block", ".inputs.TO.block"}) },
            {"operator_subtract",new OpcodeParseInfo(typeof(SubtractASTTreeNode), new string[]{ ".inputs.NUM1.block", ".inputs.NUM2.block"}) },
            {"operator_add",new OpcodeParseInfo(typeof(AddASTTreeNode), new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}) },
            {"operator_join",new OpcodeParseInfo(typeof(JoinASTTreeNode), new string[]{ ".inputs.STRING1.block", ".inputs.STRING2.block"}) },
            {"operator_contains",new OpcodeParseInfo(typeof(ContainsASTTreeNode), new string[]{".inputs.STRING1.block", ".inputs.STRING2.block"}) },
            {"operator_letter_of",new OpcodeParseInfo(typeof(LetterOfASTTreeNode), new string[]{ ".inputs.LETTER.block", ".inputs.STRING.block"}) },
            {"operator_length",new OpcodeParseInfo(typeof(LenOfASTTreeNode), new string[]{".inputs.STRING.block"}) },
            {"operator_multiply",new OpcodeParseInfo(typeof(MultiplyASTTreeNode), new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}) },
            {"operator_divide",new OpcodeParseInfo(typeof(DevideASTTreeNode), new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}) },
            {"operator_or",new OpcodeParseInfo(typeof(OrASTTreeNode), new string[]{ ".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}) },
            {"operator_gt",new OpcodeParseInfo(typeof(GTASTTreeNode), new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}) },
            {"operator_lt",new OpcodeParseInfo(typeof(LTASTTreeNode), new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}) },
            {"operator_and",new OpcodeParseInfo(typeof(AndASTTreeNode), new string[]{".inputs.OPERAND1.block", ".inputs.OPERAND2.block"}) },
            {"operator_mod",new OpcodeParseInfo(typeof(ModASTTreeNode), new string[]{".inputs.NUM1.block", ".inputs.NUM2.block"}) },
            {"operator_round",new OpcodeParseInfo(typeof(RoundASTTreeNode), new string[]{".inputs.NUM.block" }) },
            {"operator_mathop",new OpcodeParseInfo(typeof(MathOpASTTreeNode), new string[]{ ".fields.OPERATOR.value", ".inputs.NUM.block" }) },
            {"operator_not",new OpcodeParseInfo(typeof(NotASTTreeNode), new string[]{ ".inputs.OPERAND.block"}) },
            {"data_variable",new OpcodeParseInfo(typeof(DataVariableASTTreeNode), new string[]{".fields.VARIABLE.value"}) },
            {"text",new OpcodeParseInfo(typeof(TextASTTreeNode), new string[]{".fields.TEXT.value"}) },
            {"math_whole_number",new OpcodeParseInfo(typeof(WholeNumberASTTreeNode), new string[]{".fields.NUM.value"}) },
            {"math_number",new OpcodeParseInfo(typeof(NumberASTTreeNode), new string[]{".fields.NUM.value"}) },
            {"default",new OpcodeParseInfo(typeof(ASTreeNode), new string[]{}) }
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
            switch (opCode)
            {
                case "data_setvariableto":
                    dynamic valueToSet = ASTree.findBlock(blockList, (string)node.inputs.VALUE.block);
                    string field = node.fields.VARIABLE.value;
                    treeNode = new SetVariableToASTreeNode();
                    treeNode.Children.Add(new TextASTTreeNode() { Value = field });
                    ASTree.traverse(treeNode, blockList, valueToSet);
                    break;
                case "data_changevariableby":
                    dynamic valueToSetBy = ASTree.findBlock(blockList, (string)node.inputs.VALUE.block);
                    string fieldBy = (string)node.fields.VARIABLE.value;
                    treeNode = new SetVariableByASTreeNode();
                    treeNode.Children.Add(new TextASTTreeNode() { Value = fieldBy });
                    ASTree.traverse(treeNode, blockList, valueToSetBy);
                    break;
                case "control_repeat":
                    treeNode = new RepeaToASTreeNode();
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.TIMES.block));
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK.block));
                    break;
                case "control_repeat_until":
                    treeNode = new RepeatUntilASTreeNode();
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.CONDITION.block));
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK.block));
                    break;
                case "control_wait":
                    treeNode = new WaitASTreeNode();
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.DURATION.block));
                    break;
                case "control_wait_until":
                    treeNode = new WaitUntilASTreeNode();
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.CONDITION.block));
                    break;
                case "control_forever":
                    treeNode = new ForeverASTreeNode();
                    ASTree.traverse(treeNode, blockList, ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK.block));
                    break;
                case "control_if_else":
                    dynamic cond = ASTree.findBlock(blockList, (string)node.inputs.CONDITION.block);
                    dynamic t1 = ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK.block);
                    dynamic t2 = ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK2.block);
                    treeNode = new IfElseASTTreeNode();
                    treeNode.Children.Add(new ASTreeNode());
                    treeNode.Children.Add(new ASTreeNode());
                    treeNode.Children.Add(new ASTreeNode());
                    ASTree.traverse(treeNode.Children[0], blockList, cond);
                    ASTree.traverse(treeNode.Children[1], blockList, t1);
                    ASTree.traverse(treeNode.Children[2], blockList, t2);
                    break;
                case "control_if":
                    dynamic condOI = ASTree.findBlock(blockList, (string)node.inputs.CONDITION.block);
                    dynamic t1OI = ASTree.findBlock(blockList, (string)node.inputs.SUBSTACK.block);
                    treeNode = new IfASTTreeNode();
                    ASTree.traverse(treeNode, blockList, condOI);
                    ASTree.traverse(treeNode, blockList, t1OI);
                    break;
                case "operator_equals":
                    dynamic o1 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND1.block);
                    dynamic o2 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND2.block);
                    treeNode = new EqualsASTTreeNode();
                    ASTree.traverse(treeNode, blockList, o1);
                    ASTree.traverse(treeNode, blockList, o2);
                    break;
                case "operator_random":
                    dynamic from = ASTree.findBlock(blockList, (string)node.inputs.FROM.block);
                    dynamic to = ASTree.findBlock(blockList, (string)node.inputs.TO.block);
                    treeNode = new RandomFromToASTTreeNode();
                    ASTree.traverse(treeNode, blockList, from);
                    ASTree.traverse(treeNode, blockList, to);
                    break;
                case "operator_subtract":
                    dynamic os1 = ASTree.findBlock(blockList, (string)node.inputs.NUM1.block);
                    dynamic os2 = ASTree.findBlock(blockList, (string)node.inputs.NUM2.block);
                    treeNode = new SubtractASTTreeNode();
                    ASTree.traverse(treeNode, blockList, os1);
                    ASTree.traverse(treeNode, blockList, os2);
                    break;
                case "operator_add":
                    dynamic add1 = ASTree.findBlock(blockList, (string)node.inputs.NUM1.block);
                    dynamic add2 = ASTree.findBlock(blockList, (string)node.inputs.NUM2.block);
                    treeNode = new AddASTTreeNode();
                    ASTree.traverse(treeNode, blockList, add1);
                    ASTree.traverse(treeNode, blockList, add2);
                    break;
                case "operator_join":
                    dynamic j1 = ASTree.findBlock(blockList, (string)node.inputs.STRING1.block);
                    dynamic j2 = ASTree.findBlock(blockList, (string)node.inputs.STRING2.block);
                    treeNode = new JoinASTTreeNode();
                    ASTree.traverse(treeNode, blockList, j1);
                    ASTree.traverse(treeNode, blockList, j2);
                    break;
                case "operator_contains":
                    dynamic c1 = ASTree.findBlock(blockList, (string)node.inputs.STRING1.block);
                    dynamic c2 = ASTree.findBlock(blockList, (string)node.inputs.STRING2.block);
                    treeNode = new ContainsASTTreeNode();
                    ASTree.traverse(treeNode, blockList, c1);
                    ASTree.traverse(treeNode, blockList, c2);
                    break;
                case "operator_letter_of":
                    dynamic l1 = ASTree.findBlock(blockList, (string)node.inputs.LETTER.block);
                    dynamic l2 = ASTree.findBlock(blockList, (string)node.inputs.STRING.block);
                    treeNode = new LetterOfASTTreeNode();
                    ASTree.traverse(treeNode, blockList, l1);
                    ASTree.traverse(treeNode, blockList, l2);
                    break;
                case "operator_length":
                    dynamic len1 = ASTree.findBlock(blockList, (string)node.inputs.STRING.block);
                    treeNode = new LenOfASTTreeNode();
                    ASTree.traverse(treeNode, blockList, len1);
                    break;
                case "operator_multiply":
                    dynamic n1 = ASTree.findBlock(blockList, (string)node.inputs.NUM1.block);
                    dynamic n2 = ASTree.findBlock(blockList, (string)node.inputs.NUM2.block);
                    treeNode = new MultiplyASTTreeNode();
                    ASTree.traverse(treeNode, blockList, n1);
                    ASTree.traverse(treeNode, blockList, n2);
                    break;
                case "operator_divide":
                    dynamic d1 = ASTree.findBlock(blockList, (string)node.inputs.NUM1.block);
                    dynamic d2 = ASTree.findBlock(blockList, (string)node.inputs.NUM2.block);
                    treeNode = new DevideASTTreeNode();
                    ASTree.traverse(treeNode, blockList, d1);
                    ASTree.traverse(treeNode, blockList, d2);
                    break;
                case "operator_or":
                    dynamic or1 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND1.block);
                    dynamic or2 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND2.block);
                    treeNode = new OrASTTreeNode();
                    ASTree.traverse(treeNode, blockList, or1);
                    ASTree.traverse(treeNode, blockList, or2);
                    break;
                case "operator_gt":
                    dynamic gt1 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND1.block);
                    dynamic gt2 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND2.block);
                    treeNode = new GTASTTreeNode();
                    ASTree.traverse(treeNode, blockList, gt1);
                    ASTree.traverse(treeNode, blockList, gt2);
                    break;
                case "operator_lt":
                    dynamic lt1 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND1.block);
                    dynamic lt2 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND2.block);
                    treeNode = new LTASTTreeNode();
                    ASTree.traverse(treeNode, blockList, lt1);
                    ASTree.traverse(treeNode, blockList, lt2);
                    break;
                case "operator_and":
                    dynamic and1 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND1.block);
                    dynamic and2 = ASTree.findBlock(blockList, (string)node.inputs.OPERAND2.block);
                    treeNode = new AndASTTreeNode();
                    ASTree.traverse(treeNode, blockList, and1);
                    ASTree.traverse(treeNode, blockList, and2);
                    break;
                case "operator_mod":
                    dynamic mod1 = ASTree.findBlock(blockList, (string)node.inputs.NUM1.block);
                    dynamic mod2 = ASTree.findBlock(blockList, (string)node.inputs.NUM2.block);
                    treeNode = new ModASTTreeNode();
                    ASTree.traverse(treeNode, blockList, mod1);
                    ASTree.traverse(treeNode, blockList, mod2);
                    break;
                case "operator_round":
                    dynamic r1 = ASTree.findBlock(blockList, (string)node.inputs.NUM.block);
                    treeNode = new RoundASTTreeNode();
                    ASTree.traverse(treeNode, blockList, r1);
                    break;
                case "operator_mathop":
                    string oper = node.fields.OPERATOR.value;
                    dynamic mo2 = ASTree.findBlock(blockList, (string)node.inputs.NUM.block);
                    treeNode = new MathOpASTTreeNode()
                    {
                        Operator = oper
                    };
                    ASTree.traverse(treeNode, blockList, mo2);
                    break;
                case "operator_not":
                    dynamic no = ASTree.findBlock(blockList, (string)node.inputs.OPERAND.block);
                    treeNode = new NotASTTreeNode();
                    ASTree.traverse(treeNode, blockList, no);
                    break;
                case "data_variable":
                    treeNode = new DataVariableASTTreeNode();
                    treeNode.Children.Add(new TextASTTreeNode() { Value = (string)node.fields.VARIABLE.value });
                    break;
                case "text":
                    treeNode = new TextASTTreeNode()
                    {
                        Value = node.fields.TEXT.value
                    };
                    break;
                case "math_whole_number":
                    treeNode = new WholeNumberASTTreeNode()
                    {
                        Value = node.fields.NUM.value
                    };
                    break;
                case "math_number":
                    treeNode = new NumberASTTreeNode()
                    {
                        Value = node.fields.NUM.value
                    };
                    break;
                default:
                    treeNode = new ASTreeNode();
                    break;
            }
            treeNode.OpCode = node.opcode;

            return treeNode;
        }

    }

}
