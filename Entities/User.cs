using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; init;}
    public string Email {get; init;}
    public string FirstName {get; init;}
    public string LastName {get; init;}
    public Role Role {get; init;}
    public byte[] Password {get; init;}

    public User(string email, string firstName, string lastName, Role role, byte[] password) {
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