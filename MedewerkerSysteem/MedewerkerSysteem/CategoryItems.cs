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

public class CategoryItems : Category
{
	public string Name
	{
		get;
		set;
	}

    public CategoryItems(string Name, string Details, decimal Price, string Type) : base(Details,  Price,  Type)
	{
        this.Name = Name;
	}

}

