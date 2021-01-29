using System.Collections.Generic;
using System.IO;
using System.Linq;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model.MockAdministratorsRepository.Exceptions;

namespace cashDispenserLibrary.Model.MockAdministratorsRepository
{
    public class MockAdministratorsRepository
    {
        public PlatformType _PlatformType { get; private set; }

        public MockAdministratorsRepository(PlatformType platformType) =>
            _PlatformType = platformType;

        public IEnumerable<Administrator> GetAll()
        {
            var responseAdministrators = new List<Administrator>();
            var administratorsData = new List<string[]>();


            //Read administrators data
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\Administrators.txt"
                    : "cashDispenserDatabase/Administrators.txt"))
            {
                //Get all administrators repository's records
                while (sr.Peek() >= 0)
                {
                    administratorsData.Add(
                        sr.ReadLine().Split(';'));
                }

                //Check empty file
                if (administratorsData.Count == 0)
                {
                    throw new MockAdministratorsRepository_Exception(
                        MockAdministratorsRepository_ExceptionType.EmptyFile);
                }
            }

            //Fill response collection
            responseAdministrators = administratorsData.Select(
                (administrator) =>
                {
                    return new Administrator(id: int.Parse(administrator[0]),
                        pin: new PinVAL(value: administrator[1]),
                        name: new NameVAL(value: administrator[2]),
                        surname: new SurnameVAL(value: administrator[3])
                    );
                }).ToList();

            return responseAdministrators;
        }
    }
}