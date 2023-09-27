using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using templateApp.Shared;
using static System.Windows.Forms.AxHost;

namespace templateApp
{
    /// <summary>
    /// ログインフォームの処理を実装したクラス
    /// </summary>
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// FrmLoginの新しいインスタンスを初期化する
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームがロードされる際の処理
        /// フォームの位置を親フォームの中央に配置し、エラーメッセージを初期化する
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // フォームの位置を親フォームの中央に配置する
            this.Location = new Point(
                this.Owner.Location.X + (this.Owner.Width - this.Width) / 2,
                this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2);

            // エラーメッセージを表示するラベルを初期化（空に設定）
            labelMsg.Text = String.Empty;
        }

        /// <summary>
        /// ユーザーIDのテキストボックスの内容が変わったときの処理
        /// ログインボタンの有効/無効を切り替える
        /// </summary>
        private void tbLoginId_TextChanged(object sender, EventArgs e)
        {
            // ユーザーIDとパスワードが入力されていればログインボタンを有効化、そうでなければ無効化
            btnLogin.Enabled = tbLoginId.Text.Length > 0 && tbPassword.Text.Length > 0;
        }

        /// <summary>
        /// フォームがアクティブになったときの処理
        /// ユーザーIDのテキストボックスにフォーカスを移動する
        /// </summary>
        private void FrmLogin_Activated(object sender, EventArgs e)
        {
            // ユーザーIDのテキストボックスにフォーカスを設定する
            tbLoginId.Focus();
        }

        /// <summary>
        /// ログインボタンがクリックされたときの処理
        /// ログイン処理およびエラーハンドリングを行う
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // ウェイトカーソルを表示
                Application.UseWaitCursor = true;

                /* 以下でデータベースのユーザーとパスワードを照会する
                // 非同期でログインAPIを呼び出す
                var resp = await Comm.Post(Constants.API["login"], new { LoginId = tbLoginId.Text, Password = tbPassword.Text });

                // ログインに成功した場合、ユーザー情報を保存
               /State.setLoginUser(resp.ToObject<Models.MWpTantou>());
                */

                // ログインフォームを閉じる
                this.Close();

                // ウェイトカーソルを非表示
                Application.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                // ウェイトカーソルを非表示
                Application.UseWaitCursor = false;

               // エラーメッセージを表示
               labelMsg.Text = ex.Message;
            }
        }
    }
}
