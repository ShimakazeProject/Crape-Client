﻿using System;
using System.Windows.Media;

namespace L2DLib.Framework
{
    public class L2DSound
    {
        #region 属性
        /// <summary>
        /// 获取目的地的路径。
        /// </summary>
        public string Path
        {
            get { return _Path; }
        }
        private string _Path;
        #endregion

        #region 对象
        MediaPlayer player = new MediaPlayer();
        #endregion

        #region 构造函数
        public L2DSound(string path)
        {
            _Path = path;
            player.Open(new Uri(path, UriKind.RelativeOrAbsolute));
            player.MediaEnded += Player_MediaEnded;
            player.MediaFailed += Player_MediaFailed;
        }
        #endregion

        #region 用户功能
        public void Play()
        {
            player.Play();
        }
        #endregion

        #region 玩家活动
        private void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void Player_MediaFailed(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine(e.ErrorException.Message);
        }
        #endregion
    }
}
