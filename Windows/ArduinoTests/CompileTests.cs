using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using scratch_lang;

namespace ArduinoTests
{
    
    [TestClass]
    public class CompileTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var blockList = JObject.Parse(sampleProjBlocks).Children();
            
            var tree = ASTree.Traverse(blockList, "~s0z32=`}v`1T#eFE={I");
            Console.WriteLine(tree.ToString());
            Console.WriteLine(tree.AsCode(0));
            Assert.IsTrue(tree != null);
        }

        private static readonly String sampleProjBlocks = @"{
  "",{dtN2oNc8Y;c-*}N|(3"": {
    ""opcode"": ""operator_equals"",
    ""next"": null,
    ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""8}m^10lePad?)=1BdQOj"",
        ""shadow"": ""qy42GXvLDQi4dPF%UVY.""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": "";z?-rO[X8uEb3}2CqnZS"",
        ""shadow"": "";z?-rO[X8uEb3}2CqnZS""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "",{dtN2oNc8Y;c-*}N|(3""
  },
  "";yyMS^/3`b2!#Fx2_qkk"": {
    ""opcode"": ""control_if_else"",
    ""next"": null,
    ""parent"": ""=:,f3c|`9Q);k~O%5+y@"",
    ""inputs"": {
      ""CONDITION"": {
        ""name"": ""CONDITION"",
        ""block"": "",{dtN2oNc8Y;c-*}N|(3"",
        ""shadow"": null
      },
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": ""zt{[Pjbn]^zsSgnCK9@l"",
        ""shadow"": null
      },
      ""SUBSTACK2"": {
        ""name"": ""SUBSTACK2"",
        ""block"": "";X-V2mQDZ-P)E!-wfW-B"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "";yyMS^/3`b2!#Fx2_qkk""
  },
  ""*mxG8LwP]cxD5VhDvg_."": {
    ""opcode"": ""data_setvariableto"",
    ""next"": null,
    ""parent"": "",B=c0%M7];I@U7aZDC?m"",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": ""g5;8ivX%c@L`Z}imC2S^"",
        ""shadow"": ""3]d?@Lx8Rqo4?Yx9%bSe""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""*mxG8LwP]cxD5VhDvg_.""
  },
  ""W7.rBJt-R)/V4dX=q(b5"": {
    ""opcode"": ""data_setvariableto"",
    ""next"": ""ax;t}QV7k8L?pXA9p!39"",
    ""parent"": ""p-d4/FSzkCPMR;JX-W?D"",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": ""SW0f|wi%^oPKmVX=Ydl)"",
        ""shadow"": ""SW0f|wi%^oPKmVX=Ydl)""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""W7.rBJt-R)/V4dX=q(b5""
  },
  ""(~Fq(NqzKR-zPfvDAIVx"": {
    ""opcode"": ""control_repeat"",
    ""next"": null,
    ""parent"": ""L8suIw,4Ez25*~5ZEC#d"",
    ""inputs"": {
      ""TIMES"": {
        ""name"": ""TIMES"",
        ""block"": ""~FG/^f4?O.8?wvu-AlI4"",
        ""shadow"": ""~FG/^f4?O.8?wvu-AlI4""
      },
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": ""V$!WNqKFLB,),,r%+:)P"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""(~Fq(NqzKR-zPfvDAIVx""
  },
  ""tkg3VSVTrSfhS[:eVLGx"": {
    ""opcode"": ""looks_sayforsecs"",
    ""next"": "",B=c0%M7];I@U7aZDC?m"",
    ""parent"": "";X-V2mQDZ-P)E!-wfW-B"",
    ""inputs"": {
      ""MESSAGE"": {
        ""name"": ""MESSAGE"",
        ""block"": ""ynDxKJ-JqyCYnY*+y6Bc"",
        ""shadow"": ""ynDxKJ-JqyCYnY*+y6Bc""
      },
      ""SECS"": {
        ""name"": ""SECS"",
        ""block"": ""Gbb%LGg-H`KM+o%.T2Hy"",
        ""shadow"": ""Gbb%LGg-H`KM+o%.T2Hy""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""tkg3VSVTrSfhS[:eVLGx""
  },
  ""QO{+4[L.?`h#-eG)9_Tv"": {
    ""opcode"": ""data_setvariableto"",
    ""next"": ""187!}4`6#W[RVbt*(aZI"",
    ""parent"": ""Qufq-Bvd%z-!t|0;lz}="",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": ""#zx)I8nG13+;c_Km*j8v"",
        ""shadow"": ""#zx)I8nG13+;c_Km*j8v""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""QO{+4[L.?`h#-eG)9_Tv""
  },
  ""~s0z32=`}v`1T#eFE={I"": {
    ""opcode"": ""event_whenflagclicked"",
    ""next"": ""Qufq-Bvd%z-!t|0;lz}="",
    ""parent"": null,
    ""inputs"": {},
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": true,
    ""x"": 495,
    ""y"": -476,
    ""id"": ""~s0z32=`}v`1T#eFE={I""
  },
  ""p-d4/FSzkCPMR;JX-W?D"": {
    ""opcode"": ""looks_sayforsecs"",
    ""next"": ""W7.rBJt-R)/V4dX=q(b5"",
    ""parent"": ""zwYCrcsK5CQbJ`$w=1H*"",
    ""inputs"": {
      ""MESSAGE"": {
        ""name"": ""MESSAGE"",
        ""block"": ""=@zH3Yb;Xy+HNJq_RV*n"",
        ""shadow"": ""=@zH3Yb;Xy+HNJq_RV*n""
      },
      ""SECS"": {
        ""name"": ""SECS"",
        ""block"": ""b1o_onr/EWtu^!|~M1=n"",
        ""shadow"": ""b1o_onr/EWtu^!|~M1=n""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""p-d4/FSzkCPMR;JX-W?D""
  },
  ""V$!WNqKFLB,),,r%+:)P"": {
    ""opcode"": ""event_broadcast"",
    ""next"": ""=:,f3c|`9Q);k~O%5+y@"",
    ""parent"": ""(~Fq(NqzKR-zPfvDAIVx"",
    ""inputs"": {
      ""BROADCAST_INPUT"": {
        ""name"": ""BROADCAST_INPUT"",
        ""block"": ""+PX`O/EbnO,3n1)#M:fR"",
        ""shadow"": ""+PX`O/EbnO,3n1)#M:fR""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""V$!WNqKFLB,),,r%+:)P""
  },
  ""zt{[Pjbn]^zsSgnCK9@l"": {
    ""opcode"": ""event_broadcastandwait"",
    ""next"": ""zwYCrcsK5CQbJ`$w=1H*"",
    ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
    ""inputs"": {
      ""BROADCAST_INPUT"": {
        ""name"": ""BROADCAST_INPUT"",
        ""block"": ""5OuIWQ,d({W@P0f/by/,"",
        ""shadow"": ""i*FB~nmWr*6Oiby5)j]M""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""zt{[Pjbn]^zsSgnCK9@l""
  },
  "";X-V2mQDZ-P)E!-wfW-B"": {
    ""opcode"": ""event_broadcastandwait"",
    ""next"": ""tkg3VSVTrSfhS[:eVLGx"",
    ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
    ""inputs"": {
      ""BROADCAST_INPUT"": {
        ""name"": ""BROADCAST_INPUT"",
        ""block"": ""5~r^=Ds0Yttk~}W90(e}"",
        ""shadow"": ""p,97B3s7#RQV@pw`/W]!""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "";X-V2mQDZ-P)E!-wfW-B"",
    ""x"": 543,
    ""y"": 580
  },
  ""=:,f3c|`9Q);k~O%5+y@"": {
    ""opcode"": ""control_wait"",
    ""next"": "";yyMS^/3`b2!#Fx2_qkk"",
    ""parent"": ""V$!WNqKFLB,),,r%+:)P"",
    ""inputs"": {
      ""DURATION"": {
        ""name"": ""DURATION"",
        ""block"": "":yWN64gJjB@}1{M3,=9J"",
        ""shadow"": ""(Abb9I9_[YkmQRmN9Uv3""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""=:,f3c|`9Q);k~O%5+y@""
  },
  ""Qufq-Bvd%z-!t|0;lz}="": {
    ""opcode"": ""control_forever"",
    ""next"": null,
    ""parent"": ""~s0z32=`}v`1T#eFE={I"",
    ""inputs"": {
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": ""QO{+4[L.?`h#-eG)9_Tv"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""Qufq-Bvd%z-!t|0;lz}=""
  },
  ""ax;t}QV7k8L?pXA9p!39"": {
    ""opcode"": ""control_if"",
    ""next"": ""?rS[K@|%lAAeN_wO5oem"",
    ""parent"": ""W7.rBJt-R)/V4dX=q(b5"",
    ""inputs"": {
      ""CONDITION"": {
        ""name"": ""CONDITION"",
        ""block"": ""o1_v73Wq^-E5yX//nnbW"",
        ""shadow"": null
      },
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": ""6wF(+zr844WP`|1gI@AG"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""ax;t}QV7k8L?pXA9p!39""
  },
  ""o1_v73Wq^-E5yX//nnbW"": {
    ""opcode"": ""operator_equals"",
    ""next"": null,
    ""parent"": ""ax;t}QV7k8L?pXA9p!39"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""LMA2*cfQ8H[!mTp)5%=V"",
        ""shadow"": "".{6_Kex5K/_]:+T{u3Wt""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""k7#HDR*yPae[io94mWQ/"",
        ""shadow"": ""k7#HDR*yPae[io94mWQ/""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""o1_v73Wq^-E5yX//nnbW""
  },
  ""6wF(+zr844WP`|1gI@AG"": {
    ""opcode"": ""control_wait_until"",
    ""next"": null,
    ""parent"": ""ax;t}QV7k8L?pXA9p!39"",
    ""inputs"": {
      ""CONDITION"": {
        ""name"": ""CONDITION"",
        ""block"": ""%ATvA`9Y1qV6@v4!{nbx"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""6wF(+zr844WP`|1gI@AG""
  },
  ""%ATvA`9Y1qV6@v4!{nbx"": {
    ""opcode"": ""operator_equals"",
    ""next"": null,
    ""parent"": ""6wF(+zr844WP`|1gI@AG"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""!SVTA:{%j#E^?rhqroeu"",
        ""shadow"": ""tD9YJqi4OWE@Mm)*p~BO""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""+9nn`pS5sd-pj]@A$YB6"",
        ""shadow"": ""7eO-XA8v`HgdVRC;y#X*""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""%ATvA`9Y1qV6@v4!{nbx""
  },
  ""?rS[K@|%lAAeN_wO5oem"": {
    ""opcode"": ""control_repeat_until"",
    ""next"": null,
    ""parent"": ""ax;t}QV7k8L?pXA9p!39"",
    ""inputs"": {
      ""CONDITION"": {
        ""name"": ""CONDITION"",
        ""block"": ""%DPs1PKp0;nMqE[Je/[*"",
        ""shadow"": null
      },
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": ""FL{7yvb_Gwmz?$s=M0O$"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""?rS[K@|%lAAeN_wO5oem""
  },
  ""%DPs1PKp0;nMqE[Je/[*"": {
    ""opcode"": ""operator_equals"",
    ""next"": null,
    ""parent"": ""?rS[K@|%lAAeN_wO5oem"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""i8xdQ:8W_#-lPC5f%RN="",
        ""shadow"": ""Rpz2BTy_`BO?_bQsQY,[""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""E):dA:`pzz1Gs|3{oF6+"",
        ""shadow"": ""OOWz_PVTB^`Qe{lW5/#^""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""%DPs1PKp0;nMqE[Je/[*""
  },
  ""W^R-cp@{U,Hru.T+PK2D"": {
    ""opcode"": ""operator_add"",
    ""next"": null,
    ""parent"": ""zwYCrcsK5CQbJ`$w=1H*"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""#0CH9n@)v!nYTFx`h4*U"",
        ""shadow"": ""q%7Q?^.2o0jZ*Pl^6,ug""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""My]j+{*XX_i4``:N:lm4"",
        ""shadow"": ""=#:HEzlX~NiG_.yMz_s8""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""W^R-cp@{U,Hru.T+PK2D""
  },
  "":yWN64gJjB@}1{M3,=9J"": {
    ""opcode"": ""operator_subtract"",
    ""next"": null,
    ""parent"": ""=:,f3c|`9Q);k~O%5+y@"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""693:G[|=DtbREkoe[oKx"",
        ""shadow"": ""PxmkG)dmy7_MgDY~).c8""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""Ytrx(Y8P_W?)Wjo1bPI2"",
        ""shadow"": ""z|)7*{?DUT2geH%7Zi7g""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "":yWN64gJjB@}1{M3,=9J""
  },
  ""ZvA(n|69M%WQvUq%,LDx"": {
    ""opcode"": ""operator_multiply"",
    ""next"": null,
    ""parent"": ""+9nn`pS5sd-pj]@A$YB6"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""uUXJX1vo[YIKD`6j5JYb"",
        ""shadow"": ""w,R#fVz-p6n^3,ezBOAz""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""Rh{+u*C}XjnA:{i_dS%:"",
        ""shadow"": ""Lue[-a;V9kYfjr~5P#sQ""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""ZvA(n|69M%WQvUq%,LDx""
  },
  ""4#Dj)R1u?9ZursLdGTGj"": {
    ""opcode"": ""operator_divide"",
    ""next"": null,
    ""parent"": ""YSBv6By`ETLfB0o~)uLt"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""]mX[;j1myH2AWZ9HNaEF"",
        ""shadow"": ""=nZPH;={#=[K/bhY3UVX""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""b`oa+`6p{kF2/jmuIQCI"",
        ""shadow"": ""(:%^b4!r;E!#J#U!}q)s""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""4#Dj)R1u?9ZursLdGTGj""
  },
  ""+9nn`pS5sd-pj]@A$YB6"": {
    ""opcode"": ""operator_random"",
    ""next"": null,
    ""parent"": ""%ATvA`9Y1qV6@v4!{nbx"",
    ""inputs"": {
      ""FROM"": {
        ""name"": ""FROM"",
        ""block"": ""ZvA(n|69M%WQvUq%,LDx"",
        ""shadow"": ""gy|-C/Ng9{0yl;bP;lD?""
      },
      ""TO"": {
        ""name"": ""TO"",
        ""block"": ""JR,m2YKT{t7iIPr7bIuy"",
        ""shadow"": ""JR,m2YKT{t7iIPr7bIuy""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""+9nn`pS5sd-pj]@A$YB6""
  },
  ""YSBv6By`ETLfB0o~)uLt"": {
    ""opcode"": ""operator_gt"",
    ""next"": null,
    ""parent"": ""FN0j^d@#?e,7bpXpMt^b"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""SonS|w27s,kE/)+s@C7-"",
        ""shadow"": ""AgB{PE-4y`%,(:WH%T-p""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""4#Dj)R1u?9ZursLdGTGj"",
        ""shadow"": ""L9dY*TPjuF+:qXzH*#B1""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""YSBv6By`ETLfB0o~)uLt""
  },
  ""ZfwK,,reT[pblL+w!WL)"": {
    ""opcode"": ""operator_lt"",
    ""next"": null,
    ""parent"": ""FN0j^d@#?e,7bpXpMt^b"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": "";Z6Ly5txS`Utf5qWi(Hu"",
        ""shadow"": ""{]])~K4F0`UZ`(G?HXhN""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": "")+/U|Dd,bNy%I|Vvj5(`"",
        ""shadow"": ""A+iV}A3dWjU{{3dhT1R`""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""ZfwK,,reT[pblL+w!WL)""
  },
  ""Nx/2O)2crT,+x+FF0_gu"": {
    ""opcode"": ""operator_equals"",
    ""next"": null,
    ""parent"": ""GCefIt8Arw#[L4hL*W%R"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""#~[%HwNeDO]/*WXzP}Z8"",
        ""shadow"": ""z2L884X+F1UzOO;#QkMS""
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""c(aq9OPNo!qdL@XluKI7"",
        ""shadow"": ""4z`!XdQ`gT8n*!lPvJeI""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""Nx/2O)2crT,+x+FF0_gu""
  },
  ""FN0j^d@#?e,7bpXpMt^b"": {
    ""opcode"": ""operator_and"",
    ""next"": null,
    ""parent"": ""GCefIt8Arw#[L4hL*W%R"",
    ""inputs"": {
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""YSBv6By`ETLfB0o~)uLt"",
        ""shadow"": null
      },
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""ZfwK,,reT[pblL+w!WL)"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""FN0j^d@#?e,7bpXpMt^b""
  },
  ""GCefIt8Arw#[L4hL*W%R"": {
    ""opcode"": ""operator_or"",
    ""next"": null,
    ""parent"": ""g5;8ivX%c@L`Z}imC2S^"",
    ""inputs"": {
      ""OPERAND2"": {
        ""name"": ""OPERAND2"",
        ""block"": ""FN0j^d@#?e,7bpXpMt^b"",
        ""shadow"": null
      },
      ""OPERAND1"": {
        ""name"": ""OPERAND1"",
        ""block"": ""Nx/2O)2crT,+x+FF0_gu"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""GCefIt8Arw#[L4hL*W%R""
  },
  ""g5;8ivX%c@L`Z}imC2S^"": {
    ""opcode"": ""operator_not"",
    ""next"": null,
    ""parent"": ""*mxG8LwP]cxD5VhDvg_."",
    ""inputs"": {
      ""OPERAND"": {
        ""name"": ""OPERAND"",
        ""block"": ""GCefIt8Arw#[L4hL*W%R"",
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""g5;8ivX%c@L`Z}imC2S^""
  },
  ""5OuIWQ,d({W@P0f/by/,"": {
    ""opcode"": ""operator_join"",
    ""next"": null,
    ""parent"": ""zt{[Pjbn]^zsSgnCK9@l"",
    ""inputs"": {
      ""STRING1"": {
        ""name"": ""STRING1"",
        ""block"": ""2s2V.Jf*W?2qVJKAqV/:"",
        ""shadow"": ""2s2V.Jf*W?2qVJKAqV/:""
      },
      ""STRING2"": {
        ""name"": ""STRING2"",
        ""block"": ""FfUftn)rm;;@gn0VwM7U"",
        ""shadow"": ""el51|!x)bu3yW_O)|k/)""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""5OuIWQ,d({W@P0f/by/,""
  },
  ""Blil^J5L-!HbDqeeOE:k"": {
    ""opcode"": ""operator_letter_of"",
    ""next"": null,
    ""parent"": ""E):dA:`pzz1Gs|3{oF6+"",
    ""inputs"": {
      ""LETTER"": {
        ""name"": ""LETTER"",
        ""block"": ""Wh1*w+OP[7;;@4F{Kl2s"",
        ""shadow"": ""Wh1*w+OP[7;;@4F{Kl2s""
      },
      ""STRING"": {
        ""name"": ""STRING"",
        ""block"": ""#|~8jPizSu=ui!yG{1sO"",
        ""shadow"": ""gq7:WrwoJhM:OckUOS0u""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""Blil^J5L-!HbDqeeOE:k""
  },
  ""E):dA:`pzz1Gs|3{oF6+"": {
    ""opcode"": ""operator_length"",
    ""next"": null,
    ""parent"": ""%DPs1PKp0;nMqE[Je/[*"",
    ""inputs"": {
      ""STRING"": {
        ""name"": ""STRING"",
        ""block"": ""Blil^J5L-!HbDqeeOE:k"",
        ""shadow"": ""VyrN9ym{2Tc8TE!s`z=c""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""E):dA:`pzz1Gs|3{oF6+""
  },
  "")+/U|Dd,bNy%I|Vvj5(`"": {
    ""opcode"": ""operator_mod"",
    ""next"": null,
    ""parent"": ""ZfwK,,reT[pblL+w!WL)"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""t/MYAL^pWX#.4BsQn]5_"",
        ""shadow"": ""yReaZvG%ACvkf=#Y]pJz""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""8*,(/iA},OY|oP(;vT{?"",
        ""shadow"": ""J3I;-Z}7}}!S5IIPB.4#""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "")+/U|Dd,bNy%I|Vvj5(`""
  },
  ""5~r^=Ds0Yttk~}W90(e}"": {
    ""opcode"": ""operator_round"",
    ""next"": null,
    ""parent"": "";X-V2mQDZ-P)E!-wfW-B"",
    ""inputs"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""block"": ""Xu].KXUttFUD5zHn;`3F"",
        ""shadow"": ""Pck+YRU@f-uz9S:97lM0""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""5~r^=Ds0Yttk~}W90(e}""
  },
  ""c(aq9OPNo!qdL@XluKI7"": {
    ""opcode"": ""operator_mathop"",
    ""next"": null,
    ""parent"": ""Nx/2O)2crT,+x+FF0_gu"",
    ""inputs"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""block"": ""{Hy[3BP-5}J1g7%qS-D="",
        ""shadow"": ""Of]QE*)V*Kp{Y?,}f.jc""
      }
    },
    ""fields"": {
      ""OPERATOR"": {
        ""name"": ""OPERATOR"",
        ""value"": ""abs"",
        ""id"": null
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""c(aq9OPNo!qdL@XluKI7""
  },
  "",B=c0%M7];I@U7aZDC?m"": {
    ""opcode"": ""data_changevariableby"",
    ""next"": ""*mxG8LwP]cxD5VhDvg_."",
    ""parent"": ""tkg3VSVTrSfhS[:eVLGx"",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": "":SvbtnTEg[Q6;d`pSAso"",
        ""shadow"": "":SvbtnTEg[Q6;d`pSAso""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": "",B=c0%M7];I@U7aZDC?m""
  },
  ""187!}4`6#W[RVbt*(aZI"": {
    ""opcode"": ""data_setvariableto"",
    ""next"": ""L8suIw,4Ez25*~5ZEC#d"",
    ""parent"": ""QO{+4[L.?`h#-eG)9_Tv"",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": ""vzqHniM7.U%X(TG1.-`M"",
        ""shadow"": ""vzqHniM7.U%X(TG1.-`M""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""varstr"",
        ""id"": ""la9mmi!(+9HRB(D6UCE|"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""187!}4`6#W[RVbt*(aZI""
  },
  ""L8suIw,4Ez25*~5ZEC#d"": {
    ""opcode"": ""data_setvariableto"",
    ""next"": ""(~Fq(NqzKR-zPfvDAIVx"",
    ""parent"": ""187!}4`6#W[RVbt*(aZI"",
    ""inputs"": {
      ""VALUE"": {
        ""name"": ""VALUE"",
        ""block"": ""WCQ#(0f^`LSTL~Q^.XJi"",
        ""shadow"": ""WCQ#(0f^`LSTL~Q^.XJi""
      }
    },
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    },
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""L8suIw,4Ez25*~5ZEC#d""
  },
  ""zwYCrcsK5CQbJ`$w=1H*"": {
    ""opcode"": ""event_broadcast"",
    ""next"": ""p-d4/FSzkCPMR;JX-W?D"",
    ""parent"": ""zt{[Pjbn]^zsSgnCK9@l"",
    ""inputs"": {
      ""BROADCAST_INPUT"": {
        ""name"": ""BROADCAST_INPUT"",
        ""block"": ""W^R-cp@{U,Hru.T+PK2D"",
        ""shadow"": ""2!YlwpAk_-%PUJ])78A{""
      }
    },
    ""fields"": {},
    ""shadow"": false,
    ""topLevel"": false,
    ""id"": ""zwYCrcsK5CQbJ`$w=1H*""
  },
  ""8}m^10lePad?)=1BdQOj"": {
    ""id"": ""8}m^10lePad?)=1BdQOj"",
    ""next"": null,
    ""parent"": "",{dtN2oNc8Y;c-*}N|(3"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""qy42GXvLDQi4dPF%UVY."": {
    ""id"": ""qy42GXvLDQi4dPF%UVY."",
    ""next"": null,
    ""parent"": "",{dtN2oNc8Y;c-*}N|(3"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  "";z?-rO[X8uEb3}2CqnZS"": {
    ""id"": "";z?-rO[X8uEb3}2CqnZS"",
    ""next"": null,
    ""parent"": "",{dtN2oNc8Y;c-*}N|(3"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""3]d?@Lx8Rqo4?Yx9%bSe"": {
    ""id"": ""3]d?@Lx8Rqo4?Yx9%bSe"",
    ""next"": null,
    ""parent"": ""*mxG8LwP]cxD5VhDvg_."",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""SW0f|wi%^oPKmVX=Ydl)"": {
    ""id"": ""SW0f|wi%^oPKmVX=Ydl)"",
    ""next"": null,
    ""parent"": ""W7.rBJt-R)/V4dX=q(b5"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""10""
      }
    },
    ""topLevel"": false
  },
  ""~FG/^f4?O.8?wvu-AlI4"": {
    ""id"": ""~FG/^f4?O.8?wvu-AlI4"",
    ""next"": null,
    ""parent"": ""(~Fq(NqzKR-zPfvDAIVx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_whole_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""5""
      }
    },
    ""topLevel"": false
  },
  ""ynDxKJ-JqyCYnY*+y6Bc"": {
    ""id"": ""ynDxKJ-JqyCYnY*+y6Bc"",
    ""next"": null,
    ""parent"": ""tkg3VSVTrSfhS[:eVLGx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""10""
      }
    },
    ""topLevel"": false
  },
  ""Gbb%LGg-H`KM+o%.T2Hy"": {
    ""id"": ""Gbb%LGg-H`KM+o%.T2Hy"",
    ""next"": null,
    ""parent"": ""tkg3VSVTrSfhS[:eVLGx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""#zx)I8nG13+;c_Km*j8v"": {
    ""id"": ""#zx)I8nG13+;c_Km*j8v"",
    ""next"": null,
    ""parent"": ""QO{+4[L.?`h#-eG)9_Tv"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""=@zH3Yb;Xy+HNJq_RV*n"": {
    ""id"": ""=@zH3Yb;Xy+HNJq_RV*n"",
    ""next"": null,
    ""parent"": ""p-d4/FSzkCPMR;JX-W?D"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""b1o_onr/EWtu^!|~M1=n"": {
    ""id"": ""b1o_onr/EWtu^!|~M1=n"",
    ""next"": null,
    ""parent"": ""p-d4/FSzkCPMR;JX-W?D"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""+PX`O/EbnO,3n1)#M:fR"": {
    ""id"": ""+PX`O/EbnO,3n1)#M:fR"",
    ""next"": null,
    ""parent"": ""V$!WNqKFLB,),,r%+:)P"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""event_broadcast_menu"",
    ""fields"": {
      ""BROADCAST_OPTION"": {
        ""name"": ""BROADCAST_OPTION"",
        ""value"": ""message1"",
        ""id"": ""UI9^fq%O6#=h?DNrb#a*"",
        ""variableType"": ""broadcast_msg""
      }
    },
    ""topLevel"": false
  },
  ""i*FB~nmWr*6Oiby5)j]M"": {
    ""id"": ""i*FB~nmWr*6Oiby5)j]M"",
    ""next"": null,
    ""parent"": ""zt{[Pjbn]^zsSgnCK9@l"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""event_broadcast_menu"",
    ""fields"": {
      ""BROADCAST_OPTION"": {
        ""name"": ""BROADCAST_OPTION"",
        ""value"": ""message2"",
        ""id"": ""rF^ydp]9xhh.?t5oUS!`"",
        ""variableType"": ""broadcast_msg""
      }
    },
    ""topLevel"": false
  },
  ""p,97B3s7#RQV@pw`/W]!"": {
    ""id"": ""p,97B3s7#RQV@pw`/W]!"",
    ""next"": null,
    ""parent"": "";X-V2mQDZ-P)E!-wfW-B"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""event_broadcast_menu"",
    ""fields"": {
      ""BROADCAST_OPTION"": {
        ""name"": ""BROADCAST_OPTION"",
        ""value"": ""message3"",
        ""id"": ""Pn8Qc%%gKuyD/t]1$=)2"",
        ""variableType"": ""broadcast_msg""
      }
    },
    ""topLevel"": false
  },
  ""(Abb9I9_[YkmQRmN9Uv3"": {
    ""id"": ""(Abb9I9_[YkmQRmN9Uv3"",
    ""next"": null,
    ""parent"": ""=:,f3c|`9Q);k~O%5+y@"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_positive_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""LMA2*cfQ8H[!mTp)5%=V"": {
    ""id"": ""LMA2*cfQ8H[!mTp)5%=V"",
    ""next"": null,
    ""parent"": ""o1_v73Wq^-E5yX//nnbW"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  "".{6_Kex5K/_]:+T{u3Wt"": {
    ""id"": "".{6_Kex5K/_]:+T{u3Wt"",
    ""next"": null,
    ""parent"": ""o1_v73Wq^-E5yX//nnbW"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""k7#HDR*yPae[io94mWQ/"": {
    ""id"": ""k7#HDR*yPae[io94mWQ/"",
    ""next"": null,
    ""parent"": ""o1_v73Wq^-E5yX//nnbW"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""!SVTA:{%j#E^?rhqroeu"": {
    ""id"": ""!SVTA:{%j#E^?rhqroeu"",
    ""next"": null,
    ""parent"": ""%ATvA`9Y1qV6@v4!{nbx"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""tD9YJqi4OWE@Mm)*p~BO"": {
    ""id"": ""tD9YJqi4OWE@Mm)*p~BO"",
    ""next"": null,
    ""parent"": ""%ATvA`9Y1qV6@v4!{nbx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""7eO-XA8v`HgdVRC;y#X*"": {
    ""id"": ""7eO-XA8v`HgdVRC;y#X*"",
    ""next"": null,
    ""parent"": ""%ATvA`9Y1qV6@v4!{nbx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""i8xdQ:8W_#-lPC5f%RN="": {
    ""id"": ""i8xdQ:8W_#-lPC5f%RN="",
    ""next"": null,
    ""parent"": ""%DPs1PKp0;nMqE[Je/[*"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""Rpz2BTy_`BO?_bQsQY,["": {
    ""id"": ""Rpz2BTy_`BO?_bQsQY,["",
    ""next"": null,
    ""parent"": ""%DPs1PKp0;nMqE[Je/[*"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""OOWz_PVTB^`Qe{lW5/#^"": {
    ""id"": ""OOWz_PVTB^`Qe{lW5/#^"",
    ""next"": null,
    ""parent"": ""%DPs1PKp0;nMqE[Je/[*"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""#0CH9n@)v!nYTFx`h4*U"": {
    ""id"": ""#0CH9n@)v!nYTFx`h4*U"",
    ""next"": null,
    ""parent"": ""W^R-cp@{U,Hru.T+PK2D"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""q%7Q?^.2o0jZ*Pl^6,ug"": {
    ""id"": ""q%7Q?^.2o0jZ*Pl^6,ug"",
    ""next"": null,
    ""parent"": ""W^R-cp@{U,Hru.T+PK2D"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""My]j+{*XX_i4``:N:lm4"": {
    ""id"": ""My]j+{*XX_i4``:N:lm4"",
    ""next"": null,
    ""parent"": ""W^R-cp@{U,Hru.T+PK2D"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""=#:HEzlX~NiG_.yMz_s8"": {
    ""id"": ""=#:HEzlX~NiG_.yMz_s8"",
    ""next"": null,
    ""parent"": ""W^R-cp@{U,Hru.T+PK2D"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""693:G[|=DtbREkoe[oKx"": {
    ""id"": ""693:G[|=DtbREkoe[oKx"",
    ""next"": null,
    ""parent"": "":yWN64gJjB@}1{M3,=9J"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""PxmkG)dmy7_MgDY~).c8"": {
    ""id"": ""PxmkG)dmy7_MgDY~).c8"",
    ""next"": null,
    ""parent"": "":yWN64gJjB@}1{M3,=9J"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""Ytrx(Y8P_W?)Wjo1bPI2"": {
    ""id"": ""Ytrx(Y8P_W?)Wjo1bPI2"",
    ""next"": null,
    ""parent"": "":yWN64gJjB@}1{M3,=9J"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""z|)7*{?DUT2geH%7Zi7g"": {
    ""id"": ""z|)7*{?DUT2geH%7Zi7g"",
    ""next"": null,
    ""parent"": "":yWN64gJjB@}1{M3,=9J"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""uUXJX1vo[YIKD`6j5JYb"": {
    ""id"": ""uUXJX1vo[YIKD`6j5JYb"",
    ""next"": null,
    ""parent"": ""ZvA(n|69M%WQvUq%,LDx"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""w,R#fVz-p6n^3,ezBOAz"": {
    ""id"": ""w,R#fVz-p6n^3,ezBOAz"",
    ""next"": null,
    ""parent"": ""ZvA(n|69M%WQvUq%,LDx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""Rh{+u*C}XjnA:{i_dS%:"": {
    ""id"": ""Rh{+u*C}XjnA:{i_dS%:"",
    ""next"": null,
    ""parent"": ""ZvA(n|69M%WQvUq%,LDx"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""Lue[-a;V9kYfjr~5P#sQ"": {
    ""id"": ""Lue[-a;V9kYfjr~5P#sQ"",
    ""next"": null,
    ""parent"": ""ZvA(n|69M%WQvUq%,LDx"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""]mX[;j1myH2AWZ9HNaEF"": {
    ""id"": ""]mX[;j1myH2AWZ9HNaEF"",
    ""next"": null,
    ""parent"": ""4#Dj)R1u?9ZursLdGTGj"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""=nZPH;={#=[K/bhY3UVX"": {
    ""id"": ""=nZPH;={#=[K/bhY3UVX"",
    ""next"": null,
    ""parent"": ""4#Dj)R1u?9ZursLdGTGj"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""b`oa+`6p{kF2/jmuIQCI"": {
    ""id"": ""b`oa+`6p{kF2/jmuIQCI"",
    ""next"": null,
    ""parent"": ""4#Dj)R1u?9ZursLdGTGj"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""(:%^b4!r;E!#J#U!}q)s"": {
    ""id"": ""(:%^b4!r;E!#J#U!}q)s"",
    ""next"": null,
    ""parent"": ""4#Dj)R1u?9ZursLdGTGj"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""gy|-C/Ng9{0yl;bP;lD?"": {
    ""id"": ""gy|-C/Ng9{0yl;bP;lD?"",
    ""next"": null,
    ""parent"": ""+9nn`pS5sd-pj]@A$YB6"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""JR,m2YKT{t7iIPr7bIuy"": {
    ""id"": ""JR,m2YKT{t7iIPr7bIuy"",
    ""next"": null,
    ""parent"": ""+9nn`pS5sd-pj]@A$YB6"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""10""
      }
    },
    ""topLevel"": false
  },
  ""SonS|w27s,kE/)+s@C7-"": {
    ""id"": ""SonS|w27s,kE/)+s@C7-"",
    ""next"": null,
    ""parent"": ""YSBv6By`ETLfB0o~)uLt"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    }
  },
  ""AgB{PE-4y`%,(:WH%T-p"": {
    ""id"": ""AgB{PE-4y`%,(:WH%T-p"",
    ""next"": null,
    ""parent"": ""YSBv6By`ETLfB0o~)uLt"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""L9dY*TPjuF+:qXzH*#B1"": {
    ""id"": ""L9dY*TPjuF+:qXzH*#B1"",
    ""next"": null,
    ""parent"": ""YSBv6By`ETLfB0o~)uLt"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  "";Z6Ly5txS`Utf5qWi(Hu"": {
    ""id"": "";Z6Ly5txS`Utf5qWi(Hu"",
    ""next"": null,
    ""parent"": ""ZfwK,,reT[pblL+w!WL)"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    }
  },
  ""{]])~K4F0`UZ`(G?HXhN"": {
    ""id"": ""{]])~K4F0`UZ`(G?HXhN"",
    ""next"": null,
    ""parent"": ""ZfwK,,reT[pblL+w!WL)"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""A+iV}A3dWjU{{3dhT1R`"": {
    ""id"": ""A+iV}A3dWjU{{3dhT1R`"",
    ""next"": null,
    ""parent"": ""ZfwK,,reT[pblL+w!WL)"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""5m~j/Di72lPGpR^*,`C~"": {
    ""id"": ""5m~j/Di72lPGpR^*,`C~"",
    ""next"": null,
    ""parent"": ""#~[%HwNeDO]/*WXzP}Z8"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    },
    ""x"": 834.31794261932373,
    ""y"": 676,
    ""topLevel"": false
  },
  ""z2L884X+F1UzOO;#QkMS"": {
    ""id"": ""z2L884X+F1UzOO;#QkMS"",
    ""next"": null,
    ""parent"": ""Nx/2O)2crT,+x+FF0_gu"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""4z`!XdQ`gT8n*!lPvJeI"": {
    ""id"": ""4z`!XdQ`gT8n*!lPvJeI"",
    ""next"": null,
    ""parent"": ""Nx/2O)2crT,+x+FF0_gu"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""50""
      }
    },
    ""topLevel"": false
  },
  ""2s2V.Jf*W?2qVJKAqV/:"": {
    ""id"": ""2s2V.Jf*W?2qVJKAqV/:"",
    ""next"": null,
    ""parent"": ""5OuIWQ,d({W@P0f/by/,"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""apple ""
      }
    },
    ""topLevel"": false
  },
  ""FfUftn)rm;;@gn0VwM7U"": {
    ""id"": ""FfUftn)rm;;@gn0VwM7U"",
    ""next"": null,
    ""parent"": ""5OuIWQ,d({W@P0f/by/,"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""varstr"",
        ""id"": ""la9mmi!(+9HRB(D6UCE|"",
        ""variableType"": """"
      }
    }
  },
  ""el51|!x)bu3yW_O)|k/)"": {
    ""id"": ""el51|!x)bu3yW_O)|k/)"",
    ""next"": null,
    ""parent"": ""5OuIWQ,d({W@P0f/by/,"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""banana""
      }
    },
    ""topLevel"": false
  },
  ""Wh1*w+OP[7;;@4F{Kl2s"": {
    ""id"": ""Wh1*w+OP[7;;@4F{Kl2s"",
    ""next"": null,
    ""parent"": ""Blil^J5L-!HbDqeeOE:k"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_whole_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""#|~8jPizSu=ui!yG{1sO"": {
    ""id"": ""#|~8jPizSu=ui!yG{1sO"",
    ""next"": null,
    ""parent"": ""Blil^J5L-!HbDqeeOE:k"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""varstr"",
        ""id"": ""la9mmi!(+9HRB(D6UCE|"",
        ""variableType"": """"
      }
    }
  },
  ""gq7:WrwoJhM:OckUOS0u"": {
    ""id"": ""gq7:WrwoJhM:OckUOS0u"",
    ""next"": null,
    ""parent"": ""Blil^J5L-!HbDqeeOE:k"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""apple""
      }
    },
    ""topLevel"": false
  },
  ""VyrN9ym{2Tc8TE!s`z=c"": {
    ""id"": ""VyrN9ym{2Tc8TE!s`z=c"",
    ""next"": null,
    ""parent"": ""E):dA:`pzz1Gs|3{oF6+"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""apple""
      }
    },
    ""topLevel"": false
  },
  ""t/MYAL^pWX#.4BsQn]5_"": {
    ""id"": ""t/MYAL^pWX#.4BsQn]5_"",
    ""next"": null,
    ""parent"": "")+/U|Dd,bNy%I|Vvj5(`"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    }
  },
  ""yReaZvG%ACvkf=#Y]pJz"": {
    ""id"": ""yReaZvG%ACvkf=#Y]pJz"",
    ""next"": null,
    ""parent"": "")+/U|Dd,bNy%I|Vvj5(`"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""8*,(/iA},OY|oP(;vT{?"": {
    ""id"": ""8*,(/iA},OY|oP(;vT{?"",
    ""next"": null,
    ""parent"": "")+/U|Dd,bNy%I|Vvj5(`"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""J3I;-Z}7}}!S5IIPB.4#"": {
    ""id"": ""J3I;-Z}7}}!S5IIPB.4#"",
    ""next"": null,
    ""parent"": "")+/U|Dd,bNy%I|Vvj5(`"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""Xu].KXUttFUD5zHn;`3F"": {
    ""id"": ""Xu].KXUttFUD5zHn;`3F"",
    ""next"": null,
    ""parent"": ""5~r^=Ds0Yttk~}W90(e}"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""my variable"",
        ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
        ""variableType"": """"
      }
    }
  },
  ""Pck+YRU@f-uz9S:97lM0"": {
    ""id"": ""Pck+YRU@f-uz9S:97lM0"",
    ""next"": null,
    ""parent"": ""5~r^=Ds0Yttk~}W90(e}"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  ""{Hy[3BP-5}J1g7%qS-D="": {
    ""id"": ""{Hy[3BP-5}J1g7%qS-D="",
    ""next"": null,
    ""parent"": ""c(aq9OPNo!qdL@XluKI7"",
    ""shadow"": false,
    ""inputs"": {},
    ""opcode"": ""data_variable"",
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""value"": ""var2"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""variableType"": """"
      }
    }
  },
  ""Of]QE*)V*Kp{Y?,}f.jc"": {
    ""id"": ""Of]QE*)V*Kp{Y?,}f.jc"",
    ""next"": null,
    ""parent"": ""c(aq9OPNo!qdL@XluKI7"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""topLevel"": false
  },
  "":SvbtnTEg[Q6;d`pSAso"": {
    ""id"": "":SvbtnTEg[Q6;d`pSAso"",
    ""next"": null,
    ""parent"": "",B=c0%M7];I@U7aZDC?m"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""math_number"",
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": ""1""
      }
    },
    ""topLevel"": false
  },
  ""vzqHniM7.U%X(TG1.-`M"": {
    ""id"": ""vzqHniM7.U%X(TG1.-`M"",
    ""next"": null,
    ""parent"": ""187!}4`6#W[RVbt*(aZI"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""asasas""
      }
    },
    ""topLevel"": false
  },
  ""WCQ#(0f^`LSTL~Q^.XJi"": {
    ""id"": ""WCQ#(0f^`LSTL~Q^.XJi"",
    ""next"": null,
    ""parent"": ""L8suIw,4Ez25*~5ZEC#d"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""text"",
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""0""
      }
    },
    ""topLevel"": false
  },
  ""2!YlwpAk_-%PUJ])78A{"": {
    ""id"": ""2!YlwpAk_-%PUJ])78A{"",
    ""next"": null,
    ""parent"": ""zwYCrcsK5CQbJ`$w=1H*"",
    ""shadow"": true,
    ""inputs"": {},
    ""opcode"": ""event_broadcast_menu"",
    ""fields"": {
      ""BROADCAST_OPTION"": {
        ""name"": ""BROADCAST_OPTION"",
        ""value"": ""message1"",
        ""id"": ""UI9^fq%O6#=h?DNrb#a*"",
        ""variableType"": ""broadcast_msg""
      }
    },
    ""topLevel"": false
  },
  ""#~[%HwNeDO]/*WXzP}Z8"": {
    ""id"": ""#~[%HwNeDO]/*WXzP}Z8"",
    ""opcode"": ""operator_add"",
    ""inputs"": {
      ""NUM1"": {
        ""name"": ""NUM1"",
        ""block"": ""5m~j/Di72lPGpR^*,`C~"",
        ""shadow"": ""iY(ynZF.Q|IpaGvV+ckF""
      },
      ""NUM2"": {
        ""name"": ""NUM2"",
        ""block"": ""84GsTQlGH2Y8Pk]~`[3`"",
        ""shadow"": ""2yr4[!orOOZkI:Gb)DbY""
      }
    },
    ""fields"": {},
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""Nx/2O)2crT,+x+FF0_gu"",
    ""shadow"": false,
    ""x"": 1020.6470653985881,
    ""y"": 513.93542793288486
  },
  ""iY(ynZF.Q|IpaGvV+ckF"": {
    ""id"": ""iY(ynZF.Q|IpaGvV+ckF"",
    ""opcode"": ""math_number"",
    ""inputs"": {},
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""next"": null,
    ""topLevel"": true,
    ""parent"": null,
    ""shadow"": true,
    ""x"": 830.31794261932373,
    ""y"": 680
  },
  ""2yr4[!orOOZkI:Gb)DbY"": {
    ""id"": ""2yr4[!orOOZkI:Gb)DbY"",
    ""opcode"": ""math_number"",
    ""inputs"": {},
    ""fields"": {
      ""NUM"": {
        ""name"": ""NUM"",
        ""value"": """"
      }
    },
    ""next"": null,
    ""topLevel"": true,
    ""parent"": null,
    ""shadow"": true,
    ""x"": 914.7609806060791,
    ""y"": 680
  },
  ""84GsTQlGH2Y8Pk]~`[3`"": {
    ""id"": ""84GsTQlGH2Y8Pk]~`[3`"",
    ""opcode"": ""data_variable"",
    ""inputs"": {},
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""id"": ""9i!Max2./I6Heta)?R$o"",
        ""value"": ""var2"",
        ""variableType"": """"
      }
    },
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""#~[%HwNeDO]/*WXzP}Z8"",
    ""shadow"": false,
    ""x"": ""834"",
    ""y"": ""676""
  },
  ""FL{7yvb_Gwmz?$s=M0O$"": {
    ""id"": ""FL{7yvb_Gwmz?$s=M0O$"",
    ""opcode"": ""control_if"",
    ""inputs"": {
      ""CONDITION"": {
        ""name"": ""CONDITION"",
        ""block"": ""}O3PIM3O!Dn)Hkdq#9|a"",
        ""shadow"": null
      },
      ""SUBSTACK"": {
        ""name"": ""SUBSTACK"",
        ""block"": null,
        ""shadow"": null
      }
    },
    ""fields"": {},
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""?rS[K@|%lAAeN_wO5oem"",
    ""shadow"": false,
    ""x"": ""62"",
    ""y"": ""720""
  },
  ""}O3PIM3O!Dn)Hkdq#9|a"": {
    ""id"": ""}O3PIM3O!Dn)Hkdq#9|a"",
    ""opcode"": ""operator_contains"",
    ""inputs"": {
      ""STRING1"": {
        ""name"": ""STRING1"",
        ""block"": ""wy]1d:x;FxE|;1F=[rRb"",
        ""shadow"": ""N!K#u[xi7[hqo%j[i3_Q""
      },
      ""STRING2"": {
        ""name"": ""STRING2"",
        ""block"": ""Z|UbsgILpq.Ga0`c}%d7"",
        ""shadow"": ""Z|UbsgILpq.Ga0`c}%d7""
      }
    },
    ""fields"": {},
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""FL{7yvb_Gwmz?$s=M0O$"",
    ""shadow"": false,
    ""x"": ""607"",
    ""y"": ""416""
  },
  ""wy]1d:x;FxE|;1F=[rRb"": {
    ""id"": ""wy]1d:x;FxE|;1F=[rRb"",
    ""opcode"": ""data_variable"",
    ""inputs"": {},
    ""fields"": {
      ""VARIABLE"": {
        ""name"": ""VARIABLE"",
        ""id"": ""la9mmi!(+9HRB(D6UCE|"",
        ""value"": ""varstr"",
        ""variableType"": """"
      }
    },
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""}O3PIM3O!Dn)Hkdq#9|a"",
    ""shadow"": false
  },
  ""N!K#u[xi7[hqo%j[i3_Q"": {
    ""id"": ""N!K#u[xi7[hqo%j[i3_Q"",
    ""opcode"": ""text"",
    ""inputs"": {},
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""apple""
      }
    },
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""}O3PIM3O!Dn)Hkdq#9|a"",
    ""shadow"": true
  },
  ""Z|UbsgILpq.Ga0`c}%d7"": {
    ""id"": ""Z|UbsgILpq.Ga0`c}%d7"",
    ""opcode"": ""text"",
    ""inputs"": {},
    ""fields"": {
      ""TEXT"": {
        ""name"": ""TEXT"",
        ""value"": ""a""
      }
    },
    ""next"": null,
    ""topLevel"": false,
    ""parent"": ""}O3PIM3O!Dn)Hkdq#9|a"",
    ""shadow"": true
  }
}";
    }
}
