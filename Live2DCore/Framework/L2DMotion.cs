using System;
using System.Runtime.InteropServices;
using L2DLib.Core;

namespace L2DLib.Framework
{
    /// <summary>
    /// 提供与Live2D动作相关的功能。
    /// </summary>
    public class L2DMotion : L2DBase
    {
        #region 属性
        /// <summary>
        /// 获取目的地的路径。
        /// </summary>
        public string Path
        {
            get { return _Path; }
        }
        protected string _Path;

        /// <summary>
        /// 在动画播放期间播放的声音文件。
        /// </summary>
        public L2DSound Sound
        {
            get { return _Sound; }
            set { _Sound = value; }
        }
        private L2DSound _Sound;

        /// <summary>
        /// 获取动作是否会重复播放。
        /// </summary>
        public bool Loop
        {
            get { return _Loop; }
        }
        private bool _Loop = false;

        /// <summary>
        /// 获取动作的淡入淡出时间。
        /// </summary>
        public int FadeIn
        {
            get { return _FadeIn; }
        }
        private int _FadeIn;

        /// <summary>
        /// 获取运动的淡出时间。
        /// </summary>
        public int FadeOut
        {
            get { return _FadeOut; }
        }
        private int _FadeOut;
        #endregion

        #region 构造函数
        /// <summary>
        /// 创建运动目标。
        /// </summary>
        /// <param name="path">动作文件的路径。</param>
        public L2DMotion(string path)
        {
            LoadMotion(path);
        }

        /// <summary>
        /// 创建运动目标。
        /// </summary>
        /// <param name="path">动作文件的路径。</param>
        /// <param name="soundPath">声音文件的路径。</param>
        public L2DMotion(string path, string soundPath)
        {
            LoadMotion(path);
            _Sound = new L2DSound(soundPath);
        }
        #endregion

        #region 内部功能
        private void LoadMotion(string path)
        {
            _Path = path;
            HRESULT.Check(NativeMethods.LoadMotion(Marshal.StringToHGlobalAnsi(path), out _Handle));
            _IsLoaded = true;
        }
        #endregion

        #region 用户功能
        /// <summary>
        /// 开始播放动作。
        /// </summary>
        public void StartMotion()
        {
            HRESULT.Check(NativeMethods.StartMotion(new IntPtr(Handle)));

            if (Sound != null)
            {
                Sound.Play();
            }
        }

        /// <summary>
        /// 设置动作的淡入时间。
        /// </summary>
        /// <param name="msec">动画的时间（以毫秒为单位）。</param>
        public void SetFadeIn(int msec)
        {
            HRESULT.Check(NativeMethods.SetFadeIn(new IntPtr(Handle), msec));
            _FadeIn = msec;
        }

        /// <summary>
        /// 设置动作的淡出时间。
        /// </summary>
        /// <param name="msec">动画的时间（以毫秒为单位）。</param>
        public void SetFadeOut(int msec)
        {
            HRESULT.Check(NativeMethods.SetFadeOut(new IntPtr(Handle), msec));
            _FadeOut = msec;
        }

        /// <summary>
        /// 设置是否重复动作。
        /// </summary>
        /// <param name="loop">是否重复动作。</param>
        public void SetLoop(bool loop)
        {
            HRESULT.Check(NativeMethods.SetLoop(new IntPtr(Handle), loop));
            _Loop = loop;
        }
        #endregion
    }
}
