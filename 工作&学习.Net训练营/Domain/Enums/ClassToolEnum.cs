using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums
{
    /// <summary>
    /// 上课工具
    /// </summary>
    public enum ClassToolEnum
    {
        /// <summary>
        /// 在线课堂
        /// </summary>
        [Description("在线课堂")]
        在线课堂 = 0,

        /// <summary>
        /// QQ
        /// </summary>
        [Description("QQ")]
        Qq = 1,

        /// <summary>
        /// Skype
        /// </summary>
        [Description("Skype")]
        Skype = 2,

        /// <summary>
        /// 好视通
        /// </summary>
        [Description("好视通")]
        FastMeeting = 3,

        /// <summary>
        /// 在线课堂
        /// </summary>
        [Description("微信上课")]
        微信上课 = 4
    }
}
