using System;
using System.Text.Json.Serialization;

namespace Duo.Models
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// For specs see: <a href="https://duo.com/docs/adminapi#retrieve-users">https://duo.com/docs/adminapi#retrieve-users</a></remarks>
    public class User {

		/// <summary>
		/// The user's creation date timestamp.
		/// </summary>
		public int created { private get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime DateCreated
		{
			get
			{
				return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(created);
			}
		}

		/// <summary>
		/// The user's email address.
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// The user's given name.
		/// </summary>
		public string? FirstName { get; set; }

		/// <summary>
		/// List of groups to which this user belongs.See Retrieve Groups for response info.
		/// </summary>
		/// <remarks>todo: formalize group structure</remarks>
		public object[]? Groups { get; set; }

		/// <summary>
		/// Is true if the user has a phone, hardware token, U2F token, or security key available for authentication.Otherwise, false.
		/// </summary>
		public bool Is_Enrolled { get; set; }

		/// <summary>
		/// An integer indicating the last update to the user via directory sync as a Unix timestamp, or null if the user has never synced with an external directory or if the directory that originally created the user has been deleted from Duo.
		/// </summary>
		public int? last_directory_sync { private get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastDirectoryDync { get {
				return last_directory_sync.HasValue
					? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(last_directory_sync.Value)
					: (DateTime?)null;
			}
		}

		/// <summary>
		/// An integer indicating the last time this user logged in, as a Unix timestamp, or null if the user has not logged in.
		/// </summary>
		public int? Last_Login { private get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLogin
		{
			get
			{
				return Last_Login.HasValue
					? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Last_Login.Value)
					: (DateTime?)null;
			}
		}

		/// <summary>
		/// The user's surname.
		/// </summary>
		public string? LastName { get; set; }

		/// <summary>
		/// Notes about this user.Viewable in the Duo Admin Panel.
		/// </summary>
		public string? Notes { get; set; }

		/// <summary>
		/// A list of phones that this user can use. See Retrieve Phones for descriptions of the phone response values.
		/// </summary>
		/// <remarks>todo: formalize phone structure</remarks>
		public object[]? Phones { get; set; }

		/// <summary>
		/// The user's real name (or full name).
		/// </summary>
		public string? RealName { get; set; }

		/// <summary>
		///  The user's status. One of:
		///  "active" The user must complete secondary authentication.
		///  "bypass" The user will bypass secondary authentication after completing primary authentication.
		///  "disabled" The user will not be able to log in.
		///  "locked out" The user has been automatically locked out due to excessive authentication attempts.
		///  "pending deletion" The user was marked for deletion by a Duo admin from the Admin Panel, by the system for inactivity, or by directory sync. If not restored within seven days the user is permanently deleted.
		///  Note that when a user is a member of a group, the group status may override the individual user's status. Group status is not shown in the user response.
		/// </summary>
		public string? Status { get; set; }

		/// <summary>
		/// A list of tokens that this user can use.See Retrieve Hardware Tokens for descriptions of the response values.
		/// </summary>
		public object[]? Tokens { get; set; }

		/// <summary>
		/// A list of U2F tokens that this user can use.See Retrieve U2F Tokens for descriptions of the response values.
		/// </summary>
		public string[]? U2F_Tokens { get; set; }

		/// <summary>
		/// The user's ID.
		/// </summary>
		public string? User_Id { get; set; }

		/// <summary>
		/// The user's username.
		/// </summary>
		public string? UserName { get; set; }

		/// <summary>
		/// A list of WebAuthn authenticators that this user can use.See Retrieve WebAuthn Credentials by User ID for descriptions of the response values.
		/// </summary>
		/// <remarks>todo: formalize authenticator structure</remarks>
		public object[]? WebAuthnCredentials { get; set; }
	}
}
