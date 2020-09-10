using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Model
{
    /// <summary>
    /// 课程工具模型
    /// </summary>
    public class ClassToolModel
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 上课工具列表
        /// </summary>
        public List<ClassToolDataLists> ClassToolDataList { get; set; }
    }

    public class ClassToolDataLists
    {
        public ClassToolEnum? ClassTool { get; set; }

        public string ClassToolDescription => ClassTool.GetValueOrDefault().ToString();
    }
}
