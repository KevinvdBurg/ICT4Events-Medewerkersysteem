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

	public virtual void Add(Account Account)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Add(Reserve Reserve)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddEvent(Event Event)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Delete(Account Account)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Delete(Reserve Reserve)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Delete(Event Event)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Find(Account Account)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Find(Event Event)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Find(Reserve Reserve)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Update(Account Account)
	{
		throw new System.NotImplementedException();
	}

}

