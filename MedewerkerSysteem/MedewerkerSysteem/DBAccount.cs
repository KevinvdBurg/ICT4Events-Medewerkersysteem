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

	public virtual void Delete()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Insert()
	{
		throw new System.NotImplementedException();
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
                    nr = Convert.ToString(reader["nr"]);
                    zipcode = Convert.ToString(reader["postcode"]);
                    email = Convert.ToString(reader["emailadres"]);

                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }
                }
                resultaat = new Account(new Person(new Address(city, country, nr, zipcode), email, name, lastName), type, rfid);
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

    internal List<Account> SelectAll(string Code)
    {
        List<Account> resultaat = new List<Account>();
        string sql;
        sql = "select * from gebruiker";
        string lastName = "";
        string name = "";
        string type = "";
        string rfid = "";
        string city = "";
        string country = "";
        string nr = "";
        string zipcode = "";
        string email = "";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }
                    Account tempAccount =
                        new Account(
                            new Person(
                                new Address(Convert.ToString(reader["plaats"]), 
                                            Convert.ToString(reader["Land"]),
                                            Convert.ToString(reader["nr"]), 
                                            Convert.ToString(reader["postcode"])),
                                Convert.ToString(reader["emailadres"]), 
                                Convert.ToString(reader["voornaam"]),
                                Convert.ToString(reader["achternaam"])), 
                        type, Convert.ToString(reader["rfid"]));

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

