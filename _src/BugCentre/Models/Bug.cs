using System;
using System.Collections.Generic;

public class Bug
{
    public int BugID {get; set;}
    public string Title {get; set;}
    public DateTime DateTimeReported {get; set;}
    public string Description {get;set;}
    public byte[] Image {get;set;}

    public ICollection<Note> Notes { get; set; }
}