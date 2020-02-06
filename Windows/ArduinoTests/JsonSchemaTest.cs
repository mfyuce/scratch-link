using System;
using System.IO;
using Arduino;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace ArduinoTests
{
    [TestClass]
    public class JsonSchemaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var schema = JsonSchema.FromJsonAsync(File.ReadAllText("./files/sb3_schema.json"), "./files/").Result;
            var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings() {
                Namespace = "scratch_schema",
                HandleReferences = true,
                 ClassStyle = CSharpClassStyle.Record,
                  
            });


            var file = generator.GenerateFile();

            Assert.IsTrue(!String.IsNullOrWhiteSpace(file));
        }
        [TestMethod]
        public void TestMethod2()
        {
            JObject o1 = JObject.Parse(sampleProj);

            Assert.IsTrue(o1!=null);
        }
        private static readonly String sampleProj = @"
{
  ""targets"": [
    {
      ""isStage"": true,
      ""name"": ""Stage"",
      ""variables"": {
        ""`jEk@4|i[#Fk?(8x)AV.-my variable"": [
          ""my variable"",
          ""10""
        ]
      },
      ""lists"": {},
      ""broadcasts"": {},
      ""blocks"": {},
      ""comments"": {},
      ""currentCostume"": 0,
      ""costumes"": [
        {
          ""assetId"": ""cd21514d0531fdffb22204e0ec5ed84a"",
          ""name"": ""backdrop1"",
          ""md5ext"": ""cd21514d0531fdffb22204e0ec5ed84a.svg"",
          ""dataFormat"": ""svg"",
          ""rotationCenterX"": 240,
          ""rotationCenterY"": 180
        }
      ],
      ""sounds"": [
        {
          ""assetId"": ""83a9787d4cb6f3b7632b4ddfebf74367"",
          ""name"": ""pop"",
          ""dataFormat"": ""wav"",
          ""format"": """",
          ""rate"": 48000,
          ""sampleCount"": 1123,
          ""md5ext"": ""83a9787d4cb6f3b7632b4ddfebf74367.wav""
        }
      ],
      ""volume"": 100,
      ""layerOrder"": 0,
      ""tempo"": 60,
      ""videoTransparency"": 50,
      ""videoState"": ""on"",
      ""textToSpeechLanguage"": null
    },
    {
      ""isStage"": false,
      ""name"": ""Sprite1"",
      ""variables"": {},
      ""lists"": {},
      ""broadcasts"": {},
      ""blocks"": {
        "",{dtN2oNc8Y;c-*}N|(3"": {
          ""opcode"": ""operator_equals"",
          ""next"": null,
          ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
          ""inputs"": {
            ""OPERAND1"": [
              3,
              [
                12,
                ""my variable"",
                ""`jEk@4|i[#Fk?(8x)AV.-my variable""
              ],
              [
                10,
                """"
              ]
            ],
            ""OPERAND2"": [
              1,
              [
                10,
                ""50""
              ]
            ]
          },
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": false
        },
        "";yyMS^/3`b2!#Fx2_qkk"": {
          ""opcode"": ""control_if_else"",
          ""next"": null,
          ""parent"": ""(~Fq(NqzKR-zPfvDAIVx"",
          ""inputs"": {
            ""CONDITION"": [
              2,
              "",{dtN2oNc8Y;c-*}N|(3""
            ],
            ""SUBSTACK"": [
              2,
              ""p-d4/FSzkCPMR;JX-W?D""
            ],
            ""SUBSTACK2"": [
              2,
              ""tkg3VSVTrSfhS[:eVLGx""
            ]
          },
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": false
        },
        ""*mxG8LwP]cxD5VhDvg_."": {
          ""opcode"": ""data_setvariableto"",
          ""next"": null,
          ""parent"": ""tkg3VSVTrSfhS[:eVLGx"",
          ""inputs"": {
            ""VALUE"": [
              1,
              [
                10,
                ""50""
              ]
            ]
          },
          ""fields"": {
            ""VARIABLE"": [
              ""my variable"",
              ""`jEk@4|i[#Fk?(8x)AV.-my variable""
            ]
          },
          ""shadow"": false,
          ""topLevel"": false
        },
        ""W7.rBJt-R)/V4dX=q(b5"": {
          ""opcode"": ""data_setvariableto"",
          ""next"": null,
          ""parent"": ""p-d4/FSzkCPMR;JX-W?D"",
          ""inputs"": {
            ""VALUE"": [
              1,
              [
                10,
                ""10""
              ]
            ]
          },
          ""fields"": {
            ""VARIABLE"": [
              ""my variable"",
              ""`jEk@4|i[#Fk?(8x)AV.-my variable""
            ]
          },
          ""shadow"": false,
          ""topLevel"": false
        },
        ""(~Fq(NqzKR-zPfvDAIVx"": {
          ""opcode"": ""control_repeat"",
          ""next"": null,
          ""parent"": ""QO{+4[L.?`h#-eG)9_Tv"",
          ""inputs"": {
            ""TIMES"": [
              1,
              [
                6,
                ""5""
              ]
            ],
            ""SUBSTACK"": [
              2,
              "";yyMS^/3`b2!#Fx2_qkk""
            ]
          },
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": false
        },
        ""tkg3VSVTrSfhS[:eVLGx"": {
          ""opcode"": ""looks_sayforsecs"",
          ""next"": ""*mxG8LwP]cxD5VhDvg_."",
          ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
          ""inputs"": {
            ""MESSAGE"": [
              1,
              [
                10,
                ""10""
              ]
            ],
            ""SECS"": [
              1,
              [
                4,
                ""1""
              ]
            ]
          },
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": false
        },
        ""QO{+4[L.?`h#-eG)9_Tv"": {
          ""opcode"": ""data_setvariableto"",
          ""next"": ""(~Fq(NqzKR-zPfvDAIVx"",
          ""parent"": ""~s0z32=`}v`1T#eFE={I"",
          ""inputs"": {
            ""VALUE"": [
              1,
              [
                10,
                ""50""
              ]
            ]
          },
          ""fields"": {
            ""VARIABLE"": [
              ""my variable"",
              ""`jEk@4|i[#Fk?(8x)AV.-my variable""
            ]
          },
          ""shadow"": false,
          ""topLevel"": false
        },
        ""~s0z32=`}v`1T#eFE={I"": {
          ""opcode"": ""event_whenflagclicked"",
          ""next"": ""QO{+4[L.?`h#-eG)9_Tv"",
          ""parent"": null,
          ""inputs"": {},
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": true,
          ""x"": 215,
          ""y"": -110
        },
        ""p-d4/FSzkCPMR;JX-W?D"": {
          ""opcode"": ""looks_sayforsecs"",
          ""next"": ""W7.rBJt-R)/V4dX=q(b5"",
          ""parent"": "";yyMS^/3`b2!#Fx2_qkk"",
          ""inputs"": {
            ""MESSAGE"": [
              1,
              [
                10,
                ""50""
              ]
            ],
            ""SECS"": [
              1,
              [
                4,
                ""1""
              ]
            ]
          },
          ""fields"": {},
          ""shadow"": false,
          ""topLevel"": false
        }
      },
      ""comments"": {},
      ""currentCostume"": 0,
      ""costumes"": [
        {
          ""assetId"": ""b7853f557e4426412e64bb3da6531a99"",
          ""name"": ""costume1"",
          ""bitmapResolution"": 1,
          ""md5ext"": ""b7853f557e4426412e64bb3da6531a99.svg"",
          ""dataFormat"": ""svg"",
          ""rotationCenterX"": 48,
          ""rotationCenterY"": 50
        },
        {
          ""assetId"": ""e6ddc55a6ddd9cc9d84fe0b4c21e016f"",
          ""name"": ""costume2"",
          ""bitmapResolution"": 1,
          ""md5ext"": ""e6ddc55a6ddd9cc9d84fe0b4c21e016f.svg"",
          ""dataFormat"": ""svg"",
          ""rotationCenterX"": 46,
          ""rotationCenterY"": 53
        }
      ],
      ""sounds"": [
        {
          ""assetId"": ""83c36d806dc92327b9e7049a565c6bff"",
          ""name"": ""Meow"",
          ""dataFormat"": ""wav"",
          ""format"": """",
          ""rate"": 48000,
          ""sampleCount"": 40681,
          ""md5ext"": ""83c36d806dc92327b9e7049a565c6bff.wav""
        }
      ],
      ""volume"": 100,
      ""layerOrder"": 1,
      ""visible"": true,
      ""x"": 0,
      ""y"": 0,
      ""size"": 100,
      ""direction"": 90,
      ""draggable"": false,
      ""rotationStyle"": ""all around""
    }
  ],
  ""monitors"": [
    {
      ""id"": ""`jEk@4|i[#Fk?(8x)AV.-my variable"",
      ""mode"": ""default"",
      ""opcode"": ""data_variable"",
      ""params"": {
        ""VARIABLE"": ""my variable""
      },
      ""spriteName"": null,
      ""value"": ""1"",
      ""width"": 0,
      ""height"": 0,
      ""x"": 5,
      ""y"": 5,
      ""visible"": false,
      ""sliderMin"": 0,
      ""sliderMax"": 100,
      ""isDiscrete"": true
    }
  ],
  ""extensions"": [],
  ""meta"": {
    ""semver"": ""3.0.0"",
    ""vm"": ""0.2.0"",
    ""agent"": ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36""
  }
}";
    }
}
