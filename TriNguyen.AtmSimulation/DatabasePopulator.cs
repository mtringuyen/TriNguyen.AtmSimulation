using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel.Interfaces;

namespace TriNguyen.AtmSimulation.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository atmRepository)
        {
            if (atmRepository.List<User>().Count() >= 3) return 0;
            atmRepository.Add(new User
            {
                UserName = "tester01",
                PinNumber = "123123"
            });

            atmRepository.Add(new User
            {
                UserName = "tester02",
                PinNumber = "123456"
            });

            atmRepository.Add(new User
            {
                UserName = "tester03",
                PinNumber = "qweasd"
            });
            return atmRepository.List<User>().Count;
        }
    }
}
