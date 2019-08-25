﻿using System;
using L2DLib.Core;
using L2DLib.Utility;
using System.Runtime.InteropServices;

namespace L2DLib.Framework
{
    public class L2DPhysics : L2DBase
    {
        #region 属性
        /// <summary>
        /// 设置或获取设置。
        /// </summary>
        public PhysicsSetup Setup
        {
            get { return _Setup; }
            set
            {
                _Setup = value;
                UpdateSetup();
            }
        }
        private PhysicsSetup _Setup;

        /// <summary>
        /// 设置或获取源数组。
        /// </summary>
        public PhysicsSource[] Sources
        {
            get { return _Sources; }
            set
            {
                _Sources = value;
                UpdateSources();
            }
        }
        private PhysicsSource[] _Sources;

        /// <summary>
        /// 设置或获取目标数组。
        /// </summary>
        public PhysicsTargets[] Targets
        {
            get { return _Targets; }
            set
            {
                _Targets = value;
                UpdateTargets();
            }
        }
        private PhysicsTargets[] _Targets;
        #endregion

        #region 对象
        long startTimeMSec = 0;
        #endregion

        #region 结构
        public struct PhysicsSetup
        {
            public float length;
            public float regist;
            public float mass;
        }

        public struct PhysicsSource
        {
            public string id;
            public string ptype;
            public float scale;
            public float weight;
        }

        public struct PhysicsTargets
        {
            public string id;
            public string ptype;
            public float scale;
            public float weight;
        }
        #endregion

        #region 构造函数
        public L2DPhysics()
        {
            HRESULT.Check(NativeMethods.CreatePhysics(out _Handle));
            startTimeMSec = L2DUtility.GetUserTimeMSec();
            _IsLoaded = true;
        }
        #endregion

        #region 内部功能
        private void UpdateSetup()
        {
            HRESULT.Check(NativeMethods.PhysicsSetup(new IntPtr(Handle), Setup.length, Setup.regist, Setup.mass));
        }

        private void UpdateSources()
        {
            foreach (PhysicsSource source in Sources)
            {
                HRESULT.Check(NativeMethods.PhysicsAddSrcParam(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(source.ptype), Marshal.StringToHGlobalAnsi(source.id), source.scale, source.weight));
            }
        }

        private void UpdateTargets()
        {
            foreach (PhysicsTargets target in Targets)
            {
                HRESULT.Check(NativeMethods.PhysicsAddTargetParam(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(target.ptype), Marshal.StringToHGlobalAnsi(target.id), target.scale, target.weight));
            }
        }
        #endregion

        #region 用户功能
        public void UpdateParam(L2DModel model)
        {
            HRESULT.Check(NativeMethods.PhysicsUpdate(new IntPtr(Handle), new IntPtr(model.Handle), L2DUtility.GetUserTimeMSec() - startTimeMSec));
        }
        #endregion
    }
}
