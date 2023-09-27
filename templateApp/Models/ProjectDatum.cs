using System;
using System.Collections.Generic;

namespace templateApp.Models
{
    /// <summary>
    /// プロジェクトデータ群
    /// </summary>
    public partial class ProjectDatum
    {
        /// <summary>
        /// No
        /// </summary>
        public string no { get; set; } = null!;
        /// <summary>
        /// ID
        /// </summary>
        public int? id { get; set; }
        /// <summary>
        /// 担当者
        /// </summary>
        public string? responsible_person { get; set; }
        /// <summary>
        /// 依頼日
        /// </summary>
        public DateTime? order_date { get; set; }
        /// <summary>
        /// 完了日
        /// </summary>
        public DateTime? complete_expected_date { get; set; }
        /// <summary>
        /// 管理番号
        /// </summary>
        public string? management_number { get; set; }
        /// <summary>
        /// ユーザー名
        /// </summary>
        public string? user_name { get; set; }
        /// <summary>
        /// ユーザー詳細
        /// </summary>
        public string? user_detail { get; set; }
        /// <summary>
        /// 連絡先
        /// </summary>
        public string? contact_address { get; set; }
        /// <summary>
        /// 備考
        /// </summary>
        public string? note { get; set; }
    }
}
