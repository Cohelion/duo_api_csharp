using Duo;
using System;
using System.Collections.Generic;
using Xunit;
using System.Text.Json;

public class TestRealAPICall
{
    private const string test_ikey = "INTEGRATION KEY";
    private const string test_skey = "SECRET KEY";
    private const string test_host = "api-NUMBER.duosecurity.com";

    private DuoApi api;

    /// <summary>
    /// 
    /// </summary>
    public TestRealAPICall()
    {
        api = new DuoApi(test_ikey, test_skey, test_host);
    }

    [Fact]
    public void GetUsers()
    {
        
        var users = api.GetUsers();


        Console.WriteLine($"{users.Count:n0} users");

        Console.WriteLine(JsonSerializer.Serialize(users, new JsonSerializerOptions() {  WriteIndented = true }));
    }

}
