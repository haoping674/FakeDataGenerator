using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Diagnostics.Tracing;
using static System.TimeZoneInfo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FakeDataGenerator
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=test;Uid=root;Pwd=root;";
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void register_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string name = registerName.Text;
                if (CheckName(name))
                {
                    string recommend_code = recommend.Text;
                    string code = GenerateInvitationCode(new Random());
                    DateTime date = DateTime.Now;
                    int agentFk = GetRecommenderpk(recommend_code);
                    string query = $"INSERT INTO member (username, invitation_code, recommendmember, agent_fk, create_time) " +
                             $"VALUES ('{name}', '{code}', '{recommend_code}', {agentFk}, " +
                             $"'{date.ToString("yyyy-MM-dd HH:mm:ss")}')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("註冊成功!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("註冊失敗!!");
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        private void randomTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                connection.Open();
                string query = "SELECT COUNT(*) FROM member";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
                int total = Convert.ToInt32(countCommand.ExecuteScalar());
                for (int i = 0; i < 2500; i++)
                {
                    int pk = random.Next(1, total + 1);
                    (int transactionType, DateTime transactiondate) = GenerateTransactionDate(random, pk);
                    decimal transactionAmount = (decimal)random.NextDouble() * 10000;
                    string insertQuery = $"INSERT INTO borrow_fee (member_fk, type, borrow_fee, create_time) " +
                             $"VALUES ({pk}, {transactionType}, {transactionAmount}, " +
                             $"'{transactiondate.ToString("yyyy-MM-dd HH:mm:ss")}')";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("隨機產生交易成功!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("隨機產生交易失敗!!");
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        private void randomUser_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                Random random = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    string code = GenerateInvitationCode(random);
                    DateTime date = GenerateRegistrationDate(random);
                    string name = $"User_{i + 1}";
                    string query = $"INSERT INTO member (username, invitation_code, recommendmember, create_time) " +
                                $"VALUES ('{name}', '{code}', NULL, '{date.ToString("yyyy-MM-dd HH:mm:ss")}')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("隨機產生用戶成功!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("隨機產生用戶失敗!!");
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        private void randomRecommender_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT invitation_code FROM member ORDER BY RAND() LIMIT 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    recommend.Text = reader.GetString(0);
                }
                reader.Close();
                MessageBox.Show("隨機產生推薦人成功!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("隨機產生推薦人失敗!!");
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = $"SELECT pk, agent_fk, invitation_code FROM member WHERE username = '{loginName.Text}'";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                string code = "";
                string recommender = "None";
                int agentFk = 0;
                int pk = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    pk = reader.GetInt32(0);
                    agentFk = reader.GetInt32(1);
                    code = reader.GetString(2);
                }
                reader.Close();

                if (agentFk != 0)
                {
                    query = $"SELECT username FROM member WHERE pk = {agentFk}";
                    command = new MySqlCommand(query, connection);
                    recommender = command.ExecuteScalar().ToString();
                }
                DisplayRecord(pk);
                recommenderLabel.Text = "Your recommender : " + recommender;
                codeLabel.Text = "Your invitation code : " + code;
                MessageBox.Show("登入成功!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("登入失敗!!");
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        private string GenerateInvitationCode(Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private DateTime GenerateRegistrationDate(Random random)
        {
            DateTime start = new DateTime(2023, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private (int, DateTime) GenerateTransactionDate(Random random, int member_pk)
        {
            int type = 1;
            DateTime start = GetRegistrationDate(member_pk);
            string query = $"SELECT MIN(create_time) FROM borrow_fee WHERE member_fk = {member_pk}";
            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                start = Convert.ToDateTime(result);
                type = 2;
            }
            int range = (DateTime.Today - start).Days;
            return (type, start.AddDays(random.Next(range)));
        }

        private int GetRecommenderpk(string code)
        {
            string query = $"SELECT pk FROM member WHERE invitation_code = '{code}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private DateTime GetRegistrationDate(int pk)
        {
            string query = $"SELECT create_time FROM member WHERE pk = {pk}";
            MySqlCommand command = new MySqlCommand(query, connection);
            return Convert.ToDateTime(command.ExecuteScalar());
        }

        private bool CheckName(string name)
        {
            string query = $"SELECT COUNT(*) FROM member WHERE username = '{name}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            return Convert.ToInt32(command.ExecuteScalar()) == 0;
        }

        private void DisplayRecord(int member_pk)
        {
            string query = $"SELECT borrow_fee.borrow_fee, borrow_fee.create_time, borrow_fee.type FROM borrow_fee " +
                           $"INNER JOIN member ON borrow_fee.member_fk = member.pk " +
                           $"WHERE member.pk = '{member_pk}'" + 
                           $"ORDER BY borrow_fee.create_time DESC, borrow_fee.pk DESC"; ;
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            transactionRecord.Items.Clear();
            while (reader.Read())
            {
                decimal borrowFee = reader.GetDecimal(0);
                DateTime createTime = reader.GetDateTime(1);
                int type = reader.GetInt32(2);
                transactionRecord.Items.Add($"Borrow Fee: {borrowFee}, Date: {createTime}, Type: {type}");
            }
            reader.Close();
        }
    }
}
