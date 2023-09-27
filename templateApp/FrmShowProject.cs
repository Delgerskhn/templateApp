using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using templateApp.Models;
using templateApp.Shared;
using Newtonsoft.Json.Linq;
using templateApp.ViewModels;
using Dma.DatasourceLoader;

namespace templateApp
{
    public partial class FrmShowProject : Form
    {
        // 
        private readonly List<string> ListLayOut = new List<string>();       //リストレイアウト
        public DataTable DtLayOut = new DataTable();                         //データテーブルレイアウト
        private readonly DataTable DtProject = new DataTable();              //FlexGrid用データテーブル
        GridOrderManager gridManager;

        // 検索用の変数
        private List<Label> labelList;
        private List<TextBox> textBoxList;
        private int currentElementIndex;

        public FrmShowProject()
        {
            InitializeComponent();

            // テーブルの初期設定
            DtProject = InitializeDataTable();
            ConfigureDataGridView(GdProjectList, DtProject);

            // GridOrderManagerのインスタンスを作成
            gridManager = new GridOrderManager("orderSetting.json", ProjectDatumHelpers.ColumnConfigs);

            DtLayOut = DtProject.Copy();

            // 検索欄の初期設定
            labelList = new List<Label> { label1, label2, label3 };
            textBoxList = new List<TextBox> { textBox1, textBox2, textBox3 };
            foreach (var label in labelList)
            {
                label.Visible = false;
            }
            foreach (var textBox in textBoxList)
            {
                textBox.Visible = false;
            }
            currentElementIndex = 0;
        }

        /// <summary>
        /// DataTableを初期化して列を追加する
        /// </summary>
        /// <returns>初期化されたDataTable</returns>
        private DataTable InitializeDataTable()
        {
            DataTable dt = new DataTable();

            foreach (var config in ProjectDatumHelpers.ColumnConfigs)
            {
                dt.Columns.Add(config.Caption, config.DataType);
            }

            return dt;
        }

        /// <summary>
        /// 指定されたFlexGridを設定し、DataTableをデータソースとして設定する
        /// </summary>
        /// <param name="grid">設定対象のFlexGrid</param>
        /// <param name="dt">データソースとして設定するDataTable</param>
        private void ConfigureDataGridView(DataGridView dgv, DataTable dt)
        {
            // ヘッダの設定
            //dgv.Columns[0].HeaderText = "";
            //dgv.Columns[0].Width = 30;

            dgv.DataSource = dt;

            // DataGridViewが自動的にカラムを作成するため、不要なカラムを削除
            while (dgv.Columns.Count > ProjectDatumHelpers.ColumnConfigs.Count + 1)
            {
                dgv.Columns.RemoveAt(dgv.Columns.Count - 1);
            }

            for (int i = 0; i < ProjectDatumHelpers.ColumnConfigs.Count; i++)
            {
                var config = ProjectDatumHelpers.ColumnConfigs[i];

                if (i + 1 < dgv.Columns.Count) // 既存のカラムを使用
                {
                    dgv.Columns[i + 1].HeaderText = config.Caption;
                    dgv.Columns[i + 1].Width = config.Width;
                    dgv.Columns[i + 1].DefaultCellStyle.Alignment = config.TextAlign;
                    dgv.Columns[i + 1].DefaultCellStyle.Font = config.Font;
                }
                else // 新しいカラムを追加する必要がある場合
                {
                    DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                    newColumn.HeaderText = config.Caption;
                    newColumn.Width = config.Width;
                    newColumn.DefaultCellStyle.Alignment = config.TextAlign;
                    newColumn.DefaultCellStyle.Font = config.Font;
                    dgv.Columns.Add(newColumn);
                }
            }
        }


        /// <summary>
        /// 指定されたDataTableにデータを追加する
        /// </summary>
        /// <param name="dt">データを追加するDataTable</param>
        private async Task PopulateDataToDataTable(DataTable dt, List<ProjectDatum> list, bool shouldReset = false)
        {
            if (shouldReset)
            {
                // データテーブルを初期化する
                dt.Clear();
            }

            // テストデータを取得

            /* Currently, we are retrieving and displaying test data as mentioned above.
             * Below is an example of fetching data from the database.
            List<Models.ProjectDatum> list = await State.GetTManagementItemsDataAsync();
            */

            // 一時的にdtをDtProjectに変更する
            foreach (var data in list)
            {
                DataRow newRow = dt.NewRow();

                foreach (var config in ProjectDatumHelpers.ColumnConfigs)
                {
                    // ColumnConfig のマッピングストラテジーを使用してデータを変換する
                    object mappedValue = config.MapData(data);
                    if (mappedValue == null)
                    {
                        if (dt.Columns[config.Caption].DataType == typeof(short))
                        {
                            mappedValue = 0;
                        }
                        else
                        {
                            mappedValue = string.Empty;
                        }
                    }
                    newRow[config.Caption] = mappedValue;
                }

                dt.Rows.Add(newRow);
            }
        }


        /// <summary>
        /// データテーブル更新処理
        /// データテーブルの表示更新をしたい場合に本関数をCallする
        /// 更新ボタンやデータの変更通知を受け取り、更新したい場合に使用することを想定
        /// </summary>
        private async void updateDataTable()
        {
            // 非同期でデータ取得
            List<Models.ProjectDatum> list = TestDataGenerator2nd.CreateSampleProjectData();
            await PopulateDataToDataTable(DtProject, list, true);
            GdProjectList_RowColChange(this, EventArgs.Empty);
            GdProjectList.Refresh();
        }

        /// <summary>
        /// フォームロード（案件一覧画面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmShowProject_Load(object sender, EventArgs e)
        {
            try
            {
                // ログイン完了まで一覧の情報は非表示にする
                GdProjectList.Visible = false;

                // ログイン画面の表示
                onLoginUser();

                // 非同期でデータ取得
                List<Models.ProjectDatum> list = TestDataGenerator2nd.CreateSampleProjectData();
                await PopulateDataToDataTable(DtProject, list);
                GdProjectList_RowColChange(this, EventArgs.Empty);
                GdProjectList.Refresh();

                // 初期設定はラジオボタン1
                RdoShowMode1.Checked = true;

                // コンボボックスの初期設定はパターンA
                SetComboBoxItemsFromPattern("PatternA");

                //GdProjectList.RowColChange += GdProjectList_RowColChange;
                //GdProjectList.AfterDragColumn += GdProjectList_AfterDragColumn;

                // 仮で3行目の色を変更
                //SetRowColor(GdProjectList, 3, Color.SandyBrown);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.BtnSetting.Enabled = true;
            this.BtnClear.Enabled = true;
            this.BtnNew.Enabled = true;
            this.BtnUpdate.Enabled = true;
            this.BtnTabClose.Visible = true;
        }

        /// <summary>
        /// 検索項目追加コンボボックスの項目設定
        /// </summary>
        /// <param name="patternName"></param>
        private void SetComboBoxItemsFromPattern(string patternName)
        {
            // 指定されたパターン名に対して列の順序を取得
            string[] columnOrder = gridManager.GetColumnOrderForPattern(patternName);

            // 既存の項目をクリア
            comboBox1.Items.Clear();

            // ComboBoxに項目をセット
            comboBox1.Items.AddRange(columnOrder);
        }

        /// <summary>
        /// ラジオボタンの設定に応じて一覧を更新する
        /// </summary>
        private void RdoShowMode_CheckedChanged(object sender, EventArgs e)
        {
            // ラジオボタンの選択に応じてパターン名を取得
            string selectedPattern = string.Empty;

            if (RdoShowMode1.Checked)
                selectedPattern = "PatternA";
            else if (RdoShowMode2.Checked)
                selectedPattern = "PatternB";
            else if (RdoShowMode3.Checked)
                selectedPattern = "PatternC";

            // コンボボックスの項目を変更する
            SetComboBoxItemsFromPattern(selectedPattern);

            if (gridManager.DoesPatternExist(selectedPattern))
            {
                // 列の順序と設定を取得
                var columnOrder = gridManager.GetColumnOrderForPattern(selectedPattern);
                var columnSettings = gridManager.GetColumnSettingsForPattern(selectedPattern);

                /*
                // グリッドの列順序を更新
                for (int i = 0; i < columnOrder.Length - 1; i++)
                {
                    var col = GdProjectList.Columns[columnOrder[i]];

                    // 最初の列（行ヘッダ用の列）を移動しないようにする
                    if (col.Index == 0) continue;

                    // 移動先のインデックスも0を避けるようにする
                    int targetIndex = i + 1;

                    // DataGridViewはCols.Moveメソッドを提供していないため、
                    // DisplayIndexプロパティを使用して列の位置を変更する必要があります
                    col.DisplayIndex = targetIndex;
                }
                */

                // グリッドの列設定を更新
                gridManager.ApplyColumnSettingsToGrid(GdProjectList, columnSettings);
            }
            else
            {
                // 仮で以下のメッセージにしたけど、後に修正予定
                MessageBox.Show($"{selectedPattern} パターンは存在しません");
            }
        }


        /// <summary>
        /// ヘッダの行番号を割り振る
        /// </summary>
        private void GdProjectList_RowColChange(object sender, EventArgs e)
        {
            /* C1FlexGridをDataGridViewに置き換えた場合は不要な処理
            // すべての行についてループを実行
            for (int rowIndex = 1; rowIndex < GdProjectList.Rows.Count; rowIndex++)
            {
                GdProjectList[rowIndex, 0] = rowIndex; // 行のインデックスをCols[0]に設定
            }
            */
        }

        /// <summary>
        /// 列をドラッグで入れ替えた際に表示順をJSONファイルに保存する
        /// </summary>
        private void GdProjectList_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            // 現在選択されているパターンを取得
            string selectedPattern = GetSelectedPattern();

            // 現在の列順序を取得
            List<string> currentColumnOrder = new List<string>();
            foreach (DataGridViewColumn col in GdProjectList.Columns)
            {
                currentColumnOrder.Add(col.Name);
            }

            // JSONを更新
            gridManager.UpdateColumnOrderForPattern(selectedPattern, currentColumnOrder.ToArray());

            // 更新されたJSONデータをファイルに保存
            gridManager.SaveToFile();
        }


        // 現在選択されているラジオボタンに応じてパターン名を返す
        private string GetSelectedPattern()
        {
            if (RdoShowMode1.Checked) return "PatternA";
            if (RdoShowMode2.Checked) return "PatternB";
            if (RdoShowMode3.Checked) return "PatternC";
            return string.Empty;
        }

        ///<summary>
        /// ログイン
        ///</summary>
        private void onLoginUser()
        {
            try
            {
                var frmLogin = new FrmLogin();
                // ログインのクローズイベントと接続
                frmLogin.FormClosed += frmLogin_FormClosed;
                frmLogin.Show(this);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // ログインフォームが閉じたときのイベントハンドラ
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            GdProjectList.Visible = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // ラベルとテキストボックスを非表示にし、テキストボックスの内容をクリアする
            foreach (var label in labelList)
            {
                label.Visible = false;
            }

            foreach (var textBox in textBoxList)
            {
                textBox.Visible = false;
                textBox.Text = "";  // ここでテキストボックスの内容をクリア
            }

            // インクリメントをリセット
            currentElementIndex = 0;
        }

        private async void GdProjectList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            string No = "";
            if (GdProjectList.Rows.Count > 1 && GdProjectList.RowSel > 0)
            {
                No = (string)GdProjectList.GetData(GdProjectList.RowSel, 1);
            }
            else
            {
                return;
            }

            if (No != "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    // ここでデータを取得して詳細タブに情報を受け渡す
                    //ProjectDatum data = await State.dataOperation(State.OPEN, No);

                    // 上記のdataでタブに入れたい名称を以下で設定する
                    string StrTabTitle = "詳細タブ名";
                    TabPage tabPage = TabMain.TabPages[StrTabTitle];

                    if (tabPage == null)
                    {
                        StrTabTitle = "詳細タブ名";
                        tabPage = new TabPage(StrTabTitle);
                        tabPage.Name = StrTabTitle;
                        tabPage.Controls.Add(new Views.UCtlProject());

                        TabMain.TabPages.Add(tabPage);
                    }
                    TabMain.SelectedTab = tabPage;
                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                // エラーメッセージ追記予定
            }
            */
        }

        /// <summary>
        /// 設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Click(object sender, EventArgs e)
        {
            /*
            FrmSubSetListCol frmSubSetListCol = new FrmSubSetListCol(this);
            // 設定のクローズイベントと接続
            frmSubSetListCol.FormClosed += frmSubSetListCol_FormClosed;
            frmSubSetListCol.ShowDialog();
            */

            FrmShowProject mainFormInstance = this;
            FrmSubSetListCol frmSubSetListCol = new FrmSubSetListCol(mainFormInstance, gridManager);
            frmSubSetListCol.FormClosed += frmSubSetListCol_FormClosed;
            frmSubSetListCol.ShowDialog();
        }

        // 設定フォームが閉じたときのイベントハンドラ
        private void frmSubSetListCol_FormClosed(object sender, FormClosedEventArgs e)
        {
            RdoShowMode_CheckedChanged(this, EventArgs.Empty);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Combo_Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                ((ComboBox)sender).SelectedIndex = -1;
            }
        }

        /// <summary>
        /// タブを閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTabClose_Click(object sender, EventArgs e)
        {
            int iIndex = this.TabMain.SelectedIndex;
            if (iIndex > 0)
            {
                string sTitle = this.TabMain.TabPages[iIndex].Name;
                if (MessageBox.Show(sTitle + "\n" + "を閉じますか？", "タブを閉じる", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.TabMain.TabPages.RemoveAt(iIndex);
            }
        }

        /// <summary>
        /// ログアウトボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnLogout_Click(object sender, EventArgs e)
        {
            // ログイン画面に戻る処理を追記予定
        }

        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            // ここに新規作成時の処理を記載する
            // 新しいフォームを開いたり、タブで画面を出したり
        }

        /// <summary>
        /// フォームクローズ時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmShowProject_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 項目数を制御する
            if (currentElementIndex >= 3)
                return;

            string selectedItem = comboBox1.SelectedItem.ToString();

            // 選択された項目を現在のラベルにセット
            labelList[currentElementIndex].Text = selectedItem;
            labelList[currentElementIndex].Visible = true;

            // 同じインデックスのテキストボックスも表示
            textBoxList[currentElementIndex].Visible = true;

            // 次のインデックスをインクリメント
            currentElementIndex++;
        }

        /// <summary>
        /// 指定したC1FlexGridの特定の行の背景色を変更
        /// </summary>
        /// <param name="grid">対象となるC1FlexGrid</param>
        /// <param name="rowIndex">色を変更する行の0ベースのインデックス</param>
        /// <param name="color">新しい背景。</param>
        /*
        public static void SetRowColor(C1FlexGrid grid, int rowIndex, Color color)
        {
            if (grid == null)
                return;

            if (rowIndex < 0 || rowIndex >= grid.Rows.Count)
                return;

            // 指定された色でのスタイルを作成
            string styleName = $"RowColor_{color.ToArgb()}";
            CellStyle rowStyle;
            if (!grid.Styles.Contains(styleName))
            {
                rowStyle = grid.Styles.Add(styleName);
                rowStyle.BackColor = color;
            }
            else
            {
                rowStyle = grid.Styles[styleName];
            }

            // スタイルを指定した行の項目に適用
            for (int i = 0; i < grid.Cols.Count; i++)
            {
                grid.SetCellStyle(rowIndex, i, rowStyle);
            }
        }
        */

        /// <summary>
        /// データを更新する
        /// </summary>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            updateDataTable();
            GdProjectList_RowColChange(this, EventArgs.Empty);
            GdProjectList.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ApplyFilter(List<FilterCriteria> filterCriterias)
        {
            var source = TestDataGenerator2nd.CreateSampleProjectData();
            var list = DataSourceLoader.ApplyCombinedFilters(source.AsQueryable(), filterCriterias.Select(f => f.AsFilterOption()).ToList());
            await PopulateDataToDataTable(DtProject, list.ToList(), true);
        }
        private List<FilterCriteria> lastSearchState;
        private void button1_Click(object sender, EventArgs e)
        {
            var searchFrm = new FrmAdvancedSearch(lastSearchState);
            searchFrm.OnSearch += (sender, e) =>
            {
                lastSearchState = null;
                ApplyFilter(searchFrm.FilterCriterias);
            };
            searchFrm.OnSearchAndSave += (sender, e) => {
                lastSearchState = searchFrm.FilterCriterias;
                ApplyFilter(searchFrm.FilterCriterias);
            };

            searchFrm.Show();
        }

       
    }
}
