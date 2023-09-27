using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using templateApp.Models;

namespace templateApp.Shared
{
    public class TestDataGenerator2nd
    {
        // テストデータ
        public static List<ProjectDatum> CreateSampleProjectData()
        {
            return new List<ProjectDatum>
            {
                new ProjectDatum
                {
                    no = "1",
                    id = 2001,
                    responsible_person = "田中勇気",
                    order_date = new DateTime(2023, 6, 10),
                    complete_expected_date = new DateTime(2023, 6, 30),
                    management_number = "MNG101",
                    user_name = "Tanaka Yuuki",
                    user_detail = "修正テストユーザーの詳細A",
                    contact_address = "tanaka@example.com",
                    note = "修正の依頼"
                },
                new ProjectDatum
                {
                    no = "2",
                    id = 2002,
                    responsible_person = "小林真理子",
                    order_date = new DateTime(2023, 7, 5),
                    complete_expected_date = new DateTime(2023, 7, 25),
                    management_number = "MNG102",
                    user_name = "Kobayashi Mariko",
                    user_detail = "修正テストユーザーの詳細B",
                    contact_address = "kobayashi@example.com",
                    note = "緊急の修正依頼"
                },
                new ProjectDatum
                {
                    no = "3",
                    id = 2003,
                    responsible_person = "渡辺直樹",
                    order_date = new DateTime(2023, 8, 1),
                    complete_expected_date = new DateTime(2023, 8, 15),
                    management_number = "MNG103",
                    user_name = "Watanabe Naoki",
                    user_detail = "修正テストユーザーの詳細C",
                    contact_address = "watanabe@example.com",
                    note = "通常の修正依頼"
                },
                new ProjectDatum
                {
                    no = "4",
                    id = 2004,
                    responsible_person = "斉藤理香",
                    order_date = new DateTime(2023, 9, 1),
                    complete_expected_date = new DateTime(2023, 9, 20),
                    management_number = "MNG104",
                    user_name = "Saito Rika",
                    user_detail = "修正テストユーザーの詳細D",
                    contact_address = "saito@example.com",
                    note = "再確認の依頼"
                },
                new ProjectDatum
                {
                    no = "5",
                    id = 2005,
                    responsible_person = "原田明",
                    order_date = new DateTime(2023, 10, 5),
                    complete_expected_date = new DateTime(2023, 10, 25),
                    management_number = "MNG105",
                    user_name = "Harada Akira",
                    user_detail = "修正テストユーザーの詳細E",
                    contact_address = "harada@example.com",
                    note = "最終修正の依頼"
                },
                new ProjectDatum
                {
                    no = "6",
                    id = 1006,
                    responsible_person = "中村悠太",
                    order_date = new DateTime(2023, 5, 1),
                    complete_expected_date = new DateTime(2023, 5, 15),
                    management_number = "MNG006",
                    user_name = "Nakamura Yuta",
                    user_detail = "テストユーザーの詳細F",
                    contact_address = "nakamura@example.com",
                    note = "初回テストデータ"
                },
                new ProjectDatum
                {
                    no = "7",
                    id = 1007,
                    responsible_person = "木村千春",
                    order_date = new DateTime(2023, 6, 1),
                    complete_expected_date = new DateTime(2023, 6, 20),
                    management_number = "MNG007",
                    user_name = "Kimura Chihiro",
                    user_detail = "テストユーザーの詳細G",
                    contact_address = "kimura@example.com",
                    note = "中間テストデータ"
                },
                new ProjectDatum
                {
                    no = "8",
                    id = 1008,
                    responsible_person = "後藤真央",
                    order_date = new DateTime(2023, 7, 1),
                    complete_expected_date = new DateTime(2023, 7, 15),
                    management_number = "MNG008",
                    user_name = "Goto Mao",
                    user_detail = "テストユーザーの詳細H",
                    contact_address = "goto@example.com",
                    note = "フィードバック待ち"
                },
                new ProjectDatum
                {
                    no = "9",
                    id = 1009,
                    responsible_person = "福田明日香",
                    order_date = new DateTime(2023, 8, 1),
                    complete_expected_date = new DateTime(2023, 8, 25),
                    management_number = "MNG009",
                    user_name = "Fukuda Asuka",
                    user_detail = "テストユーザーの詳細I",
                    contact_address = "fukuda@example.com",
                    note = "確認中の依頼"
                },
                new ProjectDatum
                {
                    no = "10",
                    id = 1010,
                    responsible_person = "吉田真琴",
                    order_date = new DateTime(2023, 9, 1),
                    complete_expected_date = new DateTime(2023, 9, 20),
                    management_number = "MNG010",
                    user_name = "Yoshida Makoto",
                    user_detail = "テストユーザーの詳細J",
                    contact_address = "yoshida@example.com",
                    note = "最終確認"
                },
                // 必要に応じてさらにデータを追加してテストする
            };
        }
    }
}
