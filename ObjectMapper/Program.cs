#region Map Example

// Create an instance of UserViewModel
var sourceMap = new UserViewModel
{
    Id = 1,
    UserName = "Mohammad Hadi",
    Email = "hadihabibi29@gmail.com",
    Password = "password"
};

// Map from UserViewModel to User
var result = Mapper.Map<UserViewModel, User>(sourceMap);

// Set console text color to green for aesthetic purposes
Console.ForegroundColor = ConsoleColor.Green;

// Print the mapping result
Console.WriteLine($"Map Example\n\n" +
    "Id: {destination.Id}\n" +
    $"UserName: {result.UserName ?? "null"}\n" +
    $"Email: {result.Email ?? "null"}\n" +
    $"Password: {result.Password ?? "null"}\n" +
    $"PhoneNumber: {result.PhoneNumber ?? "null"}\n" +
    $"________________________________________________");

#endregion

#region MapList Example

// Create a list of UserViewModel instances
var sourceMapList = new List<UserViewModel>
{
    new UserViewModel
    {
        Id = 2,
        UserName = "Mohammad Hadi",
        Email = "hadihabibi29@gmail.com",
        Password = "password"
    },
    new UserViewModel
    {
        Id = 3,
        UserName = "Mohammad Hadi",
        Email = "hadihabibi29@gmail.com",
        Password = "password"
    }
};

// Map the list of UserViewModel instances to a list of User instances
var destinationMapList = Mapper.MapList<UserViewModel, User>(sourceMapList);

// Set console text color to blue for aesthetic purposes
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\nMapList Example");

// Iterate through the mapped list and print the results
foreach (var item in destinationMapList)
{
    Console.WriteLine($"\nId: {item.Id}\n" +
    $"UserName: {item.UserName ?? "null"}\n" +
    $"Email: {item.Email ?? "null"}\n" +
    $"Password: {item.Password ?? "null"}\n" +
    $"PhoneNumber: {item.PhoneNumber ?? "null"}\n" +
    $".......................");
}

#endregion