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

public class Account
{
	public string RFID
	{
		get;
		set;
	}

	public Person Person
	{
		get;
		set;
	}

	public IEnumerable<Reserve> Reserve
	{
		get;
		set;
	}

	public Account(Person Person, string RFID)
	{
        this.Person = Person;
        this.RFID = RFID; 
	}

}

