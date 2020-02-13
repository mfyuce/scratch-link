using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_lang
{

    public class ASTreeNode
    {
        
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
            string indentationText = CodeConversion.GetIndentation(currentIndentation);
            int nextIndentation = currentIndentation + 1;
            var children = CodeConversion.GetEffectiveChildren(this);
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
            OpcodeParseInfo info = CodeConversion.GetOpcodeInfo(opCode);
            
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
                else
                {
                    treeNode.Children.Add(new ASTreeNode());
                    ASTree.Traverse(treeNode.Children.Last(), blockList, block);
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
            return AsCode(indentation, CodeConversion.DEFAULT_PLATFORM);
        }
        public string AsCode(int indentation, string platform)
        {
            StringBuilder code = new StringBuilder();
            CodeConversion.AsCode(code, this, indentation, platform);
            return code.ToString();
        }
    }

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
            return Value;
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
}
