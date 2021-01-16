using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using cashDispenserLibrary.Data;

namespace cashDispenserLibrary.Model
{
    public class MockBasicUsersRepository
    {
        public PlatformType _PlatformType { get; private set; }


        public MockBasicUsersRepository(PlatformType platformType) =>
            _PlatformType = platformType;

        public IEnumerable<BasicUser> GetAll()
        {
            char slashSplit = (_PlatformType == PlatformType.Unix) ? '/' : '\\';
            List<BasicUser> basicUsers = new List<BasicUser>();


            //Get data from cash dispenser database
            using (var sr = new StreamReader(
                "cashDispenserDatabase" + slashSplit + "BasicUsers.txt"))
            {
                // TODO implement
                //Get all basic users
                while (sr.Peek() >= 0)
                {
                    var basicUserRecord = sr.ReadLine().Split(';');

                    var pin = new PinVAL(basicUserRecord[0]);
                    var name = new NameVAL(basicUserRecord[1]);
                    var surname = new SurnameVAL(basicUserRecord[2]);
                    
                    // TODO finish implement
                    // var basicUser = new BasicUser(pin: pin, name: name, surname: surname);
                }
            }

            throw new Exception();
        }
    }
}