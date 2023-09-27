using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using templateApp.Models;

namespace templateApp.Shared
{
    public class TestDataGenerator
    {
        // テストデータ
        public static List<ProjectDatum> CreateSampleProjectData()
        {
            return new List<ProjectDatum>
            {
                new ProjectDatum
                {
                    no = "1",
                    id = 1001,
                    responsible_person = "山田太郎",
                    order_date = new DateTime(2023, 1, 10),
                    complete_expected_date = new DateTime(2023, 1, 30),
                    management_number = "MNG001",
                    user_name = "Yamada Taro",
                    user_detail = "テストユーザーの詳細A",
                    contact_address = "yamada@example.com",
                    note = "初めての依頼"
                },
                new ProjectDatum
                {
                    no = "2",
                    id = 1002,
                    responsible_person = "佐藤花子",
                    order_date = new DateTime(2023, 2, 5),
                    complete_expected_date = new DateTime(2023, 2, 25),
                    management_number = "MNG002",
                    user_name = "Sato Hanako",
                    user_detail = "テストユーザーの詳細B",
                    contact_address = "sato@example.com",
                    note = "緊急の依頼"
                },
                new ProjectDatum
                {
                    no = "3",
                    id = 1003,
                    responsible_person = "鈴木一郎",
                    order_date = new DateTime(2023, 3, 1),
                    complete_expected_date = new DateTime(2023, 3, 15),
                    management_number = "MNG003",
                    user_name = "Suzuki Ichiro",
                    user_detail = "テストユーザーの詳細C",
                    contact_address = "suzuki@example.com",
                    note = "通常の依頼"
                },
                new ProjectDatum
                {
                    no = "4",
                    id = 1004,
                    responsible_person = "高橋直也",
                    order_date = new DateTime(2023, 3, 20),
                    complete_expected_date = new DateTime(2023, 4, 5),
                    management_number = "MNG004",
                    user_name = "Takahashi Naoya",
                    user_detail = "テストユーザーの詳細D",
                    contact_address = "takahashi@example.com",
                    note = "締切近しの依頼"
                },
                new ProjectDatum
                {
                    no = "5",
                    id = 1005,
                    responsible_person = "伊藤紀子",
                    order_date = new DateTime(2023, 4, 10),
                    complete_expected_date = new DateTime(2023, 4, 30),
                    management_number = "MNG005",
                    user_name = "Ito Noriko",
                    user_detail = "テストユーザーの詳細E",
                    contact_address = "ito@example.com",
                    note = "再依頼"
                },
                // 必要に応じてさらにデータを追加してテストする
            };
        }
    }
}
