using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Model {
    public enum UserType
    {
        Client,
        Waiter,
        Admin
    }

    public class User {
        public int Id { get; private set; }
        public string Dni { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }

        public User(int id, string dni, string name, string email, string password, UserType type)
        {
            setId(id);
            setDni(dni);
            setName(name);
            setEmail(email);
            setPassword(password);
            setType(type);
        }

        public void setId(int id)
        {
            Id = id;
        }

        public void setDni(string dni)
        {
            Dni = dni;
        }
        
        public void setName(string name)
        {
            Name = name;
        }
        
        public void setEmail(string email)
        {
            Email = email;
        }
        
        public void setPassword(string password)
        {
            Password = password;
        }
        
        public void setType(UserType type)
        {
            Type = type;
        }
    }
}
