using AutoFixture;
using BenchmarkDotNet.Attributes;

namespace FastestWayToWorkWithJsonBenhmark
{
    [MemoryDiagnoser]
    public class JsonBenchmark
    {
        private static readonly IFixture Fixture = new Fixture();
        private static readonly User User = Fixture.Create<User>();
        private const string UserAsText = "{\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Age\":30,\"Email\":\"johndoe@example.com\",\"PhoneNumber\":\"+1234567890\",\"Address\":\"123 Main Street\",\"City\":\"New York\",\"State\":\"NY\",\"Country\":\"USA\",\"ZipCode\":\"10001\",\"Username\":\"johndoe\",\"Password\":\"password123\",\"RegistrationDate\":\"2022-01-01\",\"IsActive\":true,\"AccountBalance\":1000.50,\"Occupation\":\"Software Engineer\",\"Education\":\"Bachelor's Degree\",\"Bio\":\"Hello, I'm John Doe.\",\"Interests\":\"Programming, Reading, Traveling\",\"FavoriteColor\":\"Blue\",\"IsAdmin\":false,\"IsPremiumUser\":true,\"LastLogin\":\"2023-06-15\",\"ProfileImage\":\"profile.jpg\"}";

        [Benchmark]
        public string Serialization_Newtonsonft() => Newtonsoft.Json.JsonConvert.SerializeObject(User);

        [Benchmark]
        public string Serialization_SystemTextJson() => System.Text.Json.JsonSerializer.Serialize(User);

        [Benchmark]
        public string Serialization_Jil() => Jil.JSON.Serialize(User);

        [Benchmark]
        public string Serialization_Utf8Json() => Utf8Json.JsonSerializer.ToJsonString(User);

        [Benchmark]
        public User Deserialization_Newtonsonft() => Newtonsoft.Json.JsonConvert.DeserializeObject<User>(UserAsText);

        [Benchmark]
        public User Deserialization_SystemTextJson() => System.Text.Json.JsonSerializer.Deserialize<User>(UserAsText);

        [Benchmark]
        public User Deserialization_Jil() => Jil.JSON.Deserialize<User>(UserAsText);

        [Benchmark]
        public User Deserialization_Utf8Json() => Utf8Json.JsonSerializer.Deserialize<User>(UserAsText); 

    }
}

