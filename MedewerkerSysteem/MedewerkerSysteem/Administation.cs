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

public class Administation
{
    Database DB = new Database();
	public IEnumerable<Reserve> Reserve
	{
		get;
		set;
	}

	public IEnumerable<Account> Account
	{
		get;
		set;
	}

	public IEnumerable<Event> Event
	{
		get;
		set;
	}

    public Administation()
    {

    }

	public void Add(Account Account)
	{

	}

	public void Add(Reserve Reserve)
	{

	}

	public void AddEvent(Event Event)
	{

	}

	public void Delete(Account Account)
	{

	}

	public void Delete(Reserve Reserve)
	{
		
	}

	public void Delete(Event Event)
	{
		
	}

	public void Find(Account Account)
	{
		
	}

	public void Find(Event Event)
	{
	}

	public void Find(Reserve Reserve)
	{
		
	}

	public void Update(Account Account)
	{

	}

    public bool Login(string email, string password)
    {
        //database connectie hier

        Address adminAddress = new Address("admin street", "admin street","admin streetname", "Adminzip");
        //Persoon wordt aangemaakt
        Person person = new Person(adminAddress, "admin@admin.nl", "admin name", "adminlastname");
        //Account wordt aangemaakt
        Account admin = new Account(person, 999);
    }

}

