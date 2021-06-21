﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    class DataAccess
    {
        private static string _connectionString = "Server=localhost;Port=3306;Database=WizardQuest;Uid=wizard;password=55555;";
        private static MySqlConnection _mySqlConnection = null;

        public static string LoginStatus = "";
        public static string RegistrationStatus = "";
        public static string UserID;

        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(_connectionString);
                }

                return _mySqlConnection;
            }
        }

        public static MySqlConnection Conn = new MySqlConnection("Server=localhost;Port=3306;Database=WizardQuest;Uid=wizard;password=55555;");

        public string CheckUserName(string pUserName)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("@UserName", MySqlDbType.VarChar, 30);
            userName.Value = pUserName;
            parameterList.Add(userName);

            var checkUserNameDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "CheckUserName(@UserName)", parameterList.ToArray());
            return (checkUserNameDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public void UserRegistration(string pUserName, string pUserPassword, string pEmail)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            var userPassword = new MySqlParameter("UserPassword", MySqlDbType.VarChar, 20);
            var email = new MySqlParameter("Email", MySqlDbType.VarChar, 50);
            userName.Value = pUserName;
            userPassword.Value = pUserPassword;
            email.Value = pEmail;
            parameterList.Add(userName);
            parameterList.Add(userPassword);
            parameterList.Add(email);

            var userRegistrationDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userRegistration(@UserName, @UserPassword, @Email)", parameterList.ToArray());
            DataAccess.RegistrationStatus = (userRegistrationDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public void GetUserID(string pUserName)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            userName.Value = pUserName;
            parameterList.Add(userName);

            var getUserIDDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getUserID(@UserName)", parameterList.ToArray());
            DataAccess.UserID = (getUserIDDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public void UserLogin(string pUserName, string pUserPassword)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            var userPassword = new MySqlParameter("UserPassword", MySqlDbType.VarChar, 20);
            userName.Value = pUserName;
            userPassword.Value = pUserPassword;
            parameterList.Add(userName);
            parameterList.Add(userPassword);

            var userLoginDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userLogin(@UserName, @UserPassword)", parameterList.ToArray());
            DataAccess.LoginStatus = (userLoginDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public void UserLogout(string pUserName)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            userName.Value = pUserName;
            parameterList.Add(userName);

            var userLogoutDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userLogout(@UserName)", parameterList.ToArray());
            DataAccess.LoginStatus = (userLogoutDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public void UserDelete(string pUserName, string pUserPassword)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            var userPassword = new MySqlParameter("UserPassword", MySqlDbType.VarChar, 20);
            userName.Value = pUserName;
            userPassword.Value = pUserPassword;
            parameterList.Add(userName);
            parameterList.Add(userPassword);

            var userDeleteDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userDelete(@UserName, @UserPassword)", parameterList.ToArray());
            DataAccess.LoginStatus = (userDeleteDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string NewQuest(int pUserID, string pQuestName)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var questName = new MySqlParameter("QuestName", MySqlDbType.VarChar, 50);
            userID.Value = pUserID;
            questName.Value = pQuestName;
            parameterList.Add(userID);
            parameterList.Add(questName);

            var newQuestDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call newQuest(@UserID, @QuestName)", parameterList.ToArray());
            return (newQuestDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string JoinQuest(int pUserID, int pQuestID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var questID = new MySqlParameter("QuestID", MySqlDbType.Int16);
            userID.Value = pUserID;
            questID.Value = pQuestID;
            parameterList.Add(userID);
            parameterList.Add(questID);

            var joinQuestDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call joinQuest(@UserID, @QuestID)", parameterList.ToArray());
            return (joinQuestDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string UserMove(int pSessionID, int pUserID, int pxPosition, int pyPosition)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var sessionID = new MySqlParameter("SessionID", MySqlDbType.Int16);
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var xPosition = new MySqlParameter("xPosition", MySqlDbType.Int16);
            var yPosition = new MySqlParameter("yPosition", MySqlDbType.Int16);
            sessionID.Value = pSessionID;
            userID.Value = pUserID;
            xPosition.Value = pxPosition;
            yPosition.Value = pyPosition;
            parameterList.Add(sessionID);
            parameterList.Add(userID);
            parameterList.Add(xPosition);
            parameterList.Add(yPosition);

            var userMoveDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userMove(@SessionID, @UserID, @xPosition, @yPosition)", parameterList.ToArray());
            return (userMoveDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string UserChat(int pUserID, int pQuestID, string pMessage)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var questID = new MySqlParameter("QuestID", MySqlDbType.Int16);
            var message = new MySqlParameter("Message", MySqlDbType.VarChar, 255);
            userID.Value = pUserID;
            questID.Value = pQuestID;
            message.Value = pMessage;
            parameterList.Add(userID);
            parameterList.Add(questID);
            parameterList.Add(message);

            var userChatDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call userChat(@UserID, @QuestID, @Message)", parameterList.ToArray());
            return (userChatDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string LeaveQuest(int pUserID, int pQuestID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var questID = new MySqlParameter("QuestID", MySqlDbType.Int16);
            userID.Value = pUserID;
            questID.Value = pQuestID;
            parameterList.Add(userID);
            parameterList.Add(questID);

            var leaveQuestDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call leaveQuest(@UserID, @QuestID)", parameterList.ToArray());
            return (leaveQuestDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string AdministratorAdd(string pUserName, string pUserPassword, string pEmail, bool pAdministrator)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            var userPassword = new MySqlParameter("UserPassword", MySqlDbType.VarChar, 20);
            var email = new MySqlParameter("Email", MySqlDbType.VarChar, 50);
            var administrator = new MySqlParameter("Administrator", MySqlDbType.Bit);
            userName.Value = pUserName;
            userPassword.Value = pUserPassword;
            email.Value = pEmail;
            administrator.Value = pAdministrator;
            parameterList.Add(userName);
            parameterList.Add(userPassword);
            parameterList.Add(email);
            parameterList.Add(administrator);

            var administratorAddDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call administratorAdd(@UserName, @UserPassword, @Email, @Administrator)", parameterList.ToArray());
            return (administratorAddDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string AdministratorModify(int pUserID, string pUserName, string pUserPassword, string pEmail, int pLoginAttempts, bool pUserLocked, bool pAdministrator, int pTotalScore)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            var userName = new MySqlParameter("UserName", MySqlDbType.VarChar, 30);
            var userPassword = new MySqlParameter("UserPassword", MySqlDbType.VarChar, 20);
            var email = new MySqlParameter("Email", MySqlDbType.VarChar, 50);
            var logAttempts = new MySqlParameter("LoginAttempts", MySqlDbType.Int16);
            var userLocked = new MySqlParameter("UserLocked", MySqlDbType.Bit);
            var administrator = new MySqlParameter("Administrator", MySqlDbType.Bit);
            var totalScore = new MySqlParameter("TotalScore", MySqlDbType.Int16);
            userID.Value = pUserID;
            userName.Value = pUserName;
            userPassword.Value = pUserPassword;
            email.Value = pEmail;
            logAttempts.Value = pLoginAttempts;
            userLocked.Value = pUserLocked;
            administrator.Value = pAdministrator;
            totalScore.Value = pTotalScore;
            parameterList.Add(userID);
            parameterList.Add(userName);
            parameterList.Add(userPassword);
            parameterList.Add(email);
            parameterList.Add(logAttempts);
            parameterList.Add(userLocked);
            parameterList.Add(administrator);
            parameterList.Add(totalScore);

            var administratorModifyDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call administratorModify(@UserID, @UserName, @UserPassword, @Email, @LoginAttempts, @UserLocked, @Administrator, @TotalScore)", parameterList.ToArray());
            return (administratorModifyDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string AdministratorDelete(int pUserID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var userID = new MySqlParameter("UserID", MySqlDbType.Int16);
            userID.Value = pUserID;
            parameterList.Add(userID);

            var administratorDeleteDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call administratorDelete(@UserID)", parameterList.ToArray());
            return (administratorDeleteDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public string AdministratorKill(int pQuestID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var questID = new MySqlParameter("QuestID", MySqlDbType.Int16);
            questID.Value = pQuestID;
            parameterList.Add(questID);

            var administratorKillDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call administratorKill(@QuestID)", parameterList.ToArray());
            return (administratorKillDataSet.Tables[0].Rows[0])["message"].ToString();
        }

        public List<User> GetAllUsers()
        {
            List<User> users;

            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getAllUsers()");
            users = (from result in dataSet.Tables[0].AsEnumerable()
                     select
                        new User
                        {
                            UserName = result.Field<string>("UserName")
                        }).ToList();
            return users;
        }

        public List<OnlineUser> GetOnlineUsers()
        {
            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "Call getOnlineUsers()");

            List<OnlineUser> onlineUserList = new List<OnlineUser>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                OnlineUser onlineUser = new OnlineUser();
                onlineUser.Username = row.Field<string>("Username");
                onlineUserList.Add(onlineUser);
            }

            return onlineUserList;
        }

        public List<ActiveQuest> GetActiveQuest(int pUserID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();

            var userID = new MySqlParameter("@UserID", MySqlDbType.Int16);
            userID.Value = pUserID;
            parameterList.Add(userID);

            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "Call getActiveQuest(@UserID)", parameterList.ToArray());

            List<ActiveQuest> activeQuestList = new List<ActiveQuest>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ActiveQuest activeQuest = new ActiveQuest();
                activeQuest.QuestName = row.Field<string>("QuestName");
                activeQuestList.Add(activeQuest);
            }

            return activeQuestList;
        }

        public List<UserActiveQuest> GetUserActiveQuest(int pUserID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            List<UserActiveQuest> userActiveQuestList = new List<UserActiveQuest>();

            var userID = new MySqlParameter("@UserID", MySqlDbType.Int16);
            userID.Value = pUserID;
            parameterList.Add(userID);

            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "Call getUserActiveQuest(@UserID)", parameterList.ToArray());

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                UserActiveQuest userActiveQuest = new UserActiveQuest();
                userActiveQuest.QuestName = row.Field<string>("QuestName");
                userActiveQuestList.Add(userActiveQuest);
            }

            return userActiveQuestList;
        }

        public List<Inventory> GetUserInventory(int pSessionID)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            var sessionID = new MySqlParameter("@SessionID", MySqlDbType.Int16);
            sessionID.Value = pSessionID;
            parameterList.Add(sessionID);

            List<Inventory> assets;

            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getUserInventory(@SessionID)", parameterList.ToArray());
            assets = (from result in dataSet.Tables[0].AsEnumerable()
                      select
                         new Inventory
                         {
                             Item = result.Field<string>("Item"),
                             Quantity = result.Field<int>("Quantity")
                         }).ToList();
            return assets;
        }

        public List<User> GetHighScores()
        {
            List<User> users;

            var dataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getHighScores()");
            users = (from result in dataSet.Tables[0].AsEnumerable()
                     select
                        new User
                        {
                            UserName = result.Field<string>("UserName"),
                            TotalScore = result.Field<int>("TotalScore")
                        }).ToList();
            return users;
        }

    }
}
