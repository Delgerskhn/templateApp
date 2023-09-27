using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using templateApp.Shared;

namespace templateApp
{
    public partial class FrmSubSetListCol : Form
    {
        private readonly FrmShowProject FrmMain;       // 親フォーム格納
        private readonly DataTable DtLayOutCopy;       // データテーブル
        private readonly GridOrderManager _gridManager;

        public FrmSubSetListCol(FrmShowProject frmMain, GridOrderManager gridManager)
        {
            InitializeComponent();

            FrmMain = frmMain;
            _gridManager = gridManager;
            DtLayOutCopy = FrmMain.DtLayOut.Copy();

            SetupGdColListBasicSettings();
            AddColumnNamesToGdColList();

            GdColList.Refresh();
        }

        /// <summary>
        /// GdColListの基本設定
        /// </summary>
        private void SetupGdColListBasicSettings()
        {
            // 行の入れ替えを許可
            GdColList.AllowUserToOrderColumns = true;

            // ヘッダを設定
            GdColList.Columns.Add("No", "No");
            GdColList.Columns.Add("ItemName", "項目名");

            // チェックボックス用の列を追加
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn
            {
                Name = "Visibility",
                HeaderText = "表示/非表示",
                Width = 90,
                TrueValue = true,
                FalseValue = false
            };
            GdColList.Columns.Add(checkCol);

            // 仮のデータを設定
            foreach (DataColumn col in DtLayOutCopy.Columns)
            {
                GdColList.Rows.Add(new object[] { col.Ordinal + 1, col.ColumnName, true });
            }

            // ヘッダの最初の行の全てのセルの背景色を変更
            GdColList.EnableHeadersVisualStyles = false;
            GdColList.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
        }


        /// <summary>
        /// 列名をGdColListに追加
        /// </summary>
        private void AddColumnNamesToGdColList()
        {
            int rowIndex = 1;

            foreach (DataColumn column in DtLayOutCopy.Columns)
            {
                if (rowIndex < GdColList.Rows.Count)
                {
                    GdColList.Rows[rowIndex].Cells[0].Value = rowIndex.ToString();
                    GdColList.Rows[rowIndex].Cells[1].Value = column.ColumnName;
                }
                rowIndex++;
            }
        }


        /// <summary>
        /// 表示パターン変更時に表示更新を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoShowMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton == null || !radioButton.Checked)
            {
                return;
            }

            string patternName = "";

            if (radioButton == RdoShowMode1)
            {
                patternName = "PatternA";
            }
            else if (radioButton == RdoShowMode2)
            {
                patternName = "PatternB";
            }
            else if (radioButton == RdoShowMode3)
            {
                patternName = "PatternC";
            }

            ApplyPatternToGrid(patternName);
        }

        /// <summary>
        /// パターンに応じた列の項目と表示・非表示の設定
        /// </summary>
        private void ApplyPatternToGrid(string patternName)
        {
            // パターンが存在するかを確認
            if (_gridManager.DoesPatternExist(patternName))
            {
                // 選択されたパターンの列の順序を取得
                string[] columnOrder = _gridManager.GetColumnOrderForPattern(patternName);

                // GdColListの行の順序を再配置
                //ReorderRowsOfGdColList(GdColList, columnOrder);

                // GdColListの列の表示・非表示を設定
                SetColumnVisibility(GdColList, patternName);
            }
            else
            {
                // # NOTE: エラーメッセージを追記予定
            }
        }

        /// <summary>
        /// GdColListの行の順序を再配置する
        /// </summary>
        private void ReorderRowsOfGdColList(DataGridView grid, string[] columnOrder)
        {
            int rowIndex = 1; // ヘッダ行は無視して1から開始

            foreach (string colName in columnOrder)
            {
                for (int i = rowIndex; i < grid.Rows.Count; i++)
                {
                    if (grid.Rows[i].Cells[1].Value?.ToString() == colName)
                    {
                        // DataGridViewには直接的な行の移動メソッドはないため、行のクローンを作成し、
                        // 元の位置の行を削除した後、指定された位置にクローンを挿入する・・・
                        // 予定だったが、時間がかかりそうなので、呼び出し口をコメントアウトした
                        DataGridViewRow rowClone = (DataGridViewRow)grid.Rows[i].Clone();
                        for (int cellIndex = 0; cellIndex < grid.Rows[i].Cells.Count; cellIndex++)
                        {
                            rowClone.Cells[cellIndex].Value = grid.Rows[i].Cells[cellIndex].Value;
                        }

                        grid.Rows.RemoveAt(i);
                        grid.Rows.Insert(rowIndex, rowClone);

                        rowIndex++;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// GdColListの表示・非表示を設定する
        /// </summary>
        private void SetColumnVisibility(DataGridView grid, string patternName)
        {
            int rowIndex = 1; // ヘッダ行は無視して1から開始
            int checkBoxColIndex = 2;

            for (int i = rowIndex; i < grid.Rows.Count; i++)
            {
                string colName = grid.Rows[i].Cells[1].Value?.ToString();
                bool isVisible = _gridManager.GetVisibilityForColumn(patternName, colName);
                grid.Rows[i].Cells[checkBoxColIndex].Value = !isVisible;
            }
        }


        /// <summary>
        /// 設定保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Click(object sender, System.EventArgs e)
        {
            string patternName = GetPatternName();

            if (MessageBox.Show(patternName + "の設定を保存しますか？", "設定保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SavePatternToJSON(GdColList, patternName);
        }

        /// <summary>
        /// 表示パターン取得
        /// </summary>
        /// <returns></returns>
        private string GetPatternName()
        {
            string patternName = "";
            if (this.RdoShowMode1.Checked) { patternName = "PatternA"; }
            if (this.RdoShowMode2.Checked) { patternName = "PatternB"; }
            if (this.RdoShowMode3.Checked) { patternName = "PatternC"; }
            return patternName;
        }

        /// <summary>
        /// JSONファイルに保存
        /// </summary>
        private void SavePatternToJSON(DataGridView grid, string patternName)
        {
            // DataGridViewの現在の行の順序を取得
            List<string> columnOrderList = new List<string>();
            for (int i = 1; i < grid.Rows.Count; i++)
            {
                columnOrderList.Add(grid.Rows[i].Cells[1].Value?.ToString());
            }

            // columnOrderを更新
            _gridManager.UpdateColumnOrderForPattern(patternName, columnOrderList.ToArray());

            // 各列の表示・非表示の情報を取得して更新
            Dictionary<string, bool> visibilityInfo = new Dictionary<string, bool>();
            int checkBoxColIndex = 2;
            for (int i = 1; i < grid.Rows.Count; i++)
            {
                // チェックボックスの状態を取得
                string colName = grid.Rows[i].Cells[1].Value?.ToString();
                bool isVisible = Convert.ToBoolean(grid.Rows[i].Cells[checkBoxColIndex].Value);
                visibilityInfo[colName] = !isVisible;
            }
            _gridManager.UpdateColumnVisibilityForPattern(patternName, visibilityInfo);

            // JSONデータをファイルに保存
            _gridManager.SaveToFile();
        }


        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSubSetListCol_Load(object sender, EventArgs e)
        {
            // 表示モード
            RdoShowMode1.Checked = true;
        }

        /// <summary>
        /// 全選択
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            int checkBoxColIndex = 2;

            foreach (DataGridViewRow row in GdColList.Rows)
            {
                row.Cells[checkBoxColIndex].Value = true;
            }
        }

        /// <summary>
        /// 全解除
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            int checkBoxColIndex = 2;

            foreach (DataGridViewRow row in GdColList.Rows)
            {
                row.Cells[checkBoxColIndex].Value = false;
            }
        }


        /// <summary>
        /// 初期化
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("列の項目を初期化しますか？", "初期化", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // JSONファイルを初期化する
            _gridManager.InitializeJsonFile();

            // チェックボックスの状態を初期化した後に更新
            button2_Click(this, EventArgs.Empty);
            ApplyPatternToGrid("PatternA");
        }
    }
}
