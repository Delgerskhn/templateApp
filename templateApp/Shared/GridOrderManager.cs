using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace templateApp.Shared
{
    /// <summary>
    /// グリッド情報を管理するクラス
    /// JSONを参照してグリッドの項目順、表示非表示、幅を取得できる
    /// JSONにキーを増やす場合、本クラスにAPIを追加して参照することを想定
    /// </summary>
    public class GridOrderManager
    {
        private readonly string _jsonFilePath;
        private readonly List<ColumnMappingConfig> _initialColumnConfigs;
        private JObject _jsonData;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="jsonFileName">JSONファイルの名前</param>
        /// <param name="initialColumnConfigs">初期の列設定</param>
        public GridOrderManager(string jsonFileName, List<ColumnMappingConfig> initialColumnConfigs = null)
        {
            _jsonFilePath = Path.Combine(Application.LocalUserAppDataPath, jsonFileName);
            _initialColumnConfigs = initialColumnConfigs;

            if (File.Exists(_jsonFilePath))
            {
                _jsonData = JObject.Parse(File.ReadAllText(_jsonFilePath));
            }
            else
            {
                if (initialColumnConfigs != null)
                {
                    _jsonData = GenerateNewJsonData(initialColumnConfigs);
                    SaveToFile();
                }
                else
                {
                    throw new Exception(jsonFileName + "ファイルがありません");
                }
            }
        }

        /// <summary>
        /// 指定されたパターン名が存在するかどうかを判定する
        /// </summary>
        /// <param name="patternName">チェックするパターン名</param>
        /// <returns>存在する場合はtrue、そうでない場合はfalse</returns>
        public bool DoesPatternExist(string patternName)
        {
            // ファイルが存在しない場合はfalseを返す
            if (!File.Exists(_jsonFilePath))
            {
                return false;
            }

            var jsonText = File.ReadAllText(_jsonFilePath);
            var jsonObject = JObject.Parse(jsonText);
            return jsonObject["patterns"][patternName] != null;
        }

        /// <summary>
        /// 指定されたパターンに基づいて列の順序を取得
        /// </summary>
        /// <param name="patternName">列の順序を取得するパターン名</param>
        /// <returns>列の順序</returns>
        public string[] GetColumnOrderForPattern(string patternName)
        {
            if (!DoesPatternExist(patternName))
            {
                throw new InvalidOperationException($"JSONファイルに'{patternName}'というパターンは存在しません。");
            }

            var jsonText = File.ReadAllText(_jsonFilePath);
            var jsonObject = JObject.Parse(jsonText);
            var pattern = jsonObject["patterns"][patternName];
            return pattern["columnOrder"].ToObject<string[]>();
        }

        /// <summary>
        /// 指定されたパターンに基づいて列の設定を取得
        /// </summary>
        /// <param name="patternName">列の設定を取得するパターン名</param>
        /// <returns>列の設定のリスト</returns>
        public List<ColumnSetting> GetColumnSettingsForPattern(string patternName)
        {
            if (!DoesPatternExist(patternName))
            {
                throw new InvalidOperationException($"JSONファイルに'{patternName}'というパターンは存在しません。");
            }

            var jsonText = File.ReadAllText(_jsonFilePath);
            var jsonObject = JObject.Parse(jsonText);
            var pattern = jsonObject["patterns"][patternName];
            return pattern["columnSettings"].ToObject<List<ColumnSetting>>();
        }

        /// <summary>
        /// 表示・非表示状態の取得
        /// </summary>
        public bool GetVisibilityForColumn(string patternName, string columnName)
        {
            // クラス内でJSONデータ全体を保持する変数
            JObject patternsData = (JObject)_jsonData["patterns"];

            if (patternsData == null)
            {
                // デフォルトはtrueを返す
                return true;
            }

            JObject patternData = (JObject)patternsData[patternName];
            if (patternData == null)
            {
                // デフォルトはtrueを返す
                return true;
            }

            JArray columnSettings = (JArray)patternData["columnSettings"];
            foreach (JObject setting in columnSettings)
            {
                if (setting["columnName"].ToString() == columnName)
                {
                    return (bool)setting["visible"];
                }
            }

            return true;
        }

        /// <summary>
        /// 指定された設定に基づいてグリッドの列設定を適用
        /// </summary>
        /// <param name="grid">列設定を適用するグリッド</param>
        /// <param name="settings">列設定のリスト</param>
        public void ApplyColumnSettingsToGrid(DataGridView dgv, List<ColumnSetting> settings)
        {
            foreach (var setting in settings)
            {
                // DataGridViewでは列を名前で直接取得できる
                if (dgv.Columns.Contains(setting.ColumnName))
                {
                    var col = dgv.Columns[setting.ColumnName];
                    col.Width = setting.Width;
                    col.Visible = setting.Visible;
                }
            }
        }

        /// <summary>
        /// 指定された順序に基づいてDataTableの列を並べ替え
        /// </summary>
        /// <param name="dt">並べ替えるDataTable</param>
        /// <param name="columnOrder">新しい列の順序</param>
        /// <returns>並べ替え後のDataTable</returns>
        public DataTable ReorderColumns(DataTable dt, string[] columnOrder)
        {
            DataTable reorderedTable = dt.Clone();
            foreach (string columnName in columnOrder)
            {
                foreach (DataRow row in dt.Rows)
                {
                    reorderedTable.ImportRow(row);
                }
            }
            return reorderedTable;
        }

        /// <summary>
        /// 指定されたパターンのcolumnOrderを更新する
        /// </summary>
        /// <param name="patternName">更新対象のパターン名</param>
        /// <param name="newOrder">新しいcolumnOrderの配列</param>
        public void UpdateColumnOrderForPattern(string patternName, string[] newOrder)
        {
            if (_jsonData.ContainsKey("patterns") && _jsonData["patterns"].HasValues)
            {
                var patterns = _jsonData["patterns"] as JObject;
                if (patterns.ContainsKey(patternName))
                {
                    var pattern = patterns[patternName] as JObject;
                    if (pattern.ContainsKey("columnOrder"))
                    {
                        pattern["columnOrder"] = JArray.FromObject(newOrder);
                    }
                    else
                    {
                        pattern.Add("columnOrder", JArray.FromObject(newOrder));
                    }
                }
                else
                {
                    var newPattern = new JObject
                    {
                        ["columnOrder"] = JArray.FromObject(newOrder)
                    };
                    patterns.Add(patternName, newPattern);
                }
            }
        }

        /// <summary>
        /// 指定されたパターンのcolumnSettingsの表示・非表示情報を更新する
        /// </summary>
        /// <param name="patternName">更新対象のパターン名</param>
        /// <param name="visibilityInfo">表示・非表示情報の辞書</param>
        public void UpdateColumnVisibilityForPattern(string patternName, Dictionary<string, bool> visibilityInfo)
        {
            if (_jsonData.ContainsKey("patterns") && _jsonData["patterns"].HasValues)
            {
                var patterns = _jsonData["patterns"] as JObject;
                if (patterns.ContainsKey(patternName))
                {
                    var pattern = patterns[patternName] as JObject;
                    if (pattern.ContainsKey("columnSettings"))
                    {
                        var columnSettings = pattern["columnSettings"] as JArray;
                        foreach (var item in columnSettings)
                        {
                            var columnName = item["columnName"].ToString();
                            if (visibilityInfo.ContainsKey(columnName))
                            {
                                item["visible"] = visibilityInfo[columnName];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ColumnMappingConfigのリストからUserConfigオブジェクトを生成する
        /// </summary>
        /// <param name="columnConfigs">ColumnMappingConfigのリスト</param>
        /// <returns>生成されたUserConfigオブジェクト</returns>
        public UserConfig ConvertToUserConfig(List<ColumnMappingConfig> columnConfigs)
        {
            var columnSettings = columnConfigs.Select(c => new ColumnSetting
            {
                ColumnName = c.Caption,
                Width = c.Width,
                Visible = true // 生成時はTRUE
            }).ToList();

            var columnOrder = columnConfigs.Select(c => c.Caption).ToList();

            var patternConfig = new PatternConfig
            {
                ColumnOrder = columnOrder,
                ColumnSettings = columnSettings
            };

            var patterns = new Dictionary<string, PatternConfig>
            {
                { "PatternA", patternConfig },
                { "PatternB", patternConfig },
                { "PatternC", patternConfig }
            };

            return new UserConfig
            {
                // 現状は固定で返却する
                // 将来的にユーザーID毎に保存する内容を変更する場合に使用する想定
                UserId = "12345",
                Version = "1.0",
                Patterns = patterns
            };
        }

        /// <summary>
        /// ColumnMappingConfigのリストを基に新しいJSONデータを生成する
        /// </summary>
        /// <param name="columnConfigs">ColumnMappingConfigのリスト</param>
        /// <returns>生成されたJObjectオブジェクト</returns>
        private JObject GenerateNewJsonData(List<ColumnMappingConfig> columnConfigs)
        {
            var patterns = new JObject();
            var patternNames = new[] { "PatternA", "PatternB", "PatternC" };

            foreach (var patternName in patternNames)
            {
                var columnOrder = new JArray(columnConfigs.Select(config => config.Caption));
                var columnSettings = new JArray(columnConfigs.Select(config => new JObject
                {
                    ["columnName"] = config.Caption,
                    ["width"] = config.Width,
                    ["visible"] = true
                }));

                patterns[patternName] = new JObject
                {
                    ["columnOrder"] = columnOrder,
                    ["columnSettings"] = columnSettings
                };
            }

            return new JObject
            {
                // 現状はuserIdとversionは固定値にしている
                // 将来的に複数のJSONを読み込みたい場合にこの情報を用いることを想定
                ["userId"] = "00001", 
                ["version"] = "1.0",
                ["patterns"] = patterns
            };
        }

        /// <summary>
        /// 現在のJSONデータをファイルに保存する
        /// </summary>
        public void SaveToFile()
        {
            File.WriteAllText(_jsonFilePath, _jsonData.ToString());
        }

        /// <summary>
        /// JSONファイルを初期化する
        /// </summary>
        public void InitializeJsonFile()
        {
            _jsonData = GenerateNewJsonData(_initialColumnConfigs);
            SaveToFile();
        }
    }

    /// <summary>
    /// 列の設定を格納するためのクラス
    /// </summary>
    public class ColumnSetting
    {
        public string ColumnName { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
    }

    public class UserConfig
    {
        public string UserId { get; set; }
        public string Version { get; set; }
        public Dictionary<string, PatternConfig> Patterns { get; set; }
    }

    public class PatternConfig
    {
        public List<string> ColumnOrder { get; set; }
        public List<ColumnSetting> ColumnSettings { get; set; }
    }
}
