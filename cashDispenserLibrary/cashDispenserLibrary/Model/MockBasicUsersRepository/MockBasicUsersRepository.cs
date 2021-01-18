using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using cashDispenserLibrary.Data;

namespace cashDispenserLibrary.Model
{
    //TODO implement basic users with bank account information
    public class MockBasicUsersRepository
    {
        public PlatformType _PlatformType { get; private set; }


        public MockBasicUsersRepository(PlatformType platformType) =>
            _PlatformType = platformType;

        public IEnumerable<BasicUser> GetAll()
        {
            var responseBasicUser = new List<BasicUser>();
            var basicUsersData = new List<string[]>();


            //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\PhysicalMoney.txt"
                    : "cashDispenserDatabase/PhysicalMoney.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }
            }

            //Fill response collection
            // responseBasicUser =
            //     (List<BasicUser>) basicUsersData.Select<string[], BasicUser>(
            //         (string[] basicUserData) =>
            //         {
            //             // TODO check indetifier mechanism
            //             // return new BasicUser(
            //             //     pin: new PinVAL(value: basicUserData[0]),
            //             //     name: new NameVAL(value: basicUserData[1]),
            //             //     surname: new SurnameVAL(value: basicUserData[2]));
            //         });

            throw new Exception();
        }

        public BasicUser Get(int basicUserId)
        {
            throw new Exception();
        }

        public void Add(BasicUser basicUser)
        {
        }

        public void Update(BasicUser basicUser)
        {
            throw new Exception();
        }

        public void Remove(int basicUserId)
        {
        }
    }
}