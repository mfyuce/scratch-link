using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_lang
{

    public class OpcodeParseInfo
    {
        public OpcodeParseInfo(Type typeIfo, string[] childInfo) : this(typeIfo, childInfo, -1, -1)
        {

        }
        public OpcodeParseInfo(string[] childInfo) : this(typeof(ASTreeNode), childInfo, -1, -1)
        {

        }
        public OpcodeParseInfo(Type typeIfo, string[] childInfo, int childrenStartFrom) : this(typeIfo, childInfo, childrenStartFrom, -1)
        {
        }
        public OpcodeParseInfo(string[] childInfo, int childrenStartFrom, int childrenEndAt) : this(typeof(ASTreeNode), childInfo, childrenStartFrom, childrenEndAt)
        {

        }
        public OpcodeParseInfo(string[] childInfo, int childrenStartFrom) : this(typeof(ASTreeNode), childInfo, childrenStartFrom, -1)
        {
        }
        public OpcodeParseInfo(Type typeIfo, string[] childInfo, int childrenStartFrom, int childrenEndAt)
        {
            this.TypeIfo = typeIfo;
            this.ChildInfo = childInfo;
            this.ChildrenEndAt = childrenEndAt;
            this.ChildrenStartFrom = childrenStartFrom;
        }
        public Type TypeIfo { get; set; }
        public string[] ChildInfo { get; set; }
        public int ChildrenStartFrom { get; set; }
        public int ChildrenEndAt { get; set; }
    }
}
