﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void SetupConfig()
        {
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            } ;
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData() {

                Name = "testuser14",
                Password = "password",
                Email = "testuser14@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }


}
