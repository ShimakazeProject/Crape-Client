using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using L2DLib.Framework;

namespace L2DLib.Utility
{
    public class L2DFunctions
    {
        #region 内部功能
        private static string FixPath(string path, string value)
        {
            return (Directory.GetParent(path).FullName + "\\" + value).Replace("/", "\\");
        }
        #endregion

        #region 用户功能
        /// <summary>
        /// 轻松导入.Model.JSON文件。
        /// </summary>
        /// <param name="path">包含模型配置的JSON文件。</param>
        public static L2DModel LoadModel(string path)
        {
            // JSON 分析
            string modelPath;
            string[] texturePath;
            string physicsPath = null;
            string posePath = null;
            string parentPath = Directory.GetParent(path).FullName;
            Dictionary<string, L2DMotion[]> motionDictionary = new Dictionary<string, L2DMotion[]>();
            Dictionary<string, L2DExpression> expressionDictionary = new Dictionary<string, L2DExpression>();
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));

            // - model
            modelPath = FixPath(path, jsonObject.GetValue("model").Value<string>());

            // - textures
            texturePath = jsonObject.GetValue("textures").Values<string>().ToArray();
            for (int i = 0; i < texturePath.Length; i++)
            {
                texturePath[i] = FixPath(path, texturePath[i]);
            }

            // - physics
            JToken resultPhysics;
            jsonObject.TryGetValue("physics", out resultPhysics);
            if (resultPhysics != null)
            {
                physicsPath = FixPath(path, resultPhysics.Value<string>());
            }

            // - pose
            JToken resultPose;
            jsonObject.TryGetValue("pose", out resultPose);
            if (resultPose != null)
            {
                posePath = FixPath(path, resultPose.Value<string>());
            }

            // - motions


            JToken resultMotion;
            jsonObject.TryGetValue("motions", out resultMotion);
            if (resultMotion != null)
            {
                foreach (JProperty jsonMotion in jsonObject["motions"].Children())
                {
                    List<L2DMotion> motionList = new List<L2DMotion>();
                    foreach (JArray jsonChildren in jsonMotion.Children().ToList())
                    {
                        foreach (JObject result in jsonChildren)
                        {
                            L2DMotion motion = null;
                            string motionFile = FixPath(path, result.GetValue("file").Value<string>());
                            JToken resultSound;
                            result.TryGetValue("sound", out resultSound);

                            if (resultSound == null)
                            {
                                motion = new L2DMotion(motionFile);
                            }
                            else
                            {
                                string soundFile = FixPath(path, resultSound.Value<string>());
                                motion = new L2DMotion(motionFile, soundFile);
                            }

                            JToken resultFadeIn;
                            result.TryGetValue("fade_in", out resultFadeIn);

                            JToken resultFadeOut;
                            result.TryGetValue("fade_out", out resultFadeOut);

                            if (resultFadeIn != null)
                            {
                                motion.SetFadeIn(resultFadeIn.Value<int>());
                            }

                            if (resultFadeOut != null)
                            {
                                motion.SetFadeOut(resultFadeOut.Value<int>());
                            }

                            if (motion != null)
                            {
                                motionList.Add(motion);
                            }
                        }
                    }

                    motionDictionary.Add(jsonMotion.Name, motionList.ToArray());
                }
            }
            else
            {
                var ex = new NoMotionException
                    ("未能在 \".Model.Json\" 文件中找到 \"motions\" 配置");
                throw ex;
            }

            // - expression
            JToken resultExpression;
            jsonObject.TryGetValue("expressions", out resultExpression);
            if (resultExpression != null)
            {
                foreach (JObject json in resultExpression)
                {
                    string name = json["name"].Value<string>();
                    L2DExpression expression = LoadExpression(FixPath(path, json["file"].Value<string>()));
                    expressionDictionary.Add(name, expression);
                }
            }

            // 创建L2DModel
            L2DModel model = new L2DModel(modelPath);
            model.SetTexture(texturePath);
            model.Motion = motionDictionary;
            if (resultExpression != null)
            {
                model.Expression = expressionDictionary;
            }
            if (physicsPath != null)
            {
                model.Physics = LoadPhysics(physicsPath);
            }
            if (posePath != null)
            {
                model.Pose = LoadPose(posePath);
            }
            model.SaveParam();

            return model;
        }
        /// <summary>
        /// 轻松导入.Model.JSON文件。
        /// 警告: 这个方法将会使你无法正常加载Motions配置!
        /// </summary>
        /// <param name="path">包含模型配置的JSON文件。</param>
        public static L2DModel LoadModelNoMotions(string path)
        {
            // JSON 分析
            string modelPath;
            string[] texturePath;
            string physicsPath = null;
            string posePath = null;
            string parentPath = Directory.GetParent(path).FullName;
            Dictionary<string, L2DMotion[]> motionDictionary = new Dictionary<string, L2DMotion[]>();
            Dictionary<string, L2DExpression> expressionDictionary = new Dictionary<string, L2DExpression>();
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));

            // - model
            modelPath = FixPath(path, jsonObject.GetValue("model").Value<string>());

            // - textures
            texturePath = jsonObject.GetValue("textures").Values<string>().ToArray();
            for (int i = 0; i < texturePath.Length; i++)
            {
                texturePath[i] = FixPath(path, texturePath[i]);
            }

            // - physics
            JToken resultPhysics;
            jsonObject.TryGetValue("physics", out resultPhysics);
            if (resultPhysics != null)
            {
                physicsPath = FixPath(path, resultPhysics.Value<string>());
            }

            // - pose
            JToken resultPose;
            jsonObject.TryGetValue("pose", out resultPose);
            if (resultPose != null)
            {
                posePath = FixPath(path, resultPose.Value<string>());
            }

            // - expression
            JToken resultExpression;
            jsonObject.TryGetValue("expressions", out resultExpression);
            if (resultExpression != null)
            {
                foreach (JObject json in resultExpression)
                {
                    string name = json["name"].Value<string>();
                    L2DExpression expression = LoadExpression(FixPath(path, json["file"].Value<string>()));
                    expressionDictionary.Add(name, expression);
                }
            }

            // 创建L2DModel
            L2DModel model = new L2DModel(modelPath);
            model.SetTexture(texturePath);
            model.Motion = motionDictionary;
            if (resultExpression != null)
            {
                model.Expression = expressionDictionary;
            }
            if (physicsPath != null)
            {
                model.Physics = LoadPhysics(physicsPath);
            }
            if (posePath != null)
            {
                model.Pose = LoadPose(posePath);
            }
            model.SaveParam();

            return model;
        }


        /// <summary>
        /// 轻松导入Physics作为JSON文件。
        /// </summary>
        /// <param name="path">包含Physics配置的JSON文件。</param>
        /// <returns></returns>
        public static L2DPhysics[] LoadPhysics(string path)
        {
            List<L2DPhysics> physicsList = new List<L2DPhysics>();
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));
            foreach (JObject json in jsonObject["physics_hair"])
            {
                L2DPhysics physics = new L2DPhysics();
                L2DPhysics.PhysicsSetup physicsSetup = new L2DPhysics.PhysicsSetup
                {
                    length = json["setup"]["length"].Value<float>(),
                    regist = json["setup"]["regist"].Value<float>(),
                    mass = json["setup"]["mass"].Value<float>()
                };
                physics.Setup = physicsSetup;

                List<L2DPhysics.PhysicsSource> sourceList = new List<L2DPhysics.PhysicsSource>();
                foreach (JObject source in json["src"])
                {
                    L2DPhysics.PhysicsSource physicsSource = new L2DPhysics.PhysicsSource
                    {
                        id = source["id"].Value<string>(),
                        ptype = source["ptype"].Value<string>(),
                        scale = source["scale"].Value<float>(),
                        weight = source["weight"].Value<float>()
                    };
                    sourceList.Add(physicsSource);
                }
                physics.Sources = sourceList.ToArray();

                List<L2DPhysics.PhysicsTargets> targetList = new List<L2DPhysics.PhysicsTargets>();
                foreach (JObject target in json["targets"])
                {
                    L2DPhysics.PhysicsTargets physicsTargets = new L2DPhysics.PhysicsTargets
                    {
                        id = target["id"].Value<string>(),
                        ptype = target["ptype"].Value<string>(),
                        scale = target["scale"].Value<float>(),
                        weight = target["weight"].Value<float>()
                    };
                    targetList.Add(physicsTargets);
                }
                physics.Targets = targetList.ToArray();

                physicsList.Add(physics);
            }

            return physicsList.ToArray();
        }

        /// <summary>
        /// 轻松导入Pose作为JSON文件。
        /// </summary>
        /// <param name="path">包含Pose配置的JSON文件。</param>
        public static L2DPose LoadPose(string path)
        {
            L2DPose pose = new L2DPose();
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));

            JToken resultFade;
            jsonObject.TryGetValue("fade_in", out resultFade);
            if (resultFade != null)
            {
                pose.FadeTime = resultFade.Value<int>();
            }

            List<List<L2DParts>> groupList = new List<List<L2DParts>>();
            foreach (JObject json in jsonObject["parts_visible"])
            {
                List<L2DParts> partsList = new List<L2DParts>();
                foreach (JObject group in json["group"])
                {
                    List<L2DParts> linkList = new List<L2DParts>();

                    JToken resultLink;
                    group.TryGetValue("link", out resultLink);
                    if (resultLink != null)
                    {
                        foreach (JValue link in group["link"])
                        {
                            linkList.Add(new L2DParts(link.Value<string>()));
                        }
                    }

                    partsList.Add(new L2DParts(group["id"].Value<string>(), linkList.ToArray()));
                }

                groupList.Add(partsList);
            }
            pose.Groups = groupList.ToArray();

            return pose;
        }

        /// <summary>
        /// 轻松将面部表情导入JSON文件。
        /// </summary>
        /// <param name="path">具有面部表情配置的标准JSON文件。</param>
        public static L2DExpression LoadExpression(string path)
        {
            L2DExpression expression = new L2DExpression();

            JObject jsonObject = JObject.Parse(File.ReadAllText(path));
            expression.SetFadeIn(jsonObject["fade_in"].Value<int>());
            expression.SetFadeIn(jsonObject["fade_out"].Value<int>());

            JToken resultParams;
            jsonObject.TryGetValue("params", out resultParams);

            if (resultParams != null)
            {
                foreach (JObject json in resultParams)
                {
                    string paramID = json["id"].Value<string>();
                    float value = json["val"].Value<float>();
                    string calc = "add";
                    float defaultValue = 0;

                    JToken resultCalc;
                    json.TryGetValue("calc", out resultCalc);
                    if (resultCalc != null)
                    {
                        calc = resultCalc.Value<string>();
                    }

                    JToken resultDef;
                    json.TryGetValue("def", out resultDef);
                    if (resultDef != null)
                    {
                        defaultValue = resultDef.Value<float>();
                    }

                    expression.AddParam(paramID, calc, value, defaultValue);
                }
            }

            return expression;
        }
        #endregion
    }
}
