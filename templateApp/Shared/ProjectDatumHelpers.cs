using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using templateApp.Models;

namespace templateApp.Shared
{
    public static class ProjectDatumHelpers
    {

        /// <summary>
        /// データマッピングを設定
        /// 表示したいデータは本個所で設定する
        /// 列名 | 幅 | データの型 | 文字位置 | フォント | 設定するデータ
        /// ラムダ式を使用して設定→ラムダ式：簡潔な関数（メソッド）の表現方法
        /// 例：data => ((ProjectDatum)data).noはdataオブジェクトを受け取り、ProjectDatumにキャストしてnoプロパティの値を返す動作となる
        /// </summary>
        public static readonly List<ColumnMappingConfig> ColumnConfigs = new List<ColumnMappingConfig>
        {
            new ColumnMappingConfig("項目A",
                                    80,
                                    typeof(string),
                                    DataGridViewContentAlignment.MiddleCenter,
                                    new Font("Arial", 12),
                                    new LambdaMappingStrategy(data => ((ProjectDatum)data).no), "no"),

            new ColumnMappingConfig("項目B", 80, typeof(int), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).id), "id"),

            new ColumnMappingConfig("項目C", 100, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).responsible_person), "responsible_person"),

            new ColumnMappingConfig("項目D", 100, typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).order_date), "order_date"),

            new ColumnMappingConfig("項目E", 100, typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).complete_expected_date), "complete_expected_date"),

            new ColumnMappingConfig("項目F", 100, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).management_number), "management_number"),

            new ColumnMappingConfig("項目G", 120, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).user_name), "user_name"),

            new ColumnMappingConfig("項目H", 200, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).user_detail), "user_detail"),

            new ColumnMappingConfig("項目I", 200, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).contact_address), "contact_address"),

            new ColumnMappingConfig("項目J", 160, typeof(string), DataGridViewContentAlignment.MiddleCenter, new Font("Arial", 12),
                new LambdaMappingStrategy(data => ((ProjectDatum)data).note), "note")
        };
    }
}