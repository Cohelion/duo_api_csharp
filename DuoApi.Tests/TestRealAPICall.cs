using Duo;
using System;
using System.Linq;
using System.Text.Json;
using Xunit;

public class TestRealAPICall
{
    private const string test_ikey = "INTEGRATION KEY";
    private const string test_skey = "SECRET KEY";
    private const string test_host = "api-.duosecurity.com";

    private DuoApi api;

    /// <summary>
    /// 
    /// </summary>
    public TestRealAPICall()
    {
        api = new DuoApi(test_ikey, test_skey, test_host);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1, 1)]
    [InlineData(400)]
    public void GetUsers(ushort pagesize, ushort offset = 0)
    {
        //arrange
        //act
        var users = api.GetUsers(pagesize, out var pagingInfo, offset);

        //assert
        Console.WriteLine($"{users.Length:n0} users");
        Console.WriteLine(JsonSerializer.Serialize(users, new JsonSerializerOptions() { WriteIndented = true }));

        Assert.True(users.Length <= pagesize);
    }

    [Fact]
    public void GetAllTest()
    {
        //arrange
        ushort pagesize = 2;
        ushort offset = 0;

        //act
        var users = api.GetUsers(pagesize, out var pagingInfo, offset).ToList();

        while (pagingInfo.next_offset.HasValue)
        {
            offset = pagingInfo.next_offset.Value;

            users.AddRange(api.GetUsers(pagesize, out pagingInfo, offset));
        }

        //assert
        Console.WriteLine($"{users.Count:n0} users");
        Console.WriteLine(JsonSerializer.Serialize(users, new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
        }));

        Assert.Equal(users.Count, pagingInfo.total_objects);
    }

    [SkippableFact]
    public void GetSingleTest()
    {
        //arrange
        var user = api.GetUsers(100, out _).LastOrDefault();

        Skip.If(user is null);


        //act
        var actual = api.GetUser(user.UserName);

        //assert
        Assert.NotNull(actual);
        Assert.Equal(actual.User_Id, user.User_Id);

        Console.WriteLine(JsonSerializer.Serialize(actual, new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
        }));
    }

}
