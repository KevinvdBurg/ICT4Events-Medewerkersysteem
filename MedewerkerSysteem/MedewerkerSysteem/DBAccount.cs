﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

public class DBAccount : Database
{
	public virtual bool Update(Account Account)
	{
		throw new System.NotImplementedException();
	}

	public virtual bool Delete(Account account)
	{
        bool resultaat = false;
        string sql;
        //sql = "Select e.EVENTID, e.Naam, e.MAXPERSONEN, e.BEGINDATUM, e.EINDDATUM, l.HUISNUMMER, l.PLAATS, l.POSTCODE From Event e Inner Join Locatie l On e.LOCATIEID = l.LOCATIEID";
        //sql = "INSERT INTO LOCATIE (PLAATS, POSTCODE, HUISNUMMER) VALUES (:plaats, :postcode, :nr)";
        sql = "DELETE FROM Gebruiker WHERE RFID = :RFID";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("RFID", account.RFID));
            OracleDataReader reader = cmd.ExecuteReader();
            resultaat = true;
        }
        catch (OracleException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return resultaat;
	}


	public virtual bool Insert(Account account)
	{
        bool resultaat = false;
        string sql;
        sql = "INSERT INTO GEBRUIKER (RFID, EMAILADRES, WACHTWOORD, PLAATS, POSTCODE, HUISNUMMER, ISADMIN, VOORNAAM, ACHTERNAAM, LAND) VALUES (:RFID, :emailadres, :wachtwoord, :plaats, :postcode, :huisnummer, :isadmin, :voornaam, :achternaam, :land)";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("RFID", account.RFID));
            cmd.Parameters.Add(new OracleParameter("email", account.Person.Email));
            cmd.Parameters.Add(new OracleParameter("wachtwoord", account.Wachtwoord));
            cmd.Parameters.Add(new OracleParameter("plaats", account.Person.Address.City));
            cmd.Parameters.Add(new OracleParameter("postcode", account.Person.Address.ZipCode));
            cmd.Parameters.Add(new OracleParameter("huisnummer", account.Person.Address.Number));
            cmd.Parameters.Add(new OracleParameter("isadmin", "0"));
            cmd.Parameters.Add(new OracleParameter("voornaam", account.Person.Name));
            cmd.Parameters.Add(new OracleParameter("achternaam", account.Person.LastName));
            cmd.Parameters.Add(new OracleParameter("land", account.Person.Address.Country));
            cmd.ExecuteNonQuery();
            //OracleDataReader reader = cmd.ExecuteReader();
            resultaat = true;
        }
        catch (OracleException e)
        {

            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return resultaat;

       // throw new System.NotImplementedException();
	}

	public virtual void Select()
	{
	}


    internal Account Select(string Code)
    {
        Account resultaat = null;
        string sql;
        sql = "select * from gebruiker where RFID = :rfid";
            string lastName = "";
            string name = "";
            string type = "";
            string rfid = "";
            string city = "";
            string country = "";
            string nr = "";
            string zipcode = "";
            string email = "";
            string wachtwoord = "";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("RFID", Code));
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = Convert.ToString(reader["voornaam"]);
                    lastName = Convert.ToString(reader["achternaam"]);
                    rfid = Convert.ToString(reader["rfid"]);
                    city = Convert.ToString(reader["plaats"]);
                    country = Convert.ToString(reader["Land"]);
                    nr = Convert.ToString(reader["huisnummer"]);
                    zipcode = Convert.ToString(reader["postcode"]);
                    email = Convert.ToString(reader["emailadres"]);
                    wachtwoord = Convert.ToString(reader["wachtwoord"]);

                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }
                }
                resultaat = new Account(new Person(new Address(city, country, nr, zipcode), email, name, lastName), type, rfid, wachtwoord);
            }
        }
        catch (OracleException e)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return resultaat;
    }

    public int FindAccountID(string zipCode, string Code)
    {
        int accountID = -1;
        string sql;
        sql = "select GEBRUIKERID from gebruiker where RFID = :rfid";
        

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("RFID", Code));
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    accountID = Convert.ToInt32(reader["gebruikerID"]);
                   
                }
                return accountID;
            }
        }
        catch (OracleException e)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return accountID;
    }

    internal List<Account> SelectAll()
    {
        List<Account> resultaat = new List<Account>();
        string sql;
        sql = "select * from gebruiker";
        string type = "";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["voornaam"]);
                    string lastName = Convert.ToString(reader["achternaam"]);
                    string rfid = Convert.ToString(reader["rfid"]);
                    string city = Convert.ToString(reader["plaats"]);
                    string country = Convert.ToString(reader["Land"]);
                    string nr = Convert.ToString(reader["huisnummer"]);
                    string zipcode = Convert.ToString(reader["postcode"]);
                    string email = Convert.ToString(reader["emailadres"]);
                    string wachtwoord = Convert.ToString(reader["wachtwoord"]);
                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }

                    Account tempAccount = new Account(new Person(new Address(city, country, nr, zipcode), email, name, lastName), type, rfid, wachtwoord);
                    
                    resultaat.Add(tempAccount);

                }
            }
        }
        catch (OracleException e)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return resultaat;
    }

    
}

