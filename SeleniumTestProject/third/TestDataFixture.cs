using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.third
{
    public class TestDataFixture : IDisposable
    {
        public TestDataFixture()
        {
            var autoFixture = new Fixture();

            ItemsAdd = autoFixture.CreateMany<string>(5).ToList();
            ItemsCheck = ItemsAdd.Skip(3).ToList();
            ExpectdItemsLeft = 3;
        }

        public List<string> ItemsAdd { get; set; }
        public List<string> ItemsCheck { get; set; }
        public int ExpectdItemsLeft { get; set; }

        public void Dispose()
        {
        }
    }
}
