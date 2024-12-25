using System.Text.Json.Serialization;
using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class User
{
    public int Id {get; init;}
    public string Email {get; init;}
    public string FirstName {get; init;}
    public string LastName {get; init;}
    public Role Role {get; init;}
    [JsonIgnore]
    public byte[] Password {get; init;}

    public User(int id, string email, string firstName, string lastName, Role role, byte[] password) {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Password = password;
    }

    public bool IsPasswordValid(string password) {
        byte[] hashedPassword = Hash.HashPassword(password);
        return Password.SequenceEqual(hashedPassword);
    } 
}