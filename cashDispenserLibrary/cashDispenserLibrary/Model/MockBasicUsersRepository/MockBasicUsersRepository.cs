using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model.Exceptions;

namespace cashDispenserLibrary.Model
{
    public class MockBasicUsersRepository
    {
        public PlatformType _PlatformType { get; private set; }


        public MockBasicUsersRepository(PlatformType platformType) =>
            _PlatformType = platformType;

        public IEnumerable<BasicUser> GetAll()
        {
            List<BasicUser> responseBasicUser = new List<BasicUser>();
            var basicUsersData = new List<string[]>();


            // //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }

                //Check empty file
                if (basicUsersData.Count == 0)
                {
                    throw new MockBasicUsersRepository_Exception(
                        MockBasicUsersRepository_ExceptionType.EmptyFile);
                }
            }

            // Fill response collection
            responseBasicUser = basicUsersData.Select<string[], BasicUser>(
                (string[] basicUserData) =>
                {
                    return new BasicUser(id: int.Parse(basicUserData[0]),
                        pin: new PinVAL(value: basicUserData[1]),
                        name: new NameVAL(value: basicUserData[2]),
                        surname: new SurnameVAL(value: basicUserData[3]),
                        bankAccount: new BankAccount(
                            state: new MoneyVAL(
                                value: decimal.Parse(basicUserData[4],
                                    CultureInfo.InvariantCulture),
                                currency: Currency.PLN)));
                }).ToList();

            return responseBasicUser;
        }

        public BasicUser Get(int basicUserId)
        {
            var basicUsersData = new List<string[]>();


            //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }

                //Check empty file
                if (basicUsersData.Count == 0)
                {
                    throw new MockBasicUsersRepository_Exception(
                        MockBasicUsersRepository_ExceptionType.EmptyFile);
                }
            }

            //Get respectively user from database
            var responseBasicUser = basicUsersData.FirstOrDefault(
                (basicUserData) =>
                    (basicUserData[0] == basicUserId.ToString()));

            //Check basic user exist
            if (responseBasicUser == null)
            {
                throw new MockBasicUsersRepository_Exception(
                    MockBasicUsersRepository_ExceptionType.BasicUserNotExist);
            }

            return new BasicUser(id: int.Parse(responseBasicUser[0]),
                pin: new PinVAL(value: responseBasicUser[1]),
                name: new NameVAL(value: responseBasicUser[2]),
                surname: new SurnameVAL(value: responseBasicUser[3]),
                bankAccount: new BankAccount(
                    state: new MoneyVAL(
                        value: decimal.Parse(responseBasicUser[4],
                            CultureInfo.InvariantCulture),
                        currency: Currency.PLN)));
        }

        public void Add(BasicUser basicUser)
        {
            var basicUsersData = new List<string[]>();


            //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }
            }

            //Validate basic user
            if (basicUsersData.Any((basicUserData) =>
                basicUserData[0].Equals(basicUser._Id.ToString())))
            {
                throw new MockBasicUsersRepository_Exception(
                    MockBasicUsersRepository_ExceptionType.DuplicateBasicUser);
            }

            //Add basic user
            basicUsersData.Add(new string[]
            {
                basicUser._Id.ToString(),
                basicUser._Pin._Value,
                basicUser._Name._Value,
                basicUser._Surname._Value,
                basicUser._BankAccount.state._Value.ToString(
                    new CultureInfo("en-US")),
                ((int) Currency.PLN).ToString()
            });

            //Save changes
            using (StreamWriter sw = new StreamWriter(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    for (int i = 0; i < basicUserData.Length; ++i)
                    {
                        sw.Write(basicUserData[i] + ';');
                    }

                    sw.Write('\n');
                }
            }
        }

        public void Update(BasicUser basicUser)
        {
            var basicUsersData = new List<string[]>();


            //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }

                //Check empty file
                if (basicUsersData.Count == 0)
                {
                    throw new MockBasicUsersRepository_Exception(
                        MockBasicUsersRepository_ExceptionType.EmptyFile);
                }
            }

            //Check exist basic user
            var basicUserToUpdate = basicUsersData.FirstOrDefault(
                (basicUserData) =>
                    basicUserData[0].Equals(basicUser._Id.ToString()));

            if (basicUserToUpdate == null)
            {
                throw new MockBasicUsersRepository_Exception(
                    MockBasicUsersRepository_ExceptionType.BasicUserNotExist);
            }

            //get basic user to update's id
            int idBasicUserToUpdate = int.Parse(basicUserToUpdate[0]);

            //Update basic user
            basicUsersData[idBasicUserToUpdate][1] = basicUser._Pin._Value;
            basicUsersData[idBasicUserToUpdate][2] = basicUser._Name._Value;
            basicUsersData[idBasicUserToUpdate][3] = basicUser._Surname._Value;
            basicUsersData[idBasicUserToUpdate][4] =
                basicUser._BankAccount.state._Value.ToString(
                    new CultureInfo("en-US"));
            basicUsersData[idBasicUserToUpdate][5] = ((int) Currency.PLN).ToString();

            //Save changes
            using (StreamWriter sw = new StreamWriter(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    for (int i = 0; i < basicUserData.Length; ++i)
                    {
                        sw.Write(basicUserData[i] + ';');
                    }

                    sw.Write('\n');
                }
            }
        }

        public void Remove(int basicUserId)
        {
            var basicUsersData = new List<string[]>();


            //Read basic users data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt"))
            {
                //Get all basic users repository's records
                while (sr.Peek() >= 0)
                {
                    basicUsersData.Add(sr.ReadLine().Split(';'));
                }

                //Check empty file
                if (basicUsersData.Count == 0)
                {
                    throw new MockBasicUsersRepository_Exception(
                        MockBasicUsersRepository_ExceptionType.EmptyFile);
                }
            }

            //Check exist basic user
            var basicUserToRemove = basicUsersData.FirstOrDefault(
                (basicUserData) =>
                    basicUserData[0].Equals(basicUserId.ToString()));

            if (basicUserToRemove == null)
            {
                throw new MockBasicUsersRepository_Exception(
                    MockBasicUsersRepository_ExceptionType.BasicUserNotExist);
            }

            //Remove basic user
            basicUsersData.Remove(basicUsersData.FirstOrDefault(
                (basicUserData) => (basicUserData.Equals(basicUserToRemove))));

            //Save changes
            using (StreamWriter sw = new StreamWriter(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    for (int i = 0; i < basicUserData.Length; ++i)
                    {
                        sw.Write(basicUserData[i] + ';');
                    }

                    sw.Write('\n');
                }
            }
        }
    }
}