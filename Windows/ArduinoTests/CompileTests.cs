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
            Console.WriteLine(tree.AsCode(0, CodeConversion.ARDUINO_PLATFORM));
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
          ""block"": ""UFgeh.mo0QO.*aA_BA?F"",
          ""shadow"": ""TdQ*OxwilU:,of_oNE*K""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""L5gZLhZVB~y)5C-jw1kc"",
          ""shadow"": ""L5gZLhZVB~y)5C-jw1kc""
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
          ""shadow"": ""RQ+yVGxxz(R{}U9h9R|/""
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
          ""block"": ""#l3rLbgg5}x]!7^;%G;P"",
          ""shadow"": ""#l3rLbgg5}x]!7^;%G;P""
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
          ""block"": ""ydsGdywAuNl=dG8fxCm6"",
          ""shadow"": ""ydsGdywAuNl=dG8fxCm6""
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
          ""block"": ""c;//f_@T9pgUv!j@[pLK"",
          ""shadow"": ""c;//f_@T9pgUv!j@[pLK""
        },
        ""SECS"": {
          ""name"": ""SECS"",
          ""block"": ""+2uun3.Kr,B.uE_36Cpa"",
          ""shadow"": ""+2uun3.Kr,B.uE_36Cpa""
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
      ""parent"": ""1[OTcT-_Iu3%w:{kdyPk"",
      ""inputs"": {
        ""VALUE"": {
          ""name"": ""VALUE"",
          ""block"": ""XnOJ:e(S0oL|LYjI(-Dj"",
          ""shadow"": ""XnOJ:e(S0oL|LYjI(-Dj""
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
      ""next"": ""!eIUuUFisW:GCIseG2xP"",
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
          ""block"": ""Ql3@1uajSTg{p]rbCHZU"",
          ""shadow"": ""Ql3@1uajSTg{p]rbCHZU""
        },
        ""SECS"": {
          ""name"": ""SECS"",
          ""block"": ""Vfr^gYLV1jHKGri=!LJ+"",
          ""shadow"": ""Vfr^gYLV1jHKGri=!LJ+""
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
          ""block"": ""YM:#nIM=(+mFtFbxxy[3"",
          ""shadow"": ""YM:#nIM=(+mFtFbxxy[3""
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
          ""shadow"": ""WqUOlAF{!W*HriGp`^*7""
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
          ""shadow"": ""sJ0tX9wmlVcpe9=k0A;x""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": "";X-V2mQDZ-P)E!-wfW-B""
    },
    ""=:,f3c|`9Q);k~O%5+y@"": {
      ""opcode"": ""control_wait"",
      ""next"": "";yyMS^/3`b2!#Fx2_qkk"",
      ""parent"": ""V$!WNqKFLB,),,r%+:)P"",
      ""inputs"": {
        ""DURATION"": {
          ""name"": ""DURATION"",
          ""block"": "":yWN64gJjB@}1{M3,=9J"",
          ""shadow"": ""LbXi5]fPpt;^l{Y:=}zw""
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
      ""parent"": ""!eIUuUFisW:GCIseG2xP"",
      ""inputs"": {
        ""SUBSTACK"": {
          ""name"": ""SUBSTACK"",
          ""block"": ""TA=1ro[b7v3EAq8K3zBD"",
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
          ""block"": ""FaJ7eEtTg1M!-KUYuR{F"",
          ""shadow"": ""UoZO*_47Drw]S}hE1BQ2""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""e|KswjwEzn],AFw+ay];"",
          ""shadow"": ""e|KswjwEzn],AFw+ay];""
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
          ""block"": ""miWg,F8F4T?SkMDL8u/v"",
          ""shadow"": ""`JML.XthRyuKisz|w7|h""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""+9nn`pS5sd-pj]@A$YB6"",
          ""shadow"": ""ZZmyFXMa:D|Iy*F-OrDu""
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
          ""block"": ""!MaaFb0lLjuF3v+BhUR7"",
          ""shadow"": ""H`OURuY9EUK~-:~%Ky/h""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""E):dA:`pzz1Gs|3{oF6+"",
          ""shadow"": ""o`3s88BZ~!TA90rR6Qnc""
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
          ""block"": ""(S=yOPyX!QHNE8VN-Ja]"",
          ""shadow"": ""Fo~iAjGWB.l?j,R+~[EZ""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": ""ps8JgZX%4O93JiK=6Bve"",
          ""shadow"": "")bY,/bdzZK7_T~7_wx1v""
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
          ""block"": ""0iWm7*hFjPwb27ujZq(7"",
          ""shadow"": ""qUte@!L@WbK8z_U@d--w""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": ""KC+d}A4bQeM.T^G_Gre/"",
          ""shadow"": ""uw?X|+RL.I8sgnQzTb8z""
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
          ""block"": ""b{M5V5w~%6bxS2ZcE=-v"",
          ""shadow"": ""4p2}~mjDKo9QTBz8M~8/""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": ""w#j0`%}:7~k#sn`FR]d9"",
          ""shadow"": ""XxOj1@5.WA,,FV0@c~dp""
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
          ""block"": ""S(*evi]#7?ya+L]Ms=yP"",
          ""shadow"": ""*%Fes/}IIf]RfIy5xb1#""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": ""fOwvNjqc*(aYu6Hu|h/l"",
          ""shadow"": ""b5%-UWycZ%7j3@rMkWJj""
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
          ""shadow"": ""Pix3KPO*i`;U3p-efLTC""
        },
        ""TO"": {
          ""name"": ""TO"",
          ""block"": ""FED7qne6iSJ%b+NZ:)/Q"",
          ""shadow"": ""FED7qne6iSJ%b+NZ:)/Q""
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
          ""block"": ""{`-H,n7s@:rV+at}-ljj"",
          ""shadow"": ""!O=Mb(Xmz=L6N91[R;+F""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""4#Dj)R1u?9ZursLdGTGj"",
          ""shadow"": ""!8tt5lvaa]NMHjfFieEa""
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
          ""block"": ""[8nz?I3~w3+yC+UlY2Kd"",
          ""shadow"": ""/60X4}cV/IBg;I1,D-2u""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": "")+/U|Dd,bNy%I|Vvj5(`"",
          ""shadow"": ""S]d#y}Vw+WV`:*6yKLPI""
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
          ""shadow"": ""e@u0yq0:=bKq7y1eJ0G}""
        },
        ""OPERAND2"": {
          ""name"": ""OPERAND2"",
          ""block"": ""c(aq9OPNo!qdL@XluKI7"",
          ""shadow"": ""8RpCU8}eoL?E;,3M{E,|""
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
          ""block"": ""hG3}[z2wbw0+w3JsChkq"",
          ""shadow"": ""hG3}[z2wbw0+w3JsChkq""
        },
        ""STRING2"": {
          ""name"": ""STRING2"",
          ""block"": ""WA.iFO]|ikxvxQ~]1}7D"",
          ""shadow"": ""XizosRpN:f=SR7Tv[,1k""
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
          ""block"": ""wh0!MR7bA5TEE9%!dK4`"",
          ""shadow"": ""wh0!MR7bA5TEE9%!dK4`""
        },
        ""STRING"": {
          ""name"": ""STRING"",
          ""block"": ""-,05B=,wGaP^RorUZY29"",
          ""shadow"": ""I:Aq41K(c~+{L%^v_o6Y""
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
          ""shadow"": ""0(jLa:1Dn3F4p%EN70(9""
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
          ""block"": ""Tn42e#@{7W-%rpgXK1cB"",
          ""shadow"": ""/F@+.yc=#Sz/]=!z}!EP""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": "".N]%EKP+Ijels|ZD,{iB"",
          ""shadow"": ""JbtsdJT?KtOsBB!2YwIC""
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
          ""block"": ""JZB*|g6i[iZ8rp+5^C[`"",
          ""shadow"": ""fe^ZH/F3R?T-DEPP*1Wf""
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
          ""block"": ""ugj:-Qg2r55EBsq%*Ode"",
          ""shadow"": ""Q:l.AO+y.{vo6Cnn[Rd,""
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
          ""block"": ""F/jq4XM,NAl=]fu1;CJ]"",
          ""shadow"": ""F/jq4XM,NAl=]fu1;CJ]""
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
          ""block"": ""9KT/]D;zHG{ny47)v#QU"",
          ""shadow"": ""9KT/]D;zHG{ny47)v#QU""
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
          ""block"": ""Xut7AX]yuI!%gxW]rLI5"",
          ""shadow"": ""Xut7AX]yuI!%gxW]rLI5""
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
          ""shadow"": ""jQveDL@}`_jn=6FuTqr{""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""zwYCrcsK5CQbJ`$w=1H*""
    },
    ""#~[%HwNeDO]/*WXzP}Z8"": {
      ""opcode"": ""operator_add"",
      ""next"": null,
      ""parent"": ""Nx/2O)2crT,+x+FF0_gu"",
      ""inputs"": {
        ""NUM1"": {
          ""name"": ""NUM1"",
          ""block"": ""lg=_^vd=u3C;rQo:6l5@"",
          ""shadow"": ""J1U/9OVm3p,HQyR7=D=^""
        },
        ""NUM2"": {
          ""name"": ""NUM2"",
          ""block"": ""ABJ3F3)0.][Vu`Q^B%9V"",
          ""shadow"": ""T4#}]A01RmD3[]*)Brw(""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""#~[%HwNeDO]/*WXzP}Z8""
    },
    ""FL{7yvb_Gwmz?$s=M0O$"": {
      ""opcode"": ""control_if"",
      ""next"": null,
      ""parent"": ""?rS[K@|%lAAeN_wO5oem"",
      ""inputs"": {
        ""CONDITION"": {
          ""name"": ""CONDITION"",
          ""block"": ""SKfG~DCrh#,#z9.rmj3h"",
          ""shadow"": null
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""FL{7yvb_Gwmz?$s=M0O$""
    },
    ""SKfG~DCrh#,#z9.rmj3h"": {
      ""opcode"": ""operator_contains"",
      ""next"": null,
      ""parent"": ""FL{7yvb_Gwmz?$s=M0O$"",
      ""inputs"": {
        ""STRING1"": {
          ""name"": ""STRING1"",
          ""block"": ""NIbC=9Vi3[%,St~PYg)f"",
          ""shadow"": ""t2KKJ4:J.a6V{3}qNr@U""
        },
        ""STRING2"": {
          ""name"": ""STRING2"",
          ""block"": ""ZI{]nwh~5X2fJ29ss.-%"",
          ""shadow"": ""ZI{]nwh~5X2fJ29ss.-%""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""SKfG~DCrh#,#z9.rmj3h""
    },
    "",,Drf2lgl{cyBYi`sEnE"": {
      ""opcode"": ""pinoosimulator_digital_write"",
      ""next"": null,
      ""parent"": ""TA=1ro[b7v3EAq8K3zBD"",
      ""inputs"": {
        ""PIN"": {
          ""name"": ""PIN"",
          ""block"": ""]I5v}j:j@~vI9=1dPd7d"",
          ""shadow"": ""]I5v}j:j@~vI9=1dPd7d""
        },
        ""ON_OFF"": {
          ""name"": ""ON_OFF"",
          ""block"": ""/g`o)-zI]iY!a!sbh!sr"",
          ""shadow"": ""/g`o)-zI]iY!a!sbh!sr""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": "",,Drf2lgl{cyBYi`sEnE""
    },
    ""]I5v}j:j@~vI9=1dPd7d"": {
      ""opcode"": ""pinoosimulator_menu_digital_pins"",
      ""next"": null,
      ""parent"": "",,Drf2lgl{cyBYi`sEnE"",
      ""inputs"": {},
      ""fields"": {
        ""digital_pins"": {
          ""name"": ""digital_pins"",
          ""value"": ""7"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""]I5v}j:j@~vI9=1dPd7d""
    },
    ""/g`o)-zI]iY!a!sbh!sr"": {
      ""opcode"": ""pinoosimulator_menu_on_off"",
      ""next"": null,
      ""parent"": "",,Drf2lgl{cyBYi`sEnE"",
      ""inputs"": {},
      ""fields"": {
        ""on_off"": {
          ""name"": ""on_off"",
          ""value"": ""HIGH"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""/g`o)-zI]iY!a!sbh!sr""
    },
    ""!eIUuUFisW:GCIseG2xP"": {
      ""opcode"": ""pinoosimulator_set_pin_mode"",
      ""next"": ""Qufq-Bvd%z-!t|0;lz}="",
      ""parent"": ""~s0z32=`}v`1T#eFE={I"",
      ""inputs"": {
        ""PIN"": {
          ""name"": ""PIN"",
          ""block"": ""KN[vmS4.a7:!RLxEm|@J"",
          ""shadow"": ""KN[vmS4.a7:!RLxEm|@J""
        },
        ""PIN_MODE"": {
          ""name"": ""PIN_MODE"",
          ""block"": ""WcKH3A~A|_DrqG}?J(|c"",
          ""shadow"": ""WcKH3A~A|_DrqG}?J(|c""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""!eIUuUFisW:GCIseG2xP""
    },
    ""KN[vmS4.a7:!RLxEm|@J"": {
      ""opcode"": ""pinoosimulator_menu_digital_pins"",
      ""next"": null,
      ""parent"": ""!eIUuUFisW:GCIseG2xP"",
      ""inputs"": {},
      ""fields"": {
        ""digital_pins"": {
          ""name"": ""digital_pins"",
          ""value"": ""7"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""KN[vmS4.a7:!RLxEm|@J""
    },
    ""WcKH3A~A|_DrqG}?J(|c"": {
      ""opcode"": ""pinoosimulator_menu_pin_mode"",
      ""next"": null,
      ""parent"": ""!eIUuUFisW:GCIseG2xP"",
      ""inputs"": {},
      ""fields"": {
        ""pin_mode"": {
          ""name"": ""pin_mode"",
          ""value"": ""OUTPUT"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""WcKH3A~A|_DrqG}?J(|c""
    },
    ""TA=1ro[b7v3EAq8K3zBD"": {
      ""opcode"": ""control_if_else"",
      ""next"": ""1[OTcT-_Iu3%w:{kdyPk"",
      ""parent"": ""Qufq-Bvd%z-!t|0;lz}="",
      ""inputs"": {
        ""SUBSTACK"": {
          ""name"": ""SUBSTACK"",
          ""block"": "",,Drf2lgl{cyBYi`sEnE"",
          ""shadow"": null
        },
        ""SUBSTACK2"": {
          ""name"": ""SUBSTACK2"",
          ""block"": ""roiUj/p|hC;^R:VwWNvU"",
          ""shadow"": null
        },
        ""CONDITION"": {
          ""name"": ""CONDITION"",
          ""block"": ""HGP7D;}b8@Y.rHx-@kNM"",
          ""shadow"": null
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""TA=1ro[b7v3EAq8K3zBD""
    },
    ""1[OTcT-_Iu3%w:{kdyPk"": {
      ""opcode"": ""control_wait"",
      ""next"": ""QO{+4[L.?`h#-eG)9_Tv"",
      ""parent"": ""TA=1ro[b7v3EAq8K3zBD"",
      ""inputs"": {
        ""DURATION"": {
          ""name"": ""DURATION"",
          ""block"": ""K_OF-NQ3-yGhaWLBR.TM"",
          ""shadow"": ""K_OF-NQ3-yGhaWLBR.TM""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""1[OTcT-_Iu3%w:{kdyPk""
    },
    ""roiUj/p|hC;^R:VwWNvU"": {
      ""opcode"": ""pinoosimulator_digital_write"",
      ""next"": null,
      ""parent"": ""TA=1ro[b7v3EAq8K3zBD"",
      ""inputs"": {
        ""PIN"": {
          ""name"": ""PIN"",
          ""block"": ""xPYs*]Ao.NWLN=$0b^,#"",
          ""shadow"": ""xPYs*]Ao.NWLN=$0b^,#""
        },
        ""ON_OFF"": {
          ""name"": ""ON_OFF"",
          ""block"": ""n~[fh*,qt4(I-s?AQ3z$"",
          ""shadow"": ""n~[fh*,qt4(I-s?AQ3z$""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""roiUj/p|hC;^R:VwWNvU""
    },
    ""xPYs*]Ao.NWLN=$0b^,#"": {
      ""opcode"": ""pinoosimulator_menu_digital_pins"",
      ""next"": null,
      ""parent"": ""roiUj/p|hC;^R:VwWNvU"",
      ""inputs"": {},
      ""fields"": {
        ""digital_pins"": {
          ""name"": ""digital_pins"",
          ""value"": ""7"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""xPYs*]Ao.NWLN=$0b^,#""
    },
    ""n~[fh*,qt4(I-s?AQ3z$"": {
      ""opcode"": ""pinoosimulator_menu_on_off"",
      ""next"": null,
      ""parent"": ""roiUj/p|hC;^R:VwWNvU"",
      ""inputs"": {},
      ""fields"": {
        ""on_off"": {
          ""name"": ""on_off"",
          ""value"": ""LOW"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""n~[fh*,qt4(I-s?AQ3z$""
    },
    ""r#arm=Tx:[U57-mOE`nx"": {
      ""opcode"": ""pinoosimulator_pinEquals"",
      ""next"": null,
      ""parent"": ""TA=1ro[b7v3EAq8K3zBD"",
      ""inputs"": {
        ""PIN"": {
          ""name"": ""PIN"",
          ""block"": ""_6rt2;V;o$j15Gnv1mKM"",
          ""shadow"": ""_6rt2;V;o$j15Gnv1mKM""
        },
        ""ON_OFF"": {
          ""name"": ""ON_OFF"",
          ""block"": ""DG}8^SJNq9KE|!QW[c@e"",
          ""shadow"": ""DG}8^SJNq9KE|!QW[c@e""
        }
      },
      ""fields"": {},
      ""shadow"": false,
      ""topLevel"": false,
      ""id"": ""r#arm=Tx:[U57-mOE`nx""
    },
    ""_6rt2;V;o$j15Gnv1mKM"": {
      ""opcode"": ""pinoosimulator_menu_digital_pins"",
      ""next"": null,
      ""parent"": ""r#arm=Tx:[U57-mOE`nx"",
      ""inputs"": {},
      ""fields"": {
        ""digital_pins"": {
          ""name"": ""digital_pins"",
          ""value"": ""7"",
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""_6rt2;V;o$j15Gnv1mKM""
    },
    ""DG}8^SJNq9KE|!QW[c@e"": {
      ""opcode"": ""pinoosimulator_menu_on_off"",
      ""next"": null,
      ""parent"": ""r#arm=Tx:[U57-mOE`nx"",
      ""inputs"": {},
      ""fields"": {
        ""on_off"": {
          ""name"": ""on_off"",
          ""value"": 1,
          ""id"": null
        }
      },
      ""shadow"": true,
      ""topLevel"": false,
      ""id"": ""DG}8^SJNq9KE|!QW[c@e""
    },
    ""UFgeh.mo0QO.*aA_BA?F"": {
      ""id"": ""UFgeh.mo0QO.*aA_BA?F"",
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
    ""TdQ*OxwilU:,of_oNE*K"": {
      ""id"": ""TdQ*OxwilU:,of_oNE*K"",
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
    ""L5gZLhZVB~y)5C-jw1kc"": {
      ""id"": ""L5gZLhZVB~y)5C-jw1kc"",
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
    ""RQ+yVGxxz(R{}U9h9R|/"": {
      ""id"": ""RQ+yVGxxz(R{}U9h9R|/"",
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
    ""#l3rLbgg5}x]!7^;%G;P"": {
      ""id"": ""#l3rLbgg5}x]!7^;%G;P"",
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
    ""ydsGdywAuNl=dG8fxCm6"": {
      ""id"": ""ydsGdywAuNl=dG8fxCm6"",
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
    ""c;//f_@T9pgUv!j@[pLK"": {
      ""id"": ""c;//f_@T9pgUv!j@[pLK"",
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
    ""+2uun3.Kr,B.uE_36Cpa"": {
      ""id"": ""+2uun3.Kr,B.uE_36Cpa"",
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
    ""XnOJ:e(S0oL|LYjI(-Dj"": {
      ""id"": ""XnOJ:e(S0oL|LYjI(-Dj"",
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
    ""Ql3@1uajSTg{p]rbCHZU"": {
      ""id"": ""Ql3@1uajSTg{p]rbCHZU"",
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
    ""Vfr^gYLV1jHKGri=!LJ+"": {
      ""id"": ""Vfr^gYLV1jHKGri=!LJ+"",
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
    ""YM:#nIM=(+mFtFbxxy[3"": {
      ""id"": ""YM:#nIM=(+mFtFbxxy[3"",
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
    ""WqUOlAF{!W*HriGp`^*7"": {
      ""id"": ""WqUOlAF{!W*HriGp`^*7"",
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
    ""sJ0tX9wmlVcpe9=k0A;x"": {
      ""id"": ""sJ0tX9wmlVcpe9=k0A;x"",
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
    ""LbXi5]fPpt;^l{Y:=}zw"": {
      ""id"": ""LbXi5]fPpt;^l{Y:=}zw"",
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
    ""FaJ7eEtTg1M!-KUYuR{F"": {
      ""id"": ""FaJ7eEtTg1M!-KUYuR{F"",
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
    ""UoZO*_47Drw]S}hE1BQ2"": {
      ""id"": ""UoZO*_47Drw]S}hE1BQ2"",
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
    ""e|KswjwEzn],AFw+ay];"": {
      ""id"": ""e|KswjwEzn],AFw+ay];"",
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
    ""miWg,F8F4T?SkMDL8u/v"": {
      ""id"": ""miWg,F8F4T?SkMDL8u/v"",
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
    ""`JML.XthRyuKisz|w7|h"": {
      ""id"": ""`JML.XthRyuKisz|w7|h"",
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
    ""ZZmyFXMa:D|Iy*F-OrDu"": {
      ""id"": ""ZZmyFXMa:D|Iy*F-OrDu"",
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
    ""!MaaFb0lLjuF3v+BhUR7"": {
      ""id"": ""!MaaFb0lLjuF3v+BhUR7"",
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
    ""H`OURuY9EUK~-:~%Ky/h"": {
      ""id"": ""H`OURuY9EUK~-:~%Ky/h"",
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
    ""o`3s88BZ~!TA90rR6Qnc"": {
      ""id"": ""o`3s88BZ~!TA90rR6Qnc"",
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
    ""(S=yOPyX!QHNE8VN-Ja]"": {
      ""id"": ""(S=yOPyX!QHNE8VN-Ja]"",
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
    ""Fo~iAjGWB.l?j,R+~[EZ"": {
      ""id"": ""Fo~iAjGWB.l?j,R+~[EZ"",
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
    ""ps8JgZX%4O93JiK=6Bve"": {
      ""id"": ""ps8JgZX%4O93JiK=6Bve"",
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
    "")bY,/bdzZK7_T~7_wx1v"": {
      ""id"": "")bY,/bdzZK7_T~7_wx1v"",
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
    ""0iWm7*hFjPwb27ujZq(7"": {
      ""id"": ""0iWm7*hFjPwb27ujZq(7"",
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
    ""qUte@!L@WbK8z_U@d--w"": {
      ""id"": ""qUte@!L@WbK8z_U@d--w"",
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
    ""KC+d}A4bQeM.T^G_Gre/"": {
      ""id"": ""KC+d}A4bQeM.T^G_Gre/"",
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
    ""uw?X|+RL.I8sgnQzTb8z"": {
      ""id"": ""uw?X|+RL.I8sgnQzTb8z"",
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
    ""b{M5V5w~%6bxS2ZcE=-v"": {
      ""id"": ""b{M5V5w~%6bxS2ZcE=-v"",
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
    ""4p2}~mjDKo9QTBz8M~8/"": {
      ""id"": ""4p2}~mjDKo9QTBz8M~8/"",
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
    ""w#j0`%}:7~k#sn`FR]d9"": {
      ""id"": ""w#j0`%}:7~k#sn`FR]d9"",
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
    ""XxOj1@5.WA,,FV0@c~dp"": {
      ""id"": ""XxOj1@5.WA,,FV0@c~dp"",
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
    ""S(*evi]#7?ya+L]Ms=yP"": {
      ""id"": ""S(*evi]#7?ya+L]Ms=yP"",
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
    ""*%Fes/}IIf]RfIy5xb1#"": {
      ""id"": ""*%Fes/}IIf]RfIy5xb1#"",
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
    ""fOwvNjqc*(aYu6Hu|h/l"": {
      ""id"": ""fOwvNjqc*(aYu6Hu|h/l"",
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
    ""b5%-UWycZ%7j3@rMkWJj"": {
      ""id"": ""b5%-UWycZ%7j3@rMkWJj"",
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
    ""Pix3KPO*i`;U3p-efLTC"": {
      ""id"": ""Pix3KPO*i`;U3p-efLTC"",
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
    ""FED7qne6iSJ%b+NZ:)/Q"": {
      ""id"": ""FED7qne6iSJ%b+NZ:)/Q"",
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
    ""{`-H,n7s@:rV+at}-ljj"": {
      ""id"": ""{`-H,n7s@:rV+at}-ljj"",
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
    ""!O=Mb(Xmz=L6N91[R;+F"": {
      ""id"": ""!O=Mb(Xmz=L6N91[R;+F"",
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
    ""!8tt5lvaa]NMHjfFieEa"": {
      ""id"": ""!8tt5lvaa]NMHjfFieEa"",
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
    ""[8nz?I3~w3+yC+UlY2Kd"": {
      ""id"": ""[8nz?I3~w3+yC+UlY2Kd"",
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
    ""/60X4}cV/IBg;I1,D-2u"": {
      ""id"": ""/60X4}cV/IBg;I1,D-2u"",
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
    ""S]d#y}Vw+WV`:*6yKLPI"": {
      ""id"": ""S]d#y}Vw+WV`:*6yKLPI"",
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
    ""e@u0yq0:=bKq7y1eJ0G}"": {
      ""id"": ""e@u0yq0:=bKq7y1eJ0G}"",
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
    ""8RpCU8}eoL?E;,3M{E,|"": {
      ""id"": ""8RpCU8}eoL?E;,3M{E,|"",
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
    ""hG3}[z2wbw0+w3JsChkq"": {
      ""id"": ""hG3}[z2wbw0+w3JsChkq"",
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
    ""WA.iFO]|ikxvxQ~]1}7D"": {
      ""id"": ""WA.iFO]|ikxvxQ~]1}7D"",
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
    ""XizosRpN:f=SR7Tv[,1k"": {
      ""id"": ""XizosRpN:f=SR7Tv[,1k"",
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
    ""wh0!MR7bA5TEE9%!dK4`"": {
      ""id"": ""wh0!MR7bA5TEE9%!dK4`"",
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
    ""-,05B=,wGaP^RorUZY29"": {
      ""id"": ""-,05B=,wGaP^RorUZY29"",
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
    ""I:Aq41K(c~+{L%^v_o6Y"": {
      ""id"": ""I:Aq41K(c~+{L%^v_o6Y"",
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
    ""0(jLa:1Dn3F4p%EN70(9"": {
      ""id"": ""0(jLa:1Dn3F4p%EN70(9"",
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
    ""Tn42e#@{7W-%rpgXK1cB"": {
      ""id"": ""Tn42e#@{7W-%rpgXK1cB"",
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
    ""/F@+.yc=#Sz/]=!z}!EP"": {
      ""id"": ""/F@+.yc=#Sz/]=!z}!EP"",
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
    "".N]%EKP+Ijels|ZD,{iB"": {
      ""id"": "".N]%EKP+Ijels|ZD,{iB"",
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
    ""JbtsdJT?KtOsBB!2YwIC"": {
      ""id"": ""JbtsdJT?KtOsBB!2YwIC"",
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
    ""JZB*|g6i[iZ8rp+5^C[`"": {
      ""id"": ""JZB*|g6i[iZ8rp+5^C[`"",
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
    ""fe^ZH/F3R?T-DEPP*1Wf"": {
      ""id"": ""fe^ZH/F3R?T-DEPP*1Wf"",
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
    ""ugj:-Qg2r55EBsq%*Ode"": {
      ""id"": ""ugj:-Qg2r55EBsq%*Ode"",
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
    ""Q:l.AO+y.{vo6Cnn[Rd,"": {
      ""id"": ""Q:l.AO+y.{vo6Cnn[Rd,"",
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
    ""F/jq4XM,NAl=]fu1;CJ]"": {
      ""id"": ""F/jq4XM,NAl=]fu1;CJ]"",
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
    ""9KT/]D;zHG{ny47)v#QU"": {
      ""id"": ""9KT/]D;zHG{ny47)v#QU"",
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
    ""Xut7AX]yuI!%gxW]rLI5"": {
      ""id"": ""Xut7AX]yuI!%gxW]rLI5"",
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
    ""jQveDL@}`_jn=6FuTqr{"": {
      ""id"": ""jQveDL@}`_jn=6FuTqr{"",
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
    ""lg=_^vd=u3C;rQo:6l5@"": {
      ""id"": ""lg=_^vd=u3C;rQo:6l5@"",
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
      }
    },
    ""J1U/9OVm3p,HQyR7=D=^"": {
      ""id"": ""J1U/9OVm3p,HQyR7=D=^"",
      ""next"": null,
      ""parent"": ""#~[%HwNeDO]/*WXzP}Z8"",
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
    ""ABJ3F3)0.][Vu`Q^B%9V"": {
      ""id"": ""ABJ3F3)0.][Vu`Q^B%9V"",
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
      }
    },
    ""T4#}]A01RmD3[]*)Brw("": {
      ""id"": ""T4#}]A01RmD3[]*)Brw("",
      ""next"": null,
      ""parent"": ""#~[%HwNeDO]/*WXzP}Z8"",
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
    ""NIbC=9Vi3[%,St~PYg)f"": {
      ""id"": ""NIbC=9Vi3[%,St~PYg)f"",
      ""next"": null,
      ""parent"": ""SKfG~DCrh#,#z9.rmj3h"",
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
    ""t2KKJ4:J.a6V{3}qNr@U"": {
      ""id"": ""t2KKJ4:J.a6V{3}qNr@U"",
      ""next"": null,
      ""parent"": ""SKfG~DCrh#,#z9.rmj3h"",
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
    ""ZI{]nwh~5X2fJ29ss.-%"": {
      ""id"": ""ZI{]nwh~5X2fJ29ss.-%"",
      ""next"": null,
      ""parent"": ""SKfG~DCrh#,#z9.rmj3h"",
      ""shadow"": true,
      ""inputs"": {},
      ""opcode"": ""text"",
      ""fields"": {
        ""TEXT"": {
          ""name"": ""TEXT"",
          ""value"": ""a""
        }
      },
      ""topLevel"": false
    },
    ""K_OF-NQ3-yGhaWLBR.TM"": {
      ""id"": ""K_OF-NQ3-yGhaWLBR.TM"",
      ""next"": null,
      ""parent"": ""1[OTcT-_Iu3%w:{kdyPk"",
      ""shadow"": true,
      ""inputs"": {},
      ""opcode"": ""math_positive_number"",
      ""fields"": {
        ""NUM"": {
          ""name"": ""NUM"",
          ""value"": ""3""
        }
      },
      ""topLevel"": false
    },
    ""HGP7D;}b8@Y.rHx-@kNM"": {
      ""id"": ""HGP7D;}b8@Y.rHx-@kNM"",
      ""opcode"": ""pinoosimulator_pin_equals"",
      ""inputs"": {
        ""PIN"": {
          ""name"": ""PIN"",
          ""block"": ""B0?[l=8{?O2tyAM]njV2"",
          ""shadow"": ""B0?[l=8{?O2tyAM]njV2""
        },
        ""ON_OFF"": {
          ""name"": ""ON_OFF"",
          ""block"": ""F*jei%9jj=v305R5E-mZ"",
          ""shadow"": ""F*jei%9jj=v305R5E-mZ""
        }
      },
      ""fields"": {},
      ""next"": null,
      ""topLevel"": false,
      ""parent"": ""TA=1ro[b7v3EAq8K3zBD"",
      ""shadow"": false,
      ""x"": ""-358"",
      ""y"": ""-153""
    },
    ""B0?[l=8{?O2tyAM]njV2"": {
      ""id"": ""B0?[l=8{?O2tyAM]njV2"",
      ""opcode"": ""pinoosimulator_menu_digital_pins"",
      ""inputs"": {},
      ""fields"": {
        ""digital_pins"": {
          ""name"": ""digital_pins"",
          ""value"": ""7""
        }
      },
      ""next"": null,
      ""topLevel"": false,
      ""parent"": ""HGP7D;}b8@Y.rHx-@kNM"",
      ""shadow"": true
    },
    ""F*jei%9jj=v305R5E-mZ"": {
      ""id"": ""F*jei%9jj=v305R5E-mZ"",
      ""opcode"": ""pinoosimulator_menu_on_off"",
      ""inputs"": {},
      ""fields"": {
        ""on_off"": {
          ""name"": ""on_off"",
          ""value"": ""LOW""
        }
      },
      ""next"": null,
      ""topLevel"": false,
      ""parent"": ""HGP7D;}b8@Y.rHx-@kNM"",
      ""shadow"": true
    }
  }";
    }
}
