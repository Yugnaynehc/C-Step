using System;
using System.Collections.Generic;

struct Member
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TowerName { get; set; }
    public bool IsCaptain { get; set; }
    public DateTime MemberSince { get; set; }
    public List<string> Methods;
}