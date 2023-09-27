using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using templateApp.Models;
using System.Windows.Forms;

namespace templateApp.Shared
{
    /// <summary>
    /// データマッピングインターフェース
    /// 本クラスで項目とデータをマッピングする
    /// 項目：表示する列項目等
    /// データ：データベースから取得したデータ等
    /// </summary>
    public interface IDataMappingStrategy
    {
        /// <summary>
        /// データをマッピング
        /// </summary>
        /// <param name="data">マッピングするデータ</param>
        /// <returns>マッピング後のデータ</returns>
        object Map(object data);
    }

    /// <summary>
    /// ラムダ式を使用してデータマッピングを行う
    /// </summary>
    public class LambdaMappingStrategy : IDataMappingStrategy
    {
        private readonly Func<object, object> _mappingFunc;

        /// <summary>
        /// ラムダ式を引数として受け取る
        /// </summary>
        /// <param name="mappingFunc">データマッピング用のラムダ式</param>
        public LambdaMappingStrategy(Func<object, object> mappingFunc)
        {
            _mappingFunc = mappingFunc;
        }

        /// <summary>
        /// ラムダ式を利用してデータをマッピング
        /// </summary>
        public object Map(object data)
        {
            return _mappingFunc(data);
        }
    }

    /// <summary>
    /// グリッドの列の設定を保持するクラス
    /// </summary>
    public class ColumnMappingConfig
    {
        public string Caption { get; }
        public int Width { get; }
        public Type DataType { get; }
        public DataGridViewContentAlignment TextAlign { get; }
        public Font Font { get; }
        public IDataMappingStrategy DataMappingStrategy { get; }
        public string FieldName { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ColumnMappingConfig(string caption,
                                   int width,
                                   Type dataType,
                                   DataGridViewContentAlignment textAlign,
                                   Font font,
                                   IDataMappingStrategy dataMappingStrategy,
                                   string fieldName)
        {
            Caption = caption;
            Width = width;
            DataType = dataType;
            TextAlign = textAlign;
            Font = font;
            DataMappingStrategy = dataMappingStrategy;
            FieldName = fieldName;
        }

        /// <summary>
        /// データマッピング
        /// </summary>
        public object MapData(object data)
        {
            return DataMappingStrategy.Map(data);
        }
    }
}
