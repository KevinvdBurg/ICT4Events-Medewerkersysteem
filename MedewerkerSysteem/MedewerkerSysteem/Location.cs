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

public class Location
{
	public Address Address
	{
		get;
		set;
	}

	public string Name
	{
		get;
		set;
	}

	public DBAddress DBAddress
	{
		get;
		set;
	}

	

	public Location(Address Address, string Name)
	{
        this.Address = Address;
        this.Name = Name;
	}

}

