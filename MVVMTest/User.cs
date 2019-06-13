using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest {
    public class User {
        public string Name { get; private set; }
        public int Id { get; private set; }
        private static int _id = 0;
        public User(string name) {
            Name = name;
            Id = _id;
            _id++;
        }
        public User() {
            Name = "Default";
            Id = _id;
            _id++;
        }
    }
}
