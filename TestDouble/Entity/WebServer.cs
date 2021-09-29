using System;

namespace TestDouble.Entity
{
    public class WebServer
    {
        private Database database;
        int secretNumber;
        public WebServer(Database database)
        {
            this.database = database;
            secretNumber = 42;
        }
        public int getSecretNumber(String username, String password)
        {
            return database.authorize(username, password) ?
                secretNumber : -1;
        }
    }

    public class Database
    {
        public Database()
        {
        }
        public bool authorize(String username, String password)
        {
            // todo
            return true;
        }
    }
}